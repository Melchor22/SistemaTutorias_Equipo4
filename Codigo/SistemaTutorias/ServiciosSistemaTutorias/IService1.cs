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

        [OperationContract]
        TutoriaPeriodo consultarTutoriaAcademica(int IDTutoria);

        [OperationContract]
        bool modificarTutoriaAcademica(int IDTutoria, DateTime FechaTutoria, int NumSesionTutoria, int IDPeriodoEscolarTutoria, int IDRolAcademicoTutoria);
        
        [OperationContract]
        bool registrarEstudiante(string matricula, string nombre, string apellidoPaterno, string apellidoMaterno, string correo, string telefono, int idProgramaEducativo);
        
        [OperationContract]
        List<ProgramasEducativos> obtenerProgramaEducativos();
        
        [OperationContract]
        Boolean registrarRolAcademico(string numPersonal, string password, int idRol);
        
        [OperationContract]
        List<Academicos> obtenerAcademicos();
        
        [OperationContract]
        List<Estudiantes> obtenerEstudiantes();
        
        [OperationContract]
        Boolean asignarTutor(string matricula, int idTutor);
        
        [OperationContract]
        DatosTutor[] obtenerTutores();

        [OperationContract]
        DatosProblematicaAcademica[] obtenerProblematicasAcademicas(int IDTutoriaAcademica);

        [OperationContract]
        bool modificarFechaCierre(int idTutoria, DateTime FechaCierre);

        [OperationContract]
        List<Estudiantes> obtenerEstudiantesPorTutoria(int IDTutoriaAcademica);

        [OperationContract]
        List<CategoriasProblematica> obtenerCategoriasProblematica();

        [OperationContract]
        bool registrarProblematicaAcademica(int IDTutoria, string matriculaEstudiante, int IDCategoria, int NRC, string descripcion);

        [OperationContract]
        string obtenerSolucionProblematica(int IDProblematica);

        [OperationContract]
        bool registrarSolucionProblematica(int IDProblematica, string solucion);

        [OperationContract]
        ReportesTutoria obtenerReporte(int idRolAcademico, int numSesion, int idPeriodo);
    }
}
