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
    /// Interaction logic for Zona.xaml
    /// </summary>
    public partial class Zona : Window
    {
        public Zona()
        {
            InitializeComponent();
        }

        private void mostrarPlaya(object sender, RoutedEventArgs e)
        {
            Button clickedButton = (Button)sender;
            VehiculosPlaya playa;
            if (clickedButton.Content.ToString() == "Zona 1")
            {
                playa = new VehiculosPlaya(1);
            }
            else if (clickedButton.Content.ToString() == "Zona 2")
            {
                playa = new VehiculosPlaya(2);
            }
            else
            {
                playa = new VehiculosPlaya(3);
            }
            playa.Show();
            this.Close();
        }

        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {
            MenuPrincipal menuPrincipal = new MenuPrincipal("Administrador");
            menuPrincipal.Show();
            this.Close();
        }
    }
}
