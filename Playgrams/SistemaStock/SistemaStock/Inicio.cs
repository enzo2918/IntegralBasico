using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaStock
{
    internal class Inicio
    {
        public void Iniciar() 
        {
            StockPorBase stockPorBase = new StockPorBase();
            StockPorTienda stockPorTienda = new StockPorTienda();
            StockPorEtiqueta stockPorEtiqueta = new StockPorEtiqueta();
            MostrarStock mostrarStock = new MostrarStock();

            RepoBase repoBase = new RepoBase();
            RepoContratacionBase repoContratacionBase = new RepoContratacionBase();
            RepoFactura repoFactura = new RepoFactura();
            RepoTienda repoTienda = new RepoTienda();
            RepoEtiqueta repoEtiqueta = new RepoEtiqueta();
            var facturas = repoFactura.TraerLista();
            var bases = repoBase.TraerLista();
            var contratacionesPorBase = repoContratacionBase.TraerLista();
            var tiendas = repoTienda.TraerLista();
            var etiquetas = repoEtiqueta.TraerLista();
           
            var basesContratadas = CrearListaDeBasesContratadas(contratacionesPorBase, bases);
            var basesNoContratadas = CrearListaDeBasesNoContratadas(contratacionesPorBase, bases);
            var basesNuncaContratadas = CrearListaDeBasesNuncaContratadas(contratacionesPorBase, bases);
            var articulosDeTodasLasBases = CrearListaConTodosLosArticulos(bases);
            var facturasDeBasesContratadas = CrearListaDeFacturasDeBasesContratadas(basesContratadas, facturas);



            var stockArticulos = MenuInicio(stockPorBase, stockPorTienda, stockPorEtiqueta, articulosDeTodasLasBases,
                basesContratadas, facturasDeBasesContratadas, tiendas, etiquetas);

            bool hayQueMostrarStockCero = PedirOpcionMostrarStockCero();

            mostrarStock.MostrarStockPorArticulo(stockArticulos, hayQueMostrarStockCero);

            MostrarBasesNoContratadas(basesNoContratadas);
            MostrarBasesNuncaContratadas(basesNuncaContratadas);
                                                           
        }

        private List<Articulo> CrearListaConTodosLosArticulos(List<Base> bases)
        {
            var articulosDeTodasLasBasesRepetidos = bases.SelectMany(_base => _base.Articulos).ToList();

            var articulosDeTodasLasBases = articulosDeTodasLasBasesRepetidos.GroupBy(art => art.Code)
                                                                            .Select(group => group.First())
                                                                            .OrderBy(art => art.Name)
                                                                            .ToList();
            return articulosDeTodasLasBases;
        }
        private List<Base> CrearListaDeBasesContratadas(List<ContratacionBase> contratacionesBases,List<Base> bases)
        {
            var basesContratadas = new List<Base>();
            foreach (var _base in bases)
            {
                var ultimaContratacion = contratacionesBases.Where(cb => cb.IdBase == _base.Id)
                                                            .OrderByDescending(cb => cb.Fecha)
                                                            .FirstOrDefault();
                if (ultimaContratacion != null && ultimaContratacion.AccionDeContratacion == AccionContratacionBase.Alta)
                {
                    basesContratadas.Add(_base);
                }
            }

            var basesOrdenadasContratadas = basesContratadas.OrderBy(bas => bas.Name).ToList();

            return basesOrdenadasContratadas;

           
        }
        private List<Factura> CrearListaDeFacturasDeBasesContratadas(List<Base> basesContratadas, List<Factura> facturas)
        {
            var idsDeFacturasDeBasesContratadas = basesContratadas.Select(_base => _base.Id);
            var facturasDeBasesContratadas = facturas.Where(fact => idsDeFacturasDeBasesContratadas.Contains(fact.IdBase));
            
            return facturasDeBasesContratadas.ToList();
        }
        private List<Base> CrearListaDeBasesNoContratadas(List<ContratacionBase> contratacionesBases, List<Base> bases)
        {
            var basesNoContratadas = new List<Base>();
            foreach (var _base in bases)
            {
                var ultimaContratacion = contratacionesBases.Where(cb => cb.IdBase == _base.Id)
                                                            .OrderByDescending(cb=>cb.Fecha)
                                                            .FirstOrDefault();

                if (ultimaContratacion?.AccionDeContratacion == AccionContratacionBase.Baja)
                {
                    basesNoContratadas.Add(_base);
                }
            }
            return basesNoContratadas;

        }          
        private List<Base> CrearListaDeBasesNuncaContratadas(List<ContratacionBase> contratacionesBases, List<Base> bases)
        {
            var basesNuncaContratadas = new List<Base>();
            foreach (var _base in bases)
            {
                var hayRegistroDeContratacion = contratacionesBases.Any(cb => cb.IdBase == _base.Id);

                if (!hayRegistroDeContratacion) basesNuncaContratadas.Add(_base);
            }
            return basesNuncaContratadas;
        }
        private bool PedirOpcionMostrarStockCero()
        {
            Console.WriteLine("Desea ver tambien los productos que tengan stock cero? Responda si o no");
            Console.WriteLine();
            string stockCero = Console.ReadLine().ToLower();
            Console.WriteLine();

            return stockCero == "si";   
        }                       
        private void MostrarBasesNoContratadas (List<Base> basesNoContratadas)
        {
            var hayBasesNoContratadas = basesNoContratadas.Any();
            if ( hayBasesNoContratadas)
            {
                Console.WriteLine($"Se vencio el periodo contratado de las siguientes bases, debe abonar para poder ver su stock");
                string basesNC = string.Join(", ", basesNoContratadas.Select(_base => _base.Name));

                Console.WriteLine(basesNC);

                Console.WriteLine();
            }           
        }
        private void MostrarBasesNuncaContratadas(List<Base> basesNuncaContratadas)
        {
            var hayBasesNuncaContratadas = basesNuncaContratadas.Any();
            if (hayBasesNuncaContratadas)
            {
                Console.WriteLine($"Debe contratar a las siguientes bases para poder ver su stock");
                string basesNC = string.Join(", ", basesNuncaContratadas.Select(_base => _base.Name));

                Console.WriteLine(basesNC);

                Console.WriteLine();
            }
        }        
        private List<StockArticulo> MenuInicio(StockPorBase stockPorBase, StockPorTienda stockPorTienda, StockPorEtiqueta stockPorEtiqueta,
            List<Articulo> articulosDeTodasLasBases, List<Base> basesContratadas, List<Factura> facturas, List<Tienda> tiendas, List<Etiqueta> etiquetas)
        {
            
            List<StockArticulo> stockArticulos = new List<StockArticulo>();
            var stockCalculado = false;

            do
            {
                Console.WriteLine("Desea visualizar el stock por: (Responda 1, 2 o 3)\n1_ Bases\n2_ Tiendas\n3_ Etiquetas");
                Console.WriteLine();
                string dato = Console.ReadLine();
                int categoriaStock = Convert.ToInt32(dato);
                Console.WriteLine();

                switch (categoriaStock)
                {
                    case 1:
                        stockArticulos = stockPorBase.CalcularStockPorBase(articulosDeTodasLasBases, basesContratadas, facturas);
                        stockCalculado = true;
                        break;
                    case 2:
                        stockArticulos = stockPorTienda.CalcularStocksPorTienda(articulosDeTodasLasBases, tiendas, facturas, basesContratadas);
                        stockCalculado = true;
                        break;
                    case 3:
                        stockArticulos = stockPorEtiqueta.CalcularStocksPorEtiqueta(articulosDeTodasLasBases, etiquetas, tiendas, facturas);
                        stockCalculado = true;
                        break;
                    default:
                        Console.WriteLine("Revisa tu eleccion");
                        break;

                }

            } while (!stockCalculado);
            
            return stockArticulos;
        }
    }
}
