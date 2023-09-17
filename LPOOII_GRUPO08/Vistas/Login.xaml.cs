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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
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


            if (buscarUsu != null && buscarUsu.Password.Equals(textBoxPsw.Text))
            {
                MessageBox.Show("Bienvenido " + buscarUsu.Rol + " " + buscarUsu.Nombre);

            }
            else
            {
                MessageBox.Show("Usuario o Contraseña no son validos");
            }

        }
    }
}
