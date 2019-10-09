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
    public partial class cEstudianteWF : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                FechaIncio.Text = DateTime.Now.ToString("yyyy-MM-dd");
                FechaFin.Text = DateTime.Now.ToString("yyyy-MM-dd");
                LlenaReport();
            }

        }

        public void LlenaReport()
        {
            RepositorioBase<Estudiantes> repositorio = new RepositorioBase<Estudiantes>(new Contexto());
            MyReportViewer.ProcessingMode = ProcessingMode.Local;
            MyReportViewer.Reset();
            MyReportViewer.LocalReport.ReportPath = Server.MapPath(@"~\Reporte\EstudianteReport.rdlc");
            MyReportViewer.LocalReport.DataSources.Clear();
            MyReportViewer.LocalReport.DataSources.Add(new ReportDataSource("Estudiantes", repositorio.GetList(e => true)));
            MyReportViewer.LocalReport.Refresh();
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
                        break;
                    case 1:
                        Filtro = x => x.EstudianteId == id;
                        break;
                case 2:
                    Filtro = x => x.Nombres.Contains(TextBoxCriterio.Text);
                    break;
                case 3:
                    Filtro = x => x.Matricula.Contains(TextBoxCriterio.Text);
                    break;
                case 4:
                    decimal puntos = Utils.ToDecimal(TextBoxCriterio.Text);
                    Filtro = x => x.PuntosPerdidos == puntos;
                    break;

                }
            
            DatosGridView.DataSource = repositorio.GetList(Filtro);
            DatosGridView.DataBind();

        }
    }
}