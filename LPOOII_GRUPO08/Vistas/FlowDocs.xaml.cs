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
    /// Interaction logic for FlowDocs.xaml
    /// </summary>
    public partial class FlowDocs : Window
    {
        public FlowDocs()
        {
            InitializeComponent();
        }

        private void Imprimir_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();

            if (printDialog.ShowDialog() == true)
            {
                var document = flowDocumentReader.Document as FlowDocument;

                if (document != null)
                {
                    var paginator = ((IDocumentPaginatorSource)document).DocumentPaginator;

                    printDialog.PrintDocument(paginator, "Impresión Documento Dinámico");
                }
            }
        }



    }
}
