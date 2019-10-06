using Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Estudiantes> Clientes { get; set; }
        public DbSet<Categorias> Categorias { get; set; }
        public DbSet<Evaluaciones> Evaluaciones { get; set; }
        public Contexto() : base("DbEvaluacion")
        {

        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);    
        }

    }
}
