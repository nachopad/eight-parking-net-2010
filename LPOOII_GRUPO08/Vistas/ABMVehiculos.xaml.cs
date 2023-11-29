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
    /// Interaction logic for ABMUsuarios.xaml
    /// </summary>
    /// 
    public partial class ABMVehiculos : Window
    {

        public ABMVehiculos()
        {
            InitializeComponent();

        }

        CollectionView Vista;
        ObservableCollection<TipoVehiculo> listVehiculos;
        int index = 0;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ObjectDataProvider odp = (ObjectDataProvider)this.Resources["LIST_VEHICULO"];
            listVehiculos = odp.Data as ObservableCollection<TipoVehiculo>;
            Vista = (CollectionView)CollectionViewSource.GetDefaultView(grid_content.DataContext);
            cargarImagen(index);
        }

        private void btnPrimero_Click(object sender, RoutedEventArgs e)
        {
            Vista.MoveCurrentToFirst();
            index = 0;
            cargarImagen(index);
        }

        private void btnUltimo_Click(object sender, RoutedEventArgs e)
        {
            Vista.MoveCurrentToLast();
            index = listVehiculos.Count - 1;
            cargarImagen(index);
        }

        private void btnAnterior_Click(object sender, RoutedEventArgs e)
        {
            Vista.MoveCurrentToPrevious();
            if (Vista.IsCurrentBeforeFirst)
            {
                Vista.MoveCurrentToLast();
                index = listVehiculos.Count - 1;
            }
            else
            {
                index--;
            }
            cargarImagen(index);
        }

        private void btnSiguiente_Click(object sender, RoutedEventArgs e)
        {
            Vista.MoveCurrentToNext();
            if (Vista.IsCurrentAfterLast)
            {
                Vista.MoveCurrentToFirst();
                index = 0;
            }
            else
            {
                index++;
            }
            cargarImagen(index);
        }

        private void cargarImagen(int index)
        {
            string appPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            string imagesPath = System.IO.Path.Combine(appPath, "..\\..\\Images");
            string newImagePath = System.IO.Path.Combine(imagesPath, listVehiculos[index].Imagen);

            var image = new BitmapImage(new Uri(newImagePath, UriKind.Absolute));
            imgVehiculo.Source = image;
        }


        private void btnNuevo_Click(object sender, RoutedEventArgs e)
        {
            FormularioVehiculo form = new FormularioVehiculo(); 
            this.Hide();
            form.Show();
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("¿Estás seguro de que quieres eliminar este vehiculo?", "Confirmación", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                TrabajarTiposVehiculo.eliminarVehiculo(listVehiculos[index].TVCodigo);
                listVehiculos.RemoveAt(index);
                MessageBox.Show("El vehiculo seleccionado se ha eliminado correctamente.", "Eliminación exitosa", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("¿Estás seguro de que quieres modificar este vehiculo?", "Confirmación", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {

                if (listVehiculos[index].Descripcion != "" && listVehiculos[index].Imagen != "" && listVehiculos[index].Tarifa != 0)
                {
                    TrabajarTiposVehiculo.modificarVehiculo(listVehiculos[index]);
                    MessageBox.Show("El vehiculo seleccionado se ha modificado correctamente.", "Modificación exitosa", MessageBoxButton.OK, MessageBoxImage.Information);
                    cargarImagen(index);
                }
                else
                {
                    MessageBox.Show("Por favor, complete todos los campos antes de realizar la modificación.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Error);


                }
            }
        }

        private void txtNombre_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            // Verificar que solo se ingresen letras
            e.Handled = !ContieneSoloLetras(e.Text);
        }

        private void txtApellido_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            // Verificar que solo se ingresen letras
            e.Handled = !ContieneSoloLetras(e.Text);
        }

        // Función para verificar si una cadena contiene solo letras
        private bool ContieneSoloLetras(string texto)
        {
            foreach (char c in texto)
            {
                if (!char.IsLetter(c))
                {
                    return false;
                }
            }
            return true;
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            MenuPrincipal menuPrincipal = new MenuPrincipal("Administrador");
            menuPrincipal.Show();
            this.Close();
        }

    }
}