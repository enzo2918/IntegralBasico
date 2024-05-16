using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaStock
{
    internal class StockPorBase
    {
        public List<StockArticulo> CalcularStockPorBase(List<Articulo> articulos, List<Base> bases, List<Factura> facturas)
        {
            List<StockArticulo> stocksPorBase = new List<StockArticulo>();

            var facturasPorBase = new Dictionary<int, List<Factura>>();
            foreach (var _base in bases)
            {
                var facturasDeLaBase = facturas.Where(fact => fact.IdBase == _base.Id).ToList();
                facturasPorBase.Add(_base.Id, facturasDeLaBase);
            }

            var articulosPorBase = new Dictionary<Base, List<Articulo>>();
            foreach (var _base in bases)
            {
                articulosPorBase.Add(_base, _base.Articulos);
            }

            var facturasPorBase2 = bases.ToDictionary(b => b.Id, b => facturas.Where(fact => fact.IdBase == b.Id).ToList());

            var facturasPorBase3 = facturas.GroupBy(f => f.IdBase).ToDictionary(g => g.Key, g => g.ToList());

            var articulosPorBase2 = bases.ToDictionary(b => b, b => b.Articulos);







     





            foreach (var articulo in articulos)
            {
                foreach (var _base  in bases)
                {
                    int stockArticulo = 0;
                    var articuloTuvoMovimientos = false;

                    var facturasDeLaBase = facturasPorBase[_base.Id];
                    foreach (var factura in facturasDeLaBase)
                    {
                        var detalleDelArticuloEnLaFactura = factura.Detalles
                            .Where(det => det.CodeArticulo == articulo.Code);
                            
                        if (detalleDelArticuloEnLaFactura.Any())
                        {
                            var cantidadTotalDelArticuloEnLaFactura = detalleDelArticuloEnLaFactura.Sum(det => det.Cantidad);

                            if (factura.TipoFactura == TipoFactura.Egreso) cantidadTotalDelArticuloEnLaFactura *= -1;

                            stockArticulo += cantidadTotalDelArticuloEnLaFactura;
                            articuloTuvoMovimientos = true;
                        }
                    }

                    if (articuloTuvoMovimientos)
                    {
                        var stockPorBase = new StockArticulo();
                        stockPorBase.Articulo = articulo;
                        stockPorBase.Origen = _base.Name;
                        stockPorBase.Stock = stockArticulo;

                        stocksPorBase.Add(stockPorBase);
                    }                 
                }               
            }

            return stocksPorBase;
        }



       
        }
        public CalcularStockParams CalcularParametrosPorBase()
        {

        }

        private List<string> CrearListaDeOrigenes(List<Base> bases) 
        {
            var origenes = bases.Select(bas => bas.Name).ToList();
            return origenes;
        }

        private Dictionary<string,List<Articulo>> CrearDiccionarioDeArticuloYOrigen(List<Base> bases)
        {
            var articulosYSuOrigen = bases.ToDictionary(bas => bas.Name, bas => bas.Articulos);
            return articulosYSuOrigen;
        }

        private Dictionary<string,List<DT>> CrearDiccionarioDeArticuloYDT(List<Base> bases,List<Factura> facturas)
        {
            var movimientoYSuArticulo = 
        }



    }
}
