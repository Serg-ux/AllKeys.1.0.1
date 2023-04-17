using AllKeys.Modelo;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AllKeys
{
    /// <summary>
    /// Lógica de interacción para Carrito.xaml
    /// </summary>
    public partial class Carrito : Page
    {
        public static List<Videojuego> juegos_carrito = new List<Videojuego>();
        public Carrito()
        {
            InitializeComponent();
            dgCarrito.ItemsSource =juegos_carrito;
        }

        private void btnComprar_Click(object sender, RoutedEventArgs e)
        {
            if (juegos_carrito.Count()>0)
            {

                ValidarTarjeta validarTarjeta = new ValidarTarjeta();
                validarTarjeta.ShowDialog();
            }
            else MessageBox.Show("Carrito vacio", "Informacion", MessageBoxButton.OK, MessageBoxImage.Warning);

        }

        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            juegos_carrito = new List<Videojuego>();
            dgCarrito.ItemsSource = juegos_carrito;
        }
    }
}
