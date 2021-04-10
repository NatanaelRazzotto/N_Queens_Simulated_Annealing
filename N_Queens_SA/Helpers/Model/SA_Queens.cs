using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace N_Queens_AI.Helpers.Model
{
    public class SA_Queens
    {
        Position[] matrixPositionsQueens;
        Position[] newMatrixPositionsQueens;
        int numberQueens = 0;
        public SA_Queens(int numberQueens)
        {
            this.numberQueens =  numberQueens;
        }
        public int generateRandomState(int numberQueens)
        {
            //TODO: criar possivel metodo para essa linha
            matrixPositionsQueens = new Position[numberQueens];
            return randomizeState();

        }
        //public int[] randomizeState(int[] matrixState) {//int[] matrixState
        //    Random random = new Random();
        //    for (int i = 0; i < matrixState.Length; i++)
        //    {
        //        matrixState[i] = (int)(random.Next() * matrixState.Length);
        //    }
        //    return matrixState;
        //},
        public int randomizeState()
        {
            Random random = new Random();
            for (int iteratorQueen = 0; iteratorQueen < numberQueens; iteratorQueen++)
            {
                bool continuaIteracao = true;
                while (continuaIteracao)
                {
                    matrixPositionsQueens[iteratorQueen].coordY = randomico(random);
                    matrixPositionsQueens[iteratorQueen].coordX = randomico(random);
                    if (!checkRepetition(matrixPositionsQueens))continuaIteracao = false;
                }
            }
            return checkCountAtack(matrixPositionsQueens);
        }

        private bool checkRepetition(Position[] matrixPositionsQueens)
        {

            for (var QueenI = 0; QueenI < matrixPositionsQueens.Length -1; QueenI++)
            {
                for (int QueenY = QueenI +1; QueenY < matrixPositionsQueens.Length; QueenY++)
                {
                    if (matrixPositionsQueens[QueenI].coordX == matrixPositionsQueens[QueenY].coordX &&
                        matrixPositionsQueens[QueenI].coordY == matrixPositionsQueens[QueenY].coordY)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public int randomico(Random random)
        {
            return random.Next(0, 8);//NextDouble
        }
        public int checkCountAtack(Position[] matrixState) {
            int attacks = 0;
            for (int Queen = 0; Queen < matrixState.Length - 1; Queen++)
            {
                for (int  QueenAttaking= Queen + 1 ; QueenAttaking < matrixState.Length; QueenAttaking++)
                {
                    if (matrixState[Queen].coordX == matrixState[QueenAttaking].coordX)
                    {
                        attacks++;
                    }
                    else if (matrixState[Queen].coordY == matrixState[QueenAttaking].coordY)
                    {
                        attacks++;
                    }
                    else if (matrixState[Queen].coordY + matrixState[Queen].coordX ==
                            matrixState[Queen].coordY + matrixState[Queen].coordX)
                    {
                        attacks++;
                    }
                    else if (matrixState[Queen].coordY - matrixState[Queen].coordX ==
                            matrixState[Queen].coordY - matrixState[Queen].coordX)
                    {
                        attacks++;
                    }
                }
            }
            return attacks;
        }
        public int constructNeighbor() {
            Random random = new Random();
            newMatrixPositionsQueens = matrixPositionsQueens;
            int changingQueen = (random.Next()*numberQueens);
            bool repetitions = true;
            while (repetitions)
            {
                int coordX = newMatrixPositionsQueens[changingQueen].coordX;
                int coordY = newMatrixPositionsQueens[changingQueen].coordX;
                int valueRandomico = Convert.ToInt32(random.NextDouble() * 3);//((random.NextDouble() * 3) -1)

                newMatrixPositionsQueens[changingQueen].coordX = ((newMatrixPositionsQueens[changingQueen].coordX + (valueRandomico - 1) % 8) );
            }

            return checkCountAtack(matrixPositionsQueens);

        }
        public void registerNeighborAsCurrent() {
            for (int iteratorQueen = 0; iteratorQueen < numberQueens; iteratorQueen++)
            {
                matrixPositionsQueens[iteratorQueen].coordX = newMatrixPositionsQueens[iteratorQueen].coordX;
                matrixPositionsQueens[iteratorQueen].coordY = newMatrixPositionsQueens[iteratorQueen].coordY;
            }
        }


    }
}
