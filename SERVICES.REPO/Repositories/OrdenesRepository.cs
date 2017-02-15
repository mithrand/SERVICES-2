using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SERVICES.MODEL;
using System.Data.Entity.Migrations;

namespace SERVICES.REPO
{
    public interface IOrdenesRepository
    {
        IEnumerable<Orden> GetAll();
        Orden GetById(long id);
        IEnumerable<Orden> GetByCriteria(string Codigo, DateTime? fechaAlta, int? prioridad, string motivo, DateTime? FechaAcordada);
        Orden Add(string Codigo = null, DateTime? fechaAlta = null, int prioridad = 0, string motivo = null, DateTime? FechaAcordada = null);
        Orden Add(Orden orden);
        void Delete(int ordenID);
    }

    public class OrdenesRepository: IOrdenesRepository
    {
        private IServicesDBContext ctx;

        #region constructor
        public OrdenesRepository(IServicesDBContext ctx)
        {
            this.ctx = ctx;
        }
        #endregion

        #region Methods
        public IEnumerable<Orden> GetAll()
        {
            return ctx.Ordenes.ToList(); 
        }

        public Orden GetById(long id)
        {
            return ctx.Ordenes.Where(x => x.OrdenId == id).FirstOrDefault();
        }

        public IEnumerable<Orden> GetByCriteria(string Codigo, DateTime? fechaAlta, int? prioridad, string motivo, DateTime? FechaAcordada)
        {
            throw new NotImplementedException();
        }

        public Orden Add(string Codigo=null, DateTime? fechaAlta=null, int prioridad=0, string motivo=null, DateTime? FechaAcordada=null)
        {
            Orden result;

            result = new Orden {
                Codigo = Codigo,
                FechaAlta = fechaAlta,
                Prioridad = prioridad,
                Motivo = motivo,
                FechaAcordada = FechaAcordada
            };

            ctx.Ordenes.AddOrUpdate(result);
            ctx.SaveChanges();
            
            return result;
        }

        public Orden Add(Orden orden)
        {

            ctx.Ordenes.AddOrUpdate(orden);
            ctx.SaveChanges();

            return orden;
        }

        public void Delete(int ordenID)
        {
            Orden orden = ctx.Ordenes.Where(x => x.OrdenId == ordenID).FirstOrDefault();
            if(orden != null)
            {
                ctx.Ordenes.Remove(orden);
            }
        }
        #endregion
    }
}
