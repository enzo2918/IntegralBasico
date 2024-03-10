using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaStock
{
    internal class RepoTienda
    {
        List<Tienda> tiendas = new List<Tienda>();
        public RepoTienda() 
        {
            tiendas.AddRange(new List<Tienda>
            {
                new Tienda
                {
                    Id = "vn1",
                    Name = "Villa Nueva 1",
                    IdBases = {2,3},
                    IdEtiquetas = {"vn","mza"}
                },
                new Tienda
                {
                    Id = "vn2",
                    Name = "Villa Nueva 2",
                    IdBases = {1},
                    IdEtiquetas = {"vn","mza"}
                },
                new Tienda
                {
                    Id = "gc",
                    Name = "Godoy Cruz",
                    IdBases = {5},
                    IdEtiquetas = {"gc","mza"}
                },
                new Tienda
                {
                    Id = "cba",
                    Name = "Cordoba",
                    IdBases = {4}
                }
            }
            );
        }

        public List<Tienda> TraerLista()
        {
            return tiendas;
        } 
    }
}
