using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace N_Queens_AI.Helpers.Model
{
    public class Position
    {
        public int coordY { get; set; }
        public int coordX { get; set; }
        public bool conflito { get; set; } = false;

    }
}
