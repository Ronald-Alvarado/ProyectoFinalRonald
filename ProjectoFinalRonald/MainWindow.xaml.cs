using ProjectoFinalRonald.UI.Consultas;
using ProjectoFinalRonald.UI.Registros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProjectoFinalRonald
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        //-----------------------------Registros-----------------------//

        private void RegistrarUsuario_Click(object sender, RoutedEventArgs e)
        {
            rUsuarios rusuario = new rUsuarios();
            rusuario.Show();
        }

        private void RegistrarCategoria_Click(object sender, RoutedEventArgs e)
        {
            rCategorias rcategorias = new rCategorias();
            rcategorias.Show();
        }

        private void RegistrarProductos_Click(object sender, RoutedEventArgs e)
        {
            rProductos rproductos = new rProductos();
            rproductos.Show();
        }

        private void RegistrarSalidas_Click(object sender, RoutedEventArgs e)
        {
            rSalidas rsalidas = new rSalidas();
            rsalidas.Show();
        }

        //----------------------Consultas-------------------------------//

        private void ConsultarUsuario_Click(object sender, RoutedEventArgs e)
        {
            cUsuarios cusuarios = new cUsuarios();
            cusuarios.Show();
        }

        private void ConsultarCategoria_Click(object sender, RoutedEventArgs e)
        {
            cCategorias ccategorias = new cCategorias();
            ccategorias.Show();
        }

        private void ConsultarProductos_Click(object sender, RoutedEventArgs e)
        {
            cProductos cproductos = new cProductos();
            cproductos.Show();
        }

        private void ConsultarSalidas_Click(object sender, RoutedEventArgs e)
        {
            cSalidas csalidas = new cSalidas();
            csalidas.Show();
        }
    }
}
