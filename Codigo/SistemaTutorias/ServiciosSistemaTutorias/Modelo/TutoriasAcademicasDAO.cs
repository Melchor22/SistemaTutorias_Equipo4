using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Web;

namespace ServiciosSistemaTutorias.Modelo
{
    public class TutoriasAcademicasDAO
    {
        public static Boolean registrarTutoriaAcademica(DateTime FechaTutoria, int NumSesionTutoria, int IDPeriodoEscolarTutoria, int IDRolAcademicoTutoria)
        {
            try
            {
                DataClassesSistemaTutoriasDataContext conexionBD = getConnection();

                var tutoria = new TutoriasAcademicas()
                {
                    Fecha = FechaTutoria,
                    NumSesion = NumSesionTutoria,
                    IDPeriodoEscolar = IDPeriodoEscolarTutoria,
                    IDRolAcademico = IDRolAcademicoTutoria
                };
                conexionBD.TutoriasAcademicas.InsertOnSubmit(tutoria);
                conexionBD.SubmitChanges();

                return true;
            }catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                return false;
            }
        }

        public static TutoriaPeriodo[] obtenerTutoriasAcademicas(int IDRolAcademico)
        {
            DataClassesSistemaTutoriasDataContext conexionBD = getConnection();
            var tutoriasAcademicasBD = from tutoriaBD in conexionBD.TutoriasAcademicas
                                       join periodoBD in conexionBD.PeriodosEscolares on tutoriaBD.IDPeriodoEscolar equals periodoBD.IDPeriodoEscolar
                                       where tutoriaBD.IDRolAcademico == IDRolAcademico
                                       select new { tutoriaBD, periodoBD };

            List<TutoriaPeriodo> tutoriasBD = new List<TutoriaPeriodo>();

            foreach (var t in tutoriasAcademicasBD)
            {
                TutoriaPeriodo tutoriaPeriodo = new TutoriaPeriodo
                {
                    tutoria = new TutoriasAcademicas
                    {
                        IDTutoriaAcademica = t.tutoriaBD.IDTutoriaAcademica,
                        Duracion = t.tutoriaBD.Duracion,
                        Fecha = t.tutoriaBD.Fecha,
                        NumSesion = t.tutoriaBD.NumSesion,
                        IDRolAcademico = t.tutoriaBD.NumSesion,
                        IDReporteTutoria = t.tutoriaBD.IDReporteTutoria,
                        IDPeriodoEscolar = t.tutoriaBD.IDPeriodoEscolar,
                        FechaCierre = t.tutoriaBD.FechaCierre
                    },
                    periodoEscolar = new PeriodosEscolares
                    {
                        IDPeriodoEscolar = t.periodoBD.IDPeriodoEscolar,
                        FechaInicio = t.periodoBD.FechaInicio,
                        FechaFin = t.periodoBD.FechaFin
                    }
                };
                tutoriasBD.Add(tutoriaPeriodo);
            }

            return tutoriasBD.ToArray();
        }

        public static TutoriaPeriodo consultarTutoriaAcademica(int IDTutoria)
        {
            DataClassesSistemaTutoriasDataContext conexionBD = getConnection();
            var tutoriasAcademicasBD = (from tutoriaBD in conexionBD.TutoriasAcademicas
                                       join periodoBD in conexionBD.PeriodosEscolares on tutoriaBD.IDPeriodoEscolar equals periodoBD.IDPeriodoEscolar
                                       where tutoriaBD.IDTutoriaAcademica == IDTutoria
                                       select new { tutoriaBD, periodoBD }).FirstOrDefault();

            TutoriaPeriodo tutoriaPeriodo = new TutoriaPeriodo
            {
                tutoria = new TutoriasAcademicas
                {
                    IDTutoriaAcademica = tutoriasAcademicasBD.tutoriaBD.IDTutoriaAcademica,
                    Duracion = tutoriasAcademicasBD.tutoriaBD.Duracion,
                    Fecha = tutoriasAcademicasBD.tutoriaBD.Fecha,
                    NumSesion = tutoriasAcademicasBD.tutoriaBD.NumSesion,
                    IDRolAcademico = tutoriasAcademicasBD.tutoriaBD.IDRolAcademico,
                    IDReporteTutoria = tutoriasAcademicasBD.tutoriaBD.IDReporteTutoria,
                    IDPeriodoEscolar = tutoriasAcademicasBD.tutoriaBD.IDPeriodoEscolar
                },
                periodoEscolar = new PeriodosEscolares
                {
                    IDPeriodoEscolar = tutoriasAcademicasBD.periodoBD.IDPeriodoEscolar,
                    FechaInicio = tutoriasAcademicasBD.periodoBD.FechaInicio,
                    FechaFin = tutoriasAcademicasBD.periodoBD.FechaFin
                }
            };

            return tutoriaPeriodo;
        }

        public static bool modificarTutoriaAcademica(int IDTutoria, DateTime FechaTutoria, int NumSesionTutoria, int IDPeriodoEscolarTutoria, int IDRolAcademicoTutoria)
        {
            try
            {
                DataClassesSistemaTutoriasDataContext conexionBD = getConnection();

                var tutoriaModificar = (from tutoriaBD in conexionBD.TutoriasAcademicas
                                       where tutoriaBD.IDTutoriaAcademica == IDTutoria
                                       select tutoriaBD).FirstOrDefault();

                if (tutoriaModificar != null)
                {
                    tutoriaModificar.Fecha = FechaTutoria;
                    tutoriaModificar.NumSesion = NumSesionTutoria;
                    tutoriaModificar.IDPeriodoEscolar = IDPeriodoEscolarTutoria;
                    tutoriaModificar.IDRolAcademico = IDRolAcademicoTutoria;

                    conexionBD.SubmitChanges();
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static bool modificarFechaCierre(int idTutoria, DateTime FechaCierre)
        {
            try
            {
                DataClassesSistemaTutoriasDataContext conexionBD = getConnection();

                var tutoriaModificarFechaCierre = (from tutoriaModificar in conexionBD.TutoriasAcademicas
                                        where tutoriaModificar.IDTutoriaAcademica == idTutoria
                                        select tutoriaModificar).FirstOrDefault();

                if (tutoriaModificarFechaCierre != null)
                {
                    tutoriaModificarFechaCierre.FechaCierre = FechaCierre;

                    conexionBD.SubmitChanges();
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public static DataClassesSistemaTutoriasDataContext getConnection()
        {
            return new DataClassesSistemaTutoriasDataContext(global::System.Configuration.ConfigurationManager.ConnectionStrings["SistemaTutoriasConnectionString"].ConnectionString);
        }
    }
}