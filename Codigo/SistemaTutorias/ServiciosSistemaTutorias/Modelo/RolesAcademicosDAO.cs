using System;
using System.Collections.Generic;
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

        public static DataClassesSistemaTutoriasDataContext getConnection()
        {
            return new DataClassesSistemaTutoriasDataContext(global::System.Configuration.ConfigurationManager.ConnectionStrings["SistemaTutoriasConnectionString"].ConnectionString);
        }
    }
}