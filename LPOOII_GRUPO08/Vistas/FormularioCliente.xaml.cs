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
    /// Interaction logic for FormularioCliente.xaml
    /// </summary>
    public partial class FormularioCliente : Window
    {
        public FormularioCliente()
        {
            InitializeComponent();
            Cliente cliente = new Cliente();
            this.DataContext = cliente; 
        }

        private void btnRegistrar_Click(object sender, RoutedEventArgs e)
        {
            Cliente cliente = new Cliente();

            if (txtApellido.Text.Equals("") || txtDNI.Text.Equals("") || txtNombre.Text.Equals("") || txtTelefono.Text.Equals(""))
            {
                MessageBox.Show("Debe ingresar todos los datos solicitados", "Datos incompletos", MessageBoxButton.OK, MessageBoxImage.Hand);
            }
            else
            {
                cliente.ClienteDNI = txtDNI.Text;
                cliente.Nombre = txtNombre.Text;
                cliente.Apellido = txtApellido.Text;
                cliente.Telefono = txtTelefono.Text;

                // Verificar si el cliente ya existe
                TrabajarCliente trabajarCliente = new TrabajarCliente();
                if (trabajarCliente.ClienteExisteEnBaseDeDatos(cliente.ClienteDNI))
                {
                    MessageBox.Show("Ya existe un cliente con ese DNI.", "Error de registro", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    trabajarCliente.registrarCliente(cliente);
                    MessageBox.Show("Nombre:  " + cliente.Nombre + " - Apellido: " + cliente.Apellido + " - DNI: " + cliente.ClienteDNI + " - Telefono: " + cliente.Telefono, "Datos registrados", MessageBoxButton.OK);
                }
            }
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            Zona ventanaZona = new Zona();
            ventanaZona.Show();
            this.Close();
        }

        private void txtDNI_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtNumericInput_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, e.Text.Length - 1))
            {
                e.Handled = true;
            }
        }
    }
}
