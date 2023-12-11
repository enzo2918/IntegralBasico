using ClassLibrary1;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numeros = { 1, 2, 3, 4, 5, 6, 7, 8, };

            var valores = (from n in numeros where n % 2 == 0 select n);

            foreach (int i in valores) { Console.WriteLine(i); }

            numeros[0] = 12;

            foreach (int i in valores) { Console.WriteLine(i); }

            Class1.Write1();

            Console.WriteLine("------------------------------------------------------------------------------------------------------");
            Console.WriteLine();



            IEnumerable<string> postresM = ClaseExplicita.PostresDeManzana();
            foreach (string i in postresM) { Console.WriteLine(i); }


            Console.WriteLine("------------------");

            int[] impares = ClaseExplicita.EnterosImpares();
            foreach (int i in impares) { Console.WriteLine(i); }


            Console.WriteLine("------------------");

            List<int> pares = ClaseExplicita.EnterosPares();
            foreach (int i in pares) { Console.WriteLine(i); }




            Console.WriteLine("------------------------------------------------------------------------------------------------------");
            Console.WriteLine();



            List<Estudiante> estudiantes = new List<Estudiante>
            {
                new Estudiante("marcos","ing",8.9),
                new Estudiante("elena","foto",4.9),
                new Estudiante("maria","arte",2.9),
                new Estudiante("laura","ing",3.9),
                new Estudiante("nico","foto",9.9),
                new Estudiante("lucas","ing",7.9),
                new Estudiante("daniel","arte",9.8)

            };

            List<IQ> iqs = new List<IQ>
            {
                new IQ("ing",100),
                new IQ("foto",80),
                new IQ("arte",60),
            };
            var estudiantesdescendentes = from e in estudiantes
                                          orderby e.Promedio descending
                                          select e
                                          into i
                                          where i.Carrera == "ing"
                                          select i;

            foreach (var e in estudiantesdescendentes) { Console.WriteLine(e); }
            Console.WriteLine("------------------");

            var estudiantesascendentes = from e in estudiantes
                                          orderby e.Nombre ascending
                                         select e;

            foreach (var e in estudiantesascendentes) { Console.WriteLine(e); }
            Console.WriteLine("------------------");

            var estudiantesIngenieros = from e in estudiantes
                                        where e.Carrera == "ing"
                                        select e;

            foreach (var e in estudiantesIngenieros) { Console.WriteLine(e); }
            Console.WriteLine("------------------");

            IEnumerable<string> estudiantesReprobados = from e in estudiantes
                                                        where e.Promedio < 6
                                                        select e.Nombre;

            foreach (var e in estudiantesReprobados) { Console.WriteLine(e); }
            Console.WriteLine("------------------");

            var estudiantesAprobados = from e in estudiantes
                                       where e.Promedio >= 6
                                       select e.Nombre;

            foreach (var e in estudiantesAprobados) { Console.WriteLine(e); }
            Console.WriteLine("------------------");

            var estudianteshombres = from e in estudiantes
                                     where e.Promedio >= 6
                                     select new { e.Nombre, e.Promedio };

            foreach (var e in estudianteshombres) { Console.WriteLine(e); }
            Console.WriteLine("------------------------------------------------------------------------------------------------");




            //SINTAXIS FLUIDA

            IEnumerable<Estudiante> estudiantesingenieros = estudiantes
                .Where(p => p.Promedio > ((estudiantes.Where(p2=> p2.Promedio > 6)).First()).Promedio)
                .OrderByDescending(p => p.Promedio);
                

            foreach (var e in estudiantesingenieros) { Console.WriteLine(e); }
            Console.WriteLine("------------------");
            var carreracorrecta = from e in estudiantes
                                  from i in iqs
                                  where e.Carrera == i.Carrera
                                  select i.Iq + " es el iq adecuado para estudiar " + e.Carrera;
            foreach (var e in carreracorrecta) { Console.WriteLine(e); }

            Console.WriteLine("------------------");
            var carreraapropiada = estudiantes.SelectMany(e => iqs.Where(i => i.Carrera == e.Carrera),
                (e, i) =>  (i.Iq, " es el iq adecuado para estudiar ", e.Carrera));
            foreach (var e in carreraapropiada) { Console.WriteLine(e); }

            Console.WriteLine("------------------");
            var carreraCorrecta = estudiantes.Join(iqs, estudiante => estudiante.Carrera, iq => iq.Carrera, 
                (estudiante, iq) => (iq.Iq, " es el iq adecuado para estudiar ", estudiante.Carrera));
            foreach (var e in carreraCorrecta) { Console.WriteLine(e); }


            Console.WriteLine("------------------------------------------------------------------------------------------------");


            var carreraApropiada = from e in estudiantes
                                   join i in iqs on e.Carrera equals i.Carrera
                                   select i.Iq + " es el iq adecuado para estudiar " + e.Carrera;

            foreach (var e in carreraApropiada) { Console.WriteLine(e); }

            Console.WriteLine("------------------");

            var carreraApropiadaIq = from e in estudiantes
                                     join i in iqs on e.Carrera equals i.Carrera
                                     into apropiado
                                     select new { estudianteiq = e.Carrera, apropiado };
            foreach(var e in carreraApropiadaIq)
            {
                Console.WriteLine(e.estudianteiq);
                foreach(var i in e.apropiado) { Console.WriteLine(i); }
            }

        }
    }
}
