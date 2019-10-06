using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    [Serializable]
    public class Estudiantes
    {
        [Key]
        public int EstudianteId { get; set; }
        public string Nombres { get; set; }
        public string Matricula { get; set; }
        public decimal PuntosPerdidos { get; set; }
        public Estudiantes()
        {
            EstudianteId = 0;
            Nombres = string.Empty;
            Matricula = string.Empty;
            PuntosPerdidos = 0;
        }

        public Estudiantes(int clienteId, string nombres, string matricula, decimal puntosPerdidos)
        {
            EstudianteId = clienteId;
            Nombres = nombres;
            Matricula = matricula;
            PuntosPerdidos = puntosPerdidos;
        }
    }
}
