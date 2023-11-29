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
    /// Interaction logic for ListadoDeUsuarios.xaml
    /// </summary>
    public partial class ListadoDeUsuarios : Window
    {
        private TrabajarUsuarios _trabajarUsuarios = new TrabajarUsuarios();
        public ListadoDeUsuarios()
        {
            InitializeComponent();
            CargarDatos();
        }

        private void CargarDatos()
        {
            var listaDeUsuarios = _trabajarUsuarios.TraerUsuario();
            dataGrid1.ItemsSource = listaDeUsuarios.OrderBy(u => u.UserName);//Ordena la grilla de forma ascendente UserName
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            string filtro = textBox1.Text;

            var listaCompleta = _trabajarUsuarios.TraerUsuario();

            var listaFiltrada = listaCompleta.Where(u => u.UserName.Contains(filtro)).ToList();

            dataGrid1.ItemsSource = listaFiltrada;
        }


        private void dataGrid1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void btnVistaPrevia_Click(object sender, RoutedEventArgs e)
        {
            FlowDocs vistaPrevia = new FlowDocs();
            vistaPrevia.Show();
        }

        private void btn_Volver_Click(object sender, RoutedEventArgs e)
        {
            ABMUsuarios abmUsuario = new ABMUsuarios();
            abmUsuario.Show();
            this.Close();
        }


    }
}
