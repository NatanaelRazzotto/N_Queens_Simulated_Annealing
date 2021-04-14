using N_Queens_AI.Helpers.Model.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace N_Queens_AI.Helpers.Model
{
    public class SimulatedAnnealing
    {
        public ParametersOfSA parameterSA;
        SA_Queens QueensUtil;
        public double getEnergySystem() {
            return parameterSA.currentSystemEnergy;
        }
        public double getTemperatureSystem()
        {
            return parameterSA.currentSystemTemperature;
        }
        public SimulatedAnnealing(ParametersOfSolver  parameter, SA_Queens queensUtil) {
            this.QueensUtil = queensUtil;
            parameterSA = new ParametersOfSA();
            parameterSA.numberQueens = parameter.numberQueens;
            parameterSA.coolingFactor = parameter.coolingFactor;
            parameterSA.stabilizingFactor = parameter.stabilizingFactor;
            parameterSA.freezingTemperature = parameter.freezingTemperature;
            parameterSA.generateNewSolution = parameter.generateNewSolution;
            parameterSA.generateNeighbor = parameter.generateNeighbor;
            parameterSA.acceptNeighbor = parameter.acceptNeighbor;
            parameterSA.currentSystemEnergy = QueensUtil.generateRandomState(parameterSA.numberQueens);
            parameterSA.currentSystemTemperature = parameter.initialTemperature;
            parameterSA.currentStabilizer = parameter.initialstabilizer;

        }
        public bool simulationStep() {
            if (parameterSA.currentSystemTemperature > parameterSA.freezingTemperature)
            {
                for (int i = 0; i < parameterSA.currentStabilizer; i++)
                {
                    Console.WriteLine("-------------Tentativa SA---------------");
                    double newEnergy = QueensUtil.constructNeighbor();
                    double energyDelta = newEnergy - parameterSA.currentSystemEnergy;
                    if (probability(parameterSA.currentSystemEnergy, energyDelta))
                    {
                        QueensUtil.registerNeighborAsCurrent();
                        parameterSA.currentSystemEnergy = newEnergy;

                    }
                }
                parameterSA.currentSystemTemperature = parameterSA.currentSystemTemperature - parameterSA.coolingFactor;
                parameterSA.currentStabilizer = parameterSA.currentStabilizer * parameterSA.stabilizingFactor;
                Console.WriteLine("---------**---- currentStabilizer ---**------------");
                return false;
            }
            parameterSA.currentSystemTemperature = parameterSA.freezingTemperature;
            return true;
        }
        public bool probability(double temperature, double delta)
        {
            Random random = new Random();
            if (delta < 0)
            {
                return true;
            }

            double calculo = Math.Exp(-delta / temperature);
            double randomico = random.NextDouble();
            if (randomico < calculo)
            {
                return true;
            }
            return false;
        }

    }
}
