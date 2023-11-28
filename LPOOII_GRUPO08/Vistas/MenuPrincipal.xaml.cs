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

        private string rol;
        public MenuPrincipal(String rol)
        {
            this.rol = rol;
            InitializeComponent();
            if(rol.Equals("1")){
                //Administrador
                canv_Sectore.Visibility = Visibility.Visible;
                canv_Vehiculo.Visibility = Visibility.Visible;
                canv_usuario.Visibility = Visibility.Visible;
                canv_Estacionamiento.Visibility = Visibility.Hidden;
                canv_Cliente.Visibility = Visibility.Hidden;              
                btnAdministrador.Visibility = Visibility.Visible;
                Color color = (Color)ColorConverter.ConvertFromString("#FFCB4E00");
                btnAdministrador.Background = new SolidColorBrush(color);
                btnOperador.IsEnabled = false;
                btnOperador.Foreground = Brushes.Gray;
                
            }else if(rol.Equals("2")){
                //Operador
                canv_Sectore.Visibility = Visibility.Hidden;
                canv_Vehiculo.Visibility = Visibility.Hidden;
                canv_usuario.Visibility = Visibility.Hidden;
                canv_Estacionamiento.Visibility = Visibility.Visible;
                canv_Cliente.Visibility = Visibility.Visible;
                btnAdministrador.IsEnabled = false;
                btnAdministrador.Foreground = Brushes.Gray;
                btnOperador.Visibility = Visibility.Visible;
                Color color = (Color)ColorConverter.ConvertFromString("#FFCB4E00");
                btnOperador.Background = new SolidColorBrush(color);
            }
        }

        private void Button_CerrarSesion(object sender, RoutedEventArgs e)
        {
            // Crear una nueva ventana
            Window nuevaVentana = new Window();
            // Crear una instancia del control de usuario
            loginControl login = new loginControl();
            // Establecer el contenido de la nueva ventana como el control de usuario
            nuevaVentana.Content = login;
            // Mostrar la nueva ventana
            nuevaVentana.Show();
            this.Close();
            
        }

        private void btnOperador_Click(object sender, RoutedEventArgs e)
        {
            canv_Sectore.Visibility = Visibility.Hidden;
            canv_Vehiculo.Visibility = Visibility.Hidden;
            canv_usuario.Visibility = Visibility.Hidden;
            canv_Estacionamiento.Visibility = Visibility.Visible;
            canv_Cliente.Visibility = Visibility.Visible;
        }

        private void btnAdministrador_Click(object sender, RoutedEventArgs e)
        {
            canv_Sectore.Visibility = Visibility.Visible;
            canv_Vehiculo.Visibility = Visibility.Visible;
            canv_usuario.Visibility = Visibility.Visible;
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
            ABMClientes abmClientes = new ABMClientes();
            abmClientes.Show();
            this.Close();
        }

        private void btnGestionarVehiculos_Click(object sender, RoutedEventArgs e)
        {
            FormularioVehiculo formVehiculo = new FormularioVehiculo();
            formVehiculo.Show();
            this.Close();
        }

        private void btnGestionarUsuarios_Click(object sender, RoutedEventArgs e)
        {
            ABMUsuarios abmUsuario = new ABMUsuarios();
            abmUsuario.Show();
            this.Close();
        }

        private void btnNosotros_Click(object sender, RoutedEventArgs e)
        {
            AcercaDe acercaDe = new AcercaDe(rol);
            acercaDe.Show();
            this.Close();
        }

        private void btnPresentacion_Click(object sender, RoutedEventArgs e)
        {
            Presentacion pres = new Presentacion(rol);
            pres.Show();
            this.Close();
        }
    }
}
