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
    public class UsuariosBLL
    {
        public static bool Guardar(Usuarios usuarios)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                if (contexto.Usuario.Add(usuarios) != null)
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

        public static bool Modificar(Usuarios usuarios)
        {

            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Entry(usuarios).State = EntityState.Modified;
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

                Usuarios usuarios = contexto.Usuario.Find(id);
                contexto.Usuario.Remove(usuarios);

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

        public static Usuarios Buscar(int id)
        {
            Usuarios usuarios = new Usuarios();
            Contexto contexto = new Contexto();
            try
            {
                usuarios = contexto.Usuario.Find(id);
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return usuarios;
        }

        public static List<Usuarios> GetListTodo()
        {
            List<Usuarios> lista = null;
            try
            {
                Contexto dbase = new Contexto();
                lista = dbase.Usuario.ToList();
            }
            catch (Exception)
            {

                throw;
            }
            return lista;
        }

        public static List<Usuarios> GetList(Expression<Func<Usuarios, bool>> expression)
        {
            List<Usuarios> usario = new List<Usuarios>();
            Contexto contexto = new Contexto();

            try
            {
                usario = contexto.Usuario.Where(expression).ToList();
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }

            return usario;
        }
    }
}
