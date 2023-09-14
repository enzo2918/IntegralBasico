using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO
{
    internal class CUsuario
    {
        private string nombre = "";
        private string fechanacimiento = "";
        private string usuario = "";
        private string contraseña = "";

        public CUsuario(string pnombre, string pfechanacimiento, string pusuario, string pcontraseña) 
        { 
            nombre = pnombre;
            fechanacimiento = pfechanacimiento; 
            usuario = pusuario;
            contraseña = pcontraseña;
        }
        public void mostrar()
        {
            Console.WriteLine("{0}\n{1}\n{2}\n{3}", nombre, fechanacimiento, usuario, contraseña);
        }
        public string Usuario 
        {          
            get
            {
                return usuario;

            }                       
        }
        public string Contraseña
        {
            get
            {
                return contraseña;

            }
        }
    }
}
