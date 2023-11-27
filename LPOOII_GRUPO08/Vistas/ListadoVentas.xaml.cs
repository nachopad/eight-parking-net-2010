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
    /// Interaction logic for ListadoVentas.xaml
    /// </summary>
    public partial class ListadoVentas : Window
    {
        public ListadoVentas()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            decimal montoTotal;
            // Llame al método TraerTickets para obtener todas las ventas
            TrabajarTicket trabajarTicket = new TrabajarTicket();
            ObservableCollection<Ticket> tickets = trabajarTicket.TraerTicketsAbiertos(out montoTotal);

            // Actualice la lista de ventas
            dataGrid1.ItemsSource = tickets;

            // Actualice la etiqueta con el monto total
            totalAmountTextBlock.Text = string.Format("Monto Total: {0:C}", montoTotal);
        }

        private void btnFiltro_Click(object sender, RoutedEventArgs e)
        {
            // Obtén las fechas seleccionadas
            DateTime? fechaInicioNullable = datePicker1.SelectedDate;
            DateTime? fechaFinNullable = datePicker2.SelectedDate;

            // Verifica si alguna de las fechas es nula
            if (!fechaInicioNullable.HasValue || !fechaFinNullable.HasValue)
            {
                // Muestra un mensaje indicando que ambas fechas deben ser ingresadas
                MessageBox.Show("Por favor, selecciona ambas fechas.", "Error al filtrar por rango de fechas", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Verifica si la fecha de entrada es mayor que la fecha de salida
            if (fechaInicioNullable.Value > fechaFinNullable.Value)
            {
                // Muestra un mensaje indicando que la fecha de entrada debe ser menor o igual a la fecha de salida
                MessageBox.Show("La fecha de entrada debe ser menor o igual a la fecha de salida.", "Error al filtrar por rango de fechas", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Llama al método TraerTicketsPorFechaConTotal para obtener las ventas y el monto total
            TrabajarTicket trabajarTicket = new TrabajarTicket();
            ObservableCollection<Ticket> tickets;
            decimal montoTotal;

            tickets = trabajarTicket.TraerTicketsPorFecha(fechaInicioNullable.Value, fechaFinNullable.Value.AddDays(1), out montoTotal);

            // Actualiza la lista de ventas
            dataGrid1.ItemsSource = tickets;

            // Actualiza la etiqueta con el monto total
            totalAmountTextBlock.Text = string.Format("Monto Total: {0:C}", montoTotal);
        }

        private void btnMostrarTodo_Click(object sender, RoutedEventArgs e)
        {
            decimal montoTotal;
            TrabajarTicket trabajarTicket = new TrabajarTicket();
            ObservableCollection<Ticket> tickets = trabajarTicket.TraerTicketsAbiertos(out montoTotal);

            // Actualice la lista de ventas
            dataGrid1.ItemsSource = tickets;

            // Actualice la etiqueta con el monto total
            totalAmountTextBlock.Text = string.Format("Monto Total: {0:C}", montoTotal);
        }

        private void btnImprimir_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog pdlg = new PrintDialog();
            if (pdlg.ShowDialog() == true)
            {
                pdlg.PrintDocument(((IDocumentPaginatorSource)DocMain).DocumentPaginator, "Imprimir");
            }
        }

        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {
            MenuPrincipal menuPrincipal = new MenuPrincipal("Administrador");
            menuPrincipal.Show();
            this.Close();
        }

    }
}