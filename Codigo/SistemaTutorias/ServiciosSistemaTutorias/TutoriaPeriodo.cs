using ServiciosSistemaTutorias.Modelo;
using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ServiciosSistemaTutorias
{
    [DataContract]
    public class TutoriaPeriodo
    {
        [DataMember]
        public TutoriasAcademicas tutoria { get; set; }
        [DataMember]
        public PeriodosEscolares periodoEscolar { get; set; }
    }
}