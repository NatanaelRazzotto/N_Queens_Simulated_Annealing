using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace N_Queens_AI.Helpers.Model
{
    public class ParametersOfSolver : ParametersQueens
    {
        public double initialTemperature { get; set; } = 0.0;
        public double initialstabilizer { get; set; } = 0.0;


        public ParametersOfSolver (int numberQueens, double initialTemperature, double initialstabilizer, double coolingFactor,
                                    double stabilizingFactor, double freezingTemperature)
         {
            this.numberQueens = numberQueens; 
            this.initialTemperature = initialTemperature;
            this.initialstabilizer = initialstabilizer;
            this.coolingFactor = coolingFactor;
            this.stabilizingFactor = stabilizingFactor;
            this.freezingTemperature = freezingTemperature;



        }
            






    }
}
