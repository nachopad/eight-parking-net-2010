﻿using System;
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
    /// Interaction logic for MenuPrincipal.xaml
    /// </summary>
    public partial class MenuPrincipal : Window
    {
        public MenuPrincipal()
        {
            InitializeComponent();
            canv_Sectore.Visibility = Visibility.Visible;
            canv_Vehiculo.Visibility = Visibility.Visible;
            canv_Estacionamiento.Visibility = Visibility.Hidden;
            canv_Cliente.Visibility = Visibility.Hidden;
        }

        private void Button_CerrarSesion(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnOperador_Click(object sender, RoutedEventArgs e)
        {
            canv_Sectore.Visibility = Visibility.Hidden;
            canv_Vehiculo.Visibility = Visibility.Hidden;
            canv_Estacionamiento.Visibility = Visibility.Visible;
            canv_Cliente.Visibility = Visibility.Visible;
        }

        private void btnAdministrador_Click(object sender, RoutedEventArgs e)
        {
            canv_Sectore.Visibility = Visibility.Visible;
            canv_Vehiculo.Visibility = Visibility.Visible;
            canv_Estacionamiento.Visibility = Visibility.Hidden;
            canv_Cliente.Visibility = Visibility.Hidden;
        }
    }
}