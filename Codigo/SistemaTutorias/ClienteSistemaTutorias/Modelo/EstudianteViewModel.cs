using ServiceReference1;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClienteSistemaTutorias.Modelo
{
    internal class EstudianteViewModel
    {
        public ObservableCollection<DatosEstudiante> estudianteViewModel { get; set; }
        public EstudianteViewModel()
        {
            estudianteViewModel = new ObservableCollection<DatosEstudiante>();
            solicitarInformacionServicio();
        }

        public async void solicitarInformacionServicio()
        {
            var conexionServicio = new Service1Client();
            if (conexionServicio != null)
            {
                Estudiantes[] estudianteServicio = await conexionServicio.obtenerEstudiantesAsync();
                foreach (var estudiante in estudianteServicio)
                {
                    DatosEstudiante datosEstudiante = new DatosEstudiante()
                    {
                        matricula = estudiante.Matricula,
                        nombre = estudiante.Nombres,
                        apellidoPaterno = estudiante.ApellidoPaterno,
                        apellidoMaterno = estudiante.ApellidoMaterno,
                    };
                    estudianteViewModel.Add(datosEstudiante);
                }
            }
        }
    }
}
