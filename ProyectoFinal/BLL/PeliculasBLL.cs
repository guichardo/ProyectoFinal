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
    public class PeliculasBLL
    {
        public static string MostrarDescripcion(string Nombre)
        {
            string Descripcion = string.Empty;
            var lista = GetList(x => x.Nombre.Equals(Nombre));
            foreach (var item in lista)
            {
                Nombre = item.Nombre;
            }

            return Descripcion;
        }

        public static bool Guardar(Peliculas peliculas)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                if (contexto.Pelicula.Add(peliculas) != null)
                {
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

        public static bool Modificar(Peliculas peliculas )
        {

            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Entry(peliculas).State = EntityState.Modified;
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

                Peliculas peliculas = contexto.Pelicula.Find(id);
                contexto.Pelicula.Remove(peliculas);

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

        public static Peliculas Buscar(int id)
        {
            Peliculas peliculas = new Peliculas();
            Contexto contexto = new Contexto();
            try
            {
                peliculas = contexto.Pelicula.Find(id);
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return peliculas;
        }

        public static List<Peliculas> GetList(Expression<Func<Peliculas, bool>> expression)
        {
            List<Peliculas> peliculas = new List<Peliculas>();
            Contexto contexto = new Contexto();

            try
            {
                peliculas = contexto.Pelicula.Where(expression).ToList();
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }

            return peliculas;
        }

        public static List<Peliculas> GetList()
        {
            List<Peliculas> peliculas = new List<Peliculas>();
            Contexto db = new Contexto();

            try
            {
                peliculas = db.Pelicula.ToList();
                db.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return peliculas;
        }
    }
}
