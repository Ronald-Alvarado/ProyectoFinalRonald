using ProjectoFinalRonald.BLL;
using ProjectoFinalRonald.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Interaction logic for cSalidas.xaml
    /// </summary>
    public partial class cSalidas : Window
    {
        public cSalidas()
        {
            InitializeComponent();

            FiltroComboBox.Items.Add("Todo");
            FiltroComboBox.Items.Add("SalidaId");
            FiltroComboBox.Items.Add("UsuarioId");
            FiltroComboBox.Items.Add("Fecha");
        }

        private void ConsultarButton_Click(object sender, RoutedEventArgs e)
        {
            var Listado = new List<Salidas>();

            if (CriterioTextBox.Text.Trim().Length > 0 || FiltroComboBox.SelectedIndex == 0 || FiltroComboBox.SelectedIndex == 3)
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    case 0://Todo
                        Listado = SalidasBLL.GetList(s => true);
                        break;
                    case 1://SalidaId
                        try
                        {
                            int id = Convert.ToInt32(CriterioTextBox.Text);
                            Listado = SalidasBLL.GetList(c => c.SalidaId == id);
                        }
                        catch (FormatException)
                        {
                            MessageBox.Show("El Id que digitó no es valido");
                        }
                        break;
                    case 2://UsuarioId
                        try
                        {
                            int id = Convert.ToInt32(CriterioTextBox.Text);
                            Listado = SalidasBLL.GetList(c => c.UsuarioId == id);
                        }
                        catch (FormatException)
                        {
                            MessageBox.Show("El Id que digitó no es valido");
                        }
                        break;
                    case 3://Fecha
                        try
                        {
                            if (DesdeDatePicker.SelectedDate != null && HastaDatePicker.SelectedDate != null)
                            {
                                Listado = SalidasBLL.GetList(c => c.Fecha.Date >= DesdeDatePicker.SelectedDate.Value && c.Fecha.Date <= HastaDatePicker.SelectedDate.Value).ToList();
                            }
                            else
                            {
                                MessageBox.Show("Falta una o ambas Fechas");
                                break;
                            }
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("La fecha que ingreso no es valida");
                        }
                        break;
                }
                ConsultaDataGrid.ItemsSource = null;
                ConsultaDataGrid.ItemsSource = Listado;
            }
        }
    }
}
