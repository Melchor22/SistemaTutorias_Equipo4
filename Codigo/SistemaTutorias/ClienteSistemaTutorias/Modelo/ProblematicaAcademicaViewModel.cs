using ServiceReference1;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClienteSistemaTutorias.Modelo
{
    internal class ProblematicaAcademicaViewModel
    {
        public ObservableCollection<DatosProblematica> problematicaViewModel { get; set; }

        public ProblematicaAcademicaViewModel(int IDTutoria)
        {
            problematicaViewModel = new ObservableCollection<DatosProblematica>();
            solicitarInformacionServicio(IDTutoria);
        }

        public async void solicitarInformacionServicio(int IDTutoria)
        {
            var conexionServicio = new Service1Client();
            if (conexionServicio != null)
            {
                DatosProblematicaAcademica[] problematicasServicio = await conexionServicio.obtenerProblematicasAcademicasAsync(IDTutoria);
                foreach (var problematica in problematicasServicio)
                {
                    DatosProblematica datosProblematica = new DatosProblematica()
                    {
                        IDProblematicaAcademica = problematica.problematicaAcademica.IDProblematicaAcademica,
                        matricula = problematica.estudiante.Matricula,
                        estudiante = (problematica.estudiante.Nombres + " " + problematica.estudiante.ApellidoPaterno + " " + problematica.estudiante.ApellidoMaterno),
                        IDCategoriaProblematica = problematica.categoriaProblematica.IDCategoria,
                        categoria = problematica.categoriaProblematica.Tipo,
                        estado = problematica.problematicaAcademica.Estado,
                        nrc = problematica.experienciaEducativa.NRC,
                        nombreExperienciaEducativa = problematica.experienciaEducativa.Nombre,
                        descripcion = problematica.problematicaAcademica.Descripcion
                    };
                    problematicaViewModel.Add(datosProblematica);
                }
            }
        }
    }
}
