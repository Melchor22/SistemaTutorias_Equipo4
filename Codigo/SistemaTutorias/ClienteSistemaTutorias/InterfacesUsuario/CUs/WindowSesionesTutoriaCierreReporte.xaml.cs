using ClienteSistemaTutorias.Modelo;
using ServiceReference1;
using System;
using System.Collections.Generic;
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
    /// Lógica de interacción para WindowSesionesTutoriaCierreReporte.xaml
    /// </summary>
    public partial class WindowSesionesTutoriaCierreReporte : Window
    {
        public WindowSesionesTutoriaCierreReporte()
        {
            InitializeComponent();
            TutoriaAcademicaViewModel vmTutoriaAcademica = new TutoriaAcademicaViewModel(-1);
            dgSesionesTutoria.ItemsSource = vmTutoriaAcademica.tutoriaViewModel;
        }

        private void btModificarFechaCierre_Click(object sender, RoutedEventArgs e)
        {
            string fechaCierreModificada = tbFechaCierreReporte.Text.Trim();
            string horaCierreModificada = tbHoraCierreReporte.Text.Trim();
            bool validacion = VerificarCampos(horaCierreModificada, fechaCierreModificada);

            if (validacion)
            {
                DateTime fecha = DateTime.ParseExact(fechaCierreModificada, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                DateTime hora = DateTime.ParseExact(horaCierreModificada, "HH:mm", CultureInfo.InvariantCulture);
                DateTime fechaHora = new DateTime(fecha.Year, fecha.Month, fecha.Day, hora.Hour, hora.Minute, hora.Second);
                DatosTutoria FilaSeleccionada = (DatosTutoria)dgSesionesTutoria.SelectedItem;
                int idTutoria = FilaSeleccionada.idTutoria;


                ModificarFechaCierre(fechaHora, idTutoria);
            }
            else
            {
                MessageBox.Show("Favor de llenar los campos");
            }

        }

        private bool VerificarCampos(string fechaObtenida, string horaObtenida)
        {

            if (string.IsNullOrEmpty(fechaObtenida) || string.IsNullOrEmpty(horaObtenida) || dgSesionesTutoria.SelectedItem == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private async void ModificarFechaCierre(DateTime fecha, int idTutoria)
        {
            using (var conexionServicios = new Service1Client())
            {
                Task<bool> resultadoOperacion = conexionServicios.modificarFechaCierreAsync(idTutoria, fecha);
                bool registroExitoso = await resultadoOperacion;
                if (registroExitoso)
                {
                    MessageBox.Show("Fecha modificada Exitosamente.");
                }
                else
                {
                    MessageBox.Show("Ocurrio un error en el registro.");
                }
            }
        }
    }
}
