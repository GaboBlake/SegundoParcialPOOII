

using System.Reflection;
using Microsoft.EntityFrameworkCore;
using SegundoParcialPOOII.Entities;

namespace SegundoParcialPOOII

{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet <JugueteEntity> Juguetes => Set<JugueteEntity>();
        public DbSet <MarcaEntity> Marcas => Set<MarcaEntity>();

    }




}