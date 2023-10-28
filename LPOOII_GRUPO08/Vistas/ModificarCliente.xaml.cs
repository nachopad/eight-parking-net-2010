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
    /// Interaction logic for ModificarCliente.xaml
    /// </summary>
    public partial class ModificarCliente : Window
    {
        public ModificarCliente()
        {
            InitializeComponent();
            Cliente cliente = new Cliente();
            this.DataContext = cliente;
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            MenuPrincipal menuPrincipal = new MenuPrincipal("2");
            menuPrincipal.Show();
            this.Close();
        }

        private void txtDNI_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Crear una instancia de TrabajarClientes
            TrabajarCliente trabajador = new TrabajarCliente();

            // Obtener el cliente con el DNI ingresado
            Cliente cliente = trabajador.ObtenerClientePorDni(txtDNI.Text);

            // Actualizar los TextBox con los datos del cliente
            txtApellido.Text = cliente.Apellido;
            txtNombre.Text = cliente.Nombre;
            txtTelefono.Text = cliente.Telefono;
        }


    }
}
