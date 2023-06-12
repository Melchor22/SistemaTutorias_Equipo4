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

        public static DataClassesSistemaTutoriasDataContext getConnection()
        {
            return new DataClassesSistemaTutoriasDataContext(global::System.Configuration.ConfigurationManager.ConnectionStrings["SistemaTutoriasConnectionString"].ConnectionString);
        }
    }
}