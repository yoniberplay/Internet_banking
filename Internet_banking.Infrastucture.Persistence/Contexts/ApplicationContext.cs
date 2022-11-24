using Microsoft.EntityFrameworkCore;
using Internet_banking.Core.Domain.Common;
using Internet_banking.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Internet_banking.Infrastructure.Persistence.Contexts
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        public DbSet<Transacciones> Transacciones { get; set; }
        public DbSet<Cuenta> Cuenta { get; set; }
        public DbSet<Prestamo> Prestamo { get; set; }
        public DbSet<TarjetaCredito> TarjetaCredito { get; set; }
        public DbSet<Beneficiarios> Beneficiarios { get; set; }
        public DbSet<PagoExpreso> PagoExpresos { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach(var entry in ChangeTracker.Entries<AuditableBaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.Created = DateTime.Now;
                        entry.Entity.CreatedBy = "DefaultAppUser";
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModified = DateTime.Now;
                        entry.Entity.LastModifiedBy = "DefaultAppUser";
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //FLUENT API

            #region tables

            modelBuilder.Entity<Transacciones>()
                .ToTable("Transacciones");

            modelBuilder.Entity<Cuenta>()
                .ToTable("Cuenta");

            modelBuilder.Entity<Prestamo>()
                .ToTable("Prestamo");

            modelBuilder.Entity<Beneficiarios>()
                .ToTable("Beneficiarios");

            #endregion

            #region "primary keys"
            modelBuilder.Entity<Transacciones>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<Cuenta>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<Prestamo>()
               .HasKey(f => f.Id);

            modelBuilder.Entity<Beneficiarios>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<TarjetaCredito>()
               .HasKey(f => f.Id);
            #endregion

            #region "Relationships"


            //modelBuilder.Entity<Post>()
            //    .HasMany<Comments>(a => a.Comments)
            //    .WithOne(c => c.Post)
            //    .HasForeignKey(f => f.PostId)
            //    .OnDelete(DeleteBehavior.NoAction);




            #endregion

            #region "Property configurations"

            #region Transacciones

            modelBuilder.Entity<Transacciones>().
                Property(p => p.Origen)
                .IsRequired();

            modelBuilder.Entity<Transacciones>().
                Property(p => p.Destino)
                .IsRequired();

            modelBuilder.Entity<Transacciones>().
                 Property(p => p.Monto)
                 .IsRequired();

            modelBuilder.Entity<Transacciones>().
                Property(p => p.Tipo)
                .IsRequired();

            #endregion

            #region Cuenta
            modelBuilder.Entity<Cuenta>().
              Property(c => c.Balance)
              .IsRequired();

            modelBuilder.Entity<Cuenta>().
             Property(c => c.UserId)
             .IsRequired();

            modelBuilder.Entity<Cuenta>().
            Property(c => c.NumeroCuenta)
            .IsRequired();

            modelBuilder.Entity<Cuenta>().
            Property(c => c.Tipo)
            .IsRequired();
            #endregion

            #region Prestamo

            modelBuilder.Entity<Prestamo>().
              Property(f => f.UserId)
              .IsRequired();

            modelBuilder.Entity<Prestamo>().
            Property(f => f.MontoPrestamo)
            .IsRequired();

            modelBuilder.Entity<Prestamo>().
            Property(f => f.MontoPagado)
            .IsRequired();

            modelBuilder.Entity<Prestamo>().
            Property(f => f.PagadoTotal)
            .IsRequired();
            #endregion

            #region Beneficiarios

            modelBuilder.Entity<Beneficiarios>().
              Property(f => f.NombreBeneficiario)
              .IsRequired();

            modelBuilder.Entity<Beneficiarios>().
            Property(f => f.ApellidoBeneficiarios)
            .IsRequired();

            modelBuilder.Entity<Beneficiarios>().
            Property(f => f.NumeroCuenta)
            .IsRequired();
            #endregion

            #region TarjetaCredito

            modelBuilder.Entity<TarjetaCredito>().
              Property(f => f.UserId)
              .IsRequired();

            modelBuilder.Entity<TarjetaCredito>().
            Property(f => f.CreditDisponible)
            .IsRequired();

            modelBuilder.Entity<TarjetaCredito>().
            Property(f => f.Debito)
            .IsRequired();

            modelBuilder.Entity<TarjetaCredito>().
           Property(f => f.Limite)
           .IsRequired();

            modelBuilder.Entity<TarjetaCredito>().
           Property(f => f.Tipo)
           .IsRequired();
            #endregion

            #endregion

        }

    }
}
