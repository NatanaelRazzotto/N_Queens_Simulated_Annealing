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


        public ParametersOfSolver (int numberQueens, float initialTemperature, float initialstabilizer, float coolingFactor,
                                    float stabilizingFactor, float freezingTemperature)
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
