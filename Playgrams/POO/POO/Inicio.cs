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

            Pedir pedir = new Pedir();

            string Registrado = "";
            do
            {
                Console.WriteLine("Bienvenido a la biblioteca");
                Console.WriteLine("Estas registrado? 1. Si  2. No 3. Salir");
                Registrado = pedir.PedirCadena();
                Ingreso ingreso = new Ingreso("Enzo Ortiz", "x", "x", true, usuarios);

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
                                        AgregarLibro agrega = new AgregarLibro();
                                        agrega.Agregar(libros);
                                        break;
                                    case "2":
                                        EliminarLibro elimina = new EliminarLibro();
                                        elimina.Eliminar(libros);
                                        break;
                                    case "3":
                                        EditarLibro edita = new EditarLibro();
                                        edita.Editar(libros);
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
                                DevolucionLibro devuelve = new DevolucionLibro();
                                RetiroLibro retira = new RetiroLibro();
                                switch (eleccion)
                                {
                                    case "1":
                                        retira.Retiro(libros,usuarioAIngresar,prestamos);
                                        break;
                                    case "2":
                                        devuelve.Devolucion(prestamos, libros);
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

                }
            } while (Registrado != "3");

        }
    }
}
