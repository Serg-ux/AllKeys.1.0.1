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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Usuarios.Modelo;

namespace AllKeys
{
    /// <summary>
    /// Lógica de interacción para Perfil.xaml
    /// </summary>
    public partial class Perfil : Page
    {
        Usuario usuario = new Usuario();
        int idUSR= MainWindow.idUS;
        public Perfil()
        {
            InitializeComponent();
            usuario = Principal.bd.UsuariosRepository.BuscarUsId(idUSR);
            gbFormularioUser.DataContext=usuario;
            // Obtener la colección de roles desde la base de datos y ordenarla por nombre
            var roles = Principal.bd.RolesRepository.GetAll().OrderBy(r => r.RolNombre);

            if (usuario.RolId !=1)
            {
                // Seleccionar el segundo y tercer rol y asignarlos al combobox
                var rolesSeleccionados = roles.Skip(1).Take(2);
                cbRol.ItemsSource = rolesSeleccionados;
            }
            else { cbRol.ItemsSource = roles; }
            
            // Establecer las propiedades DisplayMemberPath y SelectedValuePath como antes
            cbRol.DisplayMemberPath = "RolNombre";
            cbRol.SelectedValuePath = "RolId";
        }
        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtColorFav.Text != "" && txtContra.Text != "" && txtCorreo.Text != "" && txtNombre.Text != "" && txtTelefono.Text != "" && cbRol.SelectedIndex != -1)
                {
                    String errores = Validacion.errores(usuario);
                    if (errores.Equals(""))
                    {
                        Principal.bd.UsuariosRepository.Update(usuario);
                        Principal.bd.Save();
                        MessageBox.Show("Guardado correctamente", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        MessageBox.Show(errores, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Faltan Datos", "Error Login", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                // Aquí puedes manejar la excepción como desees
                MessageBox.Show("Se produjo una excepción: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        //private void btnGuardar_Click(object sender, RoutedEventArgs e)
        //{
        //    if (txtColorFav.Text != "" && txtContra.Text != "" && txtCorreo.Text != "" && txtNombre.Text != "" && txtTelefono.Text != "" && cbRol.SelectedIndex != -1)
        //    {
        //        String errores = Validacion.errores(usuario);
        //        if (errores.Equals(""))
        //        {
        //                Principal.bd.UsuariosRepository.Update(usuario);
        //                Principal.bd.Save();
        //            MessageBox.Show("Guardado correctamente", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information);
        //        }
        //        else MessageBox.Show(errores, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        //    }
        //    else
        //        MessageBox.Show("Faltan Datos", "Error Login", MessageBoxButton.OK, MessageBoxImage.Error);
        //}
    }
}
