using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ProgramaEstudiantes
{
    internal class RepositorioSql : IRepositorioSql
    {
        private string _connectionString;

        public RepositorioSql()
        {
            _connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=sistema_estudiantes;Integrated Security=true;";
        }

        public List<TReturn> DevolverDatosTabla<TReturn>(string queryString, Func<SqlDataReader, TReturn> DevolverDatos, List<SqlParameter> parametros = null)
        {
            var datosADevolver = new List<TReturn>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(queryString, connection))
                {
                    if (parametros != null)
                        command.Parameters.AddRange(parametros.ToArray());

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var datoADevolver = DevolverDatos(reader);
                            datosADevolver.Add(datoADevolver);
                        }
                    }
                }
            }

            return datosADevolver;
        }

        public TReturn DevolverDatoTabla<TReturn>(string queryString, Func<SqlDataReader, TReturn> DevolverDatos, List<SqlParameter> parametros = null)
        {
            TReturn datoADevolver = default;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(queryString, connection))
                {
                    if (parametros != null)
                        command.Parameters.AddRange(parametros.ToArray());

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                            datoADevolver = DevolverDatos(reader);
                    }
                }
            }
            return datoADevolver;
        }

        public void EjecutarQuery(string queryString, List<SqlParameter> parametros = null)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(queryString, connection))
                {
                    if (parametros != null)
                        command.Parameters.AddRange(parametros.ToArray());

                    command.ExecuteNonQuery();
                }
            }

        }


    }
}
