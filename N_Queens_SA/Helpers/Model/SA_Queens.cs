using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace N_Queens_AI.Helpers.Model
{
    public class SA_Queens
    {
        public Position[] matrixPositionsQueens;
        public Position[] newMatrixPositionsQueens;
        public int numberQueens = 0;

        public SA_Queens(int numberQueens)
        {
            this.numberQueens =  numberQueens;
        }
        public int generateRandomState(int numberQueens)
        {
            matrixPositionsQueens = new Position[numberQueens];
            consoleMensagem("Gerando um Estado Aleatório", matrixPositionsQueens.Length.ToString());
            return randomizeState();

        }

        public int randomizeState()
        {
            Random random = new Random();
            consoleMensagem("Randomizando um Estado Aleatório", "Iniciando");
            for (int iteratorQueen = 0; iteratorQueen < matrixPositionsQueens.Length; iteratorQueen++)
            {
                bool continuaIteracao = true;
                Console.WriteLine(numberQueens);
                while (continuaIteracao)
                {
                    Position positionBoard = new Position();
                    positionBoard.coordY = randomico(random, numberQueens-1);
                    positionBoard.coordX = randomico(random, numberQueens-1);
                    matrixPositionsQueens[iteratorQueen] = positionBoard;
                    Console.WriteLine($"-- CorY : { matrixPositionsQueens[iteratorQueen].coordY } codrX: {matrixPositionsQueens[iteratorQueen].coordX}");
                    if (checkRepetition(matrixPositionsQueens))continuaIteracao = false;
                }
            }
            Console.WriteLine("*******************Queens Geradas**************************");
            ConsoleLogQueen(matrixPositionsQueens);
            return checkCountAtack(matrixPositionsQueens);
        }

        public bool checkRepetition(Position[] matrixPositionsQueens)
        {
            consoleMensagem("Check Repetitions", "Executando");

            for (int QueenI = 0; QueenI < matrixPositionsQueens.Length -1; QueenI++)
            {
                Console.WriteLine(matrixPositionsQueens.Length);
                for (int QueenY = QueenI +1; QueenY < matrixPositionsQueens.Length; QueenY++)
                {
                    if ((matrixPositionsQueens[QueenI] != null) && (matrixPositionsQueens[QueenY] != null))
                    {
                        if (matrixPositionsQueens[QueenI].coordX == matrixPositionsQueens[QueenY].coordX &&
                            matrixPositionsQueens[QueenI].coordY == matrixPositionsQueens[QueenY].coordY)
                        {
                            return false;
                        }
                    }
                }
            }
            Console.WriteLine("**********************************************");
            return true;
        }

        public int randomico(Random random, int Positions)
        {
            consoleMensagem("Escolhendo index para um Estado Aleatório", "Iniciando");
            int i = Convert.ToInt32(random.NextDouble() * Positions);
            consoleMensagem("index escolhido", $" i {i} ");

            return i;
        }
        public int checkCountAtack(Position[] matrixState) {
            Console.WriteLine("Inciando checagem de Possiveis Ataques");
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
                            matrixState[QueenAttaking].coordY + matrixState[QueenAttaking].coordX)
                    {
                        attacks++;
                    }
                    else if (matrixState[Queen].coordY - matrixState[Queen].coordX ==
                            matrixState[QueenAttaking].coordY - matrixState[QueenAttaking].coordX)
                    {
                        attacks++;
                    }
                }
            }
            consoleMensagem("Contagem de ataques", $"Total {attacks}");
            return attacks;
        }
        public int constructNeighbor() {
            consoleMensagem("Construct um Estado Visinho", "Iniciando");
            Random random = new Random();
            newMatrixPositionsQueens = matrixPositionsQueens;
            int changingQueen = randomico(random, matrixPositionsQueens.Length - 1);
            bool repetitions = true;
            while (repetitions)
            {
                int coordX = newMatrixPositionsQueens[changingQueen].coordX;
                int coordY = newMatrixPositionsQueens[changingQueen].coordX;
                newMatrixPositionsQueens[changingQueen].coordX = calculodePosiçãoAleatoria(random, changingQueen);
                newMatrixPositionsQueens[changingQueen].coordY = calculodePosiçãoAleatoria(random, changingQueen);
                if (checkRepetition(matrixPositionsQueens)) repetitions = false;
                else {
                    newMatrixPositionsQueens[changingQueen].coordX = coordX;
                    newMatrixPositionsQueens[changingQueen].coordY = coordY;
                }
            }
            Console.WriteLine("**********************************************");
            return checkCountAtack(newMatrixPositionsQueens);

        }
        public int calculodePosiçãoAleatoria(Random random, int changingQueen)
        {
            Console.WriteLine("CalcularProximaPosição-----");
            int QueenLenght = newMatrixPositionsQueens.Length - 1;
            int posicaoRandomica = (randomico(random, 3) - 1);
            int defCalPosition = ((newMatrixPositionsQueens[changingQueen].coordX + posicaoRandomica) % QueenLenght);
            int defbCalPosition = ((defCalPosition + QueenLenght) % QueenLenght);
            Console.WriteLine($"-----CalcularProximaPosição result: {defbCalPosition}" );
            return defbCalPosition;
        }
        public bool registerNeighborAsCurrent() {
            for (int iteratorQueen = 0; iteratorQueen < numberQueens; iteratorQueen++)
            {
                matrixPositionsQueens[iteratorQueen].coordX = newMatrixPositionsQueens[iteratorQueen].coordX;
                matrixPositionsQueens[iteratorQueen].coordY = newMatrixPositionsQueens[iteratorQueen].coordY;
            }           
            ConsoleLogQueen(matrixPositionsQueens);
            return true;
        }
        public void ConsoleLogQueen(Position[] matriz) {
            consoleMensagem("Estado", "Gerado");
            for (int iteratorQueen = 0; iteratorQueen < matriz.Length; iteratorQueen++)
            {
                Console.WriteLine("----- " + iteratorQueen + " ----- " + matriz[iteratorQueen].coordY + " , " + matriz[iteratorQueen].coordX);
            }

            Console.WriteLine("**********************************************");
        }
        public void consoleMensagem(string nomeMetodo, string mensagem)
        {
            Console.WriteLine($"************** {nomeMetodo} *****************");
            Console.WriteLine($"                {mensagem}                 --");


        }


    }
}
