﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ClienteSistemaTutorias.Modelo
{
    [DataContract]
    internal class DatosTutor
    {
        [DataMember]
        public string idRolAcademico { get; set; }

        [DataMember]
        public string numPersonal { get; set; }

        [DataMember]
        public string nombre { get; set; }

        [DataMember]
        public string apellidoPaterno { get; set; }

        [DataMember]
        public string apellidoMaterno { get; set; }
    }
}
