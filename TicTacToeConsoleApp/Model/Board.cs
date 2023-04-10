using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToeConsoleApp.Model
{
    public class Board
    {
        public static readonly int Dimension = 3;

        private readonly char[,] _boardData = new char[Dimension, Dimension];

        public Board()
        {
            ClearBoardData();
        }

        private void ClearBoardData()
        {
            for (int i = 0; i < Dimension; i++)
            {
                for (int j = 0; j < Dimension; j++)
                {
                    _boardData[i, j] = '-';
                }
            }
        }

        public void UpdateBoardData(int row, int column, char symbol)
        {
            _boardData[row, column] = symbol;
        }

        public char GetBoardData(int row, int column)
        {
            return _boardData[row, column];
        }


    }
}
