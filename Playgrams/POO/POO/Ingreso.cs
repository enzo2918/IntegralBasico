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
    internal class Ingreso:IIngreso
    {

        IPedir pedir;
        IRepoUsuario repoUsuario;

        public Ingreso(IPedir pedir,IRepoUsuario repoUsuario)
        {
            this.pedir = pedir;
            this.repoUsuario = repoUsuario;
        }

        public Usuario IniciarSesion()
        {
            Console.WriteLine("Escribe tu nombre de usuario");
            var nombreUsuario = pedir.Cadena();

            var usuarioAIngresar = repoUsuario.Buscar(nombreUsuario);

            if (usuarioAIngresar == null)
            {
                Console.WriteLine("Su usuario es incorrecto");
                return null; 
            }

            Console.WriteLine("Escribe tu contraseña");
            var contraseña = pedir.Cadena();

            var contraseñaEsCorrecta = usuarioAIngresar.Contraseña == contraseña;

            if (!contraseñaEsCorrecta)
            {
                Console.WriteLine("Su contraseña es incorrecta");
                return null;
            }

            return usuarioAIngresar;
        }
        public void RegistarUsuario()
        {
            Console.WriteLine("Escribe tu nombre completo");
            var nombreCompleto = pedir.Cadena();

            Console.WriteLine("Crea un usuario");
            var nombreUsuario = pedir.Cadena();

            var usuarioYaExiste = repoUsuario.Buscar(nombreUsuario);

            if (usuarioYaExiste!=null)
            {
                Console.WriteLine("Este usuario ya existe");
                return;
            }

            Console.WriteLine("Crea una contraseña");
            var contraseña = pedir.Cadena();

            var administrador = false;

            Usuario usuario = new Usuario(nombreCompleto, nombreUsuario, contraseña, administrador);
            repoUsuario.Añadir(usuario);
        }
       
       
    }
}
