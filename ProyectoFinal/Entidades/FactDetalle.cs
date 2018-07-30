using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace ProyectoFinal.Entidades
{
    public class FactDetalle
    {
        [Key]
        public int FactDetalleId { get; set; }
        public int FacturaId { get; set; }
        public int PeliculaId { get; set; }
        public int ClienteId { get; set; }
        public string Pelicula { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public decimal Importe { get; set; }

        [ForeignKey("PeliculaId")]
        public virtual Peliculas peliculas { get; set; }

        public FactDetalle()
        {
            FactDetalleId = 0;
            FacturaId = 0;
        }

        public FactDetalle(int FactDetalleId, int FacturaId,int ClienteId, int PeliculaId, string Pelicula, int Cantidad, decimal Precio, decimal Importe)
        {
            this.FactDetalleId = FactDetalleId;
            this.FacturaId = FacturaId;
            this.ClienteId = ClienteId;
            this.PeliculaId = PeliculaId;
            this.Pelicula = Pelicula;
            this.Cantidad = Cantidad;
            this.Precio = Precio;
            this.Importe = Importe;
        }
    }
}
