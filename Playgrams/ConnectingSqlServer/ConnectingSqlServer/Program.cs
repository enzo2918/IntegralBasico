using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectingSqlServer
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // Cadena de conexión
            string connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=sql_server;Integrated Security=true;";

            try
            {
                // Establecer la conexión
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Consulta SQL
                    string queryString = "SELECT * FROM dnis";

                    // Ejecutar la consulta
                    using (SqlCommand command = new SqlCommand(queryString, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            // Mostrar los resultados
                            while (reader.Read())
                            {
                                Console.WriteLine($"ID: {reader["id"]}, Dni: {reader["numeroDni"]}, idUSer: {reader["idUser"]}");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            Console.ReadLine();
            
        }
    }

}
    
