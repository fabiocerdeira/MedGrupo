using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using entitiesMedGrupo;


namespace crudMedGrupo
{
    public class MedGrupoContext : DbContext
    {

        public MedGrupoContext()
           : base()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Configuration.GetConnectionString("medGrupoContext")
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=dbMedGrupo;Integrated Security=True;TrustServerCertificate=False;");

        }


        public DbSet<Contato> Contatos { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contato>().ToTable("contatos")
                .HasKey(c => c.IdContato);
        }



    }

}
