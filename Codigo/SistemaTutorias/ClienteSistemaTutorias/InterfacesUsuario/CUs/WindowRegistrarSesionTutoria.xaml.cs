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
    public partial class WindowRegistrarSesionTutoria : Window
    {
        RolesAcademicos rolAcademico;
        Academicos academico;
        PeriodosEscolares[] periodosEscolaresObtenidos;
        public WindowRegistrarSesionTutoria(MensajeInicioSesion usuario)
        {
            InitializeComponent();
            rolAcademico = usuario.usuarioRolAcademico;
            academico = usuario.usuarioAcademico;
            cbNumSesion.Items.Add(1);
            cbNumSesion.Items.Add(2);
            cbNumSesion.Items.Add(3);
            obtenerPeriodosEscolares();

        }

        private void ButtonRegistrar_Click(object sender, RoutedEventArgs e)
        {
            string fechaObtenida = tbFecha.Text.Trim();
            string horaObtenida = tbHora.Text.Trim();
            bool validacion = VerificarCampos(fechaObtenida, horaObtenida);
            if (validacion)
            {
                DateTime fecha;
                DateTime hora;

                if (DateTime.TryParseExact(fechaObtenida, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out fecha) &&
                    DateTime.TryParseExact(horaObtenida, "HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out hora))
                {
                    DateTime fechaHora = new DateTime(fecha.Year, fecha.Month, fecha.Day, hora.Hour, hora.Minute, hora.Second);

                    int numSesionRegistro = int.Parse(cbNumSesion.SelectedItem.ToString());
                    PeriodosEscolares periodoSeleccionado = periodosEscolaresObtenidos[cbPeriodoEscolar.SelectedIndex];

                    RegistrarSesionTutoria(fechaHora, numSesionRegistro, periodoSeleccionado);
                }
                else
                {
                    MessageBox.Show("La fecha y/o hora ingresadas no son válidas.");
                }
            }
            else
            {
                MessageBox.Show("Llene todos los campos.");
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

        private async void RegistrarSesionTutoria (DateTime fecha, int numSesion, PeriodosEscolares periodoIngresado)
        {
            using (var conexionServicios = new Service1Client())
            {
                Task<bool> resultadoOperacion = conexionServicios.registrarTutoriaAcademicaAsync(fecha, numSesion, periodoIngresado.IDPeriodoEscolar, rolAcademico.IDRolAcademico);
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
