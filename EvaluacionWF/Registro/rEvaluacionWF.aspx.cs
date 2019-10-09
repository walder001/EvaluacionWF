using BLL;
using DAL;
using Entity;
using Restauran.Utilitarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EvaluacionWF.Registro
{
    public partial class rEvaluacionWF : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                base.ViewState["Evaluaciones"] = new Evaluaciones();
                EvaluacionTextBox.Text = "0";
                FechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
                LLenarCombo();
                this.BindGrid();
            }

        }

       public void LLenarCombo()
        {
            RepositorioBase<Estudiantes> estudiante = new RepositorioBase<Estudiantes>(new Contexto());
            RepositorioBase<Categorias> categoria = new RepositorioBase<Categorias>(new Contexto());

            EstudianteDropDownList.DataSource = estudiante.GetList(e => true);
            EstudianteDropDownList.DataValueField = "EstudianteId";
            EstudianteDropDownList.DataTextField = "Nombres";
            EstudianteDropDownList.DataBind();

            CategoriaDropDownList.DataSource = categoria.GetList( c => true);
            CategoriaDropDownList.DataValueField = "CategoriaId";
            CategoriaDropDownList.DataTextField = "NombreCategoria";
            CategoriaDropDownList.DataBind();
        }
        public void CaculoTotal()
        {
            decimal logro = 0, valor = 0, total = 0;
            decimal totalGeneral = 0, mont = 0;

            valor = Utils.ToDecimal(ValorTextBox.Text);

            logro = Utils.ToDecimal(LogradoTextBox.Text);

            total = valor - logro;

            mont = Utils.ToDecimal(TotalTextBox.Text);
            totalGeneral = mont + total;
            TotalTextBox.Text = totalGeneral.ToString();
        }

        public void CalcularPromedio()
        {
            RepositorioBase<Categorias> repositorio = new RepositorioBase<Categorias>(new Contexto());
  

        }
        protected void BindGrid()
        {
            GridView1.DataSource = ((Evaluaciones)base.ViewState["Evaluaciones"]).Detalles;
            GridView1.DataBind();
        }
        public void LimpiarObjeto()
        {
            EvaluacionTextBox.Text = "0";
            EstudianteDropDownList.Enabled = true;
            CategoriaDropDownList.Enabled = true;
            ValorTextBox.Text = string.Empty;
            LogradoTextBox.Text = string.Empty;
            TotalTextBox.Text = string.Empty;
            FechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
            base.ViewState["Evaluaciones"] = new Evaluaciones();
            this.BindGrid();
        }


        public Evaluaciones LLenaClase()
        {
            Evaluaciones evaluacion = new Evaluaciones();
            evaluacion = (Evaluaciones)ViewState["Evaluaciones"];

            evaluacion.EvaluacionId = Utils.ToInt(EvaluacionTextBox.Text);
            evaluacion.EsudianteId = Utils.ToInt(EstudianteDropDownList.SelectedValue);
            evaluacion.Fecha = Utils.ToDateTime(FechaTextBox.Text);

            return evaluacion;
        }

        public void LLenaCampo(Evaluaciones evaluacion)
        {
            Contexto contexto = new Contexto();
            LimpiarObjeto();
            ((Evaluaciones)ViewState["Evaluaciones"]).Detalles = evaluacion.Detalles;
            EvaluacionTextBox.Text = evaluacion.EvaluacionId.ToString();
            EstudianteDropDownList.SelectedValue = evaluacion.EsudianteId.ToString();
            FechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
            TotalTextBox.Text = contexto.Clientes.Find(Utils.ToInt(EstudianteDropDownList.SelectedValue)).ToString();
            this.BindGrid();
        }
        public void LlenarTotal()
        {
            RepositorioBase<DetalleEvaluaciones> repositorio = new RepositorioBase<DetalleEvaluaciones>(new Contexto());
            decimal puntos = 0;
            int evaluacion = Utils.ToInt(EvaluacionTextBox.Text);
            List<DetalleEvaluaciones> lista = repositorio.GetList(e=> e.EvaluacionId == evaluacion);
            foreach (var item in lista)
            {
                puntos += item.Perdido;
            }
            TotalTextBox.Text = puntos.ToString();

        }
        private bool HayErrores()
        {
            bool paso = false;
            if (String.IsNullOrEmpty(EvaluacionTextBox.Text))
            {
                Response.Write("<script>alert('Ingrese un Id');</script>");
                paso = true;
            }
          
            if (String.IsNullOrEmpty(ValorTextBox.Text))
            {
                Response.Write("<script>alert('Ingrese el valor');</script>");
                paso = true;
            }
            if (String.IsNullOrEmpty(LogradoTextBox.Text))
            {
                Response.Write("<script>alert('Ingrese logro');</script>");
                paso = true;
            }
            if (GridView1.Columns.Count == 0)
            {
                Response.Write("<script>alert('El detalle está vacío');</script>");
                paso = true;
            }
            return paso;
        }

        private void LlenarValores()
        {
            List<DetalleEvaluaciones> detalle = new List<DetalleEvaluaciones>();


            if (GridView1.DataSource != null)
            {
                detalle = (List<DetalleEvaluaciones>)GridView1.DataSource;
            }

        }

        protected void Limpiar_Click(object sender, EventArgs e)
        {
            LimpiarObjeto();

        }

        protected void Guardar_Click(object sender, EventArgs e)
        {
            bool paso = false;
            RepositorioEvaluacion repositorio = new RepositorioEvaluacion(new Contexto());
            Evaluaciones evaluacion = new Evaluaciones();
            if (HayErrores())
                return;
            else

                evaluacion = LLenaClase();
            if (Utils.ToInt(EvaluacionTextBox.Text) == 0)
            {
                repositorio.Guardar(evaluacion);
                LimpiarObjeto();
            }
            else
            {
                repositorio.Buscar(Utils.ToInt(EvaluacionTextBox.Text));
                if (repositorio != null)
                {
                    Contexto contexto = new Contexto();
                    paso = repositorio.Modificar(evaluacion);
                    LimpiarObjeto();
                }
                else
                {
                    Response.Write("<script>alert('Id no existe');</script>");
                }
            }
            if (paso)
            {
                Utils.ShowToastr(this, "Exito", "Existo", "success");
                LimpiarObjeto();
            }
            else
            {
                Utils.ShowToastr(this, "Error", "Error", "success");


            }

        }

        protected void Eliminar_Click(object sender, EventArgs e)
        {

            RepositorioEvaluacion repositorio = new RepositorioEvaluacion(new Contexto());
            Evaluaciones evaluacion = new Evaluaciones();


            if (repositorio.Eliminar(Convert.ToInt32(EvaluacionTextBox.Text)))
            {

                Utils.ShowToastr(this, "Registro eliminado", "Exito", "success");
                LimpiarObjeto();
            }
            else
            {
                Utils.ShowToastr(this, "Registro eliminado", "Error", "success");


            }

        }

        protected void Buscar_Click(object sender, EventArgs e)
        {
            RepositorioEvaluacion repositorio = new RepositorioEvaluacion(new Contexto());
            var buscar = repositorio.Buscar(Utils.ToInt(EvaluacionTextBox.Text));
            if (buscar != null)
            {
                LLenaCampo(buscar);
                LlenarTotal();
                Utils.ShowToastr(this, "Exito", "Exito");
            }
            else
            {
                Utils.ShowToastr(this, "Error", "Error");


            }

        }

        protected void Agregar_Click(object sender, EventArgs e)
        {
            CaculoTotal();

            Evaluaciones evaluacion = new Evaluaciones();
            evaluacion = (Evaluaciones)base.ViewState["Evaluaciones"];
            decimal perdiada = 0, promedio = 0;
            perdiada = Utils.ToDecimal(ValorTextBox.Text) - Utils.ToDecimal(LogradoTextBox.Text);
            promedio = Utils.ToDecimal(LogradoTextBox.Text) / Utils.ToDecimal(ValorTextBox.Text);

            //evaluacion.Agregar(0, Utils.ToInt(EvaluacionTextBox.Text), EstudianteDropDownList.SelectedValue, Utils.ToDecimal(ValorTextBox.Text), Utils.ToDecimal(LogradoTextBox.Text), perdiada);
            evaluacion.Agregar(0, Utils.ToInt(EvaluacionTextBox.Text),Utils.ToInt(CategoriaDropDownList.SelectedValue), Utils.ToInt(EstudianteDropDownList.SelectedValue), Utils.ToDecimal(LogradoTextBox.Text),perdiada,promedio);
            ViewState["Evaluaciones"] = evaluacion;
            this.BindGrid();
            LlenarValores();

        }


        /*          Eventos del la entidad Cliente             */
        public void LimpiarEstudiante()
        {
            TextBoxEstuduanteId.Text = string.Empty;
            NombreTextBox.Text = string.Empty;
            MatriculaTextBox.Text = string.Empty;
            PuntosPerdidosTextBox.Text = string.Empty;
        }

        public Estudiantes LLenaClaseEstudiante()
        {
            Estudiantes estudiantes = new Estudiantes();
            estudiantes.EstudianteId = Utils.ToInt(TextBoxEstuduanteId.Text);
            estudiantes.Nombres = NombreTextBox.Text;
            estudiantes.Matricula = MatriculaTextBox.Text;
            estudiantes.PuntosPerdidos = Utils.ToDecimal(PuntosPerdidosTextBox.Text);
              return estudiantes;
        }

        public void LLenaCampoEstudiante(Estudiantes estudiantes)
        {
            LimpiarEstudiante();
            TextBoxEstuduanteId.Text = estudiantes.EstudianteId.ToString();
            NombreTextBox.Text = estudiantes.Nombres.ToString();
            MatriculaTextBox.Text = estudiantes.Matricula.ToString();
            PuntosPerdidosTextBox.Text = estudiantes.PuntosPerdidos.ToString();

        }
        protected void LimpiarCliente_Click(object sender, EventArgs e)
        {
            LimpiarEstudiante();
        }

        protected void GuardarCliente_Click(object sender, EventArgs e)
        {
            RepositorioBase<Estudiantes> repositorio = new RepositorioBase<Estudiantes>(new Contexto());
            Estudiantes estudiantes = new Estudiantes();
            bool paso = false;
            estudiantes = LLenaClaseEstudiante();
            if (Utils.ToInt(TextBoxEstuduanteId.Text) ==0)
            {
               paso = repositorio.Guardar(estudiantes);

            }
            else
            {
                paso = repositorio.Modificar(estudiantes);

            }
            if (paso)
            {
                LimpiarEstudiante();
            }
            else
            {
                Utils.ShowToastr(this, "Erro", "Error", "success");
            }

        }

        protected void EliminarCliente_Click(object sender, EventArgs e)
        {
            RepositorioBase<Estudiantes> repositorio = new RepositorioBase<Estudiantes>(new Contexto());
            if (repositorio.Eliminar(Utils.ToInt(TextBoxEstuduanteId.Text)))
            {
                LimpiarEstudiante();

            }
            else
            {
                Utils.ShowToastr(this, "Erro", "Error", "success");

            }
        }

        protected void BuscarCliente_Click(object sender, EventArgs e)
        {
            RepositorioBase<Estudiantes> repositorio = new RepositorioBase<Estudiantes>(new Contexto());
            var buscar = repositorio.Buscar(Utils.ToInt(TextBoxEstuduanteId.Text));
            if (buscar != null)
            {
                LLenaCampoEstudiante(buscar);
                Utils.ShowToastr(this, "Exito", "Exito");
            }
            else
            {
                Utils.ShowToastr(this, "Error", "Error");


            }

        }



        /*     Implementacion de los metodos de la entidad Categoria     */

        public void LimpiarCategoria()
        {
            CategoriaIdTextBox.Text = string.Empty;
            NombreCategoriaTextBox.Text = string.Empty;
            ValorCategoriaTextBox.Text = string.Empty;
        }

        public Categorias LLenaClaseCategoria()
        {
            Categorias categorias = new Categorias();
            categorias.CategoriaId = Utils.ToInt(CategoriaIdTextBox.Text);
            categorias.NombreCategoria = NombreCategoriaTextBox.Text;
            categorias.Valor = Utils.ToDecimal(ValorCategoriaTextBox.Text);
            return categorias;
        }
        public void LLenaCampoCategoria(Categorias categorias)
        {
            CategoriaIdTextBox.Text = categorias.CategoriaId.ToString();
            NombreCategoriaTextBox.Text = categorias.NombreCategoria.ToString();
            ValorCategoriaTextBox.Text = categorias.Valor.ToString();
        }
        protected void BuscarCategiria_Click(object sender, EventArgs e)
        {
            RepositorioBase<Categorias> repositorio = new RepositorioBase<Categorias>(new Contexto());
           var buscar = repositorio.Buscar(Utils.ToInt(CategoriaIdTextBox.Text));
            if (buscar != null)
            {
                LLenaCampoCategoria(buscar);
                Utils.ShowToastr(this, "Exito", "Exito");
            }
            else
            {
                Utils.ShowToastr(this, "Error", "Error");


            }
        }

        protected void LimpiarCategoria_Click(object sender, EventArgs e)
        {
            LimpiarCategoria();

        }

        protected void GuardarCategoria_Click(object sender, EventArgs e)
        {
            RepositorioBase<Categorias> repositorio = new RepositorioBase<Categorias>(new Contexto());
            Categorias categorias = new Categorias();
            bool paso = false;
            categorias = LLenaClaseCategoria();
            if (Utils.ToInt(TextBoxEstuduanteId.Text) == 0)
            {
                paso = repositorio.Guardar(categorias);

            }
            else
            {
                paso = repositorio.Modificar(categorias);

            }
            if (paso)
            {
                LimpiarEstudiante();
            }
            else
            {
                Utils.ShowToastr(this, "Erro", "Error", "success");
            }

        }

        protected void EliminarCategoria_Click(object sender, EventArgs e)
        {
            RepositorioBase<Categorias> repositorio = new RepositorioBase<Categorias>(new Contexto());
            if (repositorio.Eliminar(Utils.ToInt(CategoriaIdTextBox.Text)))
            {
                LimpiarCategoria();
            }
            else
            {
                Utils.ShowToastr(this, "Erro", "Error", "success");
            }

        }

        protected void LogradoTextBox_TextChanged(object sender, EventArgs e)
        {
            RepositorioBase<Categorias> repositorio = new RepositorioBase<Categorias>(new Contexto());
            int id = Utils.ToInt(CategoriaDropDownList.SelectedValue);
            List<Categorias> categorias = repositorio.GetList(a => a.CategoriaId == id);

            foreach (var item in categorias)
            {
                ValorTextBox.Text = item.Valor.ToString();
            }
        }
    }
}
