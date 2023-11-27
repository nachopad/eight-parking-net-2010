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
            ObservableCollection<Ticket> tickets = trabajarTicket.TraerTickets(out montoTotal);

            // Actualice la lista de ventas
            dataGrid1.ItemsSource = tickets;

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == true)
            {
                // Capturar la ventana actual como una imagen
                RenderTargetBitmap renderTargetBitmap = new RenderTargetBitmap((int)grid_content.ActualWidth, (int)grid_content.ActualHeight, 96, 96, PixelFormats.Pbgra32);
                renderTargetBitmap.Render(grid_content);

                // Codificar la imagen capturada en un formato imprimible
                BitmapEncoder bitmapEncoder = new PngBitmapEncoder();
                bitmapEncoder.Frames.Add(BitmapFrame.Create(renderTargetBitmap));

                // Guardar la imagen en un flujo de memoria
                using (MemoryStream stream = new MemoryStream())
                {
                    bitmapEncoder.Save(stream);
                    stream.Seek(0, SeekOrigin.Begin);

                    // Crear una imagen a partir del flujo de memoria
                    BitmapImage bitmapImage = new BitmapImage();
                    bitmapImage.BeginInit();
                    bitmapImage.StreamSource = stream;
                    bitmapImage.EndInit();

                    // Crear un Image para mostrar la imagen en la ventana antes de imprimir
                    Image image = new Image();
                    image.Source = bitmapImage;

                    // Mostrar la imagen en un nuevo diálogo antes de imprimir
                    Window imageWindow = new Window
                    {
                        Title = "Vista previa de impresión",
                        Content = image,
                        Width = bitmapImage.PixelWidth,
                        Height = bitmapImage.PixelHeight
                    };
                    imageWindow.ShowDialog();

                    // Imprimir la imagen
                    printDialog.PrintVisual(image, "Imprimir contenido de la ventana");
                }
            }
        }


        
    }
}

