using ServiciosSistemaTutorias.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ServiciosSistemaTutorias
{
    [DataContract]
    public class DatosProblematicaAcademica
    {

        [DataMember]
        public ProblematicasAcademicas problematicaAcademica { get; set; }

        [DataMember]
        public TutoriasAcademicasEstudiantes tutoriaAcademicaEstudiante { get; set; }

        [DataMember]
        public Estudiantes estudiante { get; set; }

        [DataMember]
        public CategoriasProblematica categoriaProblematica { get; set; }

        [DataMember]
        public ExperienciasEducativas experienciaEducativa { get; set; }
    }
}