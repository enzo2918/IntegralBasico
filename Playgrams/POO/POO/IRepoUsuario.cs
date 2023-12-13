using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO
{
    internal interface IRepoUsuario
    {
        Usuario BuscarUsuario(string nombreUsuario);
        bool ContraseñaCorrecta(string contraseña, Usuario usuario);
        void Registrar(string nombreCompleto, string nombreUsuario, string contraseña);
    }
}
