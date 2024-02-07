using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace RepasoC_
{
    internal class Condicionales
    {
        public void Main()
        {
            int edad;

            edad = 21;
            EsMayor(edad);
            edad = 13;
            EsMayor(edad);
            edad = -3;
            EsMayor(edad);

            var match = CumpleCondiciones(21, 70, 180, "marrones", true);
        }

        private void EsMayor(int edad)
        {
            if (edad >= 18)
            {
                Console.WriteLine("Es mayor");
            }
            else if (edad >= 0)
            {
                Console.WriteLine("Es menor");
            }
            else Console.WriteLine("La edad no puede ser negativa");
        }
        private bool CumpleCondiciones(int edad, double peso,double altura, string colorDeOjos, bool tieneAuto)
        {

            /*Si tiene 25 o mas tiene que tener auto
             *En caso de que no lo tenga tiene que medir mas de 1.8 y de ojos celestes
             *La proporcion altura y peso tiene que ser mayor a 2 y menor a 3
             */
            var proporcionCorporal = altura / peso;

            var requisitosObligatorios = new List<bool>
            {
                proporcionCorporal > 2, proporcionCorporal < 3
            };
            var requisitosOpcionales = new List<bool>
            {
                tieneAuto, edad < 25, colorDeOjos == "celeste"
            };
            var cantidadRequisitosOpcionales = 1;

            if (!requisitosObligatorios.Any(x => false) && requisitosOpcionales.Count(x => true) >= cantidadRequisitosOpcionales) 
            {
                return true;
            }

            return false;
        }
    }
}
