using Microsoft.EntityFrameworkCore;
using ProjectoFinalRonald.Data;
using ProjectoFinalRonald.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace ProjectoFinalRonald.BLL
{
    public class CategoriasBLL
    {
        public static bool Guardar(Categorias categorias)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                if (db.Categorias.Add(categorias) != null)
                {
                    paso = (db.SaveChanges() > 0);
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }

            return paso;
        }

        public static bool Modificar(Categorias categorias)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                db.Entry(categorias).State = EntityState.Modified;
                paso = (db.SaveChanges() > 0);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }

            return paso;
        }

        public static bool Eliminar(int Id)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                var Eliminar = db.Categorias.Find(Id);

                if (Eliminar == null)
                {
                    return paso;
                }

                db.Entry(Eliminar).State = EntityState.Deleted;
                paso = (db.SaveChanges() > 0);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }

            return paso;
        }

        public static Categorias Buscar(int Id)
        {
            Categorias categorias = new Categorias();
            Contexto db = new Contexto();

            try
            {
                categorias = db.Categorias.Find(Id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }

            return categorias;
        }

        public static List<Categorias> GetList(Expression<Func<Categorias, bool>> categorias)
        {
            List<Categorias> Lista = new List<Categorias>();
            Contexto db = new Contexto();

            try
            {
                Lista = db.Categorias.Where(categorias).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }

            return Lista;
        }
    }
}
