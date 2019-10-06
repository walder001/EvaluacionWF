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
    public partial class cCategoriaWF : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Buscar_Click(object sender, EventArgs e)
        {
            Expression<Func<Categorias, bool>> Filtro = x => true;
            RepositorioBase<Categorias> repositorio = new RepositorioBase<Categorias>(new Contexto());
            List<Categorias> sugerencias = new List<Categorias>();

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
                        Filtro = x => x.CategoriaId == id;
                        break;
                }
            }
            DatosGridView.DataSource = repositorio.GetList(Filtro);
            DatosGridView.DataBind();
        }
    }
}