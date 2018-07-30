using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal.Entidades
{
    public class EntradaPeli
    {
        [Key]
        public int EntradaPeliId { get; set; }
        public DateTime Fecha { get; set; }
        public int PeliculaId { get; set; }
        public int Cantidad { get; set; }

        public EntradaPeli() { }
    }
}
