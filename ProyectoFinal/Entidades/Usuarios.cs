using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace ProyectoFinal.Entidades
{
    public class Usuarios
    {
        [Key]
        public int UsuarioId { get; set; }
        public string Nombre { get; set; }
        public string NombreUsuario { get; set; }
        public string Pass { get; set; }
        public DateTime Fecha { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }

        public Usuarios(){}
    }
}
