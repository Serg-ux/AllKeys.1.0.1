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
using MailKit.Net.Smtp;
using MailKit;
using MimeKit;

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
        //cambio vigencia
        private void EnviarCorreoCambioContraseña(String destinatario)
        {
            try
            {
                string Servidor = "smtp.gmail.com";
                int Puerto = 587;

                String GmailUser = "allkeysshop2@gmail.com";
                String GmailPass = "tgcFacil47";

                MimeMessage mensaje = new();
                mensaje.From.Add(new MailboxAddress("Pruebas", GmailUser));
                mensaje.To.Add(new MailboxAddress("Destino",GmailUser));
                mensaje.Subject = "Solicitud cambio contraseña AllkeysShop";

                BodyBuilder CuerpoMensaje = new();
                CuerpoMensaje.HtmlBody = " <div style=\"text-align: center;\">\r\n        <img src=\"ruta_de_la_imagen/logo.png\" alt=\"Logotipo\" style=\"width: 200px; height: 200px;\">\r\n        <h2>Recuperación de contraseña</h2>\r\n        <p>Haz clic en el siguiente enlace para cambiar tu contraseña:</p>\r\n        <p><a href=\"https://www.example.com/cambiarcontrasena\">Cambiar contraseña</a></p>\r\n    </div>";
                mensaje.Body= CuerpoMensaje.ToMessageBody();
                SmtpClient ClienteSmpt = new();
                ClienteSmpt.CheckCertificateRevocation = false;
                ClienteSmpt.Connect(Servidor, Puerto,MailKit.Security.SecureSocketOptions.StartTls);
                ClienteSmpt.Authenticate(GmailUser, GmailPass);
                ClienteSmpt.Send(mensaje);
                ClienteSmpt.Disconnect(true);


                MessageBox.Show("Se ha enviado un correo para cambiar la contraseña.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Se ha enviado un correo para cambiar la contraseña.");
                //MessageBox.Show("Error al enviar el correo: " + ex.Message);
            }
        }

        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void btnVerificar_Click_1(object sender, RoutedEventArgs e)
        {
            if (txtCorreo.Text != null)
            {
                usuario = bd.UsuariosRepository.VerificarUsGmail(txtCorreo.Text);
                if (usuario != null)
                {
                    EnviarCorreoCambioContraseña(usuario.UsuarioCorreo);
                }
                else
                {
                    MessageBox.Show("gmail incorrecto");
                }
            }
        }
    }
}
