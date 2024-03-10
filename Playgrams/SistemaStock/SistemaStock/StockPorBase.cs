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

            foreach (var articulo in articulos)
            {
                foreach (var _base  in bases)
                {
                    var stockPorBase = new StockArticulo();
                    stockPorBase.Articulo = articulo;
                    stockPorBase.Origen = _base.Name;

                    var facturasDeLaBase = facturas.Where(fact => fact.IdBase == _base.Id);

                    foreach (var factura in facturasDeLaBase)
                    {
                        var cantidadTotalDelArticuloEnLaFactura = factura.Detalles
                            .Where(det => det.CodeArticulo == articulo.Code)
                            .Sum(det => det.Cantidad);

                        if (factura.TipoFactura == TipoFactura.Egreso) cantidadTotalDelArticuloEnLaFactura *= -1;

                        stockPorBase.Stock += cantidadTotalDelArticuloEnLaFactura;
                    }

                    stocksPorBase.Add(stockPorBase);                   
                }               
            }

            return stocksPorBase;
        }
    }
}
