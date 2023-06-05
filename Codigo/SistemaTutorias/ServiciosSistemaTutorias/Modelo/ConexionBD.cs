using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiciosSistemaTutorias.Modelo
{
    public class ConexionBD
    {
        private static ConexionBD instance;
        private static readonly object lockObject = new object();
        private DataClassesSistemaTutoriasDataContext conexionSQL;

        private ConexionBD()
        {
            conexionSQL = new DataClassesSistemaTutoriasDataContext(global::System.Configuration.ConfigurationManager.ConnectionStrings["SistemaTutoriasConnectionString"].ConnectionString);
        }

        public static ConexionBD GetInstance()
        {
            if (instance == null)
            {
                lock (lockObject)
                {
                    if (instance == null)
                    {
                        instance = new ConexionBD();
                    }
                }
            }

            return instance;
        }

        public DataClassesSistemaTutoriasDataContext getConnection()
        {
            return conexionSQL;
        }

        public static DataClassesSistemaTutoriasDataContext CONNECTION
        {
            get { return GetInstance().getConnection(); }
        }
    }
}