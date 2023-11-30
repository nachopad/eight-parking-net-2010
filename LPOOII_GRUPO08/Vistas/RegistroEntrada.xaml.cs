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
using System.Collections.ObjectModel;

namespace Vistas
{
    /// <summary>
    /// Interaction logic for RegistroEntrada.xaml
    /// </summary>
    public partial class RegistroEntrada : Window
    {
        Sector sector = new Sector();

        public RegistroEntrada(Sector s)
        {
            InitializeComponent();
            txtSector.Text = s.Identificador;
            sector = s;
            DateTime fechaDeHoy = DateTime.Now;
            dtpFechaIngreso.SelectedDate = fechaDeHoy.Date;
            txtHoraEntrada.Text = fechaDeHoy.Hour.ToString();
            txtMinutosEntrada.Text = fechaDeHoy.Minute.ToString();
        }

        Ticket ticket = new Ticket();

        private void btnRegistrar_Click(object sender, RoutedEventArgs e)
        {
            TrabajarCliente trabajarCliente = new TrabajarCliente();
            TrabajarTicket trabajarTicket = new TrabajarTicket();

            if (txtDniCliente.Text != "" && txtPatente.Text != "" && txtTarifa.Text != "")
            {
                Cliente buscado = trabajarCliente.ObtenerClientePorDni(txtDniCliente.Text);
                if (buscado.ClienteDNI != null)
                {
                    ticket.ClienteDNI = txtDniCliente.Text;
                    ticket.Patente = txtPatente.Text;
                    TipoVehiculo tipoVehiculoSeleccionado = (TipoVehiculo)cmbTipoVehiculo.SelectedItem;
                    ticket.TvCodigo = tipoVehiculoSeleccionado.TVCodigo;
                    ticket.SectorCodigo = sector.SectorCodigo;
                    DateTime fechaEntrada = dtpFechaIngreso.SelectedDate ?? DateTime.Now.Date;
                    int selectedHour = int.Parse((txtHoraEntrada.Text).ToString());
                    int selectedMinute = int.Parse((txtMinutosEntrada.Text).ToString());
                    DateTime fechaCompletaEntrada = fechaEntrada.AddHours(selectedHour).AddMinutes(selectedMinute);
                    ticket.FechaHoraEnt = fechaCompletaEntrada;
                    ticket.Tarifa = decimal.Parse(txtTarifa.Text);
                    trabajarTicket.registrarTicket(ticket);
                    MessageBox.Show("La entrada del vehículo se ha registrado exitosamente.","Entrada registrada", MessageBoxButton.OK, MessageBoxImage.Information);
                    FixedDocs vistaTicket = new FixedDocs();
                    vistaTicket.Show();
                }
                else
                {
                    MessageBox.Show("El Cliente con DNI N° " + txtDniCliente.Text + " no está registrado en el sistema. Por favor, verifique la información ingresada o registre el cliente.","Cliente no registrado", MessageBoxButton.OK, MessageBoxImage.Error);
                }

            }
            else
            {
                MessageBox.Show("Por favor, complete todos los campos requeridos y verifique que el DNI del cliente esté registrado en el sistema.", "Campos incompletos o DNI no registrado", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        CollectionView Vista;
        ObservableCollection<TipoVehiculo> listVehiculos;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtTarifa.IsEnabled = false;
            txtSector.IsEnabled = false;
            ObjectDataProvider odp = (ObjectDataProvider)this.Resources["LIST_VEHICULOS"];
            listVehiculos = odp.Data as ObservableCollection<TipoVehiculo>;
            Vista = (CollectionView)CollectionViewSource.GetDefaultView(grid_content.DataContext);

            if (listVehiculos.Count > 0)
            {
                cmbTipoVehiculo.SelectedItem = listVehiculos[0];
            }
        }

        private void cmbTipoVehiculo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbTipoVehiculo.SelectedItem != null)
            {
                TipoVehiculo tipoVehiculoSeleccionado = (TipoVehiculo)cmbTipoVehiculo.SelectedItem;
                txtTarifa.Text = tipoVehiculoSeleccionado.Tarifa.ToString();
            }
            dtpFechaIngreso.IsEnabled = true;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            FormularioCliente formulario = new FormularioCliente();
            formulario.Show();
            this.Close();
        }

        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {
            Zona ventanaZona = new Zona();
            ventanaZona.Show();
            this.Close();
        }

    }
}
