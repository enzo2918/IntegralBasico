﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaStock
{
    internal class ContratacionBase
    {
        public int IdBase { get; set; }
        public DateTime Fecha { get; set; }
        public AccionContratacionBase AccionDeContratacion { get; set; }
    }
}
