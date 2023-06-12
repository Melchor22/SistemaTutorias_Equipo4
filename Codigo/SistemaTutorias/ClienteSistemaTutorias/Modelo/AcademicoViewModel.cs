using ServiceReference1;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClienteSistemaTutorias.Modelo
{
    internal class AcademicoViewModel
    {
        public ObservableCollection<DatosAcademico> academicoViewModel { get; set; }
        public AcademicoViewModel()
        {
            academicoViewModel = new ObservableCollection<DatosAcademico>();
            solicitarInformacionServicio();
        }

        public async void solicitarInformacionServicio()
        {
            var conexionServicio = new Service1Client();
            if (conexionServicio != null)
            {
                Academicos[] academicoServicio = await conexionServicio.obtenerAcademicosAsync();
                foreach (var academico in academicoServicio)
                {
                    DatosAcademico datosAcademico = new DatosAcademico()
                    {
                        numPersonal = academico.NumPersonal,
                        nombre = academico.Nombres,
                        apellidoPaterno = academico.ApellidoPaterno,
                        apellidoMaterno = academico.ApellidoMaterno
                    };
                    academicoViewModel.Add(datosAcademico);
                }
            }
        }
    }
}
