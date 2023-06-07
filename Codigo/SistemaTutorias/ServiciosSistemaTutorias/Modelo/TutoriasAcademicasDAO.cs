using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace ServiciosSistemaTutorias.Modelo
{
    public class TutoriasAcademicasDAO
    {
        public static Boolean registrarTutoriaAcademica(TutoriasAcademicas tutoriaNueva)
        {
            try
            {
                DataClassesSistemaTutoriasDataContext conexionBD = getConnection();
                PeriodosEscolares periodoTutoria = conexionBD.PeriodosEscolares.First(em => em.IDPeriodoEscolar.Equals(tutoriaNueva.IDPeriodoEscolar));
                RolesAcademicos rolAcademicoTutoria = conexionBD.RolesAcademicos.First(em => em.IDRolAcademico.Equals(tutoriaNueva.IDRolAcademico));
                var tutoria = new TutoriasAcademicas()
                {
                    Fecha = tutoriaNueva.Fecha,
                    NumSesion = tutoriaNueva.NumSesion,
                    IDPeriodoEscolar = periodoTutoria.IDPeriodoEscolar,
                    IDRolAcademico = rolAcademicoTutoria.IDRolAcademico
                };
                Debug.WriteLine("Despues de crear tutoria");
                Debug.WriteLine(tutoria.Fecha.ToString());
                Debug.WriteLine(tutoria.NumSesion);
                Debug.WriteLine(tutoria.IDPeriodoEscolar);
                Debug.WriteLine(tutoria.IDRolAcademico);
                conexionBD.TutoriasAcademicas.InsertOnSubmit(tutoria);
                Debug.WriteLine("Despues de insertonsubmit");
                conexionBD.SubmitChanges();
                Debug.WriteLine("Despues de submit on changes");

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
                        IDPeriodoEscolar = t.tutoriaBD.IDPeriodoEscolar
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

        public static DataClassesSistemaTutoriasDataContext getConnection()
        {
            return new DataClassesSistemaTutoriasDataContext(global::System.Configuration.ConfigurationManager.ConnectionStrings["SistemaTutoriasConnectionString"].ConnectionString);
        }
    }
}