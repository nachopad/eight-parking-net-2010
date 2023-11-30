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
    /// Interaction logic for AcercaDe.xaml
    /// </summary>
    public partial class AcercaDe : Window
    {
        private string rol;
        public AcercaDe(String rol)
        {
            InitializeComponent();
            this.rol = rol;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Reproductor.Play();
        }

        private void Reproductor_MediaEnded(object sender, RoutedEventArgs e)
        {
            Reproductor.Stop();
            Reproductor.Play();
        }

        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {
            MenuPrincipal menu = new MenuPrincipal(rol);
            menu.Show();
            this.Close();
        }
    }
}
