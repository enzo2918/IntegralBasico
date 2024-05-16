using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace ProgramaEstudiantes
{
    internal class Program
    {
        static void Main()
        {

            try
            {
                var inicio = new Inicio();
                inicio.IniciarPrograma();
            }
            catch (Exception ex)
            {
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine($"Hubo un error en el programa: {ex}");
                Console.WriteLine();
                Console.WriteLine();
                Main();
            }
        }
    }
}
