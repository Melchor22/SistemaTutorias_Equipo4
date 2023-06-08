using ServiceReference1;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClienteSistemaTutorias.Modelo
{
    internal class TutoriaAcademicaViewModel
    {
        public int IDRolAcademico { get; set; }
        public ObservableCollection<DatosTutoria> tutoriaViewModel { get; set; }
        public TutoriaAcademicaViewModel(int IDRolAcademico)
        {
            tutoriaViewModel = new ObservableCollection<DatosTutoria>();
            solicitarInformacionServicio(IDRolAcademico);

        }
        public async void solicitarInformacionServicio(int IDRolAcademico)
        {
            var conexionServicio = new Service1Client();
            if (conexionServicio != null)
            {
                TutoriaPeriodo[] tutoriaServicio = await conexionServicio.obtenerTutoriasAcademicasAsync(IDRolAcademico);
                foreach (var tutoria in tutoriaServicio)
                {
                    DateTime fechaInicio = (DateTime)tutoria.periodoEscolar.FechaInicio;
                    DateTime fechaFin = (DateTime)tutoria.periodoEscolar.FechaFin;
                    DatosTutoria datosTutoria = new DatosTutoria()
                    {
                        fecha = (DateTime)tutoria.tutoria.Fecha,
                        numSesion = (int)tutoria.tutoria.NumSesion,
                        periodoEscolar = fechaInicio.ToString("MMM yyyy") + " - " + fechaFin.ToString("MMM yyyy")
                    };
                    tutoriaViewModel.Add(datosTutoria);
                }
            }
        }
    }
}
