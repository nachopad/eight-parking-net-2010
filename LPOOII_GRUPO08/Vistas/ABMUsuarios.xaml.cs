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
        int idUsuario = 0;
        int indice = 0;

        private readonly TrabajarUsuarios trabajarUsuarios = new TrabajarUsuarios();
        public ObservableCollection<Usuario> usuarios { get; set; }

        public ABMUsuarios()
        {
            InitializeComponent();
            usuarios = trabajarUsuarios.TraerUsuario();
            mostrarUsuarios();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void mostrarUsuarios()
        {
            // Enlace de los textbox con la colección
            idUsuario = usuarios[indice].IdUsuario;
            txtUsername.DataContext = usuarios[indice].UserName;
            txtPassword.DataContext = usuarios[indice].Password;
            txtApellido.DataContext = usuarios[indice].Apellido;
            txtNombre.DataContext = usuarios[indice].Nombre;
            txtRol.DataContext = usuarios[indice].Rol;

            //Enlace de los textbox con la colección
            txtUsername.Text = usuarios[indice].UserName;
            txtPassword.Text = usuarios[indice].Password;
            txtApellido.Text = usuarios[indice].Apellido;
            txtNombre.Text = usuarios[indice].Nombre;
            txtRol.Text = usuarios[indice].Rol;
        }

        private void btnPrimero_Click(object sender, RoutedEventArgs e)
        {
            indice = 0;
            mostrarUsuarios();
        }

        private void btnAnterior_Click(object sender, RoutedEventArgs e)
        {
            if (indice != 0)
                indice = indice - 1;
            mostrarUsuarios();
        }

        private void btnSiguiente_Click(object sender, RoutedEventArgs e)
        {
            if (indice < usuarios.Count - 1)
                indice++;
            mostrarUsuarios();
        }

        private void btnUltimo_Click(object sender, RoutedEventArgs e)
        {
            indice = usuarios.Count - 1;
            mostrarUsuarios();
        }

        
    }
}
