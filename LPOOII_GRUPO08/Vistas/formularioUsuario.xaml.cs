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
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

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
            usuario.Rol = txtRol.Text;

            // Verificar si todos los campos están llenos
            if (string.IsNullOrWhiteSpace(usuario.Nombre) ||
                string.IsNullOrWhiteSpace(usuario.Apellido) ||
                string.IsNullOrWhiteSpace(usuario.UserName) ||
                string.IsNullOrWhiteSpace(usuario.Password) ||
                string.IsNullOrWhiteSpace(usuario.Rol))
            {
                MessageBox.Show("Debe completar todos los campos para realizar el registro", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                // Confirmar el registro
                MessageBoxResult result = MessageBox.Show("¿Estás seguro de que quieres registrar este usuario?", "Confirmación", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    TrabajarUsuarios.registrarUsuario(usuario);
                    MessageBox.Show("El usuario se ha registrado correctamente", "Notificación", MessageBoxButton.OK, MessageBoxImage.Information);

                }
            }

        }
    }
}
