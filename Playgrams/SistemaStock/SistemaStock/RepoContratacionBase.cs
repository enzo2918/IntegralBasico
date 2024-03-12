using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SistemaStock
{
    internal class RepoContratacionBase
    {
        List<ContratacionBase> contratacionesPorBase = new List<ContratacionBase>();

        public RepoContratacionBase()
        {
            contratacionesPorBase.AddRange(new List<ContratacionBase>
            {
                new ContratacionBase
                {IdBase = 1, AccionDeContratacion = AccionContratacionBase.Alta, Fecha = new DateTime(2023,06,23)},
                new ContratacionBase
                {IdBase = 2, AccionDeContratacion = AccionContratacionBase.Alta, Fecha = new DateTime(2022,06,23)},
                new ContratacionBase
                {IdBase = 3, AccionDeContratacion = AccionContratacionBase.Alta, Fecha = new DateTime(2022,06,23)},
                new ContratacionBase
                {IdBase = 4, AccionDeContratacion = AccionContratacionBase.Alta, Fecha = new DateTime(2024,06,23)},
                new ContratacionBase
                {IdBase = 5, AccionDeContratacion = AccionContratacionBase.Alta, Fecha = new DateTime(2022,06,23)}
            }
            );
        }

        public List<ContratacionBase> TraerLista()
        {
            return contratacionesPorBase.ToList();
        }
    }
}
