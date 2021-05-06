using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weelo.Dominio;

namespace Weelo.Data
{
    /// <summary>
    /// Contexto de aplicacion para el proyecto
    /// </summary>
    public class WeeloDbContext :DbContext
    {

        DbSet<Owner> Owner { get; set; }
        DbSet<Property> Property { get; set; }

        DbSet<PropertyTrace> PropertyTrace { get; set; }

        DbSet<PropertyImage> PropertyImage { get; set; }

        public WeeloDbContext(DbContextOptions<WeeloDbContext> options): base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Property>()
                   .Property(x => x.Price)
                   .HasPrecision(18, 2);

            modelBuilder.Entity<PropertyTrace>()
                  .Property(x => x.Value)
                  .HasPrecision(18, 2);

            modelBuilder.Entity<PropertyTrace>()
                 .Property(x => x.Tax)
                 .HasPrecision(18, 2);




            base.OnModelCreating(modelBuilder);
        }
    }
}
