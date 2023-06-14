using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ClienteSistemaTutorias.Modelo
{
    [DataContract]
    internal class DatosTutoria
    {
        [DataMember]
        public System.DateTime fecha { get; set; }

        [DataMember]
        public int numSesion { get; set; }

        [DataMember]
        public string periodoEscolar { get; set; }

        [DataMember]
        public string fechaCierre { get; set; }

        [DataMember]
        public int idTutoria { get; set; }
    }
}
