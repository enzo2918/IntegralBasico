using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RepasoC_.Linq;

namespace RepasoC_
{
    internal class Linq
    {
        public void Main ()
        {
            var articulos = new List<Articulo>
            { 
                new Articulo { Id = 2, Precio = 200 },
                new Articulo { Id = 1, Precio = 100 },
                new Articulo { Id = 4, Precio = 400 },
                new Articulo { Id = 3, Precio = 300 }
            };

            var art = new Articulo { Id = 1, Precio = 200, };


            // Agregar art

            articulos.Add(new Articulo { Id = 5, Precio = 500 });

            // Remover art

            articulos.RemoveAll(x => 
            {
                var pepe = 1;
                return art.Id == pepe;
            }
            );

            articulos.RemoveAll(MatchArticulo);

            // Encontrar art

            var articuloEncontrado = articulos.Find(x => x.Id == 1);

            // Saber si hay

            var loContiene = articulos.Any(x => x.Id == 1);

            // Filtrar

            var articulosBaratos = articulos.Where(x => x.Precio <= 300);

            // Foreach 

            articulos.ForEach(x => x.Precio = 111);
            foreach (var articulo in articulosBaratos)
            {
                articulo.Precio = 111;
            }

            // Comparar con otra lista
            var numerosPares = new List<int> { 2, 4, 6, 8 };
            var numerosImpares = new List<int> { 1, 3, 5, 7 };
            var numerosRandom = new List<int> { 1, 2, 5, 8, 9, 16 };

            var numerosParesDeRandom = numerosRandom.Concat(numerosPares).Distinct();
            var numerosParesDeRandom2 = numerosRandom.Where(r => numerosPares.Contains(r));

            var articulosVista = new List<ArticuloVista>();

            foreach (var articulo in articulos)
            {

                articulosVista.Add(new ArticuloVista { Id = articulo.Id, Precio = articulo.Precio.ToString("00") });
            }
            articulosVista = articulos.Select(x => new ArticuloVista { Id = x.Id, Precio = x.Precio.ToString("00") }).ToList();

            var articulosDuplicada = articulos.Select(x => x);

            // Unir con otra lista



        }

        private bool MatchArticulo(Articulo art)
        {
            return art.Id == 2;
        }

        internal class Articulo
        {
            public int Id { get; set; }

            public double Precio { get; set; }
        }

        internal class ArticuloVista
        {
            public int Id { get; set; }
            public string Precio { get; set; }
            //{ 
            //    get { return _precio.ToString("00"); }
            //    set { _precio = double.Parse(value); }
            //}
        }
    }
}
