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
using System.Windows.Shapes;

namespace ClienteSistemaTutorias.InterfacesUsuario
{
    /// <summary>
    /// Lógica de interacción para WindowCoordinador.xaml
    /// </summary>
    public partial class WindowCoordinador : Window
    {
        RolesAcademicos rolAcademico;
        Academicos academico;
        MensajeInicioSesion usuarioCoordinador;
        public WindowCoordinador(MensajeInicioSesion usuario)
        {
            InitializeComponent();
            rolAcademico = usuario.usuarioRolAcademico;
            academico = usuario.usuarioAcademico;
            usuarioCoordinador = usuario;
            lbBienvenido.Content = academico.Nombres + " " + academico.ApellidoPaterno + " " + academico.ApellidoMaterno;
        }

        private void btSesionTutoria_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btReporteTutoria_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btEstudiante_Click(object sender, RoutedEventArgs e)
        {
            WindowRegistrarEstudiante ventanaRegistrarEstudiante = new WindowRegistrarEstudiante();
            ventanaRegistrarEstudiante.Show();
        }

        private void btTutor_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btProblematica_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btCerrarSesion_Click(object sender, RoutedEventArgs e)
        {
            WindowInicioSesion ventanaInicioSesion = new WindowInicioSesion();
            ventanaInicioSesion.Show();
            Close();

        }
    }
}
