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
            TrabajarTicket trabajarTicket = new TrabajarTicket();
            ObservableCollection<Ticket> tickets = trabajarTicket.TraerTickets(out montoTotal);
            dataGrid1.ItemsSource = tickets;
            totalAmountTextBlock.Text = string.Format("Monto Total: {0:C}", montoTotal);
        }

        private void btnFiltro_Click(object sender, RoutedEventArgs e)
        {
            DateTime? fechaInicioNullable = datePicker1.SelectedDate;
            DateTime? fechaFinNullable = datePicker2.SelectedDate;

            if (!fechaInicioNullable.HasValue || !fechaFinNullable.HasValue)
            {
                MessageBox.Show("Por favor, selecciona ambas fechas.", "Error al filtrar por rango de fechas", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (fechaInicioNullable.Value > fechaFinNullable.Value)
            {
                MessageBox.Show("La fecha de entrada debe ser menor o igual a la fecha de salida.", "Error al filtrar por rango de fechas", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            TrabajarTicket trabajarTicket = new TrabajarTicket();
            ObservableCollection<Ticket> tickets;
            decimal montoTotal;
            tickets = trabajarTicket.TraerTicketsPorFecha(fechaInicioNullable.Value, fechaFinNullable.Value.AddDays(1), out montoTotal);
            dataGrid1.ItemsSource = tickets;
            totalAmountTextBlock.Text = string.Format("Monto Total: {0:C}", montoTotal);
        }

        private void btnMostrarTodo_Click(object sender, RoutedEventArgs e)
        {
            decimal montoTotal;
            TrabajarTicket trabajarTicket = new TrabajarTicket();
            ObservableCollection<Ticket> tickets = trabajarTicket.TraerTickets(out montoTotal);
            dataGrid1.ItemsSource = tickets;
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
            ListadosReportes list = new ListadosReportes();
            list.Show();
            this.Close();
        }

    }
}