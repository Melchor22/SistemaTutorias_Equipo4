using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiciosSistemaTutorias.Modelo
{
    public class ProgramaEducativosDAO
    {
        public static List<ProgramasEducativos> obtenerProgramaEducativos()
        {
            DataClassesSistemaTutoriasDataContext conexionBD = getConnection();
            var programaEducativosBD = from programaBD in conexionBD.ProgramasEducativos
                                      select programaBD;

            List<ProgramasEducativos> programasObtenidos = new List<ProgramasEducativos>();
            foreach (var item in programaEducativosBD)
            {
                ProgramasEducativos programasBucle = new ProgramasEducativos()
                {
                    IDProgramaEducativo = item.IDProgramaEducativo,
                    Nombre = item.Nombre,
                    IDAreaAcademica = item.IDAreaAcademica
                };
                programasObtenidos.Add(programasBucle);
            }
            return programasObtenidos;
        }
        public static DataClassesSistemaTutoriasDataContext getConnection()
        {
            return new DataClassesSistemaTutoriasDataContext(global::System.Configuration.ConfigurationManager.ConnectionStrings["SistemaTutoriasConnectionString"].ConnectionString);
        }
    }
}