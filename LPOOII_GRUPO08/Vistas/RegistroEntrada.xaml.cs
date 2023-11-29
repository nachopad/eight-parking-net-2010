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
                    /*
                 Aqui terminamos de asignarle todos los atributos del ticket para registrarlo en la BD;
                 */
                    ticket.ClienteDNI = txtDniCliente.Text;
                    ticket.Patente = txtPatente.Text;
                    TipoVehiculo tipoVehiculoSeleccionado = (TipoVehiculo)cmbTipoVehiculo.SelectedItem;
                    ticket.TvCodigo = tipoVehiculoSeleccionado.TVCodigo;

                    ticket.SectorCodigo = sector.SectorCodigo;

                    //Faltante
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

            // Verifica si hay al menos un vehículo en la lista antes de seleccionar el primero
            if (listVehiculos.Count > 0)
            {
                cmbTipoVehiculo.SelectedItem = listVehiculos[0];
            }
        }

        private void cmbTipoVehiculo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbTipoVehiculo.SelectedItem != null)
            {
                // Accede a la propiedad que quieres mostrar
                TipoVehiculo tipoVehiculoSeleccionado = (TipoVehiculo)cmbTipoVehiculo.SelectedItem;
                txtTarifa.Text = tipoVehiculoSeleccionado.Tarifa.ToString();
                //if (validarCampos() == true)
                //{
                //    calcularTotal();
                //}
            }
            dtpFechaIngreso.IsEnabled = true;

        }

        //private void calcularTotal()
        //{
        //    try
        //    {
        //        //Este codigo debe implementar luego NO OLVIDAR
        //        DateTime fechaEntrada = dtpFechaIngreso.SelectedDate ?? DateTime.Now.Date;

        //        int selectedHour = int.Parse((txtHoraEntrada.Text).ToString());
        //        int selectedMinute = int.Parse((txtMinutosEntrada.Text).ToString());
        //        DateTime fechaCompletaEntrada = fechaEntrada.AddHours(selectedHour).AddMinutes(selectedMinute);


        //        DateTime fechaSalida = dtpFechaSalida.SelectedDate ?? DateTime.Now.Date;

        //        int horaSalidaSeleccionada = int.Parse((txtHoraSalida.Text).ToString());
        //        int minutosSalidaSeleccionada = int.Parse((txtMinutosSalida.Text).ToString());
        //        DateTime fechaCompletaSalida = fechaEntrada.AddHours(horaSalidaSeleccionada).AddMinutes(minutosSalidaSeleccionada);
        //        TimeSpan duracion = fechaCompletaSalida - fechaCompletaEntrada;
        //        double duracionEnDouble = duracion.Hours + (duracion.Minutes / 60.0); ;

        //        double totalAPagar = duracionEnDouble * double.Parse(txtTarifa.Text);

        //        txtTotal.Text = totalAPagar.ToString();

        //        //Asignamos los valores al objeto Ticket
        //        ticket.Duracion = duracionEnDouble;
        //        ticket.FechaHoraEnt = fechaCompletaEntrada;
        //        ticket.FechaHoraSal = fechaCompletaSalida;
        //        ticket.Total = decimal.Parse(totalAPagar.ToString());
        //        ticket.Tarifa = decimal.Parse(txtTarifa.Text);

        //    }
        //    catch (Exception)
        //    {
        //        MessageBox.Show("Hubo un error, vuelva a intentarlo");
        //    }

        //}


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
