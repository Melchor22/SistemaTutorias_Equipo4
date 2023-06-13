using ServiceReference1;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Lógica de interacción para WindowAsignarTutor.xaml
    /// </summary>
    public partial class WindowAsignarTutor : Window
    {
        RolesAcademicos[] tutoresObtenidosBD;
        private string matriculaR;
        public WindowAsignarTutor(string matricula)
        {
            InitializeComponent();
            matriculaR = matricula;
            obtenerTutores();
        }

        private void btAsignar_Click(object sender, RoutedEventArgs e)
        {
            string matriculaRecibida = matriculaR;
            int tutorSeleccionado = ObtenerTutorSeleccionado();
            AsignarTutor(matriculaRecibida, tutorSeleccionado);
            

        }

        private async void obtenerTutores()
        {
            using (var conexionServicios = new Service1Client())
            {
                RolesAcademicos[] tutoresObtenidos = await conexionServicios.obtenerTutoresAsync();
                tutoresObtenidosBD = tutoresObtenidos;
                ObservableCollection<string> listaTutores = new ObservableCollection<string>();

                foreach (RolesAcademicos tutor in tutoresObtenidos)
                {
                    int idRol = tutor.IDRolAcademico;
                    string numPersonal = tutor.IDRolAcademico.ToString();
                    string formatoTutores = $"{numPersonal}";
                    listaTutores.Add(formatoTutores);
                }

                cbTutor.ItemsSource = listaTutores;
            }
        }

        private async void AsignarTutor(string matricula, int tutor)
        {
            using (var conexionServicios = new Service1Client())
            {
                Task<bool> resultadoOperacion = conexionServicios.asignarTutorAsync(matricula, tutor);
                bool registroExitoso = await resultadoOperacion;
                if (registroExitoso)
                {
                    MessageBox.Show("TutorAsignado Exitosamente.");
                }
                else
                {
                    MessageBox.Show("Ocurrio un error en la asignación.");
                }
            }
        }

        private int ObtenerTutorSeleccionado()
        {
            if (cbTutor.SelectedIndex != -1)
            {
                string itemSeleccionado = cbTutor.SelectedItem.ToString();
                int tutor = int.Parse(itemSeleccionado);
                return tutor;
            }

            return -1; //Por si no se ha seleccionado ningún programa educativo
        }
    }
}
