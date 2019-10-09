using BLL;
using DAL;
using Entity;
using Microsoft.Reporting.WebForms;
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
    public partial class cCategoriaWF : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LlenaReport();
            }

        }

        public void LlenaReport()
        {
            RepositorioBase<Estudiantes> repositorio = new RepositorioBase<Estudiantes>(new Contexto());
            MyReportViewer.ProcessingMode = ProcessingMode.Local;
            MyReportViewer.Reset();
            MyReportViewer.LocalReport.ReportPath = Server.MapPath(@"~\Reporte\CategoriaReport.rdlc");
            MyReportViewer.LocalReport.DataSources.Clear();
            MyReportViewer.LocalReport.DataSources.Add(new ReportDataSource("Categorias", repositorio.GetList(e => true)));
            MyReportViewer.LocalReport.Refresh();
        }
        protected void Buscar_Click(object sender, EventArgs e)
        {
            Expression<Func<Categorias, bool>> Filtro = x => true;
            RepositorioBase<Categorias> repositorio = new RepositorioBase<Categorias>(new Contexto());
            List<Categorias> sugerencias = new List<Categorias>();

            int id;
            id = Utils.ToInt(TextBoxCriterio.Text);

       
                switch (DropDrom.SelectedIndex)
                {
                    case 0:
                        break;
                    case 1:
                        Filtro = x => x.CategoriaId == id;
                        break;
                    case 2:
                        Filtro = x => x.NombreCategoria.Contains(TextBoxCriterio.Text);
                        break;
                    case 3:
                        decimal valor = Utils.ToInt(TextBoxCriterio.Text);
                        Filtro = x => x.Valor == valor;
                        break;
                    case 4:
                        decimal promedio = Utils.ToInt(TextBoxCriterio.Text);
                        Filtro = x => x.PromedioNeto == promedio;
                        break;
            }
            
            DatosGridView.DataSource = repositorio.GetList(Filtro);
            DatosGridView.DataBind();
        }
    }
}