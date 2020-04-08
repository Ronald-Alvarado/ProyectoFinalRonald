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
    /// Interaction logic for cProductos.xaml
    /// </summary>
    public partial class cProductos : Window
    {
        public cProductos()
        {
            InitializeComponent();

            FiltroComboBox.Items.Add("Todo");
            FiltroComboBox.Items.Add("ProductoId");
            FiltroComboBox.Items.Add("CategoriaId");
        }

        private void ConsultarButton_Click(object sender, RoutedEventArgs e)
        {
            var Listado = new List<Productos>();

            if (CriterioTextBox.Text.Trim().Length > 0 || FiltroComboBox.SelectedIndex == 0)
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    case 0://Todo
                        Listado = ProductosBLL.GetList(s => true);
                        break;
                    case 1://ProductoId
                        try
                        {
                            int id = Convert.ToInt32(CriterioTextBox.Text);
                            Listado = ProductosBLL.GetList(c => c.ProductoId == id);
                        }
                        catch (FormatException)
                        {
                            MessageBox.Show("El Id que Digitó no es valido");
                        }
                        break;
                    case 2://CategoriaId
                        try
                        {
                            int id = Convert.ToInt32(CriterioTextBox.Text);
                            Listado = ProductosBLL.GetList(c => c.CategoriaId == id);
                        }
                        catch (FormatException)
                        {
                            MessageBox.Show("El Id que digitó no es valido");
                        }
                        break;
                }
                ConsultaDataGrid.ItemsSource = null;
                ConsultaDataGrid.ItemsSource = Listado;
            }
        }
    }
}
