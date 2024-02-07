using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaRepaso.Match
{
    internal interface IValidacion
    {
        bool CumpleCondicion(MatchInfo matchInfo);
    }
}
