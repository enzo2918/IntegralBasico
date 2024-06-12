using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramaEstudiantes.Repositorios
{
    internal class EscuelaConsultasCrudasRepositorio : IEscuelaRepositorio
    {
        private IRepositorioSql _repo;

        public EscuelaConsultasCrudasRepositorio(IRepositorioSql repositorioSql)
        {
            _repo = repositorioSql;
        }

        public List<Escuela> ObtenerEscuelas()
        {
            var queryString = "Select * from escuelas order by name";
            var escuelas = _repo.DevolverDatosTabla<Escuela>(queryString, DevolverEscuelas);
            return escuelas;
        }

        private Escuela DevolverEscuelas(SqlDataReader reader)
        {
            var escuela = new Escuela()
            {
                Name = reader["name"].ToString(),
                Id = int.Parse(reader["id"].ToString())
            };
            return escuela;
        }
    }
}
