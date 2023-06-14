using ClienteSistemaTutorias.Modelo;
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

namespace ClienteSistemaTutorias.InterfacesUsuario.CUs
{
    /// <summary>
    /// Lógica de interacción para WindowRegistrarProblematicaAcademica.xaml
    /// </summary>
    public partial class WindowRegistrarProblematicaAcademica : Window
    {
        Estudiantes[] estudiantesObtenidosBD;
        CategoriasProblematica[] categoriasObtenidasBD;
        TutoriaPeriodo tutoriaSeleccionada;

        public WindowRegistrarProblematicaAcademica(TutoriaPeriodo tutoriaRecibida)
        {
            tutoriaSeleccionada = tutoriaRecibida;
            InitializeComponent();
            llenarCampos(tutoriaSeleccionada);
        }

        private void ButtonRegistrar_Click(object sender, RoutedEventArgs e)
        {
            int IDTutoria = tutoriaSeleccionada.tutoria.IDTutoriaAcademica;

            Estudiantes estudianteSeleccionado = estudiantesObtenidosBD[cbEstudiantes.SelectedIndex];
            string matriculaEstudiante = estudianteSeleccionado.Matricula;

            CategoriasProblematica categoriaSeleccionada = categoriasObtenidasBD[cbCategoria.SelectedIndex];
            int IDCategoria = categoriaSeleccionada.IDCategoria;

            int NRC = Int32.Parse(tbNRC.Text);

            string descripcion = tbDescripcion.Text;

            RegistrarProblematica(IDTutoria, matriculaEstudiante, IDCategoria, NRC, descripcion);

        }

        private void llenarCampos(TutoriaPeriodo tutoriaSeleccionada)
        {
            obtenerEstudiantesPorTutoria(tutoriaSeleccionada.tutoria.IDTutoriaAcademica);
            obtenerCategoriasProblematica();
        }

        private async void obtenerEstudiantesPorTutoria(int IDTutoria)
        {
            using (var conexionServicios = new Service1Client())
            {
                Estudiantes[] estudiantesObtenidos = await conexionServicios.obtenerEstudiantesPorTutoriaAsync(IDTutoria);
                estudiantesObtenidosBD = estudiantesObtenidos.ToArray();
                ObservableCollection<string> listaEstudiantes = new ObservableCollection<string>();

                foreach (Estudiantes estudianteBD in estudiantesObtenidos)
                {
                    string nombres = estudianteBD.Nombres;
                    string apellidoPaterno = estudianteBD.ApellidoPaterno;
                    string apellidoMaterno = estudianteBD.ApellidoMaterno;
                    string formatoEstudiantes = $"{nombres} {apellidoPaterno} {apellidoMaterno}";
                    listaEstudiantes.Add(formatoEstudiantes);
                }

                cbEstudiantes.ItemsSource = listaEstudiantes;
            }
        }

        private async void obtenerCategoriasProblematica()
        {
            using (var conexionServicios = new Service1Client())
            {
                CategoriasProblematica[] categoriasObtenidas = await conexionServicios.obtenerCategoriasProblematicaAsync();
                categoriasObtenidasBD = categoriasObtenidas.ToArray();
                ObservableCollection<string> listaCategorias = new ObservableCollection<string>();

                foreach (CategoriasProblematica categoria in categoriasObtenidas)
                {
                    string tipo = categoria.Tipo;
                    listaCategorias.Add(tipo);
                }
                cbCategoria.ItemsSource = listaCategorias;
            }
        }

        private async void RegistrarProblematica(int IDTutoria, string matriculaEstudiante, int IDCategoria, int NRC, string descripcion)
        {
            using (var conexionServicios = new Service1Client())
            {
                Task<bool> resultadoOperacion = conexionServicios.registrarProblematicaAcademicaAsync(IDTutoria,matriculaEstudiante, IDCategoria, NRC, descripcion);
                bool registroExitoso = await resultadoOperacion;
                if (registroExitoso)
                {
                    MessageBox.Show("Tutoria Registrada Exitosamente.");
                }
                else
                {
                    MessageBox.Show("Ocurrio un error en el registro.");
                }
            }
        }
    }
}
