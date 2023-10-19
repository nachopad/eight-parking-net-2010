﻿using System;
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
                MessageBox.Show("Nombre:  " + cliente.Nombre + " - Apellido: " + cliente.Apellido + " - DNI: " + cliente.ClienteDNI + " - Telefono: " + cliente.Telefono, "Datos registrados", MessageBoxButton.OK);
            }
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            MenuPrincipal menuPrincipal = new MenuPrincipal("2");
            menuPrincipal.Show();
            this.Close();
        }

        private void txtDNI_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
