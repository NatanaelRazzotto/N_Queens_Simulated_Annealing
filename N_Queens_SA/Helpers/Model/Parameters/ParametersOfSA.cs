using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace N_Queens_AI.Helpers.Model.Parameters
{
    public class ParametersOfSA : ParametersQueens
    {
        public double currentSystemEnergy { get; set; } = 0.0;
        public double currentSystemTemperature { get; set; } = 0.0;
        public double currentStabilizer { get; set; } = 0.0;
    }
}
