using GestioneSpese_EntitiesRepository.Entità;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestioneSpese_EF.Context
{
    public class GestioneSpeseContext : DbContext
    {
        //Estensione Costruttore
        public GestioneSpeseContext() : base() { }
        public GestioneSpeseContext(DbContextOptions<GestioneSpeseContext> options) : base(options) { }

        //Definizione dei DBSET
        public DbSet<Spesa> Spese { get; set; }
        public DbSet<Categorie> Categorie { get; set; }

        //Indtroduco la stringa di connessione
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Persist Security Info = False; Integrated Security = true;
                        Initial Catalog = GestioneSpese; Server =.\SQLEXPRESS");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Spesa>()
                        .HasOne(c => c.Categoria)
                        .WithMany(x => x.Spese);


        }
    }
}
