using N_Queens_AI.Helpers.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace N_Queens_AI.Helpers.Controller
{
    public class Controller
    {
        public Solver_SimulatedAnnealing solver_SA;
        public Controller() {
            solver_SA = new Solver_SimulatedAnnealing();            
        }

        public Position[] startSolverRandom(ParametersOfSolver parameter) {
            Console.WriteLine("teste startSolverRandom :" + parameter);
            SA_Queens queens_SA = solver_SA.startSolver(parameter);
            return queens_SA.matrixPositionsQueens;
        }
        public async Task solver(ParametersOfSolver parameter) {
           solver_SA.solver_SA(parameter);
        }
        public Position[] getAtualizacao() {
            return solver_SA.getMatrix();
        }
    }
}
