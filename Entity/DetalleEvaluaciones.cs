using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    [Serializable]
    public class DetalleEvaluaciones
    {
        [Key]
        public int DetalleEvaluacionId { get; set; }
        public int EvaluacionId { get; set; }
        public int CategoriaId { get; set; }
        public int EsudianteId { get; set; }
        public decimal Logrado { get; set; }
        public decimal Perdido { get; set; }
        public decimal Promedio { get; set; }

        public DetalleEvaluaciones()
        {
            DetalleEvaluacionId = 0;
            EvaluacionId = 0;
            CategoriaId = 0;
            EsudianteId = 0;
            Logrado = 0;
            Perdido = 0;
            Promedio = 0;
        }
        public DetalleEvaluaciones(int detalleEvaluacionId, int evaluacionId, int categoriaId, int esdudianteId, decimal logrado, decimal perdido, decimal promedio)
        {
            DetalleEvaluacionId = detalleEvaluacionId;
            EvaluacionId = evaluacionId;
            CategoriaId = categoriaId;
            EsudianteId = esdudianteId;
            Logrado = logrado;
            Perdido = perdido;
            Promedio = promedio;
        }
    }
}
