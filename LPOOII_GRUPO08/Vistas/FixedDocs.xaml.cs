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
    /// Interaction logic for FixedDocs.xaml
    /// </summary>
    public partial class FixedDocs : Window
    {
        public FixedDocs()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txbNombrePlayaEstacionamiento.Text = "PLAYA DE ESTACIONAMIENTO GRUPO 08";
            txbDireccion.Text = "DOMICILIO: " + "Alberdi 777  S.S De Jujuy";
            txbCuit.Text = "CUIT: " + "30-88888888-9";
            txbIibb.Text = "IIBB: " + "999";
            txbNumeroTicket.Text = "TICKET #" + "1111";
            txbPatente.Text = "PATENTE: " + "AB235A";
            txbTipoVehiculo.Text = "TIPO VEHICULO: " + "Auto";
            txbCliente.Text = "CLIENTE: " + "Juan Perez";
            txbIngreso.Text = "HORA DE INGRESO: " + "10:40";
            txbTarifa.Text = "TARIFA: " + "500";
            txbUsuario.Text = "USUARIO: " + "Operador";
        }
    }
}
