using ServiceReference1;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;

namespace ClienteSistemaTutorias.InterfacesUsuario
{
    /// <summary>
    /// Lógica de interacción para WindowAsignarTutor.xaml
    /// </summary>
    public partial class WindowAsignarTutor : Window
    {
        DatosTutor[] tutoresObtenidosBD;
        string matriculaR;
        public WindowAsignarTutor(string matricula)
        {
            InitializeComponent();
            matriculaR = matricula;
            obtenerTutores();
        }

        private void btAsignar_Click(object sender, RoutedEventArgs e)
        {
            string matriculaRecibida = matriculaR;
            DatosTutor tutorSeleccionado = tutoresObtenidosBD[cbTutor.SelectedIndex];
            int idRolTutorSeleccionado = tutorSeleccionado.rolAcademicoTutor.IDRolAcademico;
            AsignarTutor(matriculaRecibida, idRolTutorSeleccionado);
        }

        private async void obtenerTutores()
        {
            using (var conexionServicios = new Service1Client())
            {
                DatosTutor[] tutoresObtenidos = await conexionServicios.obtenerTutoresAsync();
                tutoresObtenidosBD = tutoresObtenidos;
                ObservableCollection<string> listaTutores = new ObservableCollection<string>();

                foreach (DatosTutor tutor in tutoresObtenidos)
                {
                    string numPersonal = tutor.academicoTutor.NumPersonal;
                    string nombre = tutor.academicoTutor.Nombres;
                    string apellidoPaterno = tutor.academicoTutor.ApellidoPaterno;
                    string apellidoMaterno = tutor.academicoTutor.ApellidoMaterno;
                    string formatoTutores = $"{numPersonal.ToString()} - {nombre.ToString()} {apellidoPaterno.ToString()} {apellidoMaterno.ToString()}";
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
    }
}
