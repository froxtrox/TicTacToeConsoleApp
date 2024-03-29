﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TicTacToeConsoleApp.Model
{
    public class Game
    {

        private readonly List<Move> _moves = new List<Move>();
        public Board Board { get; set; } = new Board();

        int NumberMovesPlayed => _moves.Count();
        int Dimension => Board.Dimension;

        public bool isFirstPlayerTurnToPlay => NumberMovesPlayed % 2 == 0 ? true : false;


        public void Move(Move move)
        {
            if (Board.GetBoardData(move.Row, move.Column) != '-')
                throw new InvalidOperationException("This position has already been placed.");
            //Update board state
            _moves.Add(move);
            Board.UpdateBoardData(move.Row, move.Column, isFirstPlayerTurnToPlay ? 'O' : 'X');
        }
        public List<string> GetRows()
        {
            var rows = new List<string>();

            for (int i = 0; i < Dimension; i++)
            {
                var row = new StringBuilder();

                for (int j = 0; j < Dimension; j++)
                {
                    row.Append(Board.GetBoardData(i, j));
                }

                rows.Add(row.ToString());
            }

            return rows;
        }

        public Result CheckResult()
        {
            //rows, cols and diagonal counter, 
            var rowsCounter = new int[Dimension];
            var colsCounter = new int[Dimension];
            //diagonal and reverseDiagonal
            var diagonalCounter = new int[2];

            //Iterate through the entire board and update the counters, it will either add 1 if the move is played by the first player
            // or -1 if played by the second player, Any members in each counter array that reaches 3 will therefore result in 3 moves connection and wins.
            for (int i = 0; i < Dimension; i++)
            {
                for (int j = 0; j < Dimension; j++)
                {
                    var value = Board.GetBoardData(i,j);

                    if (value == '-') { continue; }

                    var addedValue = Board.GetBoardData(i, j) == 'X' ? 1 : -1;

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
                    sb.Append(Board.GetBoardData(i, j));
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
