using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace ProyectoFinal.Entidades
{
    public class Facturas
    {
        [Key]
        public int FacturaId { get; set; }
        public int ClienteId { get; set; }
        public DateTime Fecha { get; set; }
        public string Observaciones { get; set; }
        public Decimal Total { get; set; }

        public virtual ICollection<FactDetalle> Detalle { get; set; }

        public Facturas()
        {
            FacturaId = 0;
            ClienteId = 0;
            Fecha = DateTime.Now;
            Observaciones = string.Empty;
            this.Detalle = new List<FactDetalle>();
            Total = 0;
        }

        public void AgregarDetalle(int factDetalleId,int facturaId,int clienteId,int peliculaId, string pelicula, int cantidad, decimal precio, decimal importe)
        {
            this.Detalle.Add(new FactDetalle(factDetalleId,facturaId, clienteId,peliculaId, pelicula, cantidad, precio, importe));
        }
    }
}
