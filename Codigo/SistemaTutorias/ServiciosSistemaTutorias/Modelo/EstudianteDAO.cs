using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace ServiciosSistemaTutorias.Modelo
{
    public class EstudianteDAO
    {
        public static Boolean registrarEstudiante(string matricula, string nombre, string apellidoPaterno, string apellidoMaterno, string correo, string telefono, int idProgramaEducativo)
        {
            try
            {
                DataClassesSistemaTutoriasDataContext conexionBD = getConnection();

                var estudianteNuevo = new Estudiantes()
                {
                    Matricula = matricula,
                    Nombres = nombre,
                    ApellidoPaterno = apellidoPaterno,
                    ApellidoMaterno = apellidoMaterno,
                    Correo = correo,
                    Telefono = telefono,
                    IDProgramaEducativo = idProgramaEducativo

                };

                conexionBD.Estudiantes.InsertOnSubmit(estudianteNuevo);
                conexionBD.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                return false;
            }
        }

        public static List<Estudiantes> obtenerEstudiantes()
        {
            DataClassesSistemaTutoriasDataContext conexionBD = getConnection();

            var estudiantesBD = from estudiante in conexionBD.Estudiantes
                               select estudiante;
            List<Estudiantes> estudiantesObtenidos = new List<Estudiantes>();
            foreach (var item in estudiantesBD)
            {
                Estudiantes estudianteBucle = new Estudiantes()
                {
                    Matricula = item.Matricula,
                    Nombres = item.Nombres,
                    ApellidoPaterno = item.ApellidoPaterno,
                    ApellidoMaterno = item.ApellidoMaterno,
                    Correo = item.Correo,
                    Telefono = item.Telefono,
                    IDProgramaEducativo = item.IDProgramaEducativo,
                    Tutor = item.Tutor,
                };
                estudiantesObtenidos.Add(estudianteBucle);
            }
            return estudiantesObtenidos;
        }

        public static Boolean asignarTutor(string matricula, int idTutor)
        {
            try
            {
                DataClassesSistemaTutoriasDataContext conexionBD = getConnection();

                var asignacion = (from estudiante in conexionBD.Estudiantes
                                 where matricula == estudiante.Matricula
                                 select estudiante).FirstOrDefault();
                if( asignacion != null )
                {
                    asignacion.Tutor = idTutor;

                    conexionBD.SubmitChanges();
                    return true;
                }
                else {  return false; }


            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                return false;
            }
        }

        public static List<Estudiantes> obtenerEstudiantesPorTutoria(int IDTutoriaAcademica)
        {
            DataClassesSistemaTutoriasDataContext conexionBD = getConnection();

            var estudiantesBD = from tutoriaEstudiante in conexionBD.TutoriasAcademicasEstudiantes
                                join estudiante in conexionBD.Estudiantes on tutoriaEstudiante.Matricula equals estudiante.Matricula
                                where tutoriaEstudiante.IDTutoriaAcademica == IDTutoriaAcademica
                                select estudiante;
            List<Estudiantes> estudiantesObtenidos = new List<Estudiantes>();
            foreach (var item in estudiantesBD)
            {
                Estudiantes estudianteBucle = new Estudiantes()
                {
                    Matricula = item.Matricula,
                    Nombres = item.Nombres,
                    ApellidoPaterno = item.ApellidoPaterno,
                    ApellidoMaterno = item.ApellidoMaterno,
                    Correo = item.Correo,
                    Telefono = item.Telefono,
                    IDProgramaEducativo = item.IDProgramaEducativo,
                    Tutor = item.Tutor,
                };
                estudiantesObtenidos.Add(estudianteBucle);
            }
            return estudiantesObtenidos;
        }

        public static DataClassesSistemaTutoriasDataContext getConnection()
        {
            return new DataClassesSistemaTutoriasDataContext(global::System.Configuration.ConfigurationManager.ConnectionStrings["SistemaTutoriasConnectionString"].ConnectionString);
        }
    }
}