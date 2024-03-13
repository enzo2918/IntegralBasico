using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaStock
{
    internal class StockPorEtiqueta
    {
        public List<StockArticulo> CalcularStocksPorEtiqueta(List<Articulo> articulos, List<Etiqueta> etiquetas, List<Tienda> tiendas, List<Factura> facturas)
        {
            List<StockArticulo> stocksPorEtiqueta = new List<StockArticulo>();

            foreach (var articulo in articulos)
            {
                foreach (var etiqueta in etiquetas)
                {
                    var stockPorEtiqueta = new StockArticulo();
                    
                    var stockCalculado = false;

                    var tiendasDeLaEtiqueta = tiendas.Where(tienda => tienda.IdEtiquetas.Contains(etiqueta.Id));

                    foreach (var tienda in tiendasDeLaEtiqueta)
                    {
                        var facturasDeLaTienda = facturas.Where(fact => tienda.IdBases.Contains(fact.IdBase));

                        foreach (var factura in facturasDeLaTienda)
                        {
                            var cantidadTotalDelArticuloEnLaFactura = factura.Detalles
                                .Where(det => det.CodeArticulo == articulo.Code)
                                .Sum(det => det.Cantidad);

                            if (factura.TipoFactura == TipoFactura.Egreso) cantidadTotalDelArticuloEnLaFactura *= -1;

                            stockPorEtiqueta.Stock += cantidadTotalDelArticuloEnLaFactura;
                            stockCalculado = true;
                        }

                    }

                    if (stockCalculado)
                    {
                        stockPorEtiqueta.Articulo = articulo;
                        stockPorEtiqueta.Origen = etiqueta.Name;

                        stocksPorEtiqueta.Add(stockPorEtiqueta);
                    }

                }
            }

            return stocksPorEtiqueta;
        }
    }
}
