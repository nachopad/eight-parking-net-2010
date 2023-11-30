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

namespace Vistas
{
    /// <summary>
    /// Interaction logic for formularioUsuario.xaml
    /// </summary>
    public partial class formularioUsuario : Window
    {
        public formularioUsuario()
        {
            InitializeComponent();
            Loaded += formularioUsuario_Loaded;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void formularioUsuario_Loaded(object sender, RoutedEventArgs e)
        {
            cmbRol.SelectedIndex = 0; 
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            ABMUsuarios abmUsuario = new ABMUsuarios();
            abmUsuario.Show();
            this.Hide();
        }

        private void btnRegistrar_Click(object sender, RoutedEventArgs e)
        {
            Usuario usuario = new Usuario();
            usuario.Nombre = txtNombre.Text;
            usuario.Apellido = txtApellido.Text;
            usuario.UserName = txtUserName.Text;
            usuario.Password = txtPassword.Text;
            ComboBoxItem selectedItem = (ComboBoxItem)cmbRol.SelectedItem;
            usuario.Rol = selectedItem.Content.ToString();

            if (string.IsNullOrWhiteSpace(usuario.Nombre) ||
                string.IsNullOrWhiteSpace(usuario.Apellido) ||
                string.IsNullOrWhiteSpace(usuario.UserName) ||
                string.IsNullOrWhiteSpace(usuario.Password) ||
                string.IsNullOrWhiteSpace(usuario.Rol))
            {
                MessageBox.Show("Por favor, complete todos los campos antes de realizar el registro.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (TrabajarUsuarios.UsuarioExisteEnBaseDeDatos(usuario.UserName))
                {
                    MessageBox.Show("Ya existe un usuario con ese nombre de usuario. Por favor, elige otro.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                MessageBoxResult result = MessageBox.Show("¿Estás seguro de que quieres registrar este usuario?", "Confirmación", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    TrabajarUsuarios.registrarUsuario(usuario);
                    MessageBox.Show("El usuario se ha registrado correctamente.", "Registro exitoso.", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }

        private void txtNombre_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !ContieneSoloLetras(e.Text);
        }

        private void txtApellido_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !ContieneSoloLetras(e.Text);
        }

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

    }
}
