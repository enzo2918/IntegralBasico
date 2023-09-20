using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO
{
    internal class CUsuario
    {
        public string Nombre { get; }
        public string NombreUsuario { get; }
        public string Contraseña { get; }

        public CUsuario(string pnombre, string pusuario, string pcontraseña) 
        { 
            Nombre = pnombre;
            NombreUsuario = pusuario;
            Contraseña = pcontraseña;
        }
        public void mostrar()
        {
            Console.WriteLine("{0}\n{1}", Nombre, NombreUsuario);
        }
    }
}
