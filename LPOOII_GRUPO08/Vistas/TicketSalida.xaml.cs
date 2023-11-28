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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        public void cargar(Ticket ticket)
        {
            txbDireccion.Text = "Alberdi 777";
            txbLocalidad.Text = "S.S De Jujuy";
            txbCuit.Text = "CUIT: " + "30-88888888-9";
            txbIibb.Text = "IIBB: " + "999";
            txbNumeroTicket.Text = "Ticket #" + ticket.TicketNro;
            txbPatente.Text = "Patente: " + ticket.Patente;
            txbTipoVehiculo.Text = "Tipo Vehiculo" + ticket.TvCodigo;
            txbCliente.Text = "Cliente: " + ticket.ClienteDNI;
            txbIngreso.Text = "Ingreso: " + ticket.FechaHoraEnt;
            txbSalida.Text = "Salida: " + ticket.FechaHoraSal;
            txbTarifa.Text = "Tarifa: " + ticket.Tarifa;
            txbTotal.Text = "Total: " + ticket.Total;
            txbDuracion.Text = "Tiempo transcurrido: " + ticket.Duracion;
            txbUsuario.Text = "Usuario: " + "Operador";
        }
    }
}
