using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    [Serializable]
     public class Evaluaciones
    {
        [Key]
        public int EvaluacionId { get; set; }
        public int EsudianteId { get; set; } 
        public DateTime Fecha { get; set; }

       public virtual List<DetalleEvaluaciones> Detalles { get; set; }
        public Evaluaciones()
        {
            EvaluacionId = 0;
            EsudianteId = 0;
            Fecha = DateTime.Now;
            this.Detalles = new List<DetalleEvaluaciones>();
        }  

        public Evaluaciones(int evaluacionId, int clienteId, DateTime fecha)
        {
            EvaluacionId = evaluacionId;
            EsudianteId = clienteId;
            Fecha = fecha;
            this.Detalles = new List<DetalleEvaluaciones>();
        }
        public void Agregar(int detalleEvalucionId, int evaluacionId, int categoria, int estudianteId, decimal logrado, decimal perdido, decimal promedio)
        {
            this.Detalles.Add(new DetalleEvaluaciones(detalleEvalucionId, evaluacionId, categoria, estudianteId, logrado, perdido, promedio));

        }

    }
}
