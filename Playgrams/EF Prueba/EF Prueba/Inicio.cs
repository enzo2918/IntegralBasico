using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Net;

namespace EF_Prueba
{
    internal class Inicio
    {
        public Inicio()
        {
            

            
        }
        private void ConsultasHijosComidas()
        {
            using (var BDFamilia = new FamiliaContext())
            {
                var hijosSinDatoComidas = BDFamilia.Hijos.ToList();
                var pepe = hijosSinDatoComidas.FirstOrDefault();

                var hijos = BDFamilia.Hijos.Include(h => h.HijosComidas.Select(hc => hc.Comida)).ToList();
                foreach (var hijo in hijos)
                {
                    foreach (var hijoComida in hijo.HijosComidas)
                    {
                        Console.WriteLine($"Hijo: Id({hijo.Id}), Nombre({hijo.Name}), Comidas({hijoComida.Comida.Name})");
                    }
                }
                Console.WriteLine();

                var comidas = BDFamilia.Comidas.Include(c => c.HijosComidas.Select(hc => hc.Hijo)).ToList();
                foreach (var comida in comidas)
                {
                    foreach (var hijoComida in comida.HijosComidas)
                    {
                        Console.WriteLine($"Hijo: Id({hijoComida.Hijo.Id}), Nombre({hijoComida.Hijo.Name}), Comidas({comida.Name})");
                    }
                }
                Console.WriteLine();

                var hijosComidas = BDFamilia.HijosComidas.Include(hc => hc.Hijo).Include(_hc => _hc.Comida).ToList();
                var hijosEmpanadas = hijosComidas.Where(hc => hc.Comida.Name == "hamburguesa");
                //.GroupBy(h => h.Hijo.Name)            
                //.Select(g => g.First())
                //.ToList();

                Console.WriteLine("Los hijos que comen empanadas son:");
                foreach (var hijoComida in hijosEmpanadas)
                {
                    Console.WriteLine(hijoComida.Hijo.Name);
                }
            }
        }
        private void ConsultasHijosCumpleaños()
        {
            using (var BDFamilia = new FamiliaContext())
            {
                var hijosSinDatoCumpleaños = BDFamilia.Hijos.ToList();
                var pepe = hijosSinDatoCumpleaños.FirstOrDefault();

                var hijos = BDFamilia.Hijos.Include(h => h.Cumpleaños).ToList();
                foreach (var hijo in hijos)
                {
                    Console.WriteLine($"Hijo: Id({hijo.Id}), Nombre({hijo.Name}), Cumpleaños({hijo.Cumpleaños?.FechaCumpleaños})");
                }
                var hijosQueTienenCumpleaños = BDFamilia.Hijos.Include(h => h.Cumpleaños).Where(h => h.Cumpleaños != null).ToList();


                var cumpleaños = BDFamilia.Cumpleaños.Include(c => c.Hijos).ToList();

                foreach (var cumple in cumpleaños)
                {
                    foreach (var hijo in cumple.Hijos)
                    {
                        Console.WriteLine($"Hijo: Id({hijo.Id}), Nombre({hijo.Name}), Cumpleaños({cumple.FechaCumpleaños})");
                    }
                }
            }
        }
        private void ConsultasHijosDni()
        {
            using (var BDFamilia = new FamiliaContext())
            {
                var hijosSinDatoDni = BDFamilia.Hijos.ToList();
                var pepe = hijosSinDatoDni.FirstOrDefault();

                var hijos = BDFamilia.Hijos.Include(h => h.Dni).ToList();
                foreach (var hijo in hijos)
                {
                    Console.WriteLine($"Hijo: Id({hijo.Id}), Nombre({hijo.Name}), Dni({hijo.Dni?.NumeroDni})");
                }

                var hijosQueTienenDNI = BDFamilia.Hijos.Include(h => h.Dni).Where(h => h.Dni != null).ToList();


                var dnis = BDFamilia.Dnis.Include(h => h.Hijo).ToList();

                foreach (var dni in dnis)
                {
                    Console.WriteLine($"Hijo: Id({dni.Hijo.Id}), Nombre({dni.Hijo.Name}), Dni({dni.NumeroDni})");
                }
            }
        }
        private void OperacionesBasicas()
        {
            using (var BDFamilia = new FamiliaContext())
            {

                MostrarHijos(BDFamilia);

                var hijoAñadido = AñadirHijo(BDFamilia);

                MostrarHijos(BDFamilia);

                EliminarHijo(BDFamilia, hijoAñadido.Id);

                MostrarHijos(BDFamilia);

                var hijoAñadido2 = AñadirHijo(BDFamilia);

                MostrarHijos(BDFamilia);

                BuscarHijo(BDFamilia, hijoAñadido2.Id);

                ModificarHijo(BDFamilia, hijoAñadido2.Id);

                MostrarHijos(BDFamilia);

                EliminarHijo(BDFamilia, hijoAñadido2.Id);

                MostrarHijos(BDFamilia);


            }
        }

        private Hijo AñadirHijo(FamiliaContext BDFamilia )
        {
            var nuevohijo = new Hijo { Name = $"pepe, fecha: {DateTime.Now}" };
            BDFamilia.Hijos.Add(nuevohijo);
            BDFamilia.SaveChanges();
            Console.WriteLine($"Hijo añadido {nuevohijo.Id}");
            return nuevohijo;
        }
        private void EliminarHijo(FamiliaContext BDFamilia,int id)
        {
            var hijos = BDFamilia.Hijos.ToList();
            var hijoAEliminar = hijos.FirstOrDefault(h => h.Id == id);
            BDFamilia.Hijos.Remove(hijoAEliminar);
            BDFamilia.SaveChanges();
            Console.WriteLine($"Hijo eliminado {hijoAEliminar.Id}");
        }
        private void ModificarHijo(FamiliaContext BDFamilia, int id)
        {
            var hijos = BDFamilia.Hijos.ToList();
            var hijoAModificar = hijos.FirstOrDefault(h => h.Id == id);
            hijoAModificar.Name = DateTime.Now.ToString();
            BDFamilia.SaveChanges();
            Console.WriteLine($"Hijo modificado {hijoAModificar.Id}");
        }
        private void MostrarHijos(FamiliaContext BDFamilia)
        {
            var hijos = BDFamilia.Hijos.ToList();
            Console.WriteLine("Hijos: "+string.Join(" ------ ", hijos.Select(h => h.Name)));
        }
        private void BuscarHijo(FamiliaContext BDFamilia, int id)
        {
            var hijos = BDFamilia.Hijos.ToList();
            var hijoABuscar = hijos.FirstOrDefault(h => h.Id == id);
            Console.WriteLine($"Hijo buscado: Id({hijoABuscar.Id}), Nombre({hijoABuscar.Name})");

        }
    }
}
