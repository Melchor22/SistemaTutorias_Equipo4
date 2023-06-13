﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace ServiciosSistemaTutorias.Modelo
{
    public class RolesAcademicosDAO
    {
        public static MensajeInicioSesion iniciarSesion(string username, string password)
        {
            DataClassesSistemaTutoriasDataContext conexionBD = getConnection();
            MensajeInicioSesion mensajeSesion = new MensajeInicioSesion();
            var rolacAcademicoBD = (from rolAcademico in conexionBD.RolesAcademicos
                                    join academico in conexionBD.Academicos on rolAcademico.NumPersonal equals academico.NumPersonal
                                    where rolAcademico.NumPersonal == username && rolAcademico.Password == password
                                    select new {rolAcademico, academico}).FirstOrDefault();
            if (rolacAcademicoBD != null)
            {
                mensajeSesion = new MensajeInicioSesion()
                {
                    error = false,
                    mensaje = "Usuario Encontrado",
                    usuarioRolAcademico = new RolesAcademicos()
                    {
                        IDRolAcademico = rolacAcademicoBD.rolAcademico.IDRolAcademico,
                        NumPersonal = rolacAcademicoBD.rolAcademico.NumPersonal,
                        Password = rolacAcademicoBD.rolAcademico.Password,
                        IDRol = rolacAcademicoBD.rolAcademico.IDRol
                    },
                    usuarioAcademico = new Academicos()
                    {
                        NumPersonal = rolacAcademicoBD.academico.NumPersonal,
                        Nombres = rolacAcademicoBD.academico.Nombres,
                        ApellidoPaterno = rolacAcademicoBD.academico.ApellidoPaterno,
                        ApellidoMaterno = rolacAcademicoBD.academico.ApellidoMaterno,
                        Correo = rolacAcademicoBD.academico.Correo,
                        Telefono = rolacAcademicoBD.academico.Telefono
                    }
                };
            }
            else
            {
                mensajeSesion.error = true;
                mensajeSesion.mensaje = "Usuario NO encontrado. Verifica tus credenciales.";
            }
            return mensajeSesion;
        }

        public static Boolean registrarRolAcademico(string numPersonal, string password, int idRol)
        {
            try
            {

                DataClassesSistemaTutoriasDataContext conexionBD = getConnection();

                var rolAcademicoNuevo = new RolesAcademicos()
                {
                    NumPersonal = numPersonal,
                    Password = password,
                    IDRol = idRol
                };

                conexionBD.RolesAcademicos.InsertOnSubmit(rolAcademicoNuevo);
                conexionBD.SubmitChanges();
                return true;

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                return false;
            }
        }

        public static List<RolesAcademicos> obtenerTutores()
        {
            DataClassesSistemaTutoriasDataContext conexionBD = getConnection();
            var tutores = from tutor in conexionBD.RolesAcademicos
                           join academico in conexionBD.Academicos on tutor.NumPersonal equals academico.NumPersonal
                           where tutor.IDRol == 3
                           select new { tutor, academico };

            List<RolesAcademicos> tutoresObtenidos = new List<RolesAcademicos>();

            foreach (var item in tutores)
            {
                RolesAcademicos tutoresBucle = new RolesAcademicos()
                {
                    IDRolAcademico = item.tutor.IDRolAcademico,
                    NumPersonal = item.tutor.NumPersonal,
                    Password = item.tutor.Password,
                    IDRol = item.tutor.IDRol,
                };

                Academicos academicosBucle = new Academicos()
                {
                    NumPersonal = item.academico.NumPersonal,
                    Nombres = item.academico.Nombres,
                    ApellidoPaterno = item.academico.ApellidoPaterno,
                    ApellidoMaterno = item.academico.ApellidoMaterno,
                    Correo = item.academico.Correo,
                    Telefono = item.academico.Telefono
                };
                tutoresObtenidos.Add(tutoresBucle);
            }
            return tutoresObtenidos;
        }

        public static DataClassesSistemaTutoriasDataContext getConnection()
        {
            return new DataClassesSistemaTutoriasDataContext(global::System.Configuration.ConfigurationManager.ConnectionStrings["SistemaTutoriasConnectionString"].ConnectionString);
        }
    }
}