using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaStock
{
    internal class MenuInicio
    {
        public void Iniciar() 
        {
            RepoBase repoBase = new RepoBase();
            RepoContratacionBase repoContratacionBase = new RepoContratacionBase();
            RepoFactura repoFactura = new RepoFactura();
            var facturas = repoFactura.TraerLista();
            var bases = repoBase.TraerLista();
            var contratacionesPorBase = repoContratacionBase.TraerLista();

            var basesContratadas = CrearListaDeBasesContratadas(contratacionesPorBase, bases);
            var basesNoContratadas = CrearListaDeBasesNoContratadas(contratacionesPorBase, bases);
            var basesNuncaContratadas = CrearListaDeBasesNuncaContratadas(contratacionesPorBase, bases);
            var articulosDeTodasLasBases = CrearListaConTodosLosArticulos(bases);
            bool hayQueMostrarStockCero = PedirOpcionMostrarStockCero();


            MostrarStockPorBase(articulosDeTodasLasBases, basesContratadas, hayQueMostrarStockCero,facturas);
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
            string stockCero = Console.ReadLine().ToLower();
            Console.WriteLine();

            return stockCero == "si";   
        }


        private void MostrarStockPorBase
            (List<Articulo> articulosDeTodasLasBases, List<Base> basesContratadas, bool hayQueMostrarStockCero, List<Factura> facturas)
        {
            MostrarEncabezados(basesContratadas);

            Console.WriteLine();

            foreach (Articulo articulo in articulosDeTodasLasBases)
            {                    
                var stockDelArticuloEnTodasLasBases = new List<string>();
                var tieneStockEnAlgunaBase = false;

                foreach (Base _base in basesContratadas)
                {
                    var valorStock = string.Empty;

                    var articuloAMostrar = _base.Articulos.Find
                        (art => art.Code == articulo.Code);


                    if (articuloAMostrar != null)
                    {
                        var stock = CalcularStock(_base, articuloAMostrar, facturas);

                        if (stock > 0 || hayQueMostrarStockCero)
                        {
                            valorStock = stock.ToString();
                            tieneStockEnAlgunaBase = true;
                        }                           
                    }

                    stockDelArticuloEnTodasLasBases.Add(valorStock);
                }

                if (tieneStockEnAlgunaBase || hayQueMostrarStockCero)
                {
                    Console.Write($"{articulo.Name,-10}\t");
                    Console.Write($"{articulo.Code,-10}\t");
                    foreach (var valorStock in stockDelArticuloEnTodasLasBases)
                    {
                        Console.Write($"{valorStock,-10}\t");
                    }

                    Console.WriteLine();
                }                                                                               
            }
            Console.WriteLine();

        }

        private void MostrarEncabezados(List<Base> basesContratadas)
        {
            Console.Write($"{"Articulo",-10}\t");
            Console.Write($"{"Codigo",-10}\t");
            foreach (Base Base in basesContratadas)
            {
                Console.Write($"{Base.Name,-10}\t");
            }
            Console.WriteLine();
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
        private int CalcularStock(Base _base, Articulo articulo, List<Factura> facturas)
        {
            int stock = 0 ;

            var facturasDeLaBase = facturas.Where(fact => fact.IdBase == _base.Id);

            foreach (Factura factura in facturasDeLaBase)
            {
                var cantidadTotalDeArticuloEnFactura = factura.Detalles
                    .Where(detalle => (detalle.CodeArticulo == articulo.Code))
                    .Sum(detalle => detalle.Cantidad);

                if (factura.TipoFactura == TipoFactura.Egreso) cantidadTotalDeArticuloEnFactura *= -1;


                stock += cantidadTotalDeArticuloEnFactura;

            }

            return stock;
        }
    }
}
