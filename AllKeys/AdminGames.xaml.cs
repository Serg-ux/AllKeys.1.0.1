using AllKeys.Modelo;
using ExamenVentas.DAL;
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
using Usuarios.Modelo;

namespace AllKeys
{
    /// <summary>
    /// Lógica de interacción para Carrito.xaml
    /// </summary>
    public partial class AdminGame : Page
    {
        Videojuego videojuego = new Videojuego();
        Copia copia = new Copia();
        UnitOfWork bd = new UnitOfWork();
        Boolean nuevo = true;
        Boolean new_copia = true;
        

        public AdminGame()
        {
            InitializeComponent();
            gbFormularioV.DataContext = videojuego;
            dgVideojuegos.ItemsSource = bd.VideojuegosRepository.GetAll();
            dgVideojuegos.SelectedIndex = -1;
            dgCopias.SelectedIndex = -1;
        }
        private void dgVideojuegos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgVideojuegos.SelectedIndex != -1)
            {
                videojuego = (Videojuego)dgVideojuegos.SelectedItem;
                gbFormularioV.DataContext = videojuego;
                nuevo = false;

                dgCopias.ItemsSource = bd.CopiasRepository.CopiasFiltro(videojuego.VideojuegoId);
            }
        }
        private void Limpiar()
        {
            videojuego = new Videojuego();
            gbFormularioV.DataContext = videojuego;
            nuevo = true;
        }



        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            String errores = Validacion.errores(videojuego);
            if (txtCompañia.Text != "" && txtDescripcion.Text != "" && txtDisponible.Text != "" && txtNombre.Text != "" && txtPrecio.Text != "" && txtTipo.Text != "")
            {
                if (errores.Equals(""))
                {
                    // Intentamos convertir el valor del TextBox a double y  a int
                    if (double.TryParse(txtPrecio.Text, out double precio) && int.TryParse(txtDisponible.Text, out int disponible))
                    {
                        videojuego.Precio = precio;
                        videojuego.Disponible = disponible;

                        if (nuevo)
                        {
                            bd.VideojuegosRepository.Añadir(videojuego);
                            bd.Save();
                            dgVideojuegos.ItemsSource = bd.VideojuegosRepository.GetAll();

                        }
                        else
                        {
                            bd.VideojuegosRepository.Update(videojuego);
                            bd.Save();
                        }

                        Limpiar();
                        MessageBox.Show("Guardado correctamente", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        // Mostramos un mensaje de error si no se pudo convertir el valor
                        MessageBox.Show("El precio debe ser un número válido.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show(errores, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void btnBorrar_Click(object sender, RoutedEventArgs e)
        {
            if (dgVideojuegos.SelectedIndex != -1)
            {
                if (MessageBox.Show("¿Seguro que desa borrar este videojuego?",
                 "Borrado",
                 MessageBoxButton.YesNo,
                 MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    bd.VideojuegosRepository.Delete(videojuego);
                    bd.Save();
                    Limpiar();
                    dgVideojuegos.ItemsSource = bd.VideojuegosRepository.GetAll();
                }

            }
        }

        private void dgCopias_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgCopias.SelectedIndex != -1)
            {
                copia = (Copia)dgCopias.SelectedItem;
                tbCodCopia.Text = copia.CopiaCod;
                new_copia = false;
            }
        }
        private void btnGuardarCopia_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                copia.VideojuegoId = videojuego.VideojuegoId;
                copia.CopiaCod = tbCodCopia.Text;
                String errores = Validacion.errores(copia);
                if (dgVideojuegos.SelectedIndex != -1)
                {
                    if (errores.Equals(""))
                    {
                        if (new_copia)
                        {
                            bd.CopiasRepository.Añadir(copia);
                            bd.Save();
                        }
                        else
                        {
                            bd.CopiasRepository.Update(copia);
                            bd.Save();
                        }
                        Limpiar_Copia();
                        dgCopias.ItemsSource = bd.CopiasRepository.CopiasFiltro(videojuego.VideojuegoId);
                        MessageBox.Show("Guardado correctamente", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        MessageBox.Show(errores, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Se produjo una excepción: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Limpiar_Copia()
        {
            copia = new Copia();
            tbCodCopia.Text = copia.CopiaCod;
            new_copia = true;
            dgCopias.ItemsSource = bd.CopiasRepository.CopiasFiltro(videojuego.VideojuegoId);
        }

        private void btnBorrarCopia_Click(object sender, RoutedEventArgs e)
        {
            if (dgCopias.SelectedIndex != -1)
            {
                if (MessageBox.Show("¿Seguro que desa borrar esta Copia?",
                "Borrado",
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    bd.CopiasRepository.Delete(copia);
                    bd.Save();
                    Limpiar_Copia();
                    dgCopias.ItemsSource = bd.CopiasRepository.CopiasFiltro(videojuego.VideojuegoId);

                }

            }
        }
    }
}
