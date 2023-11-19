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
    /// Interaction logic for VehiculosPlaya.xaml
    /// </summary>

    public partial class VehiculosPlaya : Window
    {
        private const string disponible = "#FF008000";
        private const string deshabilitado = "#FF808080";
        private const string  ocupado ="#FFFF0000";

        public VehiculosPlaya()
        {
            InitializeComponent();
            Loaded += VehiculosPlaya_Loaded;
        }

       private void VehiculosPlaya_Loaded(object sender, RoutedEventArgs e)
       {
            e7.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(ocupado));
       }

        private void Button_click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = (Button)sender;
            SolidColorBrush backgroundBrush = clickedButton.Background as SolidColorBrush;

            switch (backgroundBrush.Color.ToString())
            {
                case disponible:
                    MessageBox.Show("Sector Disponible, registrar entrada", "Disponible", MessageBoxButton.OK, MessageBoxImage.Information);
                    break;
                case deshabilitado:
                    MessageBox.Show("Sector deshabilitado", "Deshabilitado", MessageBoxButton.OK, MessageBoxImage.Information);
                    break;
                case ocupado:
                    MessageBox.Show("Sector Ocupado, registrar salida", "Ocupado", MessageBoxButton.OK, MessageBoxImage.Information);
                    break;
            }
        }

        private void salir_Click(object sender, RoutedEventArgs e)
        {
            Zona zona = new Zona();
            zona.Show();
            this.Close();
        }
       
    }
}
