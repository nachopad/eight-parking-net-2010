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
using Microsoft.Win32;
using ClasesBase;

namespace Vistas
{
    /// <summary>
    /// Interaction logic for FormularioVehiculo.xaml
    /// </summary>
    public partial class FormularioVehiculo : Window
    {

        private string imagePath ="";
        private string fileName = "";

        public FormularioVehiculo()
        {
            InitializeComponent();
        }

        private void btnRegistrar_Click(object sender, RoutedEventArgs e)
        {
            TipoVehiculo vehiculo = new TipoVehiculo();
            if (txtDescripcion.Text.Equals("") || txtTarifa.Text.Equals("") || fileName.Equals(""))
            {
                MessageBox.Show("Debe ingresar todos los valores", "Datos incompletos", MessageBoxButton.OK, MessageBoxImage.Hand);

            }
            else
            {
                vehiculo.Descripcion = txtDescripcion.Text;
                vehiculo.Tarifa = decimal.Parse(txtTarifa.Text);

                // Construye una nueva ruta de archivo para la carpeta de imágenes
                string appPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
                string imagesPath = System.IO.Path.Combine(appPath, "..\\..\\Images");
                string newImagePath = System.IO.Path.Combine(imagesPath, fileName);

                // Copia la imagen a la carpeta de imágenes
                System.IO.File.Copy(imagePath, newImagePath, true);
                vehiculo.Imagen = fileName;

                TrabajarTiposVehiculo.crearTipoVehiculo(vehiculo);
                MessageBox.Show("Descripcion del vehiculo: " + vehiculo.Descripcion + " - Tarifa del vehiculo: " + vehiculo.Tarifa, "Datos registrados", MessageBoxButton.OK);
            }
        }

        private int codVehiculo()
        {

            return 0;
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            ABMVehiculos abmVehiculos = new ABMVehiculos();
            abmVehiculos.Show();
            this.Close();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Imagenes|*.jpg;*.png;*.bmp;*.gif";
            if (openFileDialog.ShowDialog() == true)
            {
                imagePath = openFileDialog.FileName;
                imgPrev.Source = new BitmapImage(new Uri(imagePath));
                // Obtén el nombre del archivo de la ruta de la imagen
                fileName = System.IO.Path.GetFileName(imagePath);
            }
        }
    }
}
