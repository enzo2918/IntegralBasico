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
            var bases = repoBase.TraerLista();
            var contratacionesPorBase = repoContratacionBase.TraerLista();


            Console.WriteLine("Desea ver tambien los productos que tengan stock cero? Responda si o no");                
            string stockCero =  Console.ReadLine().ToLower();
            Console.WriteLine();


            foreach (var x in bases) 
            {                
                var ultimaContratacion = UltimaContratacion(contratacionesPorBase, x);

                if (ultimaContratacion != null)
                {
                    MostrarBaseContratada(x,stockCero,ultimaContratacion);

                }
                else Console.WriteLine("Debe contratar a la base {0} para poder ver su stock", x.Name);

                Console.WriteLine();
            }                                                            
        }



        private ContratacionBase UltimaContratacion(List<ContratacionBase> contratacionesPorBase, Base x ) 
        {
            var basesContratadas = contratacionesPorBase.Where
                    (contratacion => contratacion.IdBase == x.Id);

            var basesContratadasOrdenadas = basesContratadas.OrderByDescending(b => b.Fecha);

            var ultimaContratacion = basesContratadasOrdenadas.FirstOrDefault();

            return ultimaContratacion;
        } 

        private void MostrarBaseContratada(Base x, string stockCero,ContratacionBase ultimaContratacion)
        {
            if (ultimaContratacion.AccionDeContratacion == ContratacionBase.Accion.Alta)
            {
                MostrarStock(x, stockCero);

            }
            else Console.WriteLine("La base {0} no se encuentra contratada, " +
                "debe abonar para poder ver su stock", x.Name);
        }

        private void MostrarStock(Base x, string stockCero)
        {
            Console.WriteLine("En base {0} tienes:", x.Name);
            foreach (Articulo articulo in x.Articulo)
            {
                if (stockCero == "no")
                {
                    if (articulo.Stock != 0)
                    {
                        Console.WriteLine("{0} {1}", articulo.Stock, articulo.Name);
                        
                    }
                }
                else
                {
                    Console.WriteLine("{0} {1}", articulo.Stock, articulo.Name);
                }
            }
        }
    }
}
