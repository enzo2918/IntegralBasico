using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace SistemaStock
{
    internal class MostrarStock
    {
        public void MostrarStockPorArticulo(List<StockArticulo> stockArticulos, bool hayQueMostrarStockCero)
        {
            var articulos = CrearListaConTodosLosArticulos(stockArticulos);
            var origenes = CrearListaConTodosLosOrigenes(stockArticulos);

            MostrarEncabezados(origenes);

            foreach (var art in articulos)
            {
                string filaAMostrar = $"{art.Name,-10}\t" + $"{art.Code,-10}\t";
                var mostrarfila = false;

                foreach (var origen in origenes)
                {
                    var valorStock = string.Empty;

                    var stockArticulo = stockArticulos.FirstOrDefault(stock => stock.Origen == origen && stock.Articulo.Code == art.Code);

                    if (stockArticulo != null && (stockArticulo.Stock > 0 || hayQueMostrarStockCero))
                    {
                        valorStock = stockArticulo.Stock.ToString();
                        mostrarfila = true;
                    }                   

                    filaAMostrar += $"{valorStock,-10}\t";
                }

                if (mostrarfila) Console.WriteLine(filaAMostrar);
            }

            Console.WriteLine();
        }

        private List<Articulo> CrearListaConTodosLosArticulos(List<StockArticulo> stockArticulos)
        {
            var articulosRepetidos = stockArticulos.Select(art => art.Articulo).ToList();

            var articulos = articulosRepetidos.GroupBy(art => art.Code)
                                              .Select(group => group.First())
                                              .OrderBy(art => art.Name)
                                              .ToList();
            return articulos;
        }

        private List<string> CrearListaConTodosLosOrigenes(List<StockArticulo> stockArticulos)
        {
            var origenesRepetidos = stockArticulos.Select(stock => stock.Origen).ToList();

            var origenes = origenesRepetidos.Distinct()
                                            .OrderBy(orig => orig)
                                            .ToList();

            return origenes;
        }

        private void MostrarEncabezados(List<string> origenes)
        {
            Console.Write($"{"Articulo",-10}\t");
            Console.Write($"{"Codigo",-10}\t");

            foreach (var origen in origenes)
            {
                Console.Write($"{origen,-10}\t");
            }
            Console.WriteLine();
            Console.WriteLine();
        }

    }   
}
