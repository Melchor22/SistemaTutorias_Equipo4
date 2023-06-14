using System;
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

        public static DatosTutor[] obtenerTutores()
        {
            DataClassesSistemaTutoriasDataContext conexionBD = getConnection();
            var tutores = from tutorBD in conexionBD.RolesAcademicos
                           join academicoBD in conexionBD.Academicos on tutorBD.NumPersonal equals academicoBD.NumPersonal
                           where tutorBD.IDRol == 3
                           select new { tutorBD, academicoBD };

            List<DatosTutor> tutoresObtenidos = new List<DatosTutor>();

            foreach (var item in tutores)
            {
                DatosTutor datosTutor = new DatosTutor
                {
                    academicoTutor = new Academicos
                    {
                       NumPersonal = item.academicoBD.NumPersonal,
                       Nombres = item.academicoBD.Nombres,
                       ApellidoPaterno = item.academicoBD.ApellidoPaterno,
                       ApellidoMaterno = item.academicoBD.ApellidoMaterno,
                       Correo = item.academicoBD.Correo,
                       Telefono = item.academicoBD.Telefono
                    },
                    rolAcademicoTutor = new RolesAcademicos
                    {
                        IDRolAcademico = item.tutorBD.IDRolAcademico,
                        Password = item.tutorBD.Password,
                        IDRol = item.tutorBD.IDRol,
                        NumPersonal = item.tutorBD.NumPersonal
                    }

                };
                tutoresObtenidos.Add(datosTutor);
            }
            return tutoresObtenidos.ToArray();
        }

        public static DataClassesSistemaTutoriasDataContext getConnection()
        {
            return new DataClassesSistemaTutoriasDataContext(global::System.Configuration.ConfigurationManager.ConnectionStrings["SistemaTutoriasConnectionString"].ConnectionString);
        }
    }
}