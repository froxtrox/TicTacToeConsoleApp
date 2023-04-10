using System;
namespace TicTacToeConsoleApp.Model

{
    public struct Move
    {

        public int Row { get; set; }
        public int Column { get; set; }

        //initialize a position with 0-based row and collumn.
        public Move(int row, int collumn)
        {
            Row = row;
            Column = collumn;
            Validate();
        }

        private void Validate()
        {
            if (Row < 0 || Row >= Board.Dimension)
            {
                throw new ArgumentOutOfRangeException(nameof(Row), $"Row should be within 0 and {Board.Dimension - 1}.");
            }

            if (Column < 0 || Column >= Board.Dimension)
            {
                throw new ArgumentOutOfRangeException(nameof(Column), $"Column should be within 0 and {Board.Dimension - 1}.");
            }
        }
    }
}
 