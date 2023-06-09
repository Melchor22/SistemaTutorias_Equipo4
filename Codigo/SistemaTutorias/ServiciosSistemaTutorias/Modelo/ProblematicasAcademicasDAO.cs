﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace ServiciosSistemaTutorias.Modelo
{
    public class ProblematicasAcademicasDAO
    {
        public static DatosProblematicaAcademica[] obtenerProblematicasAcademicas(int IDTutoriaAcademicaCliente)
        {
            DataClassesSistemaTutoriasDataContext conexionBD = getConnection();
            var datosProblematicaBD = from problematicaAcademicaBD in conexionBD.ProblematicasAcademicas
                                    join tutoriaAcademicaEstudianteBD in conexionBD.TutoriasAcademicasEstudiantes on problematicaAcademicaBD.IDTutoriaAcademicaEstudiante equals tutoriaAcademicaEstudianteBD.IDTutoriaAcademicaestudiante
                                    join estudianteBD in conexionBD.Estudiantes on tutoriaAcademicaEstudianteBD.Matricula equals estudianteBD.Matricula
                                    join categoriaProblematicaBD in conexionBD.CategoriasProblematica on problematicaAcademicaBD.IDCategoria equals categoriaProblematicaBD.IDCategoria
                                    join experienciaEducativaBD in conexionBD.ExperienciasEducativas on problematicaAcademicaBD.NRC equals experienciaEducativaBD.NRC
                                    where tutoriaAcademicaEstudianteBD.IDTutoriaAcademica == IDTutoriaAcademicaCliente
                                    select new { problematicaAcademicaBD, tutoriaAcademicaEstudianteBD, estudianteBD, categoriaProblematicaBD, experienciaEducativaBD};
            
            List<DatosProblematicaAcademica> problematicaBD = new List<DatosProblematicaAcademica> ();

            foreach (var problematicaObtenidaBD in datosProblematicaBD)
            {
                DatosProblematicaAcademica datosProblematica = new DatosProblematicaAcademica
                {
                    
                    problematicaAcademica = new ProblematicasAcademicas
                    {
                        IDProblematicaAcademica = problematicaObtenidaBD.problematicaAcademicaBD.IDProblematicaAcademica,
                        Estado = problematicaObtenidaBD.problematicaAcademicaBD.Estado,
                        Descripcion = problematicaObtenidaBD.problematicaAcademicaBD.Descripcion,
                        IDCategoria = problematicaObtenidaBD.problematicaAcademicaBD.IDCategoria,
                        IDTutoriaAcademicaEstudiante = problematicaObtenidaBD.problematicaAcademicaBD.IDTutoriaAcademicaEstudiante,
                        NRC = problematicaObtenidaBD.problematicaAcademicaBD.NRC
                    },
                    tutoriaAcademicaEstudiante = new TutoriasAcademicasEstudiantes
                    {
                        IDTutoriaAcademicaestudiante = problematicaObtenidaBD.tutoriaAcademicaEstudianteBD.IDTutoriaAcademicaestudiante,
                        IDTutoriaAcademica = problematicaObtenidaBD.tutoriaAcademicaEstudianteBD.IDTutoriaAcademica,
                        Matricula = problematicaObtenidaBD.tutoriaAcademicaEstudianteBD.Matricula
                    },
                    estudiante = new Estudiantes
                    {
                        Matricula = problematicaObtenidaBD.estudianteBD.Matricula,
                        Nombres = problematicaObtenidaBD.estudianteBD.Nombres,
                        ApellidoPaterno = problematicaObtenidaBD.estudianteBD.ApellidoPaterno,
                        ApellidoMaterno = problematicaObtenidaBD.estudianteBD.ApellidoMaterno,
                        Correo = problematicaObtenidaBD.estudianteBD.Correo,
                        Telefono = problematicaObtenidaBD.estudianteBD.Telefono,
                        IDProgramaEducativo = problematicaObtenidaBD.estudianteBD.IDProgramaEducativo,
                        Tutor = problematicaObtenidaBD.estudianteBD.Tutor
                    },
                    categoriaProblematica = new CategoriasProblematica
                    {
                        IDCategoria = problematicaObtenidaBD.categoriaProblematicaBD.IDCategoria,
                        Tipo = problematicaObtenidaBD.categoriaProblematicaBD.Tipo
                    },
                    experienciaEducativa = new ExperienciasEducativas
                    {
                        NRC = problematicaObtenidaBD.experienciaEducativaBD.NRC,
                        Nombre = problematicaObtenidaBD.experienciaEducativaBD.Nombre,
                        Creditos = problematicaObtenidaBD.experienciaEducativaBD.Creditos,
                        NumPersonal = problematicaObtenidaBD.experienciaEducativaBD.NumPersonal
                    }
                };
                problematicaBD.Add(datosProblematica);
            }
            return problematicaBD.ToArray();
        }

        public static bool registrarProblematicaAcademica(int IDTutoria, string matriculaEstudiante, int IDCategoria, int NRC, string descripcion)
        {
            try
            {
                DataClassesSistemaTutoriasDataContext conexionBD = getConnection();

                ProblematicasAcademicas problematicaNueva = new ProblematicasAcademicas
                {
                    Estado = "Pendiente",
                    Descripcion = descripcion,
                    IDCategoria = IDCategoria,
                    IDTutoriaAcademicaEstudiante = TutoriasAcademicasEstudiantesDAO.obtenerTutoriaAcademicaEstudianteParaProblematica(IDTutoria, matriculaEstudiante).IDTutoriaAcademicaestudiante,
                    NRC = NRC
                };
                
                conexionBD.ProblematicasAcademicas.InsertOnSubmit(problematicaNueva);
                conexionBD.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static string obtenerSolucionProblematica(int IDProblematica)
        {
            DataClassesSistemaTutoriasDataContext conexionBD = getConnection();
            var problematicaObtenida = (from problematica in conexionBD.ProblematicasAcademicas
                                   where problematica.IDProblematicaAcademica == IDProblematica
                                   select problematica).FirstOrDefault();
            string solucionObtenida = problematicaObtenida.Solucion;
            return solucionObtenida;
        }

        public static bool registrarSolucionProblematica(int IDProblematica, string solucion)
        {
            DataClassesSistemaTutoriasDataContext conexionBD = getConnection();
            var problematicaObtenida = (from problematica in conexionBD.ProblematicasAcademicas
                                        where problematica.IDProblematicaAcademica == IDProblematica
                                        select problematica).FirstOrDefault();

            problematicaObtenida.Solucion = solucion;
            problematicaObtenida.Estado = "Resuelto";

            try
            {
                conexionBD.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return false;
            }

        }

        public static DataClassesSistemaTutoriasDataContext getConnection()
        {
            return new DataClassesSistemaTutoriasDataContext(global::System.Configuration.ConfigurationManager.ConnectionStrings["SistemaTutoriasConnectionString"].ConnectionString);
        }
    }
}