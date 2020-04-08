using ProjectoFinalRonald.BLL;
using ProjectoFinalRonald.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ProjectoFinalRonald.UI.Registros
{
    /// <summary>
    /// Interaction logic for rSalidas.xaml
    /// </summary>
    public partial class rSalidas : Window
    {
        Salidas salidas = new Salidas();
        public rSalidas()
        {
            InitializeComponent();
            SalidaIdTextBox.Text = "0";
            this.DataContext = salidas;

        }

        private void Actualizar()
        {
            this.DataContext = null;
            this.DataContext = salidas;
        }

        private void Limpiar()
        {
            SalidaIdTextBox.Text = "0";
            ProveedorIdTextBox.Text = string.Empty;
            UsuarioIdTextBox.Text = string.Empty;
            FechaCompraDateTimePicker.SelectedDate = DateTime.Now;
            TotalTextBox.Text = string.Empty;

            salidas = new Salidas();
            Actualizar();
        }

        private bool Validar()
        {
            bool paso = true;

            if (SalidaIdTextBox.Text == string.Empty)
            {
                MessageBox.Show("SalidaId Vacio");
                SalidaIdTextBox.Focus();
                paso = false;
            }
            else if (ProveedorIdTextBox.Text == string.Empty || ProveedorIdTextBox.Text == "0")
            {
                MessageBox.Show("ProveedorId no Valido");
                ProveedorIdTextBox.Focus();
                paso = false;
            }
            else if (UsuarioIdTextBox.Text == string.Empty || UsuarioIdTextBox.Text == "0")
            {
                MessageBox.Show("UsuarioId no Valido");
                UsuarioIdTextBox.Focus();
                paso = false;
            }
            else if (FechaCompraDateTimePicker.Text == string.Empty)
            {
                MessageBox.Show("Fecha Vacia");
                FechaCompraDateTimePicker.Focus();
                paso = false;
            }
            else if (TotalTextBox.Text == string.Empty)
            {
                MessageBox.Show("No hay Productos Registrados");
                TotalTextBox.Focus();
                paso = false;
            }
            else if (SDetalleDataGrid.DataContext == null)
            {
                MessageBox.Show("Debe Agregar un Producto");
                paso = false;
            }

            return paso;
        }

        private bool ValidarDetalle()
        {
            bool paso = true;

            if (ProductoIdTextBox.Text == string.Empty)
            {
                MessageBox.Show("ProductoId Vacio");
                paso = false;
            }
            else if (NombreProductoTextBox.Text == string.Empty)
            {
                MessageBox.Show("El Id que digitó no existe");
                paso = false;
            }
            else if (CantidadTextBox.Text == string.Empty)
            {
                MessageBox.Show("Debe poner una Cantidad");
                paso = false;
            }

            return paso;
        }

        private bool ExisteBase()
        {
            Salidas s = SalidasBLL.Buscar((int)Convert.ToInt32(SalidaIdTextBox.Text));

            return (s != null);
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            Salidas s = SalidasBLL.Buscar(Convert.ToInt32(SalidaIdTextBox.Text));

            if (s != null)
            {
                salidas = s;
                Actualizar();
            }
            else
            {
                MessageBox.Show("La Salida que digitó no existe o no se pudo localizar");
            }
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            bool paso = false;

            if (!Validar())
            {
                return;
            }

            if (SalidaIdTextBox.Text == "0")
            {
                paso = SalidasBLL.Guardar(salidas);
            }
            else
            {
                if (!ExisteBase())
                {
                    MessageBox.Show("La Salida que digitó no Existe en la Base de Datos");
                    return;
                }
                paso = SalidasBLL.Modificar(salidas);
            }

            if (paso)
            {
                MessageBox.Show("La Salida Se ha Guardado Exitosamente");
                Limpiar();
            }
            else
            {
                MessageBox.Show("Ocurrio un Error al Guardar La Salida");
            }
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (SalidasBLL.Eliminar(Convert.ToInt32(SalidaIdTextBox.Text)))
            {
                MessageBox.Show("La Salida Se ha Eliminado Exitosamente");
                Limpiar();
            }
            else
            {
                MessageBox.Show("La Salida que digitó no existe");
            }
        }

        private void AgregarButton_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidarDetalle())
            {
                return;
            }

            if (!SalidasBLL.QuitarProducto(Convert.ToInt32(ProductoIdTextBox.Text),Convert.ToInt32(CantidadTextBox.Text)))
            {
                MessageBox.Show("El producto esta agotado o Digitó mas cantidad de la que existe");
                return;
            }

            salidas.SDetalle.Add(new SalidasDetalle(
                Convert.ToInt32(SalidaIdTextBox.Text),
                Convert.ToInt32(ProductoIdTextBox.Text),
                NombreProductoTextBox.Text,
                Convert.ToInt32(CantidadTextBox.Text),
                Convert.ToDecimal(PrecioTextBox.Text)));

            decimal Monto;
            decimal total;

            Monto = Convert.ToDecimal(PrecioTextBox.Text) * Convert.ToDecimal(CantidadTextBox.Text);
            total = Monto + Convert.ToDecimal(TotalTextBox.Text);

            TotalTextBox.Text = Convert.ToString(total);


            Actualizar();
            ProductoIdTextBox.Clear();
            CantidadTextBox.Clear();
        }

        private void RemoverDetalleButton_Click(object sender, RoutedEventArgs e)
        {
            if(SDetalleDataGrid.SelectedIndex < 0)
            {
                MessageBox.Show("Debe de seleccionar una fila a remover");
                return;
            }
            else
            {
                if (SDetalleDataGrid.Items.Count > 1 && SDetalleDataGrid.SelectedIndex < SDetalleDataGrid.Items.Count - 1)
                {
                    var id = salidas.SDetalle[SDetalleDataGrid.SelectedIndex].ProductoId;
                    var cant = salidas.SDetalle[SDetalleDataGrid.SelectedIndex].Cantidad;

                    SalidasBLL.ReponerProducto(Convert.ToInt32(id),Convert.ToInt32(cant));

                    salidas.SDetalle.RemoveAt(SDetalleDataGrid.SelectedIndex);

                    Actualizar();
                }
                else
                {
                    MessageBox.Show("No puedes quitar mas filas");
                }
            }
        }

        private void ProductoIdTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            int Id;
            int.TryParse(ProductoIdTextBox.Text, out Id);

            Productos productos = ProductosBLL.Buscar(Id);

            if(productos != null)
            {
                NombreProductoTextBox.Text = productos.Nombre;
                PrecioTextBox.Text = Convert.ToString(productos.Precio);
            }
            else
            {
                NombreProductoTextBox.Text = string.Empty;
                PrecioTextBox.Text = string.Empty;
            }
        }
    }
}
