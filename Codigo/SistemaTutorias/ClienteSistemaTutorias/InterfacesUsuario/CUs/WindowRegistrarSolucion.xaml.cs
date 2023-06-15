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

namespace ClienteSistemaTutorias.InterfacesUsuario.CUs
{
    /// <summary>
    /// Lógica de interacción para WindowRegistrarSolucion.xaml
    /// </summary>
    public partial class WindowRegistrarSolucion : Window
    {
        int IDProblematica;
        public WindowRegistrarSolucion(int iDProblematica)
        {
            InitializeComponent();
            IDProblematica = iDProblematica;
        }

        private void ButtonRegistrarSolucion_Click(object sender, RoutedEventArgs e)
        {
            string solucionIngresada = tbSolucion.Text;

            if (!string.IsNullOrEmpty(solucionIngresada))
            {
                registrarSolucion(solucionIngresada);
                Close();
            }
            else
            {
                MessageBox.Show("Ingrese una solución para poder registrarla.");
            }
        }

        private async void registrarSolucion(string solucionIngresada)
        {
            using (var conexionServicios = new Service1Client())
            {
                bool resultadoOperacion = await conexionServicios.registrarSolucionProblematicaAsync(IDProblematica,solucionIngresada);
                if (resultadoOperacion)
                {
                    MessageBox.Show("Solución Registrada Exitosamente.");
                }
                else
                {
                    MessageBox.Show("Ocurrio un problema al registrar la solución.");
                }
            }
        }
    }
}
