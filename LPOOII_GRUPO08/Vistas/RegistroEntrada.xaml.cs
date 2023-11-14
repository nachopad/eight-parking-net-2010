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
        public RegistroEntrada()
        {
            InitializeComponent();
        }

        Ticket ticket = new Ticket();

        private void btnRegistrar_Click(object sender, RoutedEventArgs e)
        {
            TrabajarCliente trabajarCliente = new TrabajarCliente();
            TrabajarTicket trabajarTicket = new TrabajarTicket();

            if (cmbSector.SelectedItem != null && txtTotal.Text != "" && txtDniCliente.Text != "" && txtPatente.Text != "")
            {
                Cliente buscado = trabajarCliente.ObtenerClientePorDni(txtDniCliente.Text);
                if (buscado.ClienteDNI != null)
                {
                    /*
                 Aqui terminamos de asignarle todos los atributos del ticket para registrarlo en la BD;
                 */
                    MessageBox.Show("Porque entro aqui");
                    ticket.ClienteDNI = txtDniCliente.Text;
                    ticket.Patente = txtPatente.Text;
                    TipoVehiculo tipoVehiculoSeleccionado = (TipoVehiculo)cmbTipoVehiculo.SelectedItem;
                    ticket.TvCodigo = tipoVehiculoSeleccionado.TVCodigo;
                    Sector sector = (Sector)cmbSector.SelectedItem;
                    ticket.SectorCodigo = sector.SectorCodigo;
                    trabajarTicket.registrarTicket(ticket);
                }
                else
                {
                    MessageBox.Show("El cliente con dni: " + txtDniCliente.Text + " no esta registrado");
                }

            }
            else
            {
                MessageBox.Show("Complete todos los campos, verifique que el DNI del cliente ingresado este registrado");
            }

        }

        CollectionView Vista;
        ObservableCollection<TipoVehiculo> listVehiculos;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtTarifa.IsEnabled = false;
            txtTotal.IsEnabled = false;
            ObjectDataProvider odp = (ObjectDataProvider)this.Resources["LIST_VEHICULOS"];
            listVehiculos = odp.Data as ObservableCollection<TipoVehiculo>;
            Vista = (CollectionView)CollectionViewSource.GetDefaultView(grid_content.DataContext);

        }

        private void cmbTipoVehiculo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbTipoVehiculo.SelectedItem != null)
            {
                // Accede a la propiedad que quieres mostrar
                TipoVehiculo tipoVehiculoSeleccionado = (TipoVehiculo)cmbTipoVehiculo.SelectedItem;
                txtTarifa.Text = tipoVehiculoSeleccionado.Tarifa.ToString();
                if (validarCampos() == true)
                {
                    calcularTotal();
                }
            }
            dtpFechaIngreso.IsEnabled = true;

        }

        private void calcularTotal()
        {
            try
            {
                //Este codigo debe implementar luego NO OLVIDAR
                DateTime fechaEntrada = dtpFechaIngreso.SelectedDate ?? DateTime.Now.Date;

                int selectedHour = int.Parse((txtHoraEntrada.Text).ToString());
                int selectedMinute = int.Parse((txtMinutosEntrada.Text).ToString());
                DateTime fechaCompletaEntrada = fechaEntrada.AddHours(selectedHour).AddMinutes(selectedMinute);


                DateTime fechaSalida = dtpFechaSalida.SelectedDate ?? DateTime.Now.Date;

                int horaSalidaSeleccionada = int.Parse((txtHoraSalida.Text).ToString());
                int minutosSalidaSeleccionada = int.Parse((txtMinutosSalida.Text).ToString());
                DateTime fechaCompletaSalida = fechaEntrada.AddHours(horaSalidaSeleccionada).AddMinutes(minutosSalidaSeleccionada);
                TimeSpan duracion = fechaCompletaSalida - fechaCompletaEntrada;
                double duracionEnDouble = duracion.Hours + (duracion.Minutes / 60.0); ;

                double totalAPagar = duracionEnDouble * double.Parse(txtTarifa.Text);

                txtTotal.Text = totalAPagar.ToString();

                //Asignamos los valores al objeto Ticket
                ticket.Duracion = duracionEnDouble;
                ticket.FechaHoraEnt = fechaCompletaEntrada;
                ticket.FechaHoraSal = fechaCompletaSalida;
                ticket.Total = decimal.Parse(totalAPagar.ToString());
                ticket.Tarifa = decimal.Parse(txtTarifa.Text);

            }
            catch (Exception)
            {
                MessageBox.Show("Hubo un error, vuelva a intentarlo");
            }

        }

        private bool validarCampos()
        {

            // Comprueba si las fechas están seleccionadas
            if (dtpFechaIngreso.SelectedDate == null || dtpFechaSalida.SelectedDate == null || cmbTipoVehiculo.SelectedItem == null)
            {
                txtTotal.Text = "";
                return false;
            }

            // Comprueba si las horas y los minutos están ingresados
            if (string.IsNullOrEmpty(txtHoraEntrada.Text) || string.IsNullOrEmpty(txtMinutosEntrada.Text) ||
                string.IsNullOrEmpty(txtHoraSalida.Text) || string.IsNullOrEmpty(txtMinutosSalida.Text))
            {
                txtTotal.Text = "";
                return false;
            }

            return true;
        }

        private void dtpFechaIngreso_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (validarCampos() == true)
            {
                calcularTotal();
            }
        }

        private void txtHoraEntrada_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (validarCampos() == true)
            {
                calcularTotal();
            }
        }

        private void txtMinutosEntrada_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (validarCampos() == true)
            {
                calcularTotal();
            }
        }

        private void dtpFechaSalida_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (validarCampos() == true)
            {
                calcularTotal();
            }
        }

        private void txtHoraSalida_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (validarCampos() == true)
            {
                calcularTotal();
            }
        }

        private void txtMinutosSalida_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (validarCampos() == true)
            {
                calcularTotal();
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            FormularioCliente formulario = new FormularioCliente();
            formulario.Show();
        }

    }
}
