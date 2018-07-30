using ProyectoFinal.DAL;
using ProyectoFinal.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal.BLL
{
    public class EntradaPeliculaBLL
    {
        public static bool Guardar(EntradaPeli entrada)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                if (contexto.Entrada.Add(entrada) != null)
                {
                    var Pelicula = contexto.Pelicula.Find(entrada.PeliculaId);

                    Pelicula.Inventario += entrada.Cantidad;

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

        public static bool Modificar(EntradaPeli entrada, EntradaPeli anterior)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {

                db.Entry(entrada).State = EntityState.Modified;

                Peliculas peliculas = db.Pelicula.Find(entrada.PeliculaId);
                Peliculas peliAnt= db.Pelicula.Find(anterior.PeliculaId);
                peliculas.Inventario += entrada.Cantidad;
                peliAnt.Inventario -= anterior.Cantidad;
                db.Entry(peliculas).State = EntityState.Modified;

                if(db.SaveChanges() > 0)
                {
                    paso = true;
                }

                db.Dispose();
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

                EntradaPeli entrada = contexto.Entrada.Find(id);

                var Pelicula = contexto.Pelicula.Find(entrada.PeliculaId);
                Pelicula.Inventario -= entrada.Cantidad;

                contexto.Entrada.Remove(entrada);

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


        public static EntradaPeli Buscar(int id)
        {

            EntradaPeli entrada = new EntradaPeli();
            Contexto contexto = new Contexto();

            try
            {
                entrada = contexto.Entrada.Find(id);
                contexto.Dispose();
            }

            catch (Exception)
            {
                throw;
            }

            return entrada;

        }


        public static List<EntradaPeli> GetList(Expression<Func<EntradaPeli, bool>> expression)
        {

            List<EntradaPeli> entrada = new List<EntradaPeli>();
            Contexto contexto = new Contexto();

            try
            {
                entrada = contexto.Entrada.Where(expression).ToList();
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }

            return entrada;
        }
    }
}
