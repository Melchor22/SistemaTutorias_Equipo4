using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace ServiciosSistemaTutorias.Modelo
{
    public class ReportesTutoriaDAO
    {
        public static bool registrarReporteTutoria(string descripcion, string comentariosGenerales, int IDTutoriaAcademica)
        {
            try
            {
                DataClassesSistemaTutoriasDataContext conexionBD = getConnection();

                var reporteTutoria = new ReportesTutoria()
                {
                    Descripcion = descripcion,
                    ComentarioGeneral = comentariosGenerales,
                    IDTutoriaAcademica = IDTutoriaAcademica
                };

                conexionBD.ReportesTutoria.InsertOnSubmit(reporteTutoria);
                conexionBD.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                return false;
            }
        }

        public static ReportesTutoria obtenerReporte(int idRolAcademico, int numSesion, int idPeriodo)
        {
            DataClassesSistemaTutoriasDataContext conexionBD = getConnection();

            var reporteTutor = (from reporte in conexionBD.ReportesTutoria
                                join tutoriaAcademicaBD in conexionBD.TutoriasAcademicas on reporte.IDTutoriaAcademica equals tutoriaAcademicaBD.IDTutoriaAcademica
                                join rolAcademicoBD in conexionBD.RolesAcademicos on tutoriaAcademicaBD.IDRolAcademico equals rolAcademicoBD.IDRolAcademico
                                where tutoriaAcademicaBD.NumSesion == numSesion || tutoriaAcademicaBD.IDPeriodoEscolar == idPeriodo || rolAcademicoBD.IDRolAcademico == idRolAcademico
                                select reporte).FirstOrDefault();

            ReportesTutoria reporteObtenido = new ReportesTutoria()
            {
                IDTutoriaAcademica = reporteTutor.IDTutoriaAcademica,
                Descripcion = reporteTutor.Descripcion,
                ComentarioGeneral = reporteTutor.ComentarioGeneral,
                IDReporteTutoria = reporteTutor.IDReporteTutoria
            };

            return reporteObtenido;
        }
        public static DataClassesSistemaTutoriasDataContext getConnection()
        {
            return new DataClassesSistemaTutoriasDataContext(global::System.Configuration.ConfigurationManager.ConnectionStrings["SistemaTutoriasConnectionString"].ConnectionString);
        }
    }
}