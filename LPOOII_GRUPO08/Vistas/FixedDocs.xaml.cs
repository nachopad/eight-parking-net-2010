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
            TrabajarTicket tt = new TrabajarTicket();
            Ticket ticket = new Ticket();
            ticket = tt.obtenerUltimoTicket();
            txbNombrePlayaEstacionamiento.Text = "PLAYA DE ESTACIONAMIENTO GRUPO 08";
            txbDireccion.Text = "DOMICILIO: " + "Alberdi 777  S.S De Jujuy";
            txbCuit.Text = "CUIT: " + "30-88888888-9";
            txbIibb.Text = "IIBB: " + "999";
            txbNumeroTicket.Text = "TICKET #" + ticket.TicketNro;
            txbPatente.Text = "PATENTE: " + ticket.Patente;
            txbTipoVehiculo.Text = "TIPO VEHICULO: " + ticket.TvCodigo;
            txbCliente.Text = "CLIENTE: " + ticket.ClienteDNI;
            txbIngreso.Text = "HORA DE INGRESO: " + ticket.FechaHoraEnt;
            txbTarifa.Text = "TARIFA: " + ticket.Tarifa;
            txbUsuario.Text = "USUARIO: " + "Operador";
        }
    }
}
