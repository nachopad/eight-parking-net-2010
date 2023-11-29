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
using System.Windows.Markup;
using System.IO;
using ClasesBase;
using System.Collections.ObjectModel;
using Vistas.Properties;
using System.ComponentModel;

namespace Vistas
{
    /// <summary>
    /// Interaction logic for ListadoDeSectores.xaml
    /// </summary>
    public partial class ListadoDeSectores : Window
    {
        private ClasesBase.TrabajarSector trabajadorSectores = new ClasesBase.TrabajarSector();
        

        public ListadoDeSectores()
        {
            InitializeComponent();
            // Obtener datos de la base de datos y asignarlos al ListView
            // dataGrid1.ItemsSource = trabajadorSectores.ObtenerDatosDeLaBaseDeDatos();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            decimal montoTotal;
            // Llame al método TraerTickets para obtener todas las ventas
            TrabajarTicket trabajarTicket = new TrabajarTicket();
            ObservableCollection<Ticket> tickets = trabajarTicket.TraerTicketsAbiertos(out montoTotal);

            // Actualice la lista de ventas
            dataGrid1.ItemsSource = tickets;

        }

        private void button1_Click(object sender, RoutedEventArgs e)
       {
            PrintDialog printDialog = new PrintDialog();

            if (printDialog.ShowDialog() == true)
            {
                var document = flowDocumentReader.Document as FlowDocument;

                if (document != null)
                {
                    var paginator = ((IDocumentPaginatorSource)document).DocumentPaginator;

                    printDialog.PrintDocument(paginator, "Impresión Documento Dinámico");
                }
            }
        }
        

  

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            ListadosReportes ventanaZona = new ListadosReportes();

            ventanaZona.Show();

            this.Close();
        }

        
    }
}

