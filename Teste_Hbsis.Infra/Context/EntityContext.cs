namespace Teste_Hbsis.Infra
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Domain.Interfaces;
    using Domain.Entities;

    public partial class EntityContext : DbContext, IDbContext
    {
        public EntityContext()
            : base("name=Hbsis_Connection")
        {
        }

        public virtual DbSet<Cliente> Cliente { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>()
                .Property(e => e.Documento)
                .IsUnicode(false);

            modelBuilder.Entity<Cliente>()
                .Property(e => e.Telefone)
                .IsUnicode(false);
        }
    }
}
