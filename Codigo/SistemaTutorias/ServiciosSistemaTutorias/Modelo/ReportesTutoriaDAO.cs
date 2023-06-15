using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace ServiciosSistemaTutorias.Modelo
{
    public class ReportesTutoriaDAO
    {
        public static bool registrarReporteTutoria(string descripcion, string comentariosGenerales, int IDTutoriaAcademica)
        {
            try
            {
                DataClassesSistemaTutoriasDataContext conexionBD = getConnection();

                var reporteTutoria = new ReportesTutoria()
                {
                    Descripcion = descripcion,
                    ComentarioGeneral = comentariosGenerales,
                    IDTutoriaAcademica = IDTutoriaAcademica
                };

                conexionBD.ReportesTutoria.InsertOnSubmit(reporteTutoria);
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