using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Principal;
using System.Text;

namespace ProjectoFinalRonald.Entidades
{
    public class Usuarios
    {
        [Key]
        public int UsuarioId { get; set; }
        public string Nombres { get; set; }
        public string Telefono { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        public string Sexo { get; set; }
        public string Cedula { get; set; }
        public string Direccion { get; set; }
        public string TipoUsuario { get; set; }

        public Usuarios()
        {
            UsuarioId = 0;
            Nombres = string.Empty;
            Telefono = string.Empty;
            Celular = string.Empty;
            Email = string.Empty;
            Sexo = string.Empty;
            Cedula = string.Empty;
            Direccion = string.Empty;
            TipoUsuario = string.Empty;
        }
    }
}
