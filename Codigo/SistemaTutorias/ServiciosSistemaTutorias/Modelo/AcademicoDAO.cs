using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiciosSistemaTutorias.Modelo
{
    public class AcademicoDAO
    {
        public static List<Academicos> obtenerAcademicos()
        {
            DataClassesSistemaTutoriasDataContext conexionBD = getConnection();
            
            var academicosBD = from academico in conexionBD.Academicos
                               select academico;
            List<Academicos> academicosObtenidos = new List<Academicos>();
            foreach (var item in academicosBD)
            {
                Academicos academicoBucle = new Academicos()
                {
                    NumPersonal = item.NumPersonal,
                    Nombres = item.Nombres,
                    ApellidoPaterno = item.ApellidoPaterno,
                    ApellidoMaterno = item.ApellidoMaterno,
                    Correo = item.Correo,
                    Telefono = item.Telefono
                };
                academicosObtenidos.Add(academicoBucle);
            }
            return academicosObtenidos;
        }


        public static DataClassesSistemaTutoriasDataContext getConnection()
        {
            return new DataClassesSistemaTutoriasDataContext(global::System.Configuration.ConfigurationManager.ConnectionStrings["SistemaTutoriasConnectionString"].ConnectionString);
        }
    }
}