using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ProgramaEstudiantes
{
    internal interface IRepositorioSql
    {
        List<TReturn> DevolverDatosTabla<TReturn>(string queryString, Func<SqlDataReader, TReturn> DevolverDatos, List<SqlParameter> parametros = null);
        TReturn DevolverDatoTabla<TReturn>(string queryString, Func<SqlDataReader, TReturn> DevolverDatos, List<SqlParameter> parametros = null);
        void EjecutarQuery(string queryString, List<SqlParameter> parametros = null);
    }
}