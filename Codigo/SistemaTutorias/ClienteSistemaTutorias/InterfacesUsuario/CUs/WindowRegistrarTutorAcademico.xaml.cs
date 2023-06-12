using ClienteSistemaTutorias.Modelo;
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

            }else
            {
                MessageBox.Show("Favor de proporcionar una contraseña.");
            }

        }

        private bool VerificarCampos(string password)
        {

            if (string.IsNullOrEmpty(password))
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
