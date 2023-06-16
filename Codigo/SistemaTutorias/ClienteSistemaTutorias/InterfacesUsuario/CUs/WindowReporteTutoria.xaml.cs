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
    /// Lógica de interacción para WindowReporteTutoria.xaml
    /// </summary>
    public partial class WindowReporteTutoria : Window
    {
        int IDRolAcademico;
        int IDTutoriaAcademica;
        public WindowReporteTutoria(int iDRolAcademico, int iDTutoriaAcademica)
        {
            InitializeComponent();
            IDRolAcademico = iDRolAcademico;
            IDTutoriaAcademica = iDTutoriaAcademica;
        }

        private async void btGuardar_Click(object sender, RoutedEventArgs e)
        {

            if (!string.IsNullOrEmpty(tbDescripcion.Text))
            {
                string Descripcion = tbDescripcion.Text;
                string ComentariosGenerales = tbComentarioGeneral.Text;

                using (var conexionServicios = new Service1Client())
                {
                    Task<bool> resultadoOperacion = conexionServicios.registrarReporteTutoriaAsync(Descripcion, ComentariosGenerales, IDTutoriaAcademica);
                    bool registroExitoso = await resultadoOperacion;
                    if (registroExitoso)
                    {
                        MessageBox.Show("Reporte Regsitrado Exitosamente.");
                    }
                    else
                    {
                        MessageBox.Show("Ocurrio un error en el registro.");
                    }
                }
                Close();
            }
            else
            {
                MessageBox.Show("Ingrese la Descripción para continuar.");
            }
        }
    }
}
