using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProjectoFinalRonald.Entidades
{
    public class Productos
    {
        [Key]
        public int ProductoId { get; set; }
        public int CategoriaId { get; set; }
        public int UsuarioId { get; set; }
        public string Nombre { get; set; }
        public string Marca { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }

        public Productos()
        {
            ProductoId = 0;
            CategoriaId = 0;
            UsuarioId = 0;
            Nombre = string.Empty;
            Marca = string.Empty;
            Cantidad = 0;
            Precio = 0;
        }
    }
}
