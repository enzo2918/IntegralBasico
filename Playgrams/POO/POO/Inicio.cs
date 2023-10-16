using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO
{
    internal class Inicio
    {
        
        public void Iniciar ()
        {

            Usuario[] usuarios = new Usuario[5];
            Libro[] libros = new Libro[10];
            Prestamo[] prestamos = new Prestamo[50];

            Usuario usuarioAdministrador = new Usuario("Enzo Ortiz", "x", "x", true);
            usuarios[0] = usuarioAdministrador;

            IBuscador buscador = new Buscador();
            IPedir pedir = new Pedir();
            IMuestra muestra = new Muestra();

            IAgregarLibro agrega = new AgregarLibro(pedir,buscador);            
            IDevolucionLibro devuelve = new DevolucionLibro(muestra,pedir);
            IEditarLibro edita = new EditarLibro(buscador,muestra,pedir);
            IEliminarLibro elimina = new EliminarLibro(muestra, pedir);
            IIngreso ingreso = new Ingreso(usuarios, pedir);           
            IRetiroLibro retira = new RetiroLibro(buscador,muestra,pedir);
            

            string Registrado = "";
            do
            {
                Console.WriteLine("Bienvenido a la biblioteca");
                Console.WriteLine("Estas registrado? 1. Si  2. No 3. Salir");
                Registrado = pedir.PedirCadena();

               
                if (Registrado == "1" || Registrado == "si" || Registrado == "Si")
                {
                    var usuarioAIngresar = ingreso.IniciarSesion();
                    if (usuarioAIngresar!= null)
                    {
                        if (usuarioAIngresar.EsAdministrador)
                        {
                            var eleccion = "";
                            do
                            {
                                Console.WriteLine("1. Agregar nuevo libro\n2. Eliminar libro\n3. Editar libro\n4. Salir");
                                eleccion = pedir.PedirCadena();
                                switch (eleccion)
                                {
                                    case "1":
                                        agrega.Agregar(libros);
                                        Console.ReadLine();
                                        Console.Clear();
                                        break;
                                    case "2":
                                        elimina.Eliminar(libros);
                                        Console.ReadLine();
                                        Console.Clear();
                                        break;
                                    case "3":
                                        edita.Editar(libros);
                                        Console.ReadLine();
                                        Console.Clear();
                                        break;
                                    case "4":
                                        break;
                                    default: Console.WriteLine("Su seleccion es incorrecta");
                                        break;
                                }
                            } while (eleccion != "4");
                        }
                        else
                        {
                            var eleccion = "";
                            do
                            {
                                Console.WriteLine("1. Pedir libro\n2. Devolver libro\n3. Salir");
                                eleccion = pedir.PedirCadena();

                                switch (eleccion)
                                {
                                    case "1":
                                        retira.Retiro(libros,usuarioAIngresar,prestamos);
                                        Console.ReadLine();
                                        Console.Clear();
                                        break;
                                    case "2":
                                        devuelve.Devolucion(prestamos, libros,usuarioAIngresar);
                                        Console.ReadLine();
                                        Console.Clear();
                                        break;
                                    case"3":
                                        break;
                                    default: Console.WriteLine("Su seleccion es incorrecta");
                                        break;
                                }
                            } while (eleccion !="3");
                        }
                    }                    
                }
                if (Registrado == "2" || Registrado == "no" || Registrado == "No")
                {

                    ingreso.RegistarUsuario();
                    Console.ReadLine();
                    Console.Clear();

                }
            } while (Registrado != "3");

        }
    }
}
