using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ProjectoFinalRonald.Entidades
{
    public class Salidas
    {
        [Key]
        public int SalidaId { get; set; }
        public int ProveedorId { get; set; }
        public int UsuarioId { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }

        [ForeignKey("SalidaId")]
        public List<SalidasDetalle> SDetalle { get; set; }

        public Salidas()
        {
            SalidaId = 0;
            ProveedorId = 0;
            UsuarioId = 0;
            Fecha = DateTime.Now;
            Total = 0;
            SDetalle = new List<SalidasDetalle>();
        }
    }
}
