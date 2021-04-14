using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace N_Queens_AI.Helpers.Model
{
    public class Solver_SimulatedAnnealing
    {
        public SA_Queens queens;
        public Position[] getMatrix() {
            return queens.matrixPositionsQueens;
        }
        public SA_Queens startSolver(ParametersOfSolver parameter)
        {
            Console.WriteLine("------Start Solver :" + parameter.numberQueens);
            queens = new SA_Queens(parameter.numberQueens);
            parameter.generateNewSolution = queens.generateRandomState(parameter.numberQueens);
            return queens;
        }

        public void solver_SA(ParametersOfSolver parameter)
        {
            Console.WriteLine("-------------solver_SA---------------");
            parameter.generateNeighbor = queens.constructNeighbor();
            parameter.acceptNeighbor = queens.registerNeighborAsCurrent();
            Console.WriteLine("-------------solver_passo Simulated_A---------------");
            SimulatedAnnealing simulated_Annealing = new SimulatedAnnealing(parameter, queens);
            Console.WriteLine($"Energia do Sistema: {simulated_Annealing.getEnergySystem()} ---------------");

            bool done = false;
            while (!done)
            {
                Console.WriteLine("-------------Realizando Tentativa---------------");
                done = simulated_Annealing.simulationStep();
                Console.WriteLine($"Energia do Sistema: {simulated_Annealing.getEnergySystem()} ---------------");
                Console.WriteLine($"Energia do Sistema: {simulated_Annealing.getTemperatureSystem()} ---------------");
                if (done)
                {
                    break;
                }
            }
            Console.WriteLine("-------------Concluido---------------");

        }

    }
}
