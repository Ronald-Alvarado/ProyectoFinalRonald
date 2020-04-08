using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using ProjectoFinalRonald.Data;
using ProjectoFinalRonald.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace ProjectoFinalRonald.BLL
{
    public class UsuariosBLL
    {
        public static bool Guardar(Usuarios usuarios)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                if(db.Usuarios.Add(usuarios) != null)
                {
                    paso = (db.SaveChanges()>0);
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

        public static bool Modificar(Usuarios usuarios)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                db.Entry(usuarios).State = EntityState.Modified;
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
                var Eliminar = db.Usuarios.Find(Id);

                if(Eliminar == null)
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

        public static Usuarios Buscar(int Id)
        {
            Usuarios usuarios = new Usuarios();
            Contexto db = new Contexto();

            try
            {
                usuarios = db.Usuarios.Find(Id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }

            return usuarios;
        }

        public static List<Usuarios> GetList(Expression<Func<Usuarios, bool>> usuarios)
        {
            List<Usuarios> Lista = new List<Usuarios>();
            Contexto db = new Contexto();

            try
            {
                Lista = db.Usuarios.Where(usuarios).ToList();
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
