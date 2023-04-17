using AllKeys.Modelo;
using ExamenVentas.DAL;
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
using Usuarios.Modelo;

namespace AllKeys
{
    /// <summary>
    /// Lógica de interacción para AdminUser.xaml
    /// </summary>
    public partial class AdminUser : Window
    {
        Usuario usuario = new Usuario();
        UnitOfWork bd = new UnitOfWork();
        Boolean nuevo = true;
        public AdminUser()
        {
            InitializeComponent();
            gbFormularioC.DataContext = usuario;
            dgUsuarios.ItemsSource = bd.UsuariosRepository.GetAll();
            dgUsuarios.SelectedIndex = -1;

            
            cbRol.ItemsSource=bd.RolesRepository.GetAll();
            cbRol.DisplayMemberPath = "RolNombre";
            cbRol.SelectedValuePath = "RolId";
        }

        private void dgUsuarios_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgUsuarios.SelectedIndex != -1)
            {
                usuario = (Usuario)dgUsuarios.SelectedItem;
                gbFormularioC.DataContext=usuario;
                nuevo=false;
            }
        }
        private void Limpiar()
        {
            usuario = new Usuario();
            gbFormularioC.DataContext = usuario;
            nuevo=true;
        }

        private void btnGuardar_Click_1(object sender, RoutedEventArgs e)
        {
           if(txtColorFav.Text!="" && txtContra.Text!="" && txtCorreo.Text!="" && txtNombre.Text!="" && txtTelefono.Text!="" && cbRol.SelectedIndex != -1)
           {
                String errores = Validacion.errores(usuario);
                if (errores.Equals(""))
                {
                    if (nuevo)
                    {
                        bd.UsuariosRepository.Añadir(usuario);
                        bd.Save();
                        
                    }
                    else
                    {
                        bd.UsuariosRepository.Update(usuario);
                        bd.Save();
                    }
                    Limpiar();
                    dgUsuarios.ItemsSource = bd.UsuariosRepository.GetAll();
                    MessageBox.Show("Guardado correctamente", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else MessageBox.Show(errores, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
                MessageBox.Show("Faltan Datos", "Error Login", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void btnBorrar_Click_1(object sender, RoutedEventArgs e)
        {
            if (dgUsuarios.SelectedIndex != -1)
            {
                if (MessageBox.Show("¿Seguro que desa borrar este usuario?",
                  "Borrado",
                  MessageBoxButton.YesNo,
                  MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    bd.UsuariosRepository.Delete(usuario);
                    bd.Save();
                    Limpiar();
                    dgUsuarios.ItemsSource = bd.UsuariosRepository.UsuariosCompletos();
                }
                
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Principal principal = new Principal();
            principal.Show();
        }
    }
}
