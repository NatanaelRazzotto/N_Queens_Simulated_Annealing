using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace N_Queens_AI.Helpers.Model
{
    public class Solver_SimulatedAnnealing
    {
        SA_Queens queens;
        public void startSolver(ParametersOfSolver parameter)
        {
            queens = new SA_Queens(parameter.numberQueens);
            parameter.generateNewSolution = queens.generateRandomState(parameter.numberQueens);
            parameter.generateNeighbor = queens.constructNeighbor();
            //options.acceptNeighbor = Queens.AcceptNeighbor;
            solver_SA(parameter);
        }

        public void solver_SA(ParametersOfSolver parameter)
        {
            SimulatedAnnealing simulated_Annealing = new SimulatedAnnealing(parameter);
            bool done = false;
            while (!done){
                done = simulated_Annealing.simulationStep();

            }



            //  int randomizeState = solverUtil.generateRandomState(numberQueens);
            // int costAtack = solverUtil.checkCountAtack(randomizeState);

            //for (int x = 0; x < maxNumberIterations && costAtack > 0; x++)
            //{

            //}

            //return randomizeState;
        }
    }
}
