using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using projetoPSI.Models;

namespace projetoPSI.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Medicamento>().HasData(
                   new Medicamento { MedicId = 1, Nome = "Benuron", Preco = 5, Descricao = "Descrição do Medicamento"}
                   );


        }
        public DbSet<Medicamento> Medicamento { get; set; }

    }
}
