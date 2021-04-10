using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace N_Queens_AI.Helpers.Model
{
    public class ParametersQueens
    {
        public int numberQueens { get; set; } = 0;
        public double coolingFactor { get; set; } = 0.0;//
        public double stabilizingFactor { get; set; } = 0.0;//
        public double freezingTemperature { get; set; } = 0.0;//
        public int generateNewSolution { get; set; } = 0;//
        public int generateNeighbor { get; set; } = 0;//
        public int acceptNeighbor { get; set; } = 0;//
    }
}
