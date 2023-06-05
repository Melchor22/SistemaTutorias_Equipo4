using ClienteSistemaTutorias.InterfacesUsuario;
using ServiceReference1;
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

namespace ClienteSistemaTutorias
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class WindowInicioSesion : Window
    {
        public WindowInicioSesion()
        {
            InitializeComponent();
        }

        private void btInicioSesion_Click(object sender, RoutedEventArgs e)
        {
            string username = tbUsername.Text;
            string password = tbPassword.Text;
            if ((username.Length > 0 && password.Length > 0) && (username != null && password != null))
            {
                VerificarInicioSesion(username, password);
            }
            else
            {
                MessageBox.Show("Usuario y/o Contraseña requeridos para iniciar sesión.");
            }
        }

        public async void VerificarInicioSesion(string username, string password)
        {
            using (var conexionServicios = new Service1Client())
            {
                MensajeInicioSesion resultado = await conexionServicios.iniciarSesionAsync(username, password);
                if (resultado.error == true)
                {
                    MessageBox.Show(resultado.mensaje, "Credenciales Incorrectas.");
                }
                else
                {
                    switch (resultado.usuarioRolAcademico.IDRol)
                    {
                        //Jefe de Carrera
                        case 1:
                            WindowJefeCarrera ventanaJefeCarrera = new WindowJefeCarrera();
                            ventanaJefeCarrera.Show();
                            Close();
                            break;
                        //Coordinador
                        case 2:
                            WindowCoordinador ventanaCoordinador = new WindowCoordinador();
                            ventanaCoordinador.Show();
                            Close();
                            break;
                        //Tutor
                        case 3:
                            WindowTutor ventanaTutor = new WindowTutor();
                            ventanaTutor.Show();
                            Close();
                            break;
                    }
                }
            }
        }
    }
}
