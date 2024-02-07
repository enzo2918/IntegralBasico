using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaRepaso.Match.Validaciones
{
    internal class AutoValidacion : IValidacion
    {
        public bool CumpleCondicion(MatchInfo matchInfo)
        {
            return matchInfo.TieneAuto;
        }
    }

    internal class EdadValidacion : IValidacion
    {
        public bool CumpleCondicion(MatchInfo matchInfo)
        {
            return matchInfo.Edad >= 25;
        }
    }

    internal class ColorOjosValidacion : IValidacion
    {
        public bool CumpleCondicion(MatchInfo matchInfo)
        {
            return matchInfo.ColorOjos.ToLower() == "celeste";
        }
    }

    internal class ProporcionValidacion : IValidacion
    {
        public bool CumpleCondicion(MatchInfo matchInfo)
        {
            var proporcion = matchInfo.Altura / matchInfo.Peso;
            return proporcion > 2 && proporcion < 3;
        }
    }
}
