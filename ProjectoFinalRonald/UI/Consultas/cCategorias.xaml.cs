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
    /// Interaction logic for cCategorias.xaml
    /// </summary>
    public partial class cCategorias : Window
    {
        public cCategorias()
        {
            InitializeComponent();

            FiltroComboBox.Items.Add("Todo");
            FiltroComboBox.Items.Add("CategoriaId");
            FiltroComboBox.Items.Add("UsuarioId");
        }

        private void ConsultarButton_Click(object sender, RoutedEventArgs e)
        {
            var Listado = new List<Categorias>();

            if (CriterioTextBox.Text.Trim().Length > 0 || FiltroComboBox.SelectedIndex == 0)
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    case 0://Todo
                        Listado = CategoriasBLL.GetList(s => true);
                        break;
                    case 1://CategoriaId
                        try
                        {
                            int id = Convert.ToInt32(CriterioTextBox.Text);
                            Listado = CategoriasBLL.GetList(c => c.CategoriaId == id);
                        }
                        catch (FormatException)
                        {
                            MessageBox.Show("La CategoriaId que digitó no es valida");
                        }
                        break;
                    case 2://UsuarioId
                        try
                        {
                            int id = Convert.ToInt32(CriterioTextBox.Text);
                            Listado = CategoriasBLL.GetList(c => c.UsuarioId == id);
                        }
                        catch (FormatException)
                        {
                            MessageBox.Show("El UsuarioId que digitó no es Valido");
                        }
                        break;
                }
                ConsultaDataGrid.ItemsSource = null;
                ConsultaDataGrid.ItemsSource = Listado;
            }
        }
    }
}
