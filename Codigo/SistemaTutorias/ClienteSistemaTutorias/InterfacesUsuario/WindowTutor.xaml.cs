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
    /// Lógica de interacción para WindowTutor.xaml
    /// </summary>
    public partial class WindowTutor : Window
    {
        RolesAcademicos rolAcademico;
        Academicos academico;
        MensajeInicioSesion usuarioTutor;
        public WindowTutor(MensajeInicioSesion usuario)
        {
            InitializeComponent();
            rolAcademico = usuario.usuarioRolAcademico;
            academico = usuario.usuarioAcademico;
            usuarioTutor = usuario;
            lbBienvenido.Content = academico.Nombres + " " + academico.ApellidoPaterno + " " + academico.ApellidoMaterno;
        }

        private void btSesionesTutoria_Click(object sender, RoutedEventArgs e)
        {
            WindowSesionesTutoria ventanaSesionesTutoria = new WindowSesionesTutoria(usuarioTutor);
            ventanaSesionesTutoria.Show();
            Close();
        }

        private void btReporteTutoria_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btProblematica_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btComentariosGenerales_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btCerrarSesion_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
