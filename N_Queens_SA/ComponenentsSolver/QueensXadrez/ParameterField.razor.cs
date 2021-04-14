using Microsoft.AspNetCore.Components;
using N_Queens_AI.Helpers.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace N_Queens_SA.ComponenentsSolver.QueensXadrez
{
    public partial class ParameterField
    {
        [Parameter]
        public EventCallback<ParametersOfSolver> StartUpdate { get; set; }
        [Parameter]
        public EventCallback<ParametersOfSolver> StarSolver { get; set; }
        [Parameter]
        public int numberQueens { get; set; }
        [Parameter]
        public double coolingFactor { get; set; }
        [Parameter]
        public double stabilizingFactor { get; set; }
        [Parameter]
        public double freezingTemperature { get; set; }
        [Parameter]
        public double initialTemperature { get; set; }
        [Parameter]
        public double initialstabilizer { get; set; }
        protected ParametersOfSolver parameters;
        void numberQueensDefined(int value)
        {
            numberQueens = value;
        }
        void initialTemperatureChanged(double value)
        {
            initialTemperature = value;
        }
        protected async Task definedStateSolver() {
            parameters = new ParametersOfSolver(numberQueens, initialTemperature, initialstabilizer, 
                                                coolingFactor,stabilizingFactor, freezingTemperature);
            await StartUpdate.InvokeAsync(parameters);


        }
        protected async Task DefinedStartSolver() {
            parameters = new ParametersOfSolver(numberQueens, initialTemperature, initialstabilizer,
                                                coolingFactor, stabilizingFactor, freezingTemperature);
            await StarSolver.InvokeAsync(parameters);
        }

    }
}
