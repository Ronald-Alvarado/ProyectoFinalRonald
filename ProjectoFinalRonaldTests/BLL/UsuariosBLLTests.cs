using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectoFinalRonald.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectoFinalRonald.BLL.Tests
{
    [TestClass()]
    public class UsuariosBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            Usuarios usuarios = new Usuarios
            {
                UsuarioId = 0,
                Nombres = "Ronald",
                Telefono = "829-789-7987",
                Celular = "654954-9591",
                Email = "987-987954-asdf",
                Sexo = "Masculino",
                Cedula = "5494-4949444-4",
                Direccion = "Madeja",
                TipoUsuario = "Administrador"
            };

            bool paso = UsuariosBLL.Guardar(usuarios);

            Assert.IsTrue(paso);
        }

        [TestMethod()]
        public void ModificarTest()
        {
            Usuarios usuarios = new Usuarios
            {
                UsuarioId = 1,
                Nombres = "Ronald Alvarado",
                Telefono = "829-789-7987",
                Celular = "654954-9591",
                Email = "987-987954-asdf",
                Sexo = "Masculino",
                Cedula = "5494-4949444-4",
                Direccion = "Madeja",
                TipoUsuario = "Administrador"
            };

            bool paso = UsuariosBLL.Modificar(usuarios);

            Assert.IsTrue(paso);
        }

        [TestMethod()]
        public void EliminarTest()
        {
            bool paso = UsuariosBLL.Eliminar(1);

            Assert.IsTrue(paso);
        }

        [TestMethod()]
        public void BuscarTest()
        {
            Usuarios usuarios = UsuariosBLL.Buscar(2);

            Assert.IsTrue(usuarios != null);
        }

        [TestMethod()]
        public void GetListTest()
        {
            List<Usuarios> listado = UsuariosBLL.GetList(c => true);

            Assert.IsTrue(listado != null);
        }
    }
}