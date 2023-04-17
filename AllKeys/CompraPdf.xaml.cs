using AllKeys.Modelo;
using System;
using System.Collections.Generic;
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
    /// Lógica de interacción para CompraPdf.xaml
    /// </summary>
    public partial class CompraPdf : Window
    {
        public CompraPdf()
        {
            InitializeComponent();
            dgDatos.ItemsSource = Carrito.juegos_carrito;
            double total;
            total= Carrito.juegos_carrito.Sum(v => v.Precio);
            tb_total.Text=total.ToString();
        }
    }
}
