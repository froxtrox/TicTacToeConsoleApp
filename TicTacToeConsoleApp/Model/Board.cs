using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToeConsoleApp.Model
{
    public class Board
    {
        public char[,] BoardData { get; internal set; } = new char[,] { { '-', '-', '-' }, { '-', '-', '-' }, { '-', '-', '-' } };

        public static readonly int Dimension = 3;

    }
}
