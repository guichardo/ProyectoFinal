using ProyectoFinal.DAL;
using ProyectoFinal.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace ProyectoFinal.BLL
{
    public class FacturaBLL
    {

        public static decimal CalcularImporte(decimal precio, int cantidad)
        {
            return Convert.ToDecimal(precio) * Convert.ToInt32(cantidad);
        }

        public static bool Guardar(Facturas facturas)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                if (contexto.Factura.Add(facturas) != null)
                {
                    foreach (var item in facturas.Detalle)
                    {
                        contexto.Pelicula.Find(item.PeliculaId).Inventario -= item.Cantidad;
                    }

                    contexto.SaveChanges();
                    paso = true;
                }

                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        public static bool Modificar(Facturas facturas)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {

                var factant = FacturaBLL.Buscar(facturas.FacturaId);

                foreach (var item in factant.Detalle)
                {

                    contexto.Pelicula.Find(item.PeliculaId).Inventario += item.Cantidad;


                    if (!facturas.Detalle.ToList().Exists(v => v.PeliculaId == item.FactDetalleId))
                    {
                        item.peliculas = null;
                        contexto.Entry(item).State = EntityState.Deleted;
                    }
                }


                foreach (var item in facturas.Detalle)
                {

                    contexto.Pelicula.Find(item.PeliculaId).Inventario -= item.Cantidad;


                    var estado = item.PeliculaId > 0 ? EntityState.Modified : EntityState.Added;
                    contexto.Entry(item).State = estado;
                }

                if (contexto.SaveChanges() > 0)
                {
                    paso = true;
                }
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        public static bool Eliminar(int id)
        {
            bool paso = false;

            Contexto contexto = new Contexto();
            try
            {
               Facturas facturas = contexto.Factura.Find(id);

                if (facturas != null)
                {
                    foreach (var item in facturas.Detalle)
                    {
                        contexto.Pelicula.Find(item.PeliculaId).Inventario += item.Cantidad;
                    }

                    facturas.Detalle.Count();
                    contexto.Factura.Remove(facturas);
                }
                if (contexto.SaveChanges() > 0)
                {
                    paso = true;
                }
                contexto.Dispose();
            }
            catch (Exception)
            {

                throw;
            }
            return paso;
        }

        public static Facturas Buscar(int id)
        {

            Facturas facturas = new Facturas();
            Contexto contexto = new Contexto();

            try
            {
                facturas = contexto.Factura.Find(id);
                facturas.Detalle.Count();

                foreach (var item in facturas.Detalle)
                {
                    string s = item.peliculas.Nombre;
                }
                contexto.Dispose();
            }

            catch (Exception)
            {

                throw;

            }

            return facturas;

        }

        public static List<Facturas> GetList(Expression<Func<Facturas, bool>> expression)
        {

            List<Facturas> facturas = new List<Facturas>();
            Contexto contexto = new Contexto();

            try
            {

                facturas = contexto.Factura.Where(expression).ToList();
                contexto.Dispose();
            }
            catch (Exception)
            {

                throw;
            }

            return facturas;
        }
    }
}
