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
using ClasesBase;

namespace Vistas
{
    /// <summary>
    /// Interaction logic for FormularioVehiculo.xaml
    /// </summary>
    public partial class FormularioVehiculo : Window
    {
        public FormularioVehiculo()
        {
            InitializeComponent();
        }

        private void btnRegistrar_Click(object sender, RoutedEventArgs e)
        {
            TipoVehiculo vehiculo = new TipoVehiculo();
            if (txtDescripcion.Text.Equals("") || txtTarifa.Text.Equals(""))
            {
                MessageBox.Show("Debe ingresar todos los valores", "Datos incompletos", MessageBoxButton.OK, MessageBoxImage.Hand);
            }
            else
            {
                vehiculo.Descripcion = txtDescripcion.Text;
                vehiculo.Tarifa = decimal.Parse(txtTarifa.Text);
                MessageBox.Show("Descripcion del vehiculo: " + vehiculo.Descripcion + " - Tarifa del vehiculo: " + vehiculo.Tarifa, "Datos registrados", MessageBoxButton.OK);
            }
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            MenuPrincipal menuPrincipal = new MenuPrincipal("1");
            menuPrincipal.Show();
            this.Close();
        }
    }
}
