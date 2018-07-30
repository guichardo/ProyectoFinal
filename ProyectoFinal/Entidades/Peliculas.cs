using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace ProyectoFinal.Entidades
{
    public class Peliculas
    {
        [Key]
        public int PeliculaId { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int Inventario { get; set; }
        public DateTime FechaSalida { get; set; }
        public string Sipnosis { get; set; }

        public Peliculas(){}

        public override string ToString()
        {
            return this.Nombre;
        }
    }
}
