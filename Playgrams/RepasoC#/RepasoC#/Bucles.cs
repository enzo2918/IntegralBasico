using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepasoC_
{
    internal class Bucles
    {
        public void Main()
        {
            double[] numeros=new double[10];

            for (int i = 0; i < numeros.Length; i++) 
            {
                numeros[i] = i;
            }

            foreach (int i in numeros)
            {
                
                Console.WriteLine(i);
            }

            var contador = 0;
            do
            {
                numeros[contador] = contador;
                contador++;

            }while (contador < numeros.Length);

            contador = 0;
            while (contador < numeros.Length)
            {
                numeros[contador] = contador;
                contador++;
            };



        }
    }
}
               