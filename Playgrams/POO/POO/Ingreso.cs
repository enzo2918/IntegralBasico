using System;
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
    internal class Ingreso
    {
        
        Pedir pedir = new Pedir();
        Usuario[] usuarios;

        public Ingreso(string nombre, string usuario, string contraseña, bool esAdministrador,Usuario[] usuariosParametro)
        {
            usuarios = usuariosParametro;
            var usuarioAdministrador = new Usuario(nombre, usuario, contraseña, esAdministrador);
            usuarios[0] = usuarioAdministrador;
        }

        public Usuario IniciarSesion()
        {
            Console.WriteLine("Escribe tu nombre de usuario");
            var nombreUsuario = pedir.PedirCadena();

            var usuario = BuscarUsuario(nombreUsuario);

            if (usuario == null)
            {
                Console.WriteLine("Su usuario es incorrecto");
                return null; 
            }

            Console.WriteLine("Escribe tu contraseña");
            var contraseña = pedir.PedirCadena();

            var contraseñaEsCorrecta = usuario.Contraseña == contraseña;
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

            var usuarioYaExiste = UsuarioExistente(nombreUsuario);

            if (usuarioYaExiste)
            {
                Console.WriteLine("Este usuario ya existe");
                return;
            }

            Console.WriteLine("Crea una contraseña");
            var contraseña = pedir.PedirCadena();

            Registrar(nombreCompleto, nombreUsuario, contraseña, false);
        }
        private bool UsuarioExistente(string nombreUsuario)
        {
            var usuarioYaExiste = false;
            for (int n = 0; n < usuarios.Length; ++n)
            {
                if (usuarios[n] != null)
                {
                    if (nombreUsuario == usuarios[n].NombreUsuario)
                    {
                        usuarioYaExiste = true;
                        break;
                       
                    }
                }
            }
            return usuarioYaExiste;
        }
        private void Registrar(string nombreCompleto, string nombreUsuario, string contraseña,bool esAdministrador)
        {
            for (int n = 0; n < usuarios.Length; ++n)
            {
                if (usuarios[n] == null)
                {
                    usuarios[n] = new Usuario(nombreCompleto, nombreUsuario, contraseña, false);
                    break;
                }
            }
        }
        private Usuario BuscarUsuario(string nombreUsuario)
        {
            Usuario usuarioADevolver = null;
            for (int n = 0; n < usuarios.Length; n++)
            {
                if (usuarios[n] != null)
                {
                    if (nombreUsuario == usuarios[n].NombreUsuario)
                    {
                        usuarioADevolver = usuarios[n];
                        break;
                    }
                }
            }
            return usuarioADevolver;
        }
    }
}
