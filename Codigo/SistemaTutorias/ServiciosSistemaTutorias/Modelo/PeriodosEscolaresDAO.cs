using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiciosSistemaTutorias.Modelo
{
    public class PeriodosEscolaresDAO
    {
        public static List<PeriodosEscolares> obtenerPeriodosEscolares()
        {
            DataClassesSistemaTutoriasDataContext conexionBD = getConnection();
            var periodosEscolaresBD = from periodoBD in conexionBD.PeriodosEscolares
                                      select periodoBD;
            
            List<PeriodosEscolares> periodosObtenidos = new List<PeriodosEscolares>();
            foreach (var item in periodosEscolaresBD)
            {
                PeriodosEscolares periodoBucle = new PeriodosEscolares
                {
                    IDPeriodoEscolar = item.IDPeriodoEscolar,
                    FechaInicio = item.FechaInicio,
                    FechaFin = item.FechaFin,
                };
                periodosObtenidos.Add(periodoBucle);
            }
            return periodosObtenidos;
        }
        public static DataClassesSistemaTutoriasDataContext getConnection()
        {
            return new DataClassesSistemaTutoriasDataContext(global::System.Configuration.ConfigurationManager.ConnectionStrings["SistemaTutoriasConnectionString"].ConnectionString);
        }
    }
}