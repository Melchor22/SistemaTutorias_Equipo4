using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace ServiciosSistemaTutorias.Modelo
{
    public class TutoriasAcademicasEstudiantesDAO
    {
        public static TutoriasAcademicasEstudiantes obtenerTutoriaAcademicaEstudianteParaProblematica(int IDTutoria, string matricula)
        {
            try
            {
                DataClassesSistemaTutoriasDataContext conexionBD = getConnection();

                var tutoriasAcademicasEstudiantesBD = (from tutoriaestudiante in conexionBD.TutoriasAcademicasEstudiantes
                                                      where tutoriaestudiante.IDTutoriaAcademica == IDTutoria && tutoriaestudiante.Matricula == matricula
                                                      select tutoriaestudiante).FirstOrDefault();

                TutoriasAcademicasEstudiantes tutoriaEstudianteObtenida = new TutoriasAcademicasEstudiantes()
                {
                    IDTutoriaAcademicaestudiante = tutoriasAcademicasEstudiantesBD.IDTutoriaAcademicaestudiante,
                    IDTutoriaAcademica = tutoriasAcademicasEstudiantesBD.IDTutoriaAcademica,
                    Matricula = tutoriasAcademicasEstudiantesBD.Matricula
                };

                return tutoriaEstudianteObtenida;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                return null;
            }
        }

        public static DataClassesSistemaTutoriasDataContext getConnection()
        {
            return new DataClassesSistemaTutoriasDataContext(global::System.Configuration.ConfigurationManager.ConnectionStrings["SistemaTutoriasConnectionString"].ConnectionString);
        }
    }
}