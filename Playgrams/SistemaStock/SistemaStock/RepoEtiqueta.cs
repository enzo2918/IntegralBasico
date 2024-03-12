using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaStock
{
    internal class RepoEtiqueta
    {
        List<Etiqueta> etiquetas = new List<Etiqueta>();

        public RepoEtiqueta()
        {
            etiquetas.AddRange(new List<Etiqueta>
            {
                new Etiqueta {Id = "vn", Name = "Villa Nueva"},
                new Etiqueta {Id = "gc", Name = "Godoy Cruz"},
                new Etiqueta {Id = "mza", Name = "Mendoza"}
            }
            );                       
        }

        public List<Etiqueta> TraerLista()
        {
            return etiquetas.ToList();
        }

       
    }
}
