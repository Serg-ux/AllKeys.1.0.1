﻿ using AllKeys.Modelo;
using ExamenVentas.DAL;
using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Lógica de interacción para Principal.xaml
    /// </summary>
    public partial class Principal : Window
    {
        private Games game = new Games();
        private Perfil perfill = new Perfil();
        private Carrito caritoo = new Carrito();
        private AdminGame adminGame = new AdminGame();
        private AdminUser adminUser = new AdminUser();
        public static UnitOfWork bd = new UnitOfWork();

        public Principal()
        {
            InitializeComponent();
            Usuario usuario = new Usuario();
            usuario = bd.UsuariosRepository.BuscarUsId(MainWindow.idUS);
            if (usuario.RolId == 1)
            {
                Sp_admin.Visibility = Visibility.Visible;
            }
            else Sp_admin.Visibility = Visibility.Hidden;
        }
        
        private void Juegosbt_Click(object sender, RoutedEventArgs e)
        {
            Games game = new Games();
            frame.Content = game;
            ImgCentro.Visibility = Visibility.Collapsed;
        }

        private void perfil_Click(object sender, RoutedEventArgs e)
        {
            frame.Content = perfill;
            ImgCentro.Visibility = Visibility.Collapsed;
        }

        private void salir_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("¿Salir?",
                   "Logout",
                   MessageBoxButton.YesNo,
                   MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }
        }

        private void carrito_Click(object sender, RoutedEventArgs e)
        {
            frame.Content = caritoo;
            ImgCentro.Visibility = Visibility.Collapsed;
        }

        private void btadminGame_Click(object sender, RoutedEventArgs e)
        {
            frame.Content = adminGame;
            ImgCentro.Visibility = Visibility.Collapsed;
        }

        private void btadminUser_Click(object sender, RoutedEventArgs e)
        {
            frame.Content=adminUser;
            ImgCentro.Visibility = Visibility.Collapsed;
        }


        private void Ayuda_Click(object sender, RoutedEventArgs e)
        {
            string filePath = @"C:\Users\Serg-ux\source\repos\Serg-ux\AllKeys.1.0.1\AllKeys\Archivos\MANUAL_USUARIO.pdf";

            try
            {
                ProcessStartInfo psi = new ProcessStartInfo();
                psi.FileName = "cmd";
                psi.Arguments = $"/c start \"\" \"{filePath}\"";
                psi.WindowStyle = ProcessWindowStyle.Hidden;
                Process.Start(psi);
                ImgCentro.Visibility = Visibility.Collapsed;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al abrir el archivo: " + ex.Message);
            }
        }

        //private void Ayuda_Click(object sender, RoutedEventArgs e)
        //{
        //    string fileName = "MANUAL_USUARIO.pdf";
        //    string filePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Ayuda", fileName);

        //    try
        //    {
        //        ProcessStartInfo psi = new ProcessStartInfo();
        //        psi.FileName = "cmd";
        //        psi.Arguments = $"/c start \"\" \"{filePath}\"";
        //        psi.WindowStyle = ProcessWindowStyle.Hidden;
        //        Process.Start(psi);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error al abrir el archivo: " + ex.Message);
        //    }
        //}
    }
}
