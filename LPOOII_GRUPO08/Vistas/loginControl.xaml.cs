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
using System.Windows.Navigation;
using System.Windows.Shapes;
using ClasesBase;

namespace Vistas
{
    /// <summary>
    /// Interaction logic for loginControl.xaml
    /// </summary>
    public partial class loginControl : UserControl
    {

       

        public loginControl()
        {
            InitializeComponent();
        }

        private void buttonAceptar_Click(object sender, RoutedEventArgs e)
        {
            Usuario administrador = new Usuario("administrador", "123", "admin", "admin", "1");
            Usuario operador = new Usuario("operador", "123", "oper", "oper", "2");
            List<Usuario> listUsers = new List<Usuario>();
            listUsers.Add(administrador);
            listUsers.Add(operador);

            Usuario buscarUsu = listUsers.Find(p => p.UserName.Equals(textBoxUser.Text));

            if (buscarUsu != null && buscarUsu.Password.Equals(textBoxPsw.Password))
            {
                MessageBox.Show("Bienvenido al Sistema " + buscarUsu.Nombre, "Acceso concedido", MessageBoxButton.OK);
                MenuPrincipal menuPrincipal = new MenuPrincipal(buscarUsu.Rol);
                menuPrincipal.Show();
                var parentWindow = Window.GetWindow(this);
                parentWindow.Close();
            }
            else
            {
                MessageBox.Show("El usuario y/o contraseña no son válidos. Vuelve a intentarlo.", "Error al iniciar sesión", MessageBoxButton.OK, MessageBoxImage.Hand);
            }

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }


    }
}
