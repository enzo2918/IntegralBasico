using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace POO
{
    internal class CIngreso
    {
        
        CPedir pedir = new CPedir();
        CUsuario[] persona = new CUsuario[5];
        CUsuario administrador = new CUsuario("Enzo Ortiz", "x", "x");
            
        
        public bool UsuarioRegistrado()
        {
            var dato1 = "";
            var dato2 = "";
            var condicion1 = false;
            var condicion2 = false;
            var condicion3 = false;
            var condicion4 = false;
            Console.WriteLine("Escribe tu nombre de usuario");
            dato1 = pedir.pedircadena();
            for (int n = 0; n < persona.Length; n++)
            {
                if (persona[n] == null)
                {
                    condicion3 = true;
                }
                else condicion3 = false;
            }
            if (dato1 == administrador.NombreUsuario)
            {
                condicion1 = true;
                condicion2 = true;
                Console.WriteLine("Escribe tu contraseña");
                dato2 = pedir.pedircadena();
                condicion3 = false;
                if (dato2 == administrador.Contraseña)
                {
                    condicion3 = true;
                    condicion4 = true;
                    Console.WriteLine("Que deseas hacer?");
                    Console.WriteLine();                              
                }

            }
            for (int n = 0; n < persona.Length; n++)
            {

                    
                    if (persona[n] != null)
                    {
                        condicion1 = true;
                        

                        if (dato1 == persona[n].NombreUsuario)
                        {
                            condicion3 = false;
                            condicion2 = true;
                            Console.WriteLine("Escribe tu contraseña");
                            dato2 = pedir.pedircadena();

                            if (dato2 == persona[n].Contraseña)
                            {
                                condicion3 = true;
                                condicion4 = true;
                                Console.WriteLine("Que deseas hacer?");
                                Console.WriteLine();
                                break;
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
                 condicion3 = true;
                 Console.WriteLine("Su usuario es incorrecto");
            }
            if (!condicion3)
            {
                 Console.WriteLine("Su contraseña es incorrecta");
            }
            if (!condicion4) return false;
            else return true;
            
        }
        public void UsuarioNoRegistrado()
        {
            var nc = "";
            var u = "";
            var con = "";
            var usuariosllenos = false;

            for (int n = 0; n < persona.Length; n++)
            {
                var condicion1 = false;
                if (persona[n] == null)
                {
                    usuariosllenos = true;
                    Console.WriteLine("Escribe tu nombre completo");
                    nc = pedir.pedircadena();
                    Console.WriteLine("Crea un usuario");
                    u = pedir.pedircadena();
                    for (int m= 0; m < persona.Length; ++m)
                    {
                        if (persona[m] != null)
                        {
                            if (u == persona[m].NombreUsuario)
                            {
                                condicion1 = true;
                                Console.WriteLine("Este usuario ya existe");
                            }
                        }                      
                    }
                    if (!condicion1)
                    {
                        Console.WriteLine("Crea una contraseña");
                        con = pedir.pedircadena();
                        persona[n] = new CUsuario(nc, u, con);
                        Console.WriteLine("");
                        persona[n].mostrar();
                        Console.WriteLine("");
                        break;
                    }                                                              
                }

            }
            if (!usuariosllenos)
            {
                Console.WriteLine("Se ha alcanzado el maximo de usuarios, elimine alguno para crear uno nuevo");
            }

        }
    }
}
