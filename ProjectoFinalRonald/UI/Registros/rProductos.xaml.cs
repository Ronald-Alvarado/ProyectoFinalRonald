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
    /// Interaction logic for rProductos.xaml
    /// </summary>
    public partial class rProductos : Window
    {
        Productos productos = new Productos();
        public rProductos()
        {
            InitializeComponent();
            ProductoIdTextBox.Text = "0";
            CategoriaIdTextBox.Text = "0";
            UsuarioIdTextBox.Text = "0";
            this.DataContext = productos;
        }

        private void Actualizar()
        {
            this.DataContext = null;
            this.DataContext = productos;
        }

        private void Limpiar()
        {
            ProductoIdTextBox.Text = "0";
            NombreProductoTextBox.Text = string.Empty;
            MarcaProductoTextBox.Text = string.Empty;
            CantidadTextBox.Text = string.Empty;
            PrecioTextBox.Text = string.Empty;
            UsuarioIdTextBox.Text = string.Empty;
            UsuarioTextBox.Text = string.Empty;
            CategoriaIdTextBox.Text = string.Empty;
            CategoriaTextBox.Text = string.Empty;

            productos = new Productos();
            Actualizar();
        }

        private bool ExisteBase()
        {
            Productos productos = ProductosBLL.Buscar(int.Parse(ProductoIdTextBox.Text));

            return (productos != null);
        }

        private bool Validar()
        {
            bool paso = true;

            if (ProductoIdTextBox.Text == string.Empty)
            {
                MessageBox.Show("ProductoId Vacio");
                ProductoIdTextBox.Focus();
                paso = false;
            }
            else if (NombreProductoTextBox.Text == string.Empty)
            {
                MessageBox.Show("Nombre del Producto Vacio");
                NombreProductoTextBox.Focus();
                paso = false;
            }
            else if (MarcaProductoTextBox.Text == string.Empty)
            {
                MessageBox.Show("Marca del Producto Vacio");
                MarcaProductoTextBox.Focus();
                paso = false;
            }
            else if (CategoriaIdTextBox.Text == string.Empty)
            {
                MessageBox.Show("CategoriaId del Producto Vacio");
                CategoriaIdTextBox.Focus();
                paso = false;
            }
            else if (CategoriaTextBox.Text == string.Empty)
            {
                MessageBox.Show("Categoria del Producto Vacio");
                CategoriaIdTextBox.Focus();
                paso = false;
            }
            else if (CantidadTextBox.Text == string.Empty)
            {
                MessageBox.Show("Cantidad Vacia");
                CantidadTextBox.Focus();
                paso = false;
            }
            else if (PrecioTextBox.Text == string.Empty)
            {
                MessageBox.Show("Precio Vacio");
                PrecioTextBox.Focus();
                paso = false;
            }
            else if (UsuarioIdTextBox.Text == string.Empty)
            {
                MessageBox.Show("UsuarioId Vacio o no Valido");
                UsuarioIdTextBox.Focus();
                paso = false;
            }

            return paso;
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            Productos FindProduct = ProductosBLL.Buscar(Convert.ToInt32(ProductoIdTextBox.Text));

            if (FindProduct != null)
            {
                productos = FindProduct;
                Actualizar();
            }
            else
            {
                MessageBox.Show("El Producto que digitó no Existe");
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

            if (ProductoIdTextBox.Text == "0")
            {
                paso = ProductosBLL.Guardar(productos);
            }
            else
            {
                if (!ExisteBase())
                {
                    MessageBox.Show("El Producto que digitó no existe en la Base de Datos");
                    return;
                }
                paso = ProductosBLL.Modificar(productos);
            }

            if (paso)
            {
                MessageBox.Show("El Producto Se ha Guardado Exitosamente");
                Limpiar();
            }
            else
            {
                MessageBox.Show("Ocurrio un Error al Guardar el Producto");
            }
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (ProductosBLL.Eliminar(Convert.ToInt32(ProductoIdTextBox.Text)))
            {
                MessageBox.Show("El producto Se ha Eliminado Exitosamente");
                Limpiar();
            }
            else
            {
                MessageBox.Show("El Producto que digitó no existe");
            }
        }

        private void CategoriaIdTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            int Id;
            int.TryParse(CategoriaIdTextBox.Text, out Id);

            Categorias c = new Categorias();
            c = CategoriasBLL.Buscar(Id);

            if (c != null)
            {
                CategoriaTextBox.Text = c.Categoria;
            }
            else
            {
                CategoriaTextBox.Text = string.Empty;
            }       
        }

        private void UsuarioIdTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            int Id;
            int.TryParse(UsuarioIdTextBox.Text, out Id);

            Usuarios u = new Usuarios();
            u = UsuariosBLL.Buscar(Id);

            if (u != null)
            {
                UsuarioTextBox.Text = u.Nombres;
            }
            else
            {
                UsuarioTextBox.Text = string.Empty;
            }
        }
    }
}
