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
    /// Interaction logic for WindowReporteTutor.xaml
    /// </summary>
    public partial class WindowReporteTutor : Window
    {
        public WindowReporteTutor(string descripcion, string comentariosGenerales)
        {
            InitializeComponent();

            lbDescripcion.Content = descripcion;
            lbComentarioGenerales.Content = comentariosGenerales;
        }
    }
}
