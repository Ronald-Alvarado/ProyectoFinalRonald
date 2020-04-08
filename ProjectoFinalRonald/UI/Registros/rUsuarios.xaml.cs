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
    /// Interaction logic for rUsuarios.xaml
    /// </summary>
    public partial class rUsuarios : Window
    {
        Usuarios usuarios = new Usuarios();
        public rUsuarios()
        {
            InitializeComponent();
            UsuarioIdTextBox.Text = "0";
            this.DataContext = usuarios;

            SexoComboBox.Items.Add("Masculino");
            SexoComboBox.Items.Add("Femenino");

            TipoUsuarioComboBox.Items.Add("Empleado");
            TipoUsuarioComboBox.Items.Add("Administrador");
        }
        private void Refresh()
        {
            this.DataContext = null;
            this.DataContext = usuarios;
        }
        private void Limpiar()
        {
            UsuarioIdTextBox.Text = "0";
            NombresTextBox.Text = string.Empty;
            TelefonoTextBox.Text = string.Empty;
            CelularTextBox.Text = string.Empty;
            EmailTextBox.Text = string.Empty;
            SexoComboBox.SelectedItem = null;
            CedulaTextBox.Text = string.Empty;
            DireccionTextBox.Text = string.Empty;
            TipoUsuarioComboBox.SelectedItem = null;

            usuarios = new Usuarios();
            Refresh();           
        }
        private bool ExisteBase()
        {
            Usuarios User = UsuariosBLL.Buscar((int)Convert.ToInt32(UsuarioIdTextBox.Text));

            return (User != null);
        }
        private bool Validar()
        {
            bool paso = true;

            if (UsuarioIdTextBox.Text == string.Empty)
            {
                MessageBox.Show("UsuarioId Vacio");
                UsuarioIdTextBox.Focus();
                paso = false;
            }
            else if (NombresTextBox.Text == string.Empty)
            {
                MessageBox.Show("Nombres Vacio");
                NombresTextBox.Focus();
                paso = false;
            }
            else if (TelefonoTextBox.Text == string.Empty)
            {
                MessageBox.Show("Telefono Vacio");
                TelefonoTextBox.Focus();
                paso = false;
            }
            else if (CelularTextBox.Text == string.Empty)
            {
                MessageBox.Show("Celular Vacio");
                CelularTextBox.Focus();
                paso = false;
            }
            else if (EmailTextBox.Text == string.Empty)
            {
                MessageBox.Show("Email Vacio");
                EmailTextBox.Focus();
                paso = false;
            }
            else if (SexoComboBox.SelectedItem == null)
            {
                MessageBox.Show("Sexo Vacio");
                SexoComboBox.Focus();
                paso = false;
            }
            else if (CedulaTextBox.Text == string.Empty)
            {
                MessageBox.Show("Cedula Vacia");
                CedulaTextBox.Focus();
                paso = false;
            }
            else if (DireccionTextBox.Text == string.Empty)
            {
                MessageBox.Show("Direccion Vacio");
                DireccionTextBox.Focus();
                paso = false;
            }
            else if (TipoUsuarioComboBox.SelectedItem == null)
            {
                MessageBox.Show("Tipo de Usuario Vacio");
                TipoUsuarioComboBox.Focus();
                paso = false;
            }

            return paso;
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            Usuarios FindUser = UsuariosBLL.Buscar(Convert.ToInt32(UsuarioIdTextBox.Text));

            if(FindUser != null)
            {
                usuarios = FindUser;
                Refresh();
            }
            else
            {
                MessageBox.Show("El usuario que digitó no Existe");
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

            if(UsuarioIdTextBox.Text == "0")
            {
                paso = UsuariosBLL.Guardar(usuarios);
            }
            else
            {
                if (!ExisteBase())
                {
                    MessageBox.Show("El Usuario no existe en la base de datos");
                    return;
                }
                paso = UsuariosBLL.Modificar(usuarios);
            }

            if (paso)
            {
                MessageBox.Show("El Usuario se a Guardado Exitosamente");
                Limpiar();
            }
            else
            {
                MessageBox.Show("Ocurrio un Error al Guardar el Usuario");
            }
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if(UsuariosBLL.Eliminar(Convert.ToInt32(UsuarioIdTextBox.Text)))
            {
                MessageBox.Show("El Usuario se a Eliminado Exitosamente");
                Limpiar();
            }
            else
            {
                MessageBox.Show("El usuario que digitó no existe");
            }
        }
    }
}
