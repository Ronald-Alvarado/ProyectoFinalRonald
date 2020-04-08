using Microsoft.EntityFrameworkCore;
using ProjectoFinalRonald.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectoFinalRonald.Data
{
    public class Contexto : DbContext
    {
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Categorias> Categorias { get; set; }
        public DbSet<Productos> Productos { get; set; }
        public DbSet<Salidas> Salidas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source = DAL/Data/Inventario.db");
        }
    }
}
