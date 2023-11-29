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
    /// Interaction logic for VehiculosPlaya.xaml
    /// </summary>

    public partial class VehiculosPlaya : Window
    {
        private const string disponible = "#FF008000";
        private const string deshabilitado = "#FF808080";
        private const string ocupado = "#FFFF0000";

        ObservableCollection<Ticket> listaTickets = new ObservableCollection<Ticket>();
        ObservableCollection<Sector> listaSectores = new ObservableCollection<Sector>();

        public VehiculosPlaya(int zonaCodigo)
        {
            InitializeComponent();
            TrabajarSector trabajar = new TrabajarSector();
            TrabajarTicket trabajarTicket = new TrabajarTicket();


            listaSectores = trabajar.TraerTodosLosSectores(zonaCodigo);

            // Coloca tus botones en un array
            Button[] buttons = new Button[] { e1, e2, e3, e4, e5, e6, e7, e8, e9, e10 };

            for (int i = 0; i < listaSectores.Count; i++)
            {
                //Debe buscar en la Base de Datos el ultimo ticket con el sector obtenido
                Ticket ticketObtenido = new Ticket();
                ticketObtenido = trabajarTicket.obtenerUltimoTicketPorSector(listaSectores[i].SectorCodigo);


                if (ticketObtenido != null)
                {
                    //Por defecto si la fecha de salida esta en null en la BD, nos dara cuando traigamos los datos una fecha de 01/01/0001 00:00:00 
                    //Esto nos indicara que el sector sigue estando ocupado
                    if (ticketObtenido.FechaHoraSal.Date != new DateTime(1, 1, 1))
                    {
                        listaTickets.Add(ticketObtenido);
                        buttons[i].Content = listaSectores[i].Identificador;
                        buttons[i].Background = new SolidColorBrush(Colors.Green); // Verde
                    }
                    else
                    {
                        listaTickets.Add(ticketObtenido);
                        buttons[i].Content = listaSectores[i].Identificador;
                        buttons[i].Background = new SolidColorBrush(Colors.Red); // Rojo

                    }
                }
                else if (listaSectores[i].Habilitado == false)
                {
                    buttons[i].Content = listaSectores[i].Identificador;
                    buttons[i].Background = new SolidColorBrush(Colors.Gray); // Gris
                }
                else
                {
                    buttons[i].Content = listaSectores[i].Identificador;
                    buttons[i].Background = new SolidColorBrush(Colors.Green); // Verde
                }


            }


        }


        private void Button_click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = (Button)sender;
            SolidColorBrush backgroundBrush = clickedButton.Background as SolidColorBrush;
            int indice = 0;
            for (int i = 0; i < listaSectores.Count(); i++)
            {
                if (listaSectores[i].Identificador == clickedButton.Content)
                {
                    indice = i;
                }
            }
            MessageBoxResult result;
            switch (backgroundBrush.Color.ToString())
            {
                case disponible:
                    result = MessageBox.Show("Sector Disponible, ¿Desea registrar la entrada?", "Sector Disponible", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        RegistroEntrada registro = new RegistroEntrada(listaSectores[indice]);
                        registro.Show();
                        this.Close();
                    }
                    break;
                case deshabilitado:
                    MessageBox.Show("Sector deshabilitado", "Deshabilitado", MessageBoxButton.OK, MessageBoxImage.Information);
                    break;
                case ocupado:
                    result = MessageBox.Show("Sector Ocupado, ¿Desea registrar la salida?", "Sector Ocupado", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        TrabajarTicket trabajarTicket = new TrabajarTicket();
                        Ticket ticketObtenido = new Ticket();
                        ticketObtenido = trabajarTicket.obtenerUltimoTicketPorSector(listaSectores[indice].SectorCodigo);
                        //Agregar LA VENTANA REGISTRAR SALIDA:

                        RegistroSalida registroSalida = new RegistroSalida(ticketObtenido, listaSectores[indice]);
                        registroSalida.Show();
                        this.Close();
                    }
                    break;
            }
        }

        private void salir_Click(object sender, RoutedEventArgs e)
        {
            Zona zona = new Zona();
            zona.Show();
            this.Close();
        }

        private void e1_MouseEnter(object sender, MouseEventArgs e)
        {
            ToolTip toolTip = new ToolTip();
            int indice = 0;
            Button clickedButton = (Button)sender;
            SolidColorBrush backgroundBrush = clickedButton.Background as SolidColorBrush;
            for (int i = 0; i < listaSectores.Count(); i++)
            {
                if (listaSectores[i].Identificador == clickedButton.Content)
                {
                    indice = i;
                }
            }

            switch (backgroundBrush.Color.ToString())
            {
                case disponible:

                    toolTip.Content = "Sector Disponible: \n" + MensajeDisponible(listaSectores[indice].SectorCodigo);
                    break;
                case deshabilitado:
                    toolTip.Content = "Sector Deshabilitado";
                    break;
                case ocupado:
                    toolTip.Content = "Sector Ocupado: \n" + MensajeOcupado(listaSectores[indice].SectorCodigo);
                    break;
            }

            ToolTipService.SetToolTip(clickedButton, toolTip);
        }
        public string MensajeDisponible(int sectorCod)
        {
            TrabajarTicket trabajarTicket = new TrabajarTicket();
            Ticket ticketObtenido = new Ticket();
            ticketObtenido = trabajarTicket.obtenerUltimoTicketPorSector(sectorCod);
            TimeSpan duracion;

            if (ticketObtenido != null)
            {
                duracion = DateTime.Now - ticketObtenido.FechaHoraSal;
            }
            else
            {
                duracion = DateTime.Now - new DateTime(2023, 10, 26, 12, 00, 00);
            }

            return "El sector lleva libre desde hace: \n" + duracion.Hours + ":" + duracion.Minutes + " hrs.";
        }

        public string MensajeOcupado(int sectorCod)
        {
            TrabajarTicket trabajarTicket = new TrabajarTicket();
            TrabajarTiposVehiculo trabajarVehiculo = new TrabajarTiposVehiculo();



            Ticket ticketObtenido = new Ticket();
            ticketObtenido = trabajarTicket.obtenerUltimoTicketPorSector(sectorCod);


            TipoVehiculo tipoVehiculo = trabajarVehiculo.ObtenerTipoPorCodigo(ticketObtenido.TvCodigo);

            TimeSpan duracion;


            duracion = DateTime.Now - ticketObtenido.FechaHoraEnt;

            double duracionEnDouble = duracion.Hours + (duracion.Minutes / 60.0);

            double totalAPagar = duracionEnDouble * double.Parse(tipoVehiculo.Tarifa.ToString());
            totalAPagar = Math.Round(totalAPagar, 2);

            return "El sector lleva ocupado desde hace: \n" + duracion.Hours + ":" + duracion.Minutes + " hrs. \n" + " Tipo de vehiculo: " + tipoVehiculo.Descripcion + "\n Debe pagar: ARS $ " + totalAPagar;
        }

    }
}
