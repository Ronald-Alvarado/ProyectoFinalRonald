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

namespace ProjectoFinalRonald.UI.Consultas
{
    /// <summary>
    /// Interaction logic for cUsuarios.xaml
    /// </summary>
    public partial class cUsuarios : Window
    {
        public cUsuarios()
        {
            InitializeComponent();

            FiltroComboBox.Items.Add("Todo");
            FiltroComboBox.Items.Add("UsuarioId");
            FiltroComboBox.Items.Add("Sexo");
            FiltroComboBox.Items.Add("TipoUsuario");
        }

        private void ConsultarButton_Click(object sender, RoutedEventArgs e)
        {
            var Listado = new List<Usuarios>();

            if (CriterioTextBox.Text.Trim().Length > 0 || FiltroComboBox.SelectedIndex == 0)
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    case 0://Todo
                        Listado = UsuariosBLL.GetList(s => true);
                        break;
                    case 1://UsuarioId
                        try
                        {
                            int id = Convert.ToInt32(CriterioTextBox.Text);
                            Listado = UsuariosBLL.GetList(c => c.UsuarioId == id);
                        }
                        catch (FormatException)
                        {
                            MessageBox.Show("El Id que digitó no es Valido");
                        }
                        break;
                    case 2://Sexo
                        try
                        {
                            string st = CriterioTextBox.Text;
                            if (st == "Masculino" || st == "Femenino")
                            {
                                Listado = UsuariosBLL.GetList(c => c.Sexo == st);
                            }
                            else
                            {
                                MessageBox.Show("El sexo debe ser -Masculino- o -Femenino-");
                            }
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("El Sexo que digitó no es Valido");
                        }
                        break;
                    case 3://TipoUsuario
                        try
                        {
                            string st = CriterioTextBox.Text;
                            if (st == "Empleado" || st == "Administrador")
                            {
                                Listado = UsuariosBLL.GetList(c => c.TipoUsuario == st);
                            }
                            else
                            {
                                MessageBox.Show("El Tipo de Usuario debe ser Empleado o Administrador");
                            }
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("El Tipo de Usuario que digitó no es Valido");
                        }
                        break;
                }
                ConsultaDataGrid.ItemsSource = null;
                ConsultaDataGrid.ItemsSource = Listado;
            }
        }
    }
}
