using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    [Serializable]
    public class Categorias
    {
        [Key]
        public int CategoriaId { get; set; }
        public string NombreCategoria { get; set; }
        public decimal Valor { get; set; }
        public int Cantidad { get; set; }
        public decimal PromedioNeto { get; set; }
        public decimal PromedioTotal { get; set; }
        public Categorias()
        {
            CategoriaId = 0;
            NombreCategoria = string.Empty;
            Valor = 0;
            Cantidad = 0;
            PromedioNeto = 0;
            PromedioTotal = 0;

        }

        public Categorias(int categoriaId, string nombreCategoria, decimal valor, int cantidad, decimal promedioNeto, decimal promedioTotal)
        {
            CategoriaId = categoriaId;
            NombreCategoria = nombreCategoria;
            Valor = valor;
            Cantidad = cantidad;
            PromedioNeto = promedioNeto;
            PromedioTotal = promedioTotal;

        }
    }
}
