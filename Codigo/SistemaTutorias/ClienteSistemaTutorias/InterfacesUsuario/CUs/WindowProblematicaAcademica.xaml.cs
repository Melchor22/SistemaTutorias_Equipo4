using ClienteSistemaTutorias.Modelo;
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

namespace ClienteSistemaTutorias.InterfacesUsuario.CUs
{
    /// <summary>
    /// Lógica de interacción para WindowProblematicaAcademica.xaml
    /// </summary>
    public partial class WindowProblematicaAcademica : Window
    {
        TutoriaPeriodo tutoriaSeleccionada;
        MensajeInicioSesion tutorSesion;
        public WindowProblematicaAcademica(TutoriaPeriodo tutoria, MensajeInicioSesion tutor)
        {
            tutoriaSeleccionada = tutoria;
            tutorSesion = tutor;
            InitializeComponent();
            ProblematicaAcademicaViewModel vmProblematicaAcademica = new ProblematicaAcademicaViewModel(tutoriaSeleccionada.tutoria.IDTutoriaAcademica);
            dgProblematicasAcademicas.ItemsSource = vmProblematicaAcademica.problematicaViewModel;
        }

        private void btRegistrarProblematica_Click(object sender, RoutedEventArgs e)
        {
            DatosProblematica problematicaSeleccionada = (DatosProblematica)dgProblematicasAcademicas.SelectedItem;


            WindowRegistrarProblematicaAcademica ventanaRegistrarProblematicaAcademica = new WindowRegistrarProblematicaAcademica(tutoriaSeleccionada);
            ventanaRegistrarProblematicaAcademica.Show();
        }

    

   
      
    }
}
