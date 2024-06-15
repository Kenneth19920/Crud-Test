using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Crud_Test
{
    /// <summary>
    /// Clase para manejar la interacción con la base de datos mediante procedimientos almacenados.
    /// </summary>
    public class DataAccess
    {
        // Cadena de conexión obtenida desde el archivo de configuración Web.config
        private static readonly string ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        /// <summary>
        /// Ejecuta un procedimiento almacenado y retorna un DataTable con los resultados.
        /// </summary>
        /// <param name="storedProcedureName">Nombre del procedimiento almacenado a ejecutar.</param>
        /// <param name="parameters">Parámetros del procedimiento almacenado (opcional).</param>
        /// <returns>DataTable con los resultados obtenidos.</returns>
        public static DataTable ExecuteStoredProcedure(string storedProcedureName, SqlParameter[] parameters = null)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(storedProcedureName, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }

                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    return dt;
                }
            }
        }
    }
}
