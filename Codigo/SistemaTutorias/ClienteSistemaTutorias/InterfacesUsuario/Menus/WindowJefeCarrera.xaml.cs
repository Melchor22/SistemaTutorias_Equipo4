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
    /// Lógica de interacción para WindowJefeCarrera.xaml
    /// </summary>
    public partial class WindowJefeCarrera : Window
    {
        RolesAcademicos rolAcademico;
        Academicos academico;
        public WindowJefeCarrera(MensajeInicioSesion usuario)
        {
            InitializeComponent();
            rolAcademico = usuario.usuarioRolAcademico;
            academico = usuario.usuarioAcademico;
            lbBienvenido.Content = academico.Nombres + " " + academico.ApellidoPaterno + " " + academico.ApellidoMaterno;
        }

        private void btReporteTutoria_Click(object sender, RoutedEventArgs e)
        {
            WindowReporteTutoriaPorTutor ventanaReporteTutoriaPorTutor = new WindowReporteTutoriaPorTutor();
            ventanaReporteTutoriaPorTutor.Show();
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
