using Microsoft.AspNetCore.Components;
using N_Queens_AI.Helpers.Controller;
using N_Queens_AI.Helpers.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace N_Queens_SA.ComponenentsSolver.QueensXadrez
{
    public partial class QueensTabuleiro
    {
        [Parameter]
        public ParametersOfSolver parameterSolver { get; set; }

        public Position[] queens { get; set; }
        public int numberOfQueens => queens.Length;

        public Controller controller { get; set; }

        public int numberQueens { get; set; }
        public double coolingFactor { get; set; }
        public double stabilizingFactor { get; set; }
        public double freezingTemperature { get; set; }
        public double initialTemperature { get; set; }
        public double initialstabilizer { get; set; }


        protected async override Task OnInitializedAsync()
        {
            controller = new Controller();
            queens = controller.startSolverRandom(parameterSolver);
            base.OnInitializedAsync();

        }
        public void newDefinedParameter(ParametersOfSolver parameters)
        {
            parameterSolver = parameters;
            queens = controller.startSolverRandom(parameters);
            Console.WriteLine(queens.Length + "*******************");
            base.OnInitializedAsync();
        }
        public async void StartSolverGame(ParametersOfSolver parameters)
        {
            Console.WriteLine(queens.Length + "startSolver");
            parameterSolver = parameters;
            await controller.solver(parameterSolver);
            await obterQueens();
        }
        public async Task obterQueens() {
            bool resultado = true;
            while (resultado)
            {
                await Task.Delay(5000);
                queens = controller.getAtualizacao();
            }
        
        }
    }
}
