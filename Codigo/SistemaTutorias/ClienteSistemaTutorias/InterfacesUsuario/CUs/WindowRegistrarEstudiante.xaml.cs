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
    /// Lógica de interacción para RegistrarEstudiante.xaml
    /// </summary>
    public partial class WindowRegistrarEstudiante : Window
    {
        ProgramasEducativos[] programaEducativosObtenidos;
        public WindowRegistrarEstudiante()
        {
            InitializeComponent();
            obtenerProgramasEducativos();
        }

        private void btGuardarEstudiante_Click(object sender, RoutedEventArgs e)
        {
            string matricula = tbMatricula.Text;
            string nombre = tbNombre.Text;
            string apellidoPaterno = tbApellidoPaterno.Text;
            string apellidoMaterno = tbApellidoMaterno.Text;
            string correo = tbEmail.Text;
            string telefono = tbTelefono.Text;
            bool validacion = VerificarCampos(nombre, matricula, apellidoPaterno, apellidoMaterno, correo, telefono);

            if (validacion)
            {
                int periodoSeleccionado = ObtenerIDProgramaEducativoSeleccionado();
                RegistrarEstudianteNuevo(matricula, nombre, apellidoPaterno, apellidoMaterno, correo, telefono, periodoSeleccionado);
            }
            else
            {
                MessageBox.Show("Favor de llenar todos los campos.");
            }

        }

        private bool VerificarCampos(string matricula, string nombre, string apellidoPaterno, string apellidoMaterno, string email, string telefono)
        {

            if (string.IsNullOrEmpty(matricula) || string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(apellidoPaterno) || string.IsNullOrEmpty(apellidoMaterno) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(telefono) || cbProgramaEducativo.SelectedIndex == -1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private async void obtenerProgramasEducativos()
        {
            using (var conexionServicios = new Service1Client())
            {
                ProgramasEducativos[] programasObtenidos = await conexionServicios.obtenerProgramaEducativosAsync();
                programaEducativosObtenidos = programasObtenidos;
                ObservableCollection<string> listaProgramas = new ObservableCollection<string>();

                foreach (ProgramasEducativos programa in programasObtenidos)
                {
                    int idProgramaEducativo = programa.IDProgramaEducativo;
                    string nombre = programa.Nombre;
                    int idAreaAcademica = (int)programa.IDAreaAcademica;
                    string formatoPrograma = $"{idProgramaEducativo.ToString()} - {nombre.ToString()}";
                    listaProgramas.Add(formatoPrograma);
                }

                cbProgramaEducativo.ItemsSource = listaProgramas;

            }
        }
        private int ObtenerIDProgramaEducativoSeleccionado()
        {
            if (cbProgramaEducativo.SelectedIndex != -1)
            {
                string itemSeleccionado = cbProgramaEducativo.SelectedItem.ToString();
                int idProgramaEducativo = int.Parse(itemSeleccionado.Split('-')[0].Trim());
                return idProgramaEducativo;
            }

            return -1; //Por si no se ha seleccionado ningún programa educativo
        }

        private async void RegistrarEstudianteNuevo(string matricula, string nombre, string apellidoPaterno, string apellidoMaterno, string email, string telefono, int idProgramaEducativo)
        {
            using (var conexionServicios = new Service1Client())
            {
                Task<bool> resultadoOperacion = conexionServicios.registrarEstudianteAsync(matricula, nombre, apellidoPaterno, apellidoMaterno, email, telefono, idProgramaEducativo);
                bool registroExitoso = await resultadoOperacion;
                if (registroExitoso)
                {
                    MessageBox.Show("Estudiante registrado Exitosamente.");
                }
                else
                {
                    MessageBox.Show("Ocurrio un error en el registro.");
                }
            }
        }
    }
}
