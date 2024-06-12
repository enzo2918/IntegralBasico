using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramaEstudiantes.Repositorios.ConsultasCrudas
{
    internal class ErrorCRRepositorio : IErrorCRRepositorio
    {
        private IRepositorioSql _repo;

        public ErrorCRRepositorio(IRepositorioSql repositorioSql)
        {
            _repo = repositorioSql;
        }
        public void Error()
        {
            var queryString = "sdf";
            _repo.EjecutarQuery(queryString);
        }
    }
}
