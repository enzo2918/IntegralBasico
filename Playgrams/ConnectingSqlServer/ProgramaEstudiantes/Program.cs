using ProgramaEstudiantes.Exceptions;
using ProgramaEstudiantes.Repositorios;
using ProgramaEstudiantes.Repositorios.ConsultasCrudas;
using ProgramaEstudiantes.Repositorios.EF;
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
    public class Program
    {
        static void Main()
        {

            try
            {
                var repo = new RepositorioSql();
                var estudianteRepo = new EstudianteEFRepositorio();
                var cursoRepo = new CursoEFRepositorio();
                var escuelaRepo = new EscuelaEFRepositorio();
                var errorRepo = new ErrorCRRepositorio(repo);
                var input = new Input();
                var pedir = new Pedir(input);
                var output = new Output();
                var mostrar = new Mostrar(output);
                var obtener = new Obtener(pedir, mostrar, estudianteRepo, escuelaRepo, cursoRepo);

                var inicio = new Inicio(estudianteRepo, cursoRepo, escuelaRepo, errorRepo, pedir, mostrar, obtener);
                inicio.IniciarPrograma();
            }
            catch (Exception ex) when (ex is InputInvalidaException || ex is FueraDeRangoException || ex is EstudianteInexistenteException)
            {
                ImprimirMensajeError(ex.Message);
                Main();
            }
            catch (Exception)
            {
                ImprimirMensajeError("Hubo un error inesperado, se reiniciara el programa");
                Main();
            }
            
        }

        static void ImprimirMensajeError(string mensaje)
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(mensaje);
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
