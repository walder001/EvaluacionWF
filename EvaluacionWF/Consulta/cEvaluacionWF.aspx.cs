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
    public partial class cEvaluacionWF : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Buscar_Click(object sender, EventArgs e)
        {
            Expression<Func<Evaluaciones, bool>> Filtro = x => true;
            RepositorioBase<Evaluaciones> repositorio = new RepositorioBase<Evaluaciones>(new Contexto());
            List<Evaluaciones> sugerencias = new List<Evaluaciones>();

            int id;
            id = Utils.ToInt(TextBoxCriterio.Text);

            if (checkbox.Enabled == true)
            {
                switch (DropDrom.SelectedIndex)
                {
                    case 0:
                        repositorio.GetList(x => true);
                        break;
                    case 1:
                        Filtro = x => x.EvaluacionId == id;
                        break;

                }


            }
            else
                switch (DropDrom.SelectedIndex)
                {
                    case 0:
                        repositorio.GetList(x => true);
                        break;
                    case 1:
                        Filtro = x => x.EvaluacionId == id;
                        break;

                }

            DatosGridView.DataSource = repositorio.GetList(Filtro);
            DatosGridView.DataBind();
        }
    
    }
   }
