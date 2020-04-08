using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectoFinalRonald.BLL;
using ProjectoFinalRonald.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectoFinalRonald.BLL.Tests
{
    [TestClass()]
    public class CategoriasBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            Categorias categorias = new Categorias();

            categorias.CategoriaId = 0;
            categorias.Categoria = "Vegetal";
            categorias.UsuarioId = 1;

            bool paso = CategoriasBLL.Guardar(categorias);

            Assert.IsTrue(paso);
        }

        [TestMethod()]
        public void ModificarTest()
        {
            Categorias categorias = new Categorias();

            categorias.CategoriaId = 1;
            categorias.Categoria = "Vegetales";
            categorias.UsuarioId = 1;

            bool paso = CategoriasBLL.Modificar(categorias);

            Assert.IsTrue(paso);
        }

        [TestMethod()]
        public void EliminarTest()
        {
            bool paso = CategoriasBLL.Eliminar(1);

            Assert.IsTrue(paso);
        }

        [TestMethod()]
        public void BuscarTest()
        {
            Categorias categorias = CategoriasBLL.Buscar(2);

            Assert.IsTrue(categorias != null);
        }

        [TestMethod()]
        public void GetListTest()
        {
            List<Categorias> listado = CategoriasBLL.GetList(c => true);

            Assert.IsTrue(listado != null);
        }
    }
}