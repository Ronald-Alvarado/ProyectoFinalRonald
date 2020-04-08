using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProjectoFinalRonald.Entidades
{
    public class Categorias
    {
        [Key]
        public int CategoriaId { get; set; }
        public string Categoria { get; set; }
        public int UsuarioId { get; set; }

        public Categorias()
        {
            CategoriaId = 0;
            Categoria = string.Empty;
            UsuarioId = 0;
        }
    }
}
