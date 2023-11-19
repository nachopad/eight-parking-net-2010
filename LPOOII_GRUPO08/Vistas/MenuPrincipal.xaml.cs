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
    /// Interaction logic for MenuPrincipal.xaml
    /// </summary>
    public partial class MenuPrincipal : Window
    {
        public MenuPrincipal()
        { 
        } 
        public MenuPrincipal(String rol)
        {
            InitializeComponent();
            if(rol.Equals("1")){
                canv_Sectore.Visibility = Visibility.Visible;
                canv_Vehiculo.Visibility = Visibility.Visible;
                canv_Estacionamiento.Visibility = Visibility.Hidden;
                canv_Cliente.Visibility = Visibility.Hidden;
                btnAdministrador.Visibility = Visibility.Visible;
                btnOperador.Visibility = Visibility.Hidden;
            }else if(rol.Equals("2")){
                canv_Sectore.Visibility = Visibility.Hidden;
                canv_Vehiculo.Visibility = Visibility.Hidden;
                canv_Estacionamiento.Visibility = Visibility.Visible;
                canv_Cliente.Visibility = Visibility.Visible;
                btnAdministrador.Visibility = Visibility.Hidden;
                btnOperador.Visibility = Visibility.Visible;
            }
        }

        private void Button_CerrarSesion(object sender, RoutedEventArgs e)
        {
            Login ventanaLogin = new Login();
            ventanaLogin.Show();
            this.Close();
        }

        private void btnOperador_Click(object sender, RoutedEventArgs e)
        {
            canv_Sectore.Visibility = Visibility.Hidden;
            canv_Vehiculo.Visibility = Visibility.Hidden;
            canv_Estacionamiento.Visibility = Visibility.Visible;
            canv_Cliente.Visibility = Visibility.Visible;
        }

        private void btnAdministrador_Click(object sender, RoutedEventArgs e)
        {
            canv_Sectore.Visibility = Visibility.Visible;
            canv_Vehiculo.Visibility = Visibility.Visible;
            canv_Estacionamiento.Visibility = Visibility.Hidden;
            canv_Cliente.Visibility = Visibility.Hidden;
        }

        private void btnGestionarSectores_Click(object sender, RoutedEventArgs e)
        {
            Zona zonasDisponibles = new Zona();
            zonasDisponibles.Show();
            this.Close();
        }

        private void btnGestionarClientes_Click(object sender, RoutedEventArgs e)
        {
            FormularioCliente formCliente = new FormularioCliente();
            formCliente.Show();
            this.Close();
        }

        private void btnGestionarVehiculos_Click(object sender, RoutedEventArgs e)
        {
            FormularioVehiculo formVehiculo = new FormularioVehiculo();
            formVehiculo.Show();
            this.Close();
        }
    }
}
