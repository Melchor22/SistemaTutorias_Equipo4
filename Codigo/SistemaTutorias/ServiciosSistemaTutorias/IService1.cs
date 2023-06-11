using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using ServiciosSistemaTutorias.Modelo;

namespace ServiciosSistemaTutorias
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        MensajeInicioSesion iniciarSesion(string username, string password);

        [OperationContract]
        TutoriaPeriodo[] obtenerTutoriasAcademicas(int IDRolAcademico);

        [OperationContract]
        List<PeriodosEscolares> obtenerPeriodosEscolares();

        [OperationContract]
        Boolean registrarTutoriaAcademica(DateTime FechaTutoria, int NumSesionTutoria, int IDPeriodoEscolarTutoria, int IDRolAcademicoTutoria);

        [OperationContract]
        bool registrarReporteTutoria(string descripcion, string comentariosGenerales, int IDTutoriaAcademica);
    }
}
