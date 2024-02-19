using System;
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
            var articulosDeTodasLasBasesRepetidos = new List<Articulo>();
            foreach (var Base in bases) 
            {
                articulosDeTodasLasBasesRepetidos.AddRange(Base.Articulos);
            }

            var articulosDeTodasLasBases = new List<Articulo>();
            foreach (var articulo in articulosDeTodasLasBasesRepetidos)
            {
                var loContiene = articulosDeTodasLasBases.Any(art => art.Code == articulo.Code);
                if (!loContiene) articulosDeTodasLasBases.Add(articulo);
            }
            
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
            return basesContratadas;

           
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

            foreach (Articulo articulo in articulosDeTodasLasBases)
            {
                Console.Write($"{articulo.Name,-10}\t");

                foreach (Base _base in basesContratadas)
                {
                    var articuloAMostrar = _base.Articulos.Find
                        (art => art.Code == articulo.Code );

                    var stock = Stock(_base, articuloAMostrar, facturas);

                    if (articuloAMostrar != null && (stock > 0 || hayQueMostrarStockCero))
                    {
                        Console.Write($"{stock,-10}\t");                        
                    }
                    else Console.Write($"{"",-10}\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine();

        }

        private void MostrarEncabezados(List<Base> basesContratadas)
        {
            Console.Write($"{"articulo",-10}\t");
            foreach (Base Base in basesContratadas)
            {
                Console.Write($"{Base.Name,-10}\t");
            }
            Console.WriteLine();
        }

        private void MostrarBasesNoContratadas (List<Base> basesNoContratadas)
        {
            foreach (Base Base in basesNoContratadas)
            {
                Console.WriteLine($"Se vencio el periodo contratado de la base {Base.Name}, debe abonar para poder ver su stock" );
            }
            Console.WriteLine() ;

        }
        private void MostrarBasesNuncaContratadas(List<Base> basesNuncaContratadas)
        {
            foreach (Base Base in basesNuncaContratadas)
            {
                Console.WriteLine($"Debe contratar a la base {Base.Name} para poder ver su stock");
            }
            Console.WriteLine();
        }
        private int Stock(Base _base, Articulo articulo, List<Factura> facturas)
        {
            int stock = 0 ;

            if (articulo != null) 
            {
                foreach (Factura factura in facturas)
                {
                    var detallesPorArticulo = factura.Detalles
                        .Where(detalle => (factura.IdBase == _base.Id & detalle.CodeArticulo == articulo.Code));

                    foreach (Detalle detalle in detallesPorArticulo)
                    {
                        if (factura.TipoFactura == TipoFactura.Ingreso) stock = stock + detalle.Cantidad;
                        else stock = stock - detalle.Cantidad;
                    }
                }
            }           
            return stock;
        }
    }
}
