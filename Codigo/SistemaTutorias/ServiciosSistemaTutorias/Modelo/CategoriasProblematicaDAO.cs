using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiciosSistemaTutorias.Modelo
{
    public class CategoriasProblematicaDAO
    {

        public static List<CategoriasProblematica> obtenerCategoriasProblematica()
        {
            DataClassesSistemaTutoriasDataContext conexionBD = getConnection();

            var categoriasObtenidasBD = from categoria in conexionBD.CategoriasProblematica
                                        select categoria;

            List<CategoriasProblematica> categoriasObtenidas = new List<CategoriasProblematica>();
            foreach (var categoria in categoriasObtenidasBD)
            {
                CategoriasProblematica categoriaBucle = new CategoriasProblematica
                {
                    IDCategoria = categoria.IDCategoria,
                    Tipo = categoria.Tipo
                };
                categoriasObtenidas.Add(categoriaBucle);
            }
            
            return categoriasObtenidas;
        }

        public static DataClassesSistemaTutoriasDataContext getConnection()
        {
            return new DataClassesSistemaTutoriasDataContext(global::System.Configuration.ConfigurationManager.ConnectionStrings["SistemaTutoriasConnectionString"].ConnectionString);
        }
    }
}