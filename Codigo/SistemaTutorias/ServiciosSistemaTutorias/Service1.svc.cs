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

        public bool registrarTutoriaAcademica(TutoriasAcademicas tutoriaNueva)
        {
            return TutoriasAcademicasDAO.registrarTutoriaAcademica(tutoriaNueva);
        }
    }
}
