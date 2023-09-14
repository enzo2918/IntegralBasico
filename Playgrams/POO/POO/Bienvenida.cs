using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace POO
{
    internal class Bienvenida
    {
        private string eleccion = "";
        private string dato = "";
        
        CPedir pedir = new CPedir();
        CUsuario[] persona = new CUsuario[5];
        CUsuario administrador = new CUsuario("Enzo Ortiz", "29/11/1999", "enzortiz", "42318749");
        public void entrada()
        {
            do
            {
                Console.WriteLine("Bienvenido a la biblioteca");
                Console.WriteLine("Estas registrado? 1. Si  2. No 3. Salir");
                eleccion = pedir.pedircadena();

                if (eleccion == "1" || eleccion == "si" || eleccion == "Si")
                {
                    var dato1 = "";
                    var dato2 = "";
                    var seleccion = "";
                    Console.WriteLine("Eres 1. Administrador o 2. Cliente?");
                    seleccion = pedir.pedircadena();
                    
                    if (seleccion == "1" || seleccion == "administrador" || seleccion == "Administrador")
                    {
                        Console.WriteLine("Escribe tu nombre de usuario");
                        dato1 = pedir.pedircadena();
                        if (dato1 == administrador.Usuario)
                        {
                            Console.WriteLine("Escribe tu contraseña");
                            dato2 = pedir.pedircadena();
                            if (dato2 == administrador.Contraseña)
                            {
                                Console.WriteLine("Que deseas hacer?");
                                Console.WriteLine();
                            }else
                            {
                                Console.WriteLine("Su contraseña es incorrecta");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Su usuario es incorrecto");
                        }

                    }

                    if (seleccion == "2" || seleccion == "cliente" || seleccion == "Cliente")
                    {
                        dato1 = "";
                        dato2 = "";
                        var condicion1 = false;
                        var condicion2 = false;
                        var condicion3 = false;
                        Console.WriteLine("Escribe tu nombre de usuario");
                        dato1 = pedir.pedircadena();
                        for (int n = 0; n < persona.Length; n++)
                        {
                            if (persona[n] != null)
                            {
                                condicion1 = true;

                                if (dato1 == persona[n].Usuario)
                                {
                                    condicion2 = true;
                                    Console.WriteLine("Escribe tu contraseña");
                                    dato2 = pedir.pedircadena();

                                    if (dato2 == persona[n].Contraseña)
                                    {
                                        condicion3 = true;
                                        Console.WriteLine("Que deseas hacer?");
                                        Console.WriteLine();
                                    }

                                }
                            }
                        }
                        if (!condicion1)
                        {
                            Console.WriteLine("Su usuario es incorrecto");
                            condicion2 = true;
                        }
                        if (!condicion2)
                        {
                            Console.WriteLine("Su usuario es incorrecto");
                        }
                        if (!condicion3)
                        {
                            Console.WriteLine("Su contraseña es incorrecta");
                        }
                    }
                    


                }
                if (eleccion == "2" || eleccion == "no" || eleccion == "No")
                {
                    var nc = "";
                    var fn = "";
                    var u = "";
                    var con = "";
                    var usuariosllenos = false;    
                    
                    for (int n = 0; n < persona.Length; n++)
                    {

                        if (persona[n] == null)
                        {
                            Console.WriteLine("Escribe tu nombre completo");
                            nc = pedir.pedircadena();
                            Console.WriteLine("Escribe tu fecha de nacimiento");
                            fn = pedir.pedircadena();
                            Console.WriteLine("Crea un usuario");
                            u = pedir.pedircadena();
                            Console.WriteLine("Crea una contraseña");
                            con = pedir.pedircadena();
                            persona[n] = new CUsuario(nc, fn, u, con);
                            Console.WriteLine("");
                            persona[n].mostrar();
                            Console.WriteLine("");
                            usuariosllenos = true;
                            break;
                        }
                        
                    }
                    if (!usuariosllenos)
                    {
                        Console.WriteLine("Se ha alcanzado el maximo de usuarios, elimine alguno para crear uno nuevo");
                    }


                }

            } while (eleccion != "3");







        }
    }
}
