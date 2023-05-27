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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net;
using System.Net.Mail;

namespace AllKeys
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class CambioContra : Window
    {
        Usuario usuario = new Usuario();
        UnitOfWork bd = new UnitOfWork();
        public static int idUS;
        public CambioContra()
        {
            InitializeComponent();
        }

        private void btnVerificar_Click(object sender, RoutedEventArgs e)
        {
            if (txtCorreo.Text != null)
            {
                usuario = bd.UsuariosRepository.VerificarUsGmail(txtCorreo.Text);
                if (usuario != null)
                {
                    EnviarCorreoCambioContraseña(usuario.UsuarioCorreo);
                }
            }
        }
        private void EnviarCorreoCambioContraseña(string destinatario)
        {
            try
            {
                string remitente = "allkeyshopchangepass@gmail.com";
                string contraseña = "8!R_wAPcrDAg2hG";
                string asunto = "Cambio de contraseña";
                string cuerpo = "Haz clic en el siguiente enlace para cambiar tu contraseña: https://www.example.com/cambiarcontrasena";

                MailMessage mensaje = new MailMessage(remitente, destinatario, asunto, cuerpo);

                SmtpClient clienteSmtp = new SmtpClient("smtp.gmail.com", 587);
                clienteSmtp.EnableSsl = true;
                clienteSmtp.UseDefaultCredentials = false; // Deshabilita las credenciales predeterminadas
                clienteSmtp.Credentials = new NetworkCredential(remitente, contraseña);

                clienteSmtp.Send(mensaje);

                MessageBox.Show("Se ha enviado un correo para cambiar la contraseña.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al enviar el correo: " + ex.Message);
            }
        }

        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
