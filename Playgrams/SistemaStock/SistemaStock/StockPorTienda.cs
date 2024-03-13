using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SistemaStock
{
    internal class StockPorTienda
    {
        public List<StockArticulo> CalcularStocksPorTienda(List<Articulo> articulos, List<Tienda> tiendas, List<Factura> facturas, List<Base> bases)
        {
            List<StockArticulo> stocksPorTienda = new List<StockArticulo>();

            foreach (var articulo in articulos)
            {
                foreach (var tienda in tiendas)
                {
                    var stockPorTienda = new StockArticulo();
                    var stockCalculado = false;
                                                          
                    var facturasDeLaTienda = facturas.Where(fact => tienda.IdBases.Contains(fact.IdBase));

                    foreach (var factura in facturasDeLaTienda)
                    {
                        var cantidadTotalDelArticuloEnLaFactura = factura.Detalles
                            .Where(det => det.CodeArticulo == articulo.Code)
                            .Sum(det => det.Cantidad);

                        if (factura.TipoFactura == TipoFactura.Egreso) cantidadTotalDelArticuloEnLaFactura *= -1;

                        stockPorTienda.Stock += cantidadTotalDelArticuloEnLaFactura;

                        stockCalculado = true;
                    }

                    

                    if (stockCalculado)
                    {
                        stockPorTienda.Articulo = articulo;
                        stockPorTienda.Origen = tienda.Name;

                        stocksPorTienda.Add(stockPorTienda);
                    }
                    
                }
            }

            return stocksPorTienda;                       
        }
    }
}
