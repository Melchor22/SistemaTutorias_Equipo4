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

namespace ClienteSistemaTutorias.InterfacesUsuario
{
    /// <summary>
    /// Lógica de interacción para WindowReporteTutoriaPorTutor.xaml
    /// </summary>
    public partial class WindowReporteTutoriaPorTutor : Window
    {
        PeriodosEscolares[] periodosEscolaresObtenidos;
        ReportesTutoria reporteObtenido;
        public WindowReporteTutoriaPorTutor()
        {
            InitializeComponent();
            TutorViewModel vmTutorAcademico = new TutorViewModel();
            dgTutores.ItemsSource = vmTutorAcademico.tutorViewModel;
            obtenerPeriodosEscolares();
        }

        private void btBuscarReportePorTutor_Click(object sender, RoutedEventArgs e)
        {
            string numSesionRecibido = tbNoSesion.Text.Trim();
            int numSesion;
            bool validacion = VerificarCampos(numSesionRecibido);
            if (validacion)
            {
                if (int.TryParse(numSesionRecibido, out numSesion))
                {
                    DatosTutorAcademico tutorSeleccionado = (DatosTutorAcademico)dgTutores.SelectedItem;
                    int idRolAcademico = tutorSeleccionado.idRolAcademico;
                    PeriodosEscolares periodoSeleccionado = periodosEscolaresObtenidos[cbPeriodoEscolar.SelectedIndex];
                    int idPeriodo = periodoSeleccionado.IDPeriodoEscolar;
                    obtenerReportePorTutor(idRolAcademico, numSesion, idPeriodo);
                }
                else
                {
                    MessageBox.Show("El campo de texto debe ser solo números");
                }
            }
            else
            {
                MessageBox.Show("Favor de llenar todos los campos");
            }


        }

        private bool VerificarCampos(string numSesionRecibido)
        {

            if (string.IsNullOrEmpty(numSesionRecibido) || dgTutores.SelectedItem == null || cbPeriodoEscolar.SelectedIndex == -1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private async void obtenerPeriodosEscolares()
        {
            using (var conexionServicios = new Service1Client())
            {
                PeriodosEscolares[] periodosObtenidos = await conexionServicios.obtenerPeriodosEscolaresAsync();
                periodosEscolaresObtenidos = periodosObtenidos;
                ObservableCollection<string> listaPeriodos = new ObservableCollection<string>();

                foreach (PeriodosEscolares periodo in periodosObtenidos)
                {
                    DateTime fechaInicio = (DateTime)periodo.FechaInicio;
                    DateTime fechaFin = (DateTime)periodo.FechaFin;
                    string periodoFormateado = $"{fechaInicio.ToString("MMM yyyy")} - {fechaFin.ToString("MMM yyyy")}";
                    listaPeriodos.Add(periodoFormateado);
                }

                cbPeriodoEscolar.ItemsSource = listaPeriodos;
            }
        }

        private async void obtenerReportePorTutor(int idRolAcademico, int numSesion, int idPeriodo)
        {
            using (var conexionServicios = new Service1Client())
            {
                ReportesTutoria reporteObtenidoBD = await conexionServicios.obtenerReporteAsync(idRolAcademico, numSesion, idPeriodo);
                reporteObtenido = reporteObtenidoBD;
                if (reporteObtenido != null)
                {
                    WindowReporteTutor ventanaReportePorTutor = new WindowReporteTutor(reporteObtenidoBD.Descripcion, reporteObtenidoBD.ComentarioGeneral);
                    ventanaReportePorTutor.Show();
                }
                else
                {
                    MessageBox.Show("Error en la consulta, intente más tarde");
                }
            }
        }
    }
}

