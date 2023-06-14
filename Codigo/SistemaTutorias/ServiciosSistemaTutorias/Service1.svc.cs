using ServiciosSistemaTutorias.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ServiciosSistemaTutorias
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Service1 : IService1
    {
        public MensajeInicioSesion iniciarSesion(string username, string password)
        {
            return RolesAcademicosDAO.iniciarSesion(username, password);
        }

        public List<PeriodosEscolares> obtenerPeriodosEscolares()
        {
            return PeriodosEscolaresDAO.obtenerPeriodosEscolares();
        }

        public TutoriaPeriodo[] obtenerTutoriasAcademicas(int IDRolAcademico)
        {
            TutoriaPeriodo[] tutoriasObtenidas = TutoriasAcademicasDAO.obtenerTutoriasAcademicas(IDRolAcademico);
            return tutoriasObtenidas;
        }

        public bool registrarTutoriaAcademica(DateTime FechaTutoria, int NumSesionTutoria, int IDPeriodoEscolarTutoria, int IDRolAcademicoTutoria)
        {
            return TutoriasAcademicasDAO.registrarTutoriaAcademica(FechaTutoria, NumSesionTutoria, IDPeriodoEscolarTutoria, IDRolAcademicoTutoria);
        }

        public bool registrarReporteTutoria(string descripcion, string comentariosGenerales, int IDTutoriaAcademica)
        {
            return ReportesTutoriaDAO.registrarReporteTutoria(descripcion, comentariosGenerales, IDTutoriaAcademica);
        }

        public TutoriaPeriodo consultarTutoriaAcademica(int IDTutoria)
        {
            return TutoriasAcademicasDAO.consultarTutoriaAcademica(IDTutoria);
        }

        public bool modificarTutoriaAcademica(int IDTutoria, DateTime FechaTutoria, int NumSesionTutoria, int IDPeriodoEscolarTutoria, int IDRolAcademicoTutoria)
        {
            return TutoriasAcademicasDAO.modificarTutoriaAcademica(IDTutoria, FechaTutoria, NumSesionTutoria, IDPeriodoEscolarTutoria, IDRolAcademicoTutoria);
        }
        public bool registrarEstudiante(string matricula, string nombre, string apellidoPaterno, string apellidoMaterno, string correo, string telefono, int idProgramaEducativo)
        {
            return EstudianteDAO.registrarEstudiante(matricula, nombre, apellidoPaterno, apellidoMaterno, correo, telefono, idProgramaEducativo);
        }

        public List<ProgramasEducativos> obtenerProgramaEducativos()
        {
            return ProgramaEducativosDAO.obtenerProgramaEducativos();
        }

        public Boolean registrarRolAcademico(string numPersonal, string password, int idRol)
        {
            return RolesAcademicosDAO.registrarRolAcademico(numPersonal, password, idRol);
        }

        public List<Academicos> obtenerAcademicos()
        {
            return AcademicoDAO.obtenerAcademicos();
        }

        public List<Estudiantes> obtenerEstudiantes()
        {
            return EstudianteDAO.obtenerEstudiantes();
        }

        public Boolean asignarTutor(string matricula, int idTutor)
        {
            return EstudianteDAO.asignarTutor(matricula, idTutor);
        }

        public DatosTutor[] obtenerTutores()
        {
            return RolesAcademicosDAO.obtenerTutores();
        }

        public DatosProblematicaAcademica[] obtenerProblematicasAcademicas(int IDTutoriaAcademica)
        {
            return ProblematicasAcademicasDAO.obtenerProblematicasAcademicas(IDTutoriaAcademica);
        }

        public bool modificarFechaCierre(int idTutoria, DateTime FechaCierre)
        {
            return TutoriasAcademicasDAO.modificarFechaCierre(idTutoria, FechaCierre);
        }

        public List<Estudiantes> obtenerEstudiantesPorTutoria(int IDTutoriaAcademica)
        {
            return EstudianteDAO.obtenerEstudiantesPorTutoria(IDTutoriaAcademica);
        }

        public List<CategoriasProblematica> obtenerCategoriasProblematica()
        {
            return CategoriasProblematicaDAO.obtenerCategoriasProblematica();
        }

        public bool registrarProblematicaAcademica(int IDTutoria, string matriculaEstudiante, int IDCategoria, int NRC, string descripcion)
        {
            return ProblematicasAcademicasDAO.registrarProblematicaAcademica(IDTutoria, matriculaEstudiante, IDCategoria, NRC, descripcion);
        }
    }
}
