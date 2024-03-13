using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaStock
{
    internal class RepoFactura
    {
        List<Factura> facturas = new List<Factura>();

        public RepoFactura() 
        {
            facturas.AddRange(new List<Factura>
            {
                new Factura
                {
                    IdBase = 2,
                    Id = 1,
                    TipoFactura = TipoFactura.Ingreso,
                    Detalles =
                    {
                        new Detalle {CodeArticulo = "fer", Cantidad = 2, Precio = 7500},
                        new Detalle {CodeArticulo = "fid", Cantidad = 2, Precio = 500},
                        new Detalle {CodeArticulo = "len", Cantidad = 3, Precio = 600},
                        new Detalle {CodeArticulo = "por", Cantidad = 1, Precio = 400},
                        new Detalle {CodeArticulo = "cep", Cantidad = 3, Precio = 1500}
                    }
                },

                new Factura
                {
                    IdBase = 1,
                    Id = 9,
                    TipoFactura = TipoFactura.Ingreso,
                    Detalles =
                    {
                        new Detalle {CodeArticulo = "fid", Cantidad = 2, Precio = 500},
                        new Detalle {CodeArticulo = "len", Cantidad = 3, Precio = 600},
                        new Detalle {CodeArticulo = "por", Cantidad = 4, Precio = 400}
                    }
                },

                new Factura
                {
                    IdBase = 1,
                    Id = 10,
                    TipoFactura = TipoFactura.Egreso,
                    Detalles =
                    {
                        new Detalle {CodeArticulo = "fid", Cantidad = 1, Precio = 500},
                        new Detalle {CodeArticulo = "len", Cantidad = 1, Precio = 600},
                        new Detalle {CodeArticulo = "por", Cantidad = 1, Precio = 400}
                    }
                },

                new Factura
                {
                    IdBase = 2,
                    Id = 2,
                    TipoFactura = TipoFactura.Egreso,
                    Detalles =
                    {
                        new Detalle {CodeArticulo = "fer", Cantidad = 1, Precio = 7500},
                        new Detalle {CodeArticulo = "fid", Cantidad = 1, Precio = 700},
                        new Detalle {CodeArticulo = "len", Cantidad = 1, Precio = 800},
                        new Detalle {CodeArticulo = "cep", Cantidad = 3, Precio = 2000}

                    }

                },
                new Factura
                {
                    IdBase = 3,
                    Id = 3,
                    TipoFactura = TipoFactura.Ingreso,
                    Detalles =
                    {
                        new Detalle {CodeArticulo = "fer", Cantidad = 2, Precio = 7500},
                        new Detalle {CodeArticulo = "gan", Cantidad = 3, Precio = 5000},
                        new Detalle {CodeArticulo = "vod", Cantidad = 3, Precio = 4000}
                    }

                },
                new Factura
                {
                    IdBase = 3,
                    Id = 4,
                    TipoFactura = TipoFactura.Egreso,
                    Detalles =
                    {
                        new Detalle {CodeArticulo = "fer", Cantidad = 1, Precio = 9000},
                        new Detalle {CodeArticulo = "gan", Cantidad = 1, Precio = 6000},
                        new Detalle {CodeArticulo = "vod", Cantidad = 1, Precio = 5000}
                    }

                },
                new Factura
                {
                    IdBase = 4,
                    Id = 5,
                    TipoFactura = TipoFactura.Ingreso,
                    Detalles =
                    {
                        new Detalle {CodeArticulo = "fer", Cantidad = 6, Precio = 7500},
                        new Detalle {CodeArticulo = "gan", Cantidad = 5, Precio = 5000},
                        new Detalle {CodeArticulo = "vod", Cantidad = 4, Precio = 4000},
                        new Detalle {CodeArticulo = "coc", Cantidad = 10, Precio = 2000},
                        new Detalle {CodeArticulo = "spr", Cantidad = 6, Precio = 2000},
                        new Detalle {CodeArticulo = "cep", Cantidad = 3, Precio = 1500}
                    }

                },
                new Factura
                {
                    IdBase = 4,
                    Id = 6,
                    TipoFactura = TipoFactura.Egreso,
                    Detalles =
                    {
                        new Detalle {CodeArticulo = "fer", Cantidad = 1, Precio = 7500},
                        new Detalle {CodeArticulo = "gan", Cantidad = 2, Precio = 5000},
                        new Detalle {CodeArticulo = "vod", Cantidad = 1, Precio = 4000},
                        new Detalle {CodeArticulo = "coc", Cantidad = 4, Precio = 2000},
                        new Detalle {CodeArticulo = "spr", Cantidad = 1, Precio = 2000},
                        new Detalle {CodeArticulo = "cep", Cantidad = 3, Precio = 1500}
                    }

                },
                new Factura
                {
                    IdBase = 5,
                    Id = 7,
                    TipoFactura = TipoFactura.Ingreso,
                    Detalles =
                    {
                        new Detalle {CodeArticulo = "fer", Cantidad = 1, Precio = 7500},
                        new Detalle {CodeArticulo = "gan", Cantidad = 2, Precio = 5000},
                        new Detalle {CodeArticulo = "vod", Cantidad = 1, Precio = 4000},
                        new Detalle {CodeArticulo = "cep", Cantidad = 4, Precio = 2000},
                        new Detalle {CodeArticulo = "por", Cantidad = 1, Precio = 2000},
                        new Detalle {CodeArticulo = "len", Cantidad = 3, Precio = 1500},
                        new Detalle {CodeArticulo = "fid", Cantidad = 3, Precio = 1500}
                    }

                },
                new Factura
                {
                    IdBase = 5,
                    Id = 8,
                    TipoFactura = TipoFactura.Egreso,
                    Detalles =
                    {
                        new Detalle {CodeArticulo = "fer", Cantidad = 1, Precio = 7500},
                        new Detalle {CodeArticulo = "gan", Cantidad = 1, Precio = 5000},
                        new Detalle {CodeArticulo = "vod", Cantidad = 1, Precio = 4000},
                        new Detalle {CodeArticulo = "cep", Cantidad = 2, Precio = 2000},
                        new Detalle {CodeArticulo = "por", Cantidad = 1, Precio = 2000},
                        new Detalle {CodeArticulo = "len", Cantidad = 2, Precio = 1500},
                        new Detalle {CodeArticulo = "fid", Cantidad = 1, Precio = 1500}
                    }

                }
            }
            );
        }


        public List<Factura> TraerLista()
        {
            return facturas.ToList();
        }
    }
}
