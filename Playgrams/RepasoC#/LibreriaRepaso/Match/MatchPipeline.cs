using LibreriaRepaso.Match.Validaciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaRepaso.Match
{
    internal class MatchPipeline
    {
        public void Main()
        {
            var validaciones = new List<IValidacion>
            {
                new AutoValidacion(),
                new EdadValidacion(),
                new ColorOjosValidacion(),
                new ProporcionValidacion(),
            };

            var matchInfo = new MatchInfo 
            {
                TieneAuto = false,
                Edad = 25,
                Altura = 180,
                Peso = 80,
                ColorOjos = "verde",
            };

            Console.WriteLine(CumpleCondiciones(matchInfo, validaciones));
        }

        public bool CumpleCondiciones(MatchInfo matchInfo, List<IValidacion> validaciones)
        {
            foreach (var validacion in validaciones)
            {
                if (validacion.CumpleCondicion(matchInfo))
                    return true;
            }

            return false;
        }

    }
}