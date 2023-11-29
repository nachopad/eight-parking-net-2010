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

namespace Vistas
{
    /// <summary>
    /// Interaction logic for ListadosReportes.xaml
    /// </summary>
    public partial class ListadosReportes : Window
    {
        public ListadosReportes()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            ListadoDeSectores ventanaSectores = new ListadoDeSectores(); // Reemplaza 'ListadoDeSectores' con el nombre de tu ventana
            ventanaSectores.Show();
            this.Close();
        }
        private void button2_Click(object sender, RoutedEventArgs e)
        {
            MenuPrincipal ventanaMenu = new MenuPrincipal("Operador"); // Reemplaza 'MenuPrincipal' con el nombre de tu ventana
            ventanaMenu.Show();
            this.Close();
        }
        private void button3_Click(object sender, RoutedEventArgs e)
        {
            ListadoVentas ventanaVentas = new ListadoVentas(); // Reemplaza 'ListadoVentas' con el nombre de tu ventana
            ventanaVentas.Show();
            this.Close();
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            ListadoDeUsuarios ventanaUsuarios = new ListadoDeUsuarios(); // Reemplaza 'ListadoDeUsuarios' con el nombre de tu ventana
            ventanaUsuarios.Show();
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }


    }
}
