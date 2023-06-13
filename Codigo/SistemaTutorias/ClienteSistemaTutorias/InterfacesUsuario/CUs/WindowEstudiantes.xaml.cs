using ClienteSistemaTutorias.InterfacesUsuario;
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

namespace ClienteSistemaTutorias.InterfacesUsuario
{
    /// <summary>
    /// Lógica de interacción para WindowEstudiantes.xaml
    /// </summary>
    public partial class WindowEstudiantes : Window
    {
        Estudiantes estudianteSeleccionado;
        public WindowEstudiantes()
        {
            InitializeComponent();
            EstudianteViewModel vmEstudiante = new EstudianteViewModel();
            dgEstudiantes.ItemsSource = vmEstudiante.estudianteViewModel;
        }

        private void btRegistrarEstudiante_Click(object sender, RoutedEventArgs e)
        {
            WindowRegistrarEstudiante ventanaRegistrarEstudiante = new WindowRegistrarEstudiante();
            ventanaRegistrarEstudiante.Show();
        }

        private void btAsignarTutor_Click(object sender, RoutedEventArgs e)
        {
            if (dgEstudiantes.SelectedItem != null)
            {
                DatosEstudiante estudianteSeleccionadoFila = (DatosEstudiante)dgEstudiantes.SelectedItem;
                string estudiante =  dgEstudiantes.SelectedItem.ToString();
                string matricula = (estudiante.Split(' ')[0].Trim());
                WindowAsignarTutor ventanaAsignarTutor = new WindowAsignarTutor(matricula);
                ventanaAsignarTutor.Show();

            }
            else
            {
                MessageBox.Show("Seleccione un estudiante para continuar.");
            }
        }
    }
}
