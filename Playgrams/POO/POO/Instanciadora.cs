using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO
{
    internal class Instanciadora
    {
        IInicio inicio;
        public void Instanciar()
        {

            IRepoLibro repoLibro = new RepoLibro();
            IRepoPrestamo repoPrestamo = new RepoPrestamo();
            IRepoUsuario repoUsuario = new RepoUsuario();

            IPedir pedir = new Pedir();
            IMuestra muestra = new Muestra(repoLibro,repoPrestamo);

            IAgregarLibro agregar = new AgregarLibro(pedir,repoLibro);
            IDevolverLibro devolver = new DevolverLibro(muestra, pedir,repoPrestamo,repoLibro);
            IEditarLibro editar = new EditarLibro(muestra, pedir,repoLibro);
            IEliminarLibro eliminar = new EliminarLibro(muestra, pedir,repoLibro);
            IIngreso ingresar = new Ingreso(pedir,repoUsuario);
            IRetiroLibro retirar = new RetiroLibro(muestra, pedir,repoLibro,repoPrestamo);

            inicio = new Inicio(pedir, agregar, devolver, editar, eliminar, ingresar, retirar);

        }
        
        public IInicio ObtenerInstanciaInicio()
        {
            return inicio;
        }
    }
}
