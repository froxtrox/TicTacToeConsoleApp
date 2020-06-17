using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TicTacToeConsoleApp.Model
{
    public class Game
    {

        List<Move> Moves = new List<Move>();
        public Board Board { get; set; } = new Board();

        int NumberMovesPlayed => Moves.Count();
        int Dimension => Board.Dimension;

        public bool isFirstPlayerTurnToPlay => NumberMovesPlayed % 2 == 0 ? true : false;


        public void Move(Move move)
        {
            if (Board.BoardData[move.Row, move.Column] != '-')
                throw new InvalidOperationException("This position has already been placed.");
            //Update board state
            Moves.Add(move);
            Board.BoardData[move.Row, move.Column] = isFirstPlayerTurnToPlay ? 'O' : 'X';
        }

        public Result CheckResult()
        {
            //rows, cols and diagonal counter, 
            var rowsCounter = new int[Dimension];
            var colsCounter = new int[Dimension];
            //diagonal and reverseDiagonal
            var diagonalCounter = new int[2];

            for (int i = 0; i < Dimension; i++)
            {
                for (int j = 0; j < Dimension; j++)
                {
                    var value = Board.BoardData[i, j];

                    if (value == '-') { continue; }

                    var addedValue = Board.BoardData[i, j] == 'X' ? 1 : -1;

                    rowsCounter[i] += addedValue;
                    colsCounter[j] += addedValue;

                    if (i == j)
                    {
                        diagonalCounter[0] += addedValue;
                    }
                    if (j == colsCounter.Length - i - 1)
                    {
                        diagonalCounter[1] += addedValue;
                    }
                }
            }

            var anyRowWin = rowsCounter.Any(row => Math.Abs(row) == Dimension);
            var anyColsWin = colsCounter.Any(col => Math.Abs(col) == Dimension);
            var anyDiagonalWin = diagonalCounter.Any(diag => Math.Abs(diag) == Dimension);
            var isWon = anyRowWin || anyColsWin || anyDiagonalWin;

            if (isWon)
                return Result.Win;

            else if (NumberMovesPlayed == Board.Dimension * Dimension)
                return Result.Draw;

            else return Result.InProgress;

        }

        public List<string> GetBoardDataStringsByRow()
        {

            var dataCollection = new List<string>();
            for (int i = 0; i < Board.Dimension; i++)
            {
                var sb = new StringBuilder();
                for (int j = 0; j < Board.Dimension; j++)
                {
                    sb.Append(Board.BoardData[i, j]);
                }
                dataCollection.Add(sb.ToString());
            }

            return dataCollection;
        }
    }

    public enum Result
    {
        Win, Draw, InProgress
    }

}
