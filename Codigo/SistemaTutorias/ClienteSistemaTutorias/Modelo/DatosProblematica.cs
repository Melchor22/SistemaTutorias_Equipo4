using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ClienteSistemaTutorias.Modelo
{
    [DataContract]
    internal class DatosProblematica
    {
        [DataMember]
        public int IDProblematicaAcademica { get; set; }

        [DataMember]
        public string matricula { get; set; }

        [DataMember]
        public string estudiante { get; set; }

        [DataMember]
        public int IDCategoriaProblematica { get; set; }

        [DataMember]
        public string categoria { get; set; }

        [DataMember]
        public string estado { get; set; }

        [DataMember]
        public int nrc { get; set; }

        [DataMember]
        public string nombreExperienciaEducativa { get; set; }

        [DataMember]
        public string descripcion { get; set; }
    }
}
