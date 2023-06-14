using ClienteSistemaTutorias.Modelo;
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
    /// Lógica de interacción para RegistrarTutorAcademico.xaml
    /// </summary>
    public partial class WindowRegistrarTutorAcademico : Window
    {
        public WindowRegistrarTutorAcademico()
        {
            InitializeComponent();
            AcademicoViewModel vmAcademico = new AcademicoViewModel();
            dgAcademicos.ItemsSource = vmAcademico.academicoViewModel;
        }

        private void btGuardarTutor_Click(object sender, RoutedEventArgs e)
        {
            string password = tbPassword.Text;
            bool validacion = VerificarCampos(password);

            if (validacion)
            {
                DatosAcademico filaSeleccionada = (DatosAcademico)dgAcademicos.SelectedItem;
                string numPersonal = filaSeleccionada.numPersonal;
                int rolAcademico = 3;
                RegistrarTutorNuevo(numPersonal, password, rolAcademico);


            }else
            {
                MessageBox.Show("Favor de llenar los campos");
            }

        }

        private bool VerificarCampos(string password)
        {

            if (string.IsNullOrEmpty(password) || dgAcademicos.SelectedItem != null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private async void RegistrarTutorNuevo(string numPersonal, string password, int idRol)
        {
            using (var conexionServicios = new Service1Client())
            {
                Task<bool> resultadoOperacion = conexionServicios.registrarRolAcademicoAsync(numPersonal, password, idRol);
                bool registroExitoso = await resultadoOperacion;
                if (registroExitoso)
                {
                    MessageBox.Show("Tutor registrado Exitosamente.");
                }
                else
                {
                    MessageBox.Show("Ocurrio un error en el registro.");
                }
            }
        }
    }
}
