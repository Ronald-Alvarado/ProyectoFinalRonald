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
    /// Interaction logic for rCategorias.xaml
    /// </summary>
    public partial class rCategorias : Window
    {
        Categorias categorias = new Categorias();
        public rCategorias()
        {
            InitializeComponent();
            CategoriaIdTextBox.Text = "0";
            this.DataContext = categorias;
            Refresh();
        }

        private void Refresh()
        {
            this.DataContext = null;
            this.DataContext = categorias;
        }
        private void Limpiar()
        {
            CategoriaIdTextBox.Text = "0";
            CategoriaTextBox.Text = string.Empty;
            UsuarioIdTextBox.Text = string.Empty;

            categorias = new Categorias();
            Refresh();
        }
        private bool ExisteBase()
        {
            Categorias Cat = CategoriasBLL.Buscar((int)Convert.ToInt32(CategoriaIdTextBox.Text));

            return (Cat != null);
        }
        private bool Validar()
        {
            bool paso = true;

            if (CategoriaIdTextBox.Text == string.Empty)
            {
                MessageBox.Show("CategoriaId Vacio");
                CategoriaIdTextBox.Focus();
                paso = false;
            }
            else if (CategoriaTextBox.Text == string.Empty)
            {
                MessageBox.Show("Categoria Vacia");
                CategoriaTextBox.Focus();
                paso = false;
            }
            else if (UsuarioIdTextBox.Text == string.Empty)
            {
                MessageBox.Show("UsuarioId Vacio");
                UsuarioIdTextBox.Focus();
                paso = false;
            }

            return paso;
        }


        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            Categorias FindCat = CategoriasBLL.Buscar(Convert.ToInt32(CategoriaIdTextBox.Text));

            if (FindCat != null)
            {
                categorias = FindCat;
                Refresh();
            }
            else
            {
                MessageBox.Show("La Categoria que digitó no Existe");
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

            if (CategoriaIdTextBox.Text == "0")
            {
                paso = CategoriasBLL.Guardar(categorias);
            }
            else
            {
                if (!ExisteBase())
                {
                    MessageBox.Show("La Categoria no existe en la base de datos");
                    return;
                }
                paso = CategoriasBLL.Modificar(categorias);
            }

            if (paso)
            {
                MessageBox.Show("La Categoria se a Guardado Exitosamente");
                Limpiar();
            }
            else
            {
                MessageBox.Show("Ocurrio un Error al Guardar la categoria");
            }
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (CategoriasBLL.Eliminar(Convert.ToInt32(CategoriaIdTextBox.Text)))
            {
                MessageBox.Show("La Categoria se a Eliminado Exitosamente");
                Limpiar();
            }
            else
            {
                MessageBox.Show("La Categoria que digitó no existe");
            }
        }
    }
}
