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
            dataGrid1.ItemsSource = trabajadorSectores.ObtenerDatosDeLaBaseDeDatos();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == true)
            {
                // Crear una RenderTargetBitmap para capturar la imagen del ListView
                RenderTargetBitmap renderTargetBitmap = new RenderTargetBitmap(
                    (int)dataGrid1.ActualWidth, (int)dataGrid1.ActualHeight, 100, 100, PixelFormats.Pbgra32);

                renderTargetBitmap.Render(dataGrid1);

                // Crear un Image control para mostrar la imagen
                Image img = new Image();
                img.Source = renderTargetBitmap;

                // Imprimir la imagen del ListView
                printDialog.PrintVisual(img, "Imprimir contenido del ListView");
            }
        }

      
    }
}

