using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectoFinalRonald.Entidades
{
    public class SalidasDetalle
    {
        public int SalidasDetalleId { get; set; }
        public int SalidaId { get; set; }
        public int ProductoId { get; set; }
        public string Nombre { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }

        public SalidasDetalle()
        {
            SalidasDetalleId = 0;
            SalidaId = 0;
            ProductoId = 0;
            Nombre = string.Empty;
            Cantidad = 0;
            Precio = 0;
        }

        public SalidasDetalle(int SalidaId, int ProductoId, string Nombre, int Cantidad, decimal Precio)
        {

            this.SalidaId = SalidaId;
            this.ProductoId = ProductoId;
            this.Nombre = Nombre;
            this.Cantidad = Cantidad;
            this.Precio = Precio;
        }
    }
}
