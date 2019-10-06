using BLL;
using DAL;
using Entity;
using Restauran.Utilitarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EvaluacionWF.Consulta
{
    public partial class cEstudianteWF : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Buscar_Click(object sender, EventArgs e)
        {
            Expression<Func<Estudiantes, bool>> Filtro = x => true;
            RepositorioBase<Estudiantes> repositorio = new RepositorioBase<Estudiantes>(new Contexto());
            List<Categorias> sugerencias = new List<Categorias>();

            int id;
            id = Utils.ToInt(TextBoxCriterio.Text);

         
                switch (DropDrom.SelectedIndex)
                {
                    case 0:
                        repositorio.GetList(x => true);
                        break;
                    case 1:
                        Filtro = x => x.EstudianteId == id;
                        break;
                }
            
            DatosGridView.DataSource = repositorio.GetList(Filtro);
            DatosGridView.DataBind();

        }
    }
}