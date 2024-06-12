using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramaEstudiantes.Repositorios
{
    internal class EscuelaEFRepositorio : IEscuelaRepositorio
    {
        //private IRepositorioSql _repo;

        public EscuelaEFRepositorio()
        {
            //_repo = repositorioSql;
        }

        public List<Escuela> ObtenerEscuelas()
        {
            using (var BDEstudiantes = new EstudiantesContext())
            {
                var escuelas = BDEstudiantes.Escuelas.ToList();
                return escuelas;
            }
        }
    }
}
