using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace ProyectoFinal.Entidades
{
    public class Generos
    {
        [Key]

        public int GeneroId { get; set; }
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; }

        public Generos(){}

        public override string ToString()
        {
            return this.Descripcion;
        }
    }
}
