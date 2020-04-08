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
    public class SalidasBLL
    {
        public static bool QuitarProducto(int Id, int cant)
        {
            bool paso = false;
            Contexto db = new Contexto();

            Productos p = ProductosBLL.Buscar(Id);

            if (p != null)
            {
                if(p.Cantidad < 1 || cant > p.Cantidad)
                {
                    return paso;
                }
                else
                {
                    p.Cantidad -= cant;
                    db.Entry(p).State = EntityState.Modified;
                    paso = (db.SaveChanges() > 0);

                }
            }

            return paso;
        }

        public static bool ReponerProducto(int Id, int cant)
        {
            bool paso = false;
            Contexto db = new Contexto();

            Productos p = ProductosBLL.Buscar(Id);

            if (p != null)
            {                
                p.Cantidad += cant;
                db.Entry(p).State = EntityState.Modified;
                paso = (db.SaveChanges() > 0);
                
            }

            return paso;
        }

        public static bool Guardar(Salidas salida)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                if (db.Salidas.Add(salida) != null)
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

        public static bool Modificar(Salidas salida)
        {

            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                db.Database.ExecuteSqlRaw($"Delete FROM SalidasDetalle where SalidaId = {salida.SalidaId}");
                foreach (var item in salida.SDetalle)
                {
                    db.Entry(item).State = EntityState.Added;
                }
                db.Entry(salida).State = EntityState.Modified;
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
                var Eliminar = db.Salidas.Find(Id);

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

        public static Salidas Buscar(int Id)
        {
            Salidas salida = new Salidas();
            Contexto db = new Contexto();

            try
            {
                salida = db.Salidas.Where(x => x.SalidaId == Id).Include(y => y.SDetalle).SingleOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }

            return salida;
        }
        public static List<Salidas> GetList(Expression<Func<Salidas, bool>> salida)
        {
            List<Salidas> Lista = new List<Salidas>();
            Contexto db = new Contexto();

            try
            {
                Lista = db.Salidas.Where(salida).ToList();
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
