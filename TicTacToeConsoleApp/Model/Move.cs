using System;
namespace TicTacToeConsoleApp.Model

{
    public class Move
    {

        internal int Row { get; set; }
        internal int Column { get; set; }

        //initialize a position with 0-based row and collumn.
        public Move(int row, int collumn)
        {
            Row = row;
            Column = collumn;
            Validate();
        }

        private void Validate()
        {
            if (Row >= Board.Dimension || Row < 0)
            {
                throw new ArgumentOutOfRangeException($"Row input is outside of the board. Only 1 to {Board.Dimension} are allowed!");
            }

            if (Column >= Board.Dimension || Column < 0)
            {
                throw new ArgumentOutOfRangeException($"Column input is outside of the board. Only 1 to {Board.Dimension} are allowed!");
            }
        }
    }
}
 