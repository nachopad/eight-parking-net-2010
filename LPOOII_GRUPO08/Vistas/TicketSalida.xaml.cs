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
    /// Interaction logic for TicketSalida.xaml
    /// </summary>
    public partial class TicketSalida : Window
    {
        public TicketSalida()
        {
            InitializeComponent();
        }

        public void cargar(Ticket ticket)
        {
            txbDireccion.Text = "Alberdi 777";
            txbLocalidad.Text = "S.S De Jujuy";
            txbCuit.Text = "CUIT: " + "30-88888888-9";
            txbIibb.Text = "IIBB: " + "999";
            txbNumeroTicket.Text = "TICKET #" + ticket.TicketNro;
            txbPatente.Text = "PATENTE: " + ticket.Patente;
            txbTipoVehiculo.Text = "TIPO VEHICULO: " +TrabajarTiposVehiculo.ObtenerDescripcionPorCodigo((ticket.TvCodigo));
            txbCliente.Text = "CLIENTE: " + ticket.ClienteDNI;
            txbIngreso.Text = "INGRESO: " + ticket.FechaHoraEnt;
            txbSalida.Text = "SALIDA: " + ticket.FechaHoraSal;
            txbTarifa.Text = "TARIFA: " +"$"+ticket.Tarifa;
            txbTotal.Text = "TOTAL: " + "$"+ticket.Total;
            txbUsuario.Text = "Usuario: " + "Operador";
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
