using ServiceReference1;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Globalization;
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
    /// Lógica de interacción para WindowRegistrarModificarSesionTutoria.xaml
    /// </summary>
    public partial class WindowModificarSesionTutoria : Window
    {
        PeriodosEscolares[] periodosEscolaresObtenidos;
        int IDTutoria;
        int IDRolAcademico;
        public WindowModificarSesionTutoria(TutoriaPeriodo tutoriaObtenida, MensajeInicioSesion usuario)
        {
            InitializeComponent();
            IDTutoria = tutoriaObtenida.tutoria.IDTutoriaAcademica;
            IDRolAcademico = usuario.usuarioRolAcademico.IDRolAcademico;
            cbNumSesion.Items.Add(1);
            cbNumSesion.Items.Add(2);
            cbNumSesion.Items.Add(3);
            obtenerPeriodosEscolares();
            llenarCampos(tutoriaObtenida);
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

        private void llenarCampos(TutoriaPeriodo tutoriaObtenida)
        {
            tbFecha.Text = tutoriaObtenida.tutoria.Fecha.Value.ToString("dd/MM/yyyy");
            tbHora.Text = tutoriaObtenida.tutoria.Fecha.Value.ToString("HH:mm");
            cbNumSesion.SelectedIndex = tutoriaObtenida.tutoria.NumSesion.Value - 1;

            string periodoFormateado = $"{tutoriaObtenida.periodoEscolar.FechaInicio.Value.ToString("MMM yyyy")} - {tutoriaObtenida.periodoEscolar.FechaFin.Value.ToString("MMM yyyy")}";
            cbPeriodoEscolar.SelectedItem = periodoFormateado;
            Debug.WriteLine(periodoFormateado);
        }

        private void ButtonModificar_Click(object sender, RoutedEventArgs e)
        {
            string fechaObtenida = tbFecha.Text.Trim();
            string horaObtenida = tbHora.Text.Trim();
            bool validacion = VerificarCampos(fechaObtenida, horaObtenida);
            if (validacion)
            {

                DateTime fecha = DateTime.ParseExact(fechaObtenida, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                DateTime hora = DateTime.ParseExact(horaObtenida, "HH:mm", CultureInfo.InvariantCulture);
                DateTime fechaHora = new DateTime(fecha.Year, fecha.Month, fecha.Day, hora.Hour, hora.Minute, hora.Second);


                int numSesionRegistro = int.Parse(cbNumSesion.SelectedItem.ToString());
                PeriodosEscolares periodoSeleccionado = periodosEscolaresObtenidos[cbPeriodoEscolar.SelectedIndex];

                modificarSesionTutoria(fechaHora, numSesionRegistro, periodoSeleccionado);
            }
            else
            {
                MessageBox.Show("Llene todos los campos.");
            }
        }

        private async void modificarSesionTutoria(DateTime fecha, int numSesion, PeriodosEscolares periodoIngresado)
        {
            using (var conexionServicios = new Service1Client())
            {
                Task<bool> resultadoOperacion = conexionServicios.modificarTutoriaAcademicaAsync(IDTutoria, fecha, numSesion, periodoIngresado.IDPeriodoEscolar, IDRolAcademico);
                bool registroExitoso = await resultadoOperacion;
                if (registroExitoso)
                {
                    MessageBox.Show("Tutoria Modificada Exitosamente.");
                }
                else
                {
                    MessageBox.Show("Ocurrio un error en la edición.");
                }
            }
        }

        private bool VerificarCampos(string fechaObtenida, string horaObtenida)
        {

            if (string.IsNullOrEmpty(fechaObtenida) || string.IsNullOrEmpty(horaObtenida) || cbNumSesion.SelectedIndex == -1 || cbPeriodoEscolar.SelectedIndex == -1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
