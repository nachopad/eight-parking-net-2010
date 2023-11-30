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
            ListadoDeSectores ventanaSectores = new ListadoDeSectores();
            ventanaSectores.Show();
            this.Close();
        }
        private void button2_Click(object sender, RoutedEventArgs e)
        {
            MenuPrincipal ventanaMenu = new MenuPrincipal("Operador");
            ventanaMenu.Show();
            this.Close();
        }
        private void button3_Click(object sender, RoutedEventArgs e)
        {
            ListadoVentas ventanaVentas = new ListadoVentas();
            ventanaVentas.Show();
            this.Close();
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            ListadoDeUsuarios ventanaUsuarios = new ListadoDeUsuarios();
            ventanaUsuarios.Show();
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

    }
}
