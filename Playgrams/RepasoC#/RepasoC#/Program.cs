using LibreriaRepaso;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepasoC_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var pepon = new Class1();

            var miConejoPepito = new Class1();

            double numero;
            numero = default;
            bool estaVacio = numero == 0;
            Console.WriteLine(numero);
            numero = 0;
            Console.WriteLine(numero);

            string palabra;
            palabra = "h";
            Console.WriteLine(palabra);
            palabra = null;
            Console.WriteLine(palabra);

            DateTime Fecha = new DateTime();
            Fecha = new DateTime(2020, 1, 1);

            DateTime Fecha1 = DateTime.Now;
            //var Fecha2 = Fecha1.Now;
            
            Guid guid = Guid.NewGuid();

            var day = DayOfWeek.Monday;


            var pepe = new Pepe();
            var id = pepe.id;

            pepe.Res();
            Pepe.ResStatic();

            var idstatic = Pepe.idstatic;

            var pepestatic = PepeStatic.idstatic;
            //var pepestaticInstance = new Console();
            NotStatic();

            pepon.Main();
            //object pato = new Class1;

            Condicionales pepon2 = new Condicionales();
            pepon2.Main();

            Bucles pepon3 = new Bucles();
            pepon3.Main();

            Linq pepon4 = new Linq();
            pepon4.Main();

        }


        private static void NotStatic()
        {

        }
    }
    public class Pepe
    {
        public int id;
        public int Res()
        {
            return 1;
        }

        public static int idstatic;
        public static int ResStatic()
        {
            Pepe pepe = new Pepe();
            
            return pepe.Res();
        }

    }

    public static class PepeStatic
    {
        public static int idstatic;
    }
}
