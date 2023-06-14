using ServiciosSistemaTutorias.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ServiciosSistemaTutorias
{
    [DataContract]
    public class DatosTutor
    {
        [DataMember]
        public Academicos academicoTutor { get; set; }

        [DataMember]
        public RolesAcademicos rolAcademicoTutor { get; set; }
    }
}