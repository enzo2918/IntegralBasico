using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO
{
    internal class RepoUsuario:IRepoUsuario
    {
        List<Usuario> usuarios;
        public RepoUsuario(List<Usuario> Usuarios) 
        {
            usuarios = Usuarios;
        }
        public Usuario BuscarUsuario(string nombreUsuario)
        {
            var usuario = usuarios.FirstOrDefault(p => nombreUsuario == p.NombreUsuario);
            return usuario;
        }
        public bool ContraseñaCorrecta(string contraseña,Usuario usuario)
        {
            var contraseñaEsCorrecta = usuario.Contraseña == contraseña;
            return contraseñaEsCorrecta;
        }
        public void Registrar(string nombreCompleto, string nombreUsuario, string contraseña)
        {
            usuarios.Add(new Usuario(nombreCompleto, nombreUsuario, contraseña, false));
        }
    }
}
