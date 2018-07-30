using ProyectoFinal.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Peliculas> Pelicula { get; set; }
        public DbSet<Generos> Genero { get; set; }
        public DbSet<Facturas> Factura { get; set; }
        public DbSet<FactDetalle> FactDetalle { get; set; }
        public DbSet<Usuarios> Usuario { get; set; }
        public DbSet<EntradaPeli> Entrada { get; set; }

        public Contexto() : base("ConStr") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
