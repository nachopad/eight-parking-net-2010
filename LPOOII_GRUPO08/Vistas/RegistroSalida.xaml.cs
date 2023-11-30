
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
    /// Interaction logic for RegistroSalida.xaml
    /// </summary>
    public partial class RegistroSalida : Window
    {
        Ticket ticketGlobal = new Ticket();

        public RegistroSalida(Ticket ticket, Sector sector)
        {
            InitializeComponent();
            TrabajarTiposVehiculo trabajaTipo = new TrabajarTiposVehiculo();
            ticketGlobal = ticket;
            TipoVehiculo tipoVehiculo = trabajaTipo.ObtenerTipoPorCodigo(ticket.TvCodigo);
            txtDniCliente.Text = ticket.ClienteDNI;
            txtPatente.Text = ticket.Patente;
            txtTipoVehiculo.Text = tipoVehiculo.Descripcion;
            txtTarifa.Text = tipoVehiculo.Tarifa.ToString();
            txtFechaIngreso.Text = ticket.FechaHoraEnt.ToString();
            txtFechaSalida.Text = DateTime.Now.ToString();
            txtSector.Text = sector.Descripcion;
            txtTotal.Text = calcularTotal(ticket).ToString();
            ticketGlobal.FechaHoraSal = DateTime.Now;
            ticketGlobal.TicketNro = ticket.TicketNro;
            ticketGlobal.Tarifa = tipoVehiculo.Tarifa;
        }

        public double calcularTotal(Ticket ticketObtenido)
        {
            TimeSpan duracion;
            duracion = DateTime.Now - ticketObtenido.FechaHoraEnt;
            double duracionEnDouble = duracion.Hours + (duracion.Minutes / 60.0);
            double totalAPagar = duracionEnDouble * double.Parse(txtTarifa.Text);
            totalAPagar = Math.Round(totalAPagar, 2);
            ticketGlobal.Duracion = duracionEnDouble;
            ticketGlobal.Total = decimal.Parse(totalAPagar.ToString());
            return totalAPagar;
        }

        private void btnRegistrar_Click(object sender, RoutedEventArgs e)
        {
            TrabajarTicket trabajarTicket = new TrabajarTicket();
            trabajarTicket.registrarTicketSalida(ticketGlobal);
            MessageBox.Show("La salida del vehículo se ha registrado exitosamente.", "Salida registrada", MessageBoxButton.OK, MessageBoxImage.Information);
            TicketSalida ts = new TicketSalida();
            Zona ventanaZona = new Zona();
            ventanaZona.Show();
            ts.cargar(ticketGlobal);
            ts.Show();
            this.Close();
        }

    }
}
