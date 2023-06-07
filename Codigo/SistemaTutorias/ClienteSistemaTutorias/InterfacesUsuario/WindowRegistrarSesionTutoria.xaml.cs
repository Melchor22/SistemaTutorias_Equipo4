using ServiceReference1;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

                DateTime fecha = DateTime.ParseExact(fechaObtenida, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                DateTime hora = DateTime.ParseExact(horaObtenida, "HH:mm", CultureInfo.InvariantCulture);
                DateTime fechaHora = new DateTime(fecha.Year, fecha.Month, fecha.Day, hora.Hour, hora.Minute, hora.Second);
                MessageBox.Show(fechaHora.ToString());


                int numSesionRegistro = int.Parse(cbNumSesion.SelectedItem.ToString());
                PeriodosEscolares periodoSeleccionado = periodosEscolaresObtenidos[cbPeriodoEscolar.SelectedIndex];

                RegistrarSesionTutoria(fechaHora, numSesionRegistro, periodoSeleccionado);
            }
        }
        private bool VerificarCampos(string fechaObtenida, string horaObtenida)
        {

            if (string.IsNullOrEmpty(fechaObtenida) || string.IsNullOrEmpty(horaObtenida))
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
                    string periodoFormateado = $"{periodo.FechaInicio.ToString("MMM yyyy")} - {periodo.FechaFin.ToString("MMM yyyy")}";
                    listaPeriodos.Add(periodoFormateado);
                }

                cbPeriodoEscolar.ItemsSource = listaPeriodos;
            }
        }

        private async void RegistrarSesionTutoria (DateTime fecha, int numSesion, PeriodosEscolares periodoIngresado)
        {
            TutoriasAcademicas nuevaTutoria = new TutoriasAcademicas()
            {
                Fecha = fecha,
                NumSesion = numSesion,
                IDPeriodoEscolar = periodoIngresado.IDPeriodoEscolar,
                IDRolAcademico = rolAcademico.IDRolAcademico
            };

            using (var conexionServicios = new Service1Client())
            {
                Task<bool> resultadoOperacion = conexionServicios.registrarTutoriaAcademicaAsync(nuevaTutoria);
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
