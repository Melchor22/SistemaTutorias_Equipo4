using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace ServiciosSistemaTutorias.Modelo
{
    public class RolesAcademicosDAO
    {
        public static Mensaje iniciarSesion(string username, string password)
        {
            DataClassesSistemaTutoriasDataContext conexionBD = getConnection();
            Mensaje mensaje = new Mensaje();
            Console.WriteLine("Debug: username:" + username);
            Console.WriteLine("Debug: password:" + password);
            var usuario = (from rolAcademico in conexionBD.RolesAcademicos
                           where rolAcademico.NumPersonal == username && rolAcademico.Password == password
                           select rolAcademico).FirstOrDefault();
            if (usuario != null)
            {
                mensaje.error = false;
                mensaje.mensaje = "Usuario NO encontrado. Verifica tus credenciales.";
                mensaje.usuarioLogin = usuario;
                Console.WriteLine("Debug: NumPersonal:" + usuario.NumPersonal);
            }
            else
            {
                mensaje.error = true;
                mensaje.mensaje = "Usuario NO encontrado. Verifica tus credenciales.";
            }
            return mensaje;
        }

        public static DataClassesSistemaTutoriasDataContext getConnection()
        {
            return new DataClassesSistemaTutoriasDataContext(global::System.Configuration.ConfigurationManager.ConnectionStrings["SistemaTutoriasConnectionString"].ConnectionString);
        }
    }
}