using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO
{
    internal class Inicio:IInicio
    {


        IPedir pedir;
        IAgregarLibro agregar;
        IDevolverLibro devolver;
        IEditarLibro editar;
        IEliminarLibro eliminar;
        IIngreso ingresar;
        IRetiroLibro retirar;

        public Inicio(IPedir pedir, IAgregarLibro agregar, IDevolverLibro devolver,
            IEditarLibro editar, IEliminarLibro eliminar, IIngreso ingresar, IRetiroLibro retirar) 
        { 


            this.pedir = pedir;
            this.agregar = agregar;
            this.devolver = devolver;
            this.editar = editar;
            this.eliminar = eliminar;
            this.ingresar = ingresar;
            this.retirar = retirar;

        }
        public void Iniciar()
        {

            string Registrado;
            do
            {
                Console.WriteLine("Bienvenido a la biblioteca");
                Console.WriteLine("Estas registrado? 1. Si  2. No 3. Salir");
                Registrado = pedir.Cadena();

               
                if (Registrado == "1" || Registrado == "si" || Registrado == "Si")
                {
                    var usuarioAIngresar = ingresar.IniciarSesion();
                    if (usuarioAIngresar!= null)
                    {
                        if (usuarioAIngresar.EsAdministrador)
                        {
                            string accionARealizar;
                            do
                            {
                                Console.WriteLine("1. Agregar nuevo libro\n2. Eliminar libro\n3. Editar libro\n4. Salir");
                                accionARealizar = pedir.Cadena();
                                switch (accionARealizar)
                                {
                                    case "1":
                                        agregar.Agregacion();
                                        Console.ReadLine();
                                        Console.Clear();
                                        break;
                                    case "2":
                                        eliminar.Eliminacion();
                                        Console.ReadLine();
                                        Console.Clear();
                                        break;
                                    case "3":
                                        editar.Edicion();
                                        Console.ReadLine();
                                        Console.Clear();
                                        break;
                                    case "4":
                                        break;
                                    default: Console.WriteLine("Su seleccion es incorrecta");
                                        break;
                                }
                            } while (accionARealizar != "4");
                        }
                        else
                        {
                            string accionARealizar;
                            do
                            {
                                Console.WriteLine("1. Pedir libro\n2. Devolver libro\n3. Salir");
                                accionARealizar = pedir.Cadena();

                                switch (accionARealizar)
                                {
                                    case "1":
                                        retirar.Retiro(usuarioAIngresar);
                                        Console.ReadLine();
                                        Console.Clear();
                                        break;
                                    case "2":
                                        devolver.Devolucion(usuarioAIngresar);
                                        Console.ReadLine();
                                        Console.Clear();
                                        break;
                                    case"3":
                                        break;
                                    default: Console.WriteLine("Su seleccion es incorrecta");
                                        break;
                                }
                            } while (accionARealizar !="3");
                        }
                    }                    
                }
                if (Registrado == "2" || Registrado == "no" || Registrado == "No")
                {

                    ingresar.RegistarUsuario();
                    Console.ReadLine();
                    Console.Clear();

                }
            } while (Registrado != "3");

        }
    }
}
