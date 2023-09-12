using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegralBasico
{
    internal class Program
    {
        static void Main(string[] args)

        {
            int seleccionp = 0;
            int seleccion = 0;
            string dato = "";
            int semanas = 0;
            int dias = 0;
            int n = 0;
            int m = 0;
            double valor = 0;
            double sumatoria = 0;
            double divisa = 0;


            Console.WriteLine("Bienvenido a tu asistente");
            Console.WriteLine();
            do
            {
                Console.WriteLine("Seleccione la que herramienta le gustaria utilizar, o escriba 5 para salir");
                Console.WriteLine();
                Console.WriteLine("1. Calculadora\n2. Convertidor de divisas\n3. Promedio de pesos logrados por semana\n4. Registro de progresos\n5. Salir");
                seleccionp = pedirseleccion();
                switch (seleccionp)
                {
                    case 1:
                        do
                        {
                            valor = 0;
                            sumatoria = 0;

                            Console.WriteLine("Que operacion desea relizar");
                            Console.WriteLine("1. Suma\n2. Resta\n3. Multiplicación\n4. Division\n5. Salir");

                            seleccion = pedirseleccion();
                            if (seleccion == 1)
                            {
                                Console.WriteLine("Escribe los numeros que quieras sumar y luego presiona R para ver el resultado");

                                do
                                {
                                    dato = Console.ReadLine();
                                    if (dato != "R" && dato != "r")
                                    {
                                        valor = Convert.ToDouble(dato);
                                        sumatoria = sumatoria + valor;
                                    }

                                } while (dato != "R" && dato != "r");
                                Console.WriteLine("El resultado es {0}", sumatoria);
                                Console.WriteLine();
                            }
                            else if (seleccion == 2)
                            {
                                Console.WriteLine("Escribe los numeros que quieras restar y luego presiona R para ver el resultado");
                                sumatoria = pedirvalor();
                                do
                                {
                                    dato = Console.ReadLine();
                                    if (dato != "R" && dato != "r")
                                    {
                                        valor = Convert.ToDouble(dato);
                                        sumatoria = sumatoria - valor;
                                    }

                                } while (dato != "R" && dato != "r");
                                Console.WriteLine("El resultado es {0}", sumatoria);
                                Console.WriteLine();
                            }
                            else if (seleccion == 3)
                            {
                                Console.WriteLine("Escribe los numeros que quieras multiplicar y luego presiona R para ver el resultado");
                                sumatoria = 1;
                                do
                                {
                                    dato = Console.ReadLine();
                                    if (dato != "R" && dato != "r")
                                    {
                                        valor = Convert.ToDouble(dato);
                                        sumatoria = sumatoria * valor;
                                    }

                                } while (dato != "R" && dato != "r");
                                Console.WriteLine("El resultado es {0}", sumatoria);
                                Console.WriteLine();
                            }
                            else if (seleccion == 4)
                            {
                                Console.WriteLine("Escribe los numeros que quieras dividir y luego presiona R para ver el resultado");

                                sumatoria = pedirvalor();
                                do
                                {
                                    dato = Console.ReadLine();
                                    if (dato != "R" && dato != "r")
                                    {
                                        valor = Convert.ToDouble(dato);
                                        sumatoria = sumatoria / valor;
                                    }

                                } while (dato != "R" && dato != "r");
                                Console.WriteLine("El resultado es {0}", sumatoria);
                                Console.WriteLine();
                            }
                            else if (seleccion == 5)
                            {
                                Console.WriteLine();
                            }
                            else
                            {
                                Console.WriteLine("Su seleccion es incorrecta");
                                Console.WriteLine();
                            }
                        } while (seleccion != 5);
                        Console.WriteLine();

                        break;
                    case 2:

                        Console.WriteLine("Cuantos pesos tienes?");
                        valor = pedirvalor();
                        Console.WriteLine();
                        while (valor > 0)
                        {
                            Console.WriteLine("A que divisa los quieres convertir");
                            Console.WriteLine("1. Euro\n2. Dolar\n3. Chileno\n4. Salir");
                            seleccion = pedirseleccion();
                            switch (seleccion)
                            {
                                case 1:
                                    divisa = conversion(850, valor);
                                    Console.WriteLine("{0} pesos son {1} euros", valor, divisa);
                                    Console.WriteLine();
                                    break;
                                case 2:
                                    divisa = conversion(730, valor);
                                    Console.WriteLine("{0} pesos son {1} dolares", valor, divisa);
                                    Console.WriteLine();
                                    break;
                                case 3:
                                    divisa = conversion(0.5, valor);
                                    Console.WriteLine("{0} pesos son {1} chilenos", valor, divisa);
                                    Console.WriteLine();
                                    break;
                                case 4:
                                    valor = 0;
                                    break;
                                default:
                                    Console.WriteLine("Su seleccion es incorrecta");
                                    Console.WriteLine();
                                    break;
                            }

                        }
                        Console.WriteLine();
                        break;

                    case 3:
                        sumatoria = 0;
                        Console.WriteLine("Cuantas semanas quieres promediar?");
                        semanas = pedirseleccion();
                        Console.WriteLine("Cuantos dias a la semana entrenas?");
                        dias = pedirseleccion();
                        int[,] pesosl = new int[semanas, dias];
                        double[] promedio = new double[semanas];
                        for (n = 0; n < semanas; n++)
                        {
                            for (m = 0; m < dias; m++)
                            {
                                Console.WriteLine("Dame el {0}° peso de la {1}° semana", m + 1, n + 1);
                                pesosl[n, m] = pedirseleccion();
                            }
                        }
                        Console.WriteLine();
                        for (n = 0; n < semanas; n++)
                        {
                            Console.WriteLine("Semana {0}", n + 1);
                            for (m = 0; m < dias; m++)
                            {
                                Console.Write("{0} ", pesosl[n, m]);

                            }
                            Console.WriteLine();
                        }
                        Console.WriteLine();
                        for (n = 0; n < semanas; n++)
                        {
                            sumatoria = 0;
                            for (m = 0; m < dias; m++)
                            {
                                sumatoria = sumatoria + pesosl[n, m];

                            }
                            promedio[n] = sumatoria / dias;
                            Console.WriteLine("El promedio en la semana {0} es {1}", n + 1, promedio[n]);
                        }
                        Console.WriteLine();

                        break;
                    case 4:
                        double pmayor = 0;
                        string mejercicio = "";
                        Console.WriteLine("Cuantos ejercicios haces?");
                        seleccion = pedirseleccion();
                        Console.WriteLine("Cual es tu peso corporal");
                        valor = pedirvalor();
                        progresos[] ejercicio = new progresos[seleccion];
                        for (n = 0; n < seleccion; n++)
                        {
                            ejercicio[n].pcorporal = valor;
                            Console.WriteLine("Dame el nombre del {0}° ejercicio", n + 1);
                            ejercicio[n].nombre = Console.ReadLine();
                            Console.WriteLine("Que musculo entrenas principalmente con este ejercicio?");
                            ejercicio[n].musculo = Console.ReadLine();
                            Console.WriteLine("Cual es el maximo peso que levantaste a una repeticion?");
                            ejercicio[n].peso = pedirvalor();
                            ejercicio[n].difpcorporal = ejercicio[n].peso * 100 / ejercicio[n].pcorporal;
                            Console.WriteLine();
                        }
                        for (n = 0; n < seleccion; n++)
                        {
                            Console.WriteLine(ejercicio[n]);
                            Console.WriteLine("------------");

                        }
                        for (n = 0; n < seleccion; n++)
                        {
                            if (ejercicio[n].difpcorporal > pmayor)
                            {
                                pmayor = ejercicio[n].difpcorporal;
                                mejercicio = ejercicio[n].nombre;

                            }
                        }
                        Console.WriteLine();
                        Console.WriteLine("El ejercicio mejor logrado en relacion con tu peso corporal es {0} con una marca de {1}%", mejercicio, pmayor);
                        Console.WriteLine();



                        break;
                    default:
                        Console.WriteLine("Su seleccion es incorrecta");
                        Console.WriteLine();
                        break;


                }
            } while (seleccionp != 5);
        }

        public struct progresos
        {
            public string nombre;
            public string musculo;
            public double peso;
            public double pcorporal;
            public double difpcorporal;

            public override string ToString()
            {
                double difpcorporalRedondeado = Math.Round(difpcorporal, 2);
                StringBuilder cadena = new StringBuilder();
                cadena.AppendFormat("Ejercicio: {0}\nMusculo: {1}\nPeso: {2}\nRelacion con tu peso: {3}%",
                    nombre, musculo, peso, difpcorporalRedondeado);
                return cadena.ToString();
            }
        }
        public static int pedirseleccion()
        {
            int seleccion = 0;
            string dato = "";
            dato = Console.ReadLine();
            seleccion = Convert.ToInt32(dato);
            return seleccion;
        }
        public static double pedirvalor()
        {
            double valor = 0;
            string dato = "";
            dato = Console.ReadLine();
            valor = Convert.ToDouble(dato);
            return valor;
        }
        public static double conversion(double x, double valor)
        {
            double resultado = 0;
            resultado = valor / x;
            return resultado;

        }
    }
}
