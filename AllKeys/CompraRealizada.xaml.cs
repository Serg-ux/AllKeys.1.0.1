using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AllKeys
{
    /// <summary>
    /// Lógica de interacción para CompraRealizada.xaml
    /// </summary>
    public partial class CompraRealizada : Window
    {
        public CompraRealizada()
        {
            InitializeComponent();
        }

        private void btInicio_Click(object sender, RoutedEventArgs e)
        {
            
            this.Close();
        }

        private void btImprimir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            PrintDialog p = new PrintDialog();
            if (p.ShowDialog() == true)
            {
                CompraPdf j = new CompraPdf();
                //print es el nombre del grid global
                p.PrintVisual(j.Print, "Ticket de compra");
                j.Close();
            }
        }
    }
}
