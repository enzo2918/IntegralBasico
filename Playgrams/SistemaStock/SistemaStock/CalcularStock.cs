using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaStock
{
    internal class CalcularStock
    {       
        public List<StockArticulo> EjecutarLogica(CalcularStockParams calcularStockParams)
        {
            List<StockArticulo> stocksPorOrigen = new List<StockArticulo>();

            foreach (string origen in calcularStockParams.Origenes)
            {
                var articulos = calcularStockParams.ArticulosDelOrigen[origen];

                foreach (var articulo in articulos)
                {
                    var movimientos = calcularStockParams.MovimientosDelArticulo[(articulo.Code, origen)];                

                    if (movimientos.Any())
                    {
                        var stockArticulo = movimientos.Sum(mov => mov.TipoFactura == TipoFactura.Ingreso ? mov.CantidadDelArticulo : mov.CantidadDelArticulo * -1);

                        var stockPorOrigen = new StockArticulo();
                        stockPorOrigen.Articulo = articulo;
                        stockPorOrigen.Origen = origen;
                        stockPorOrigen.Stock = stockArticulo;

                        stocksPorOrigen.Add(stockPorOrigen);
                    }                    
                }                               
            }

            return stocksPorOrigen.ToList();
        }
    }
}
