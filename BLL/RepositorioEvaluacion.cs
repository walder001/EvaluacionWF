using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class RepositorioEvaluacion : RepositorioBase<Evaluaciones>
    {
        public RepositorioEvaluacion(Contexto contexto) : base(contexto)
        {

        }
        public override bool Guardar(Evaluaciones evaluaciones)
        {
            RepositorioEvaluacion repositorio = new RepositorioEvaluacion(new Contexto());
            bool paso = false;
            try
            {
                if (_contexto.Evaluaciones.Add(evaluaciones) != null)
                    foreach (var item in evaluaciones.Detalles)
                    {
                        _contexto.Clientes.Find(item.EsudianteId).PuntosPerdidos += item.Perdido;
                       var cantidad = _contexto.Categorias.Find(item.CategoriaId).Cantidad += 1;
                       var promedio = _contexto.Categorias.Find(item.CategoriaId).PromedioNeto += item.Promedio;
                       var promedioTota = promedio / cantidad;
                       _contexto.Categorias.Find(item.CategoriaId).PromedioTotal = promedioTota;
                    }
             

                paso = _contexto.SaveChanges() > 0;
                _contexto.Dispose();
            }
            catch (Exception)
            {

                throw;
            }
            
            return paso;
        }

        public override Evaluaciones Buscar(int id)
        {
            Evaluaciones evaluacion = new Evaluaciones();
            try
            {
                evaluacion = _contexto.Evaluaciones.Find(id);

                evaluacion.Detalles.Count();
            }
            catch (Exception)
            {

                throw;
            }
            return evaluacion;
        }
        public override bool Modificar(Evaluaciones evaluacion)
        {
            RepositorioEvaluacion repositorio = new RepositorioEvaluacion(new Contexto());

            var Anterior = Buscar(evaluacion.EvaluacionId);
            bool paso = false;
            Contexto con = new Contexto();
            try
            {
                Contexto contexto = new Contexto();
                bool pas = false;
                foreach (var item in Anterior.Detalles.ToList())
                {
                    if (!evaluacion.Detalles.Exists(d => d.DetalleEvaluacionId == item.DetalleEvaluacionId))
                    {
                        contexto.Entry(item).State = EntityState.Deleted;
                        pas = true;
                    }
                }
                if (pas)
                    contexto.SaveChanges();
                contexto.Dispose();


                foreach (var item in evaluacion.Detalles)
                {
                    var estado = EntityState.Unchanged;
                    if (item.DetalleEvaluacionId == 0)
                    {
                        estado = EntityState.Added;
                    }
                    con.Entry(item).State = estado;
                }


                con.Entry(evaluacion).State = EntityState.Modified;
                if (con.SaveChanges() > 0)
                    paso = true;
            }
            catch (Exception)
            {
                throw;
            }
            return paso;

        }



    }
}
