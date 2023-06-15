using ServiceReference1;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClienteSistemaTutorias.Modelo
{
    internal class TutorViewModel
    {
        public ObservableCollection<DatosTutorAcademico> tutorViewModel { get; set; }

        public TutorViewModel()
        {
            tutorViewModel = new ObservableCollection<DatosTutorAcademico>();
            solicitarInformacionServicio();
        }

        public async void solicitarInformacionServicio()
        {
            var conexionServicio = new Service1Client();
            if (conexionServicio != null)
            {
                DatosTutor[] tutorServicio = await conexionServicio.obtenerTutoresAsync();
                foreach (var item in tutorServicio)
                {
                    DatosTutorAcademico datosTutor = new DatosTutorAcademico()
                    {
                        idRolAcademico = item.rolAcademicoTutor.IDRolAcademico,
                        numPersonal = item.academicoTutor.NumPersonal,
                        nombre = item.academicoTutor.Nombres,
                        apellidoPaterno = item.academicoTutor.ApellidoPaterno,
                        apellidoMaterno = item.academicoTutor.ApellidoMaterno
                    };
                    tutorViewModel.Add(datosTutor);
                }
            }
        }
    }
}
