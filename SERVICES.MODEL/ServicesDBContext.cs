namespace SERVICES.MODEL
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Data.Entity.ModelConfiguration.Conventions;

    public interface IServicesDBContext:IDBContex
    {
        DbSet<Orden> Ordenes { get; set; }
    }

    public partial class ServicesDBContext : DbContext, IServicesDBContext
    {

        public DbSet<Orden> Ordenes { get; set; }

        public ServicesDBContext(): base("name=ServicesDBContext")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();//Desactivamos la plurarizacion
        }
    }
}
