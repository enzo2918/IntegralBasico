using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO
{
    internal class RepoUsuario:IRepoUsuario
    {
        List<Usuario> usuarios = new List<Usuario>();

        public RepoUsuario()
        {         
            Usuario usuarioAdministrador = new Usuario("Enzo", "x", "x", true);
            usuarios.Add(usuarioAdministrador);
        }
        public Usuario Buscar(string nombreUsuario)
        {
            var usuarioBuscado = usuarios.FirstOrDefault(p => nombreUsuario == p.NombreUsuario);
            return usuarioBuscado;

        }
        public void Añadir(Usuario usuario)
        {
            usuarios.Add(usuario);
        }
    }
}
