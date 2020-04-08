using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectoFinalRonald.BLL;
using ProjectoFinalRonald.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectoFinalRonald.BLL.Tests
{
    [TestClass()]
    public class ProductosBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            Productos productos = new Productos()
            {
                ProductoId = 0,
                CategoriaId = 0,
                UsuarioId = 0,
                Nombre = "Leche",
                Marca = "Milex",
                Cantidad = 10,
                Precio = 50
            };

            bool paso = ProductosBLL.Guardar(productos);

            Assert.IsTrue(paso);
        }

        [TestMethod()]
        public void ModificarTest()
        {
            Productos productos = new Productos()
            {
                ProductoId = 1,
                CategoriaId = 0,
                UsuarioId = 0,
                Nombre = "Leche",
                Marca = "Milex",
                Cantidad = 10,
                Precio = 50
            };

            bool paso = ProductosBLL.Modificar(productos);

            Assert.IsTrue(paso);
        }

        [TestMethod()]
        public void EliminarTest()
        {
            bool paso = ProductosBLL.Eliminar(1);

            Assert.IsTrue(paso);
        }

        [TestMethod()]
        public void BuscarTest()
        {
            Productos productos = ProductosBLL.Buscar(1);

            Assert.IsTrue(productos != null);
        }

        [TestMethod()]
        public void GetListTest()
        {
            List<Productos> listado = ProductosBLL.GetList(c => true);

            Assert.IsTrue(listado != null);
        }
    }
}