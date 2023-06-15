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
    /// Interaction logic for WindowRegistrarSolucionProblematicaAcademica.xaml
    /// </summary>
    public partial class WindowRegistrarSolucionProblematicaAcademica : Window
    {
        Estudiantes[] estudiantesObtenidosBD;
        CategoriasProblematica[] categoriasObtenidasBD;
        TutoriaPeriodo tutoriaSeleccionada;

        public WindowRegistrarSolucionProblematicaAcademica(TutoriaPeriodo tutoriaObtenida)
        {
            tutoriaSeleccionada = tutoriaObtenida;
            InitializeComponent();
            llenarCampos(tutoriaSeleccionada);
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

                cbEstudianteSolucion.ItemsSource = listaEstudiantes;
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
                cbCategoriaSolucion.ItemsSource = listaCategorias;
            }
        }

        private void llenarCampos(TutoriaPeriodo tutoriaSeleccionada)
        {
            obtenerEstudiantesPorTutoria(tutoriaSeleccionada.tutoria.IDTutoriaAcademica);
            obtenerCategoriasProblematica();
        }

        private void ButtonRegistrarSolucion_Click(object sender, RoutedEventArgs e)
        {
            int IDTutoria = tutoriaSeleccionada.tutoria.IDTutoriaAcademica;

            Estudiantes estudianteSeleccionado = estudiantesObtenidosBD[cbEstudianteSolucion.SelectedIndex];
            string matriculaEstudiante = estudianteSeleccionado.Matricula;

            CategoriasProblematica categoriaSeleccionada = categoriasObtenidasBD[cbCategoriaSolucion.SelectedIndex];
            int IDCategoria = categoriaSeleccionada.IDCategoria;

            int NRC = Int32.Parse(tbNRCSolucion.Text);

            string descripcion = tbSolucion.Text;

            RegistrarSolucionProblematica(IDTutoria, matriculaEstudiante, IDCategoria, NRC, descripcion);

        }
        public async void RegistrarSolucionProblematica(int IDTutoria, string matriculaEstudiante, int IDCategoria, int NRC, string solucion)
        {
            using(var conexionServicios = new Service1Client())
            {
                Task<bool> resultadoOperacion = conexionServicios.registrarSolucionProblematicaAcademicaAsync(IDTutoria, matriculaEstudiante, IDCategoria, NRC, solucion);
                bool registroExitoso = await resultadoOperacion;
                if (registroExitoso)
                {
                    MessageBox.Show("Solucion Registrada Exitosamente.");
                }
                else
                {
                    MessageBox.Show("Ocurrio un error en el registro.");
                }
            }

        } 

    }
}
