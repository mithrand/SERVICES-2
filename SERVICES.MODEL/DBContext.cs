using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;

namespace SERVICES.MODEL
{
    public interface IServicesDBContext:IDisposable,IDBContex
    {
        DbSet<Usuario> Usuarios { get; }
        DbSet<Orden> Ordenes { get; }
    }

    public class ServicesDBContext: DbContext,IServicesDBContext
    {

        #region constructors
        public ServicesDBContext() : base("name = ServicesDBContext")
        {
            
        }

        public ServicesDBContext(string conectionString) : base("name = ServicesDBContext")
        {
            this.Database.Connection.ConnectionString = conectionString;
        }

        #endregion

        public DbSet<Usuario> Usuarios { get; }
        public DbSet<Orden> Ordenes { get; }
    }

}
