using Microsoft.AspNetCore.Components;
using N_Queens_AI.Helpers.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace N_Queens_SA.ComponenentsSolver.Tabuleiro
{
    public partial class TabuleiroXadrez
    {
        [Parameter]
        public Position[] queens { get; set; }
        public int numberOfQueens => queens.Length;
    }
}
