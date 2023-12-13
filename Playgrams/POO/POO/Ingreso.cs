﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace POO
{
    internal class Ingreso:IIngreso
    {

        IPedir pedir;
        IRepoUsuario repoUsuario;

        public Ingreso(IPedir pedirParametro,IRepoUsuario RepoUsuario)
        {
            pedir = pedirParametro;
            repoUsuario = RepoUsuario;
        }

        public Usuario IniciarSesion()
        {
            Console.WriteLine("Escribe tu nombre de usuario");
            var nombreUsuario = pedir.PedirCadena();

            var usuario = repoUsuario.BuscarUsuario(nombreUsuario);

            //var usuario = usuarios.FirstOrDefault(p => nombreUsuario == p.NombreUsuario);
            //var usuario = BuscarUsuario(nombreUsuario);

            if (usuario == null)
            {
                Console.WriteLine("Su usuario es incorrecto");
                return null; 
            }

            Console.WriteLine("Escribe tu contraseña");
            var contraseña = pedir.PedirCadena();

            var contraseñaEsCorrecta = repoUsuario.ContraseñaCorrecta(contraseña, usuario);

            //var contraseñaEsCorrecta = usuario.Contraseña == contraseña;

            if (!contraseñaEsCorrecta)
            {
                Console.WriteLine("Su contraseña es incorrecta");
                return null;
            }

            return usuario;
        }
        public void RegistarUsuario()
        {
            Console.WriteLine("Escribe tu nombre completo");
            var nombreCompleto = pedir.PedirCadena();

            Console.WriteLine("Crea un usuario");
            var nombreUsuario = pedir.PedirCadena();

            var usuarioYaExiste = repoUsuario.BuscarUsuario(nombreUsuario);
            //var usuarioYaExiste = BuscarUsuario(nombreUsuario);

            if (usuarioYaExiste!=null)
            {
                Console.WriteLine("Este usuario ya existe");
                return;
            }

            Console.WriteLine("Crea una contraseña");
            var contraseña = pedir.PedirCadena();

            repoUsuario.Registrar(nombreCompleto, nombreUsuario, contraseña);
        }
       
        //private void Registrar(string nombreCompleto, string nombreUsuario, string contraseña)
        //{
        //    usuarios.Add(new Usuario(nombreCompleto, nombreUsuario, contraseña, false));
        //}

        //private Usuario BuscarUsuario(string nombreUsuario)
        //{
        //    Usuario usuarioADevolver = null;

        //    for (int n = 0; n < usuarios.Count; n++)
        //    {
        //        if (usuarios[n] != null)
        //        {
        //            if (nombreUsuario == usuarios[n].NombreUsuario)
        //            {
        //                usuarioADevolver = usuarios[n];
        //                break;
        //            }
        //        }
        //    }
        //    return usuarioADevolver;
        //}
    }
}
