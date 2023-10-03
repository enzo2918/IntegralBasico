using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO
{
    internal class Usuario
    {
        public string Nombre { get; }
        public string NombreUsuario { get; }
        public string Contraseña { get; }
        public bool EsAdministrador { get; }
        public Usuario(string nombre, string usuario, string contraseña, bool esAdministrador) 
        { 
            Nombre = nombre;
            NombreUsuario = usuario;
            Contraseña = contraseña;
            EsAdministrador = esAdministrador;
            
        }


    }
}
