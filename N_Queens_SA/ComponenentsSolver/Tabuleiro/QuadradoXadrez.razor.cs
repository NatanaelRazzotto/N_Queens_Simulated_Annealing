using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace N_Queens_SA.ComponenentsSolver.Tabuleiro
{
    public partial class QuadradoXadrez
    {
        [Parameter]
        public int row { get; set; }
        [Parameter]
        public int column { get; set; }
        [Parameter]
        public bool HasQueen { get; set; }
        [Parameter]
        public bool IsInvalid { get; set; }
        private string FillColour => (row + column) % 2 == 0 ? "#cccccc" : "white";

    }
}
