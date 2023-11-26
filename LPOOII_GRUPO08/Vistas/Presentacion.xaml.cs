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

namespace Vistas
{
    /// <summary>
    /// Interaction logic for Presentacion.xaml
    /// </summary>
    public partial class Presentacion : Window
    {
        private string rol;
        public Presentacion(String rol)
        {
            InitializeComponent();
            this.rol = rol;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string appPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

            string soundPath = System.IO.Path.Combine(appPath, "..\\..\\Multimedia\\CancionPresentacion.wav");

            System.Media.SoundPlayer sp = new System.Media.SoundPlayer();
            sp.SoundLocation = soundPath;
            sp.Play();
        }

        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {
            System.Media.SoundPlayer sp = new System.Media.SoundPlayer();
            sp.Stop();
            MenuPrincipal menu = new MenuPrincipal(rol);
            menu.Show();
            this.Close();
        }
    }
}
