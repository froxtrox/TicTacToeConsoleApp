using System;
using System.Collections.Generic;
using System.Text;
using TicTacToeConsoleApp.Model;

namespace TicTacToeConsoleApp
{
    //Handle console input and data validation using board 
    public class ConsoleGamePlayer
    {
        private Game _game = new Game();
        public void Initialise()
        {
            var isPlaying = true;

            while (isPlaying)
            {
                Console.Clear();
                RenderBoard();
                var currentPlayer = _game.isFirstPlayerTurnToPlay ? "first player" : "second player";
                int row, col;
                try
                {
                    Console.WriteLine($"{currentPlayer} Please enter row number");
                    int.TryParse(Console.ReadLine().Trim(), out row);
                    Console.WriteLine($"{currentPlayer} Please enter column number");
                    int.TryParse(Console.ReadLine().Trim(), out col);
                    _game.Move(new Move(row - 1, col - 1));
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine($"{ex.Message}, Press enter to continue.");
                    Console.ReadKey();
                    continue;
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine($"{ex.ParamName} Press enter to continue.");
                    Console.ReadKey();
                    continue;
                }

                var result = _game.CheckResult();
                if (result != Result.InProgress)
                {
                    Console.Clear();
                    RenderBoard();
                    Console.WriteLine(result == Result.Draw ?"Draw!": $"{currentPlayer} Wins");
                    Console.WriteLine("Want to play another game? Enter \"Yes\" to start.");
                    if (Console.ReadLine().Trim().ToLower() != "yes")
                    {
                        isPlaying = false;
                    }
                    else
                    {
                        _game = new Game();
                    }
                }
            }
        }

        private void RenderBoard()
        {
            foreach (var item in _game.GetBoardDataStringsByRow())
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("================================");
        }
    }
}
