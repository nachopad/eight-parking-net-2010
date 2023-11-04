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
    public partial class ABMUsuarios : Window
    {

        public ABMUsuarios()
        {
            InitializeComponent();
            
        }

        CollectionView Vista;
        ObservableCollection<Usuario> listUsuario;
        int index = 0;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ObjectDataProvider odp = (ObjectDataProvider)this.Resources["LIST_USER"];
            listUsuario = odp.Data as ObservableCollection<Usuario>;
            Vista = (CollectionView)CollectionViewSource.GetDefaultView(grid_content.DataContext);
        }

        private void btnPrimero_Click(object sender, RoutedEventArgs e)
        {
            Vista.MoveCurrentToFirst();
            index = 0;
        }

        private void btnUltimo_Click(object sender, RoutedEventArgs e)
        {
            Vista.MoveCurrentToLast();
            index = listUsuario.Count - 1;
        }

        private void btnAnterior_Click(object sender, RoutedEventArgs e)
        {
            Vista.MoveCurrentToPrevious();
            if (Vista.IsCurrentBeforeFirst)
            {
                Vista.MoveCurrentToLast();
                index = listUsuario.Count - 1;
            }
            else
            {
                index--;
            }
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
        }

        private void btnNuevo_Click(object sender, RoutedEventArgs e)
        {
            formularioUsuario formularioUsuario = new formularioUsuario();
            this.Hide();
            formularioUsuario.Show();
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("¿Estás seguro de que quieres eliminar este usuario?", "Confirmación", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                TrabajarUsuarios.eliminarUsuario(listUsuario[index].IdUsuario);
                listUsuario.RemoveAt(index);
            }
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("¿Estás seguro de que quieres modificar este usuario?", "Confirmación", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                if (listUsuario[index].Nombre != "" && listUsuario[index].Apellido != "" && listUsuario[index].UserName != "" && listUsuario[index].Password != "" && listUsuario[index].Rol != "")
                {
                    TrabajarUsuarios.modificarUsuario(listUsuario[index]);
                }
                else
                {
                    MessageBox.Show("Debe completar todos los campos para realizar la modificación", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);

                }
            }
        }
        
    }
}
