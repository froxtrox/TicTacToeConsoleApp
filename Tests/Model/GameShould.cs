using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using TicTacToeConsoleApp.Model;

namespace Tests
{
    public class GameShould
    {

        char[,] BlankBoardData;
        Game game;
        [SetUp]
        public void Setup()
        {
            BlankBoardData = new char[,] { { '-', '-', '-' }, { '-', '-', '-' }, { '-', '-', '-' } };
            game = new Game();
        }

        [Test]
        public void ReturnCorrectInitGameBoardData()
        {
            var expectedBoard = BlankBoardData;

            Assert.That(expectedBoard, Is.EquivalentTo(game.Board.BoardData));
        }

        [Test]
        public void NotAllowSamePositionMove()
        {
            var move1 = new Move(1, 2);
            var move2 = new Move(1, 2);

            game.Move(move1);
            var ex = Assert.Throws<InvalidOperationException>(delegate { game.Move(move2); });
            
            Assert.That(ex.Message, Is.EqualTo("This position has already been placed."));
        }

        [Test]
        public void UpdateCorrectBoardStates()
        {
            var move = new Move(1, 2);
            var expectedBoard = new char[,] { { '-', 'X', '-' }, { '-', '-', '-' }, { '-', '-', '-' } };

            game.Move(move);

            Assert.That(expectedBoard, Is.EquivalentTo(game.Board.BoardData));
        }


        [Test]
        public void ReturnCorrectisFirstPlayerTurnToPlay()
        {

            Assert.That(true, Is.EqualTo(game.isFirstPlayerTurnToPlay));
        }

        [Test]
        public void ReturnCorrectisSecondPlayerTurnToPlay()
        {
            var move = new Move(1, 2);
            
            game.Move(move);
            
            Assert.That(false, Is.EqualTo(game.isFirstPlayerTurnToPlay));
        }

        [Category("GameResult")]
        [Test]
        public void ReturnCorrectWinStateGameInProgress()
        {
            var moves = new Move[] { new Move(2, 0), new Move(1, 2), new Move(1, 1) };
            
            foreach (var move in moves)
            {
                game.Move(move);
            }

            Assert.That(Result.InProgress, Is.EqualTo(game.CheckResult()));
        }

        [Category("GameResult")]
        [Test]
        public void ReturnCorrecDrawState()
        {
            var moves = new Move[] { new Move(2, 0), new Move(1, 2), new Move(1, 1), new Move(0,2),new Move(2,2), new Move(2,1), new Move(0,1), new Move(0,0), new Move(1,0) };
            
            foreach (var move in moves)
            {
                game.Move(move);
            }

            Assert.That(Result.Draw, Is.EqualTo(game.CheckResult()));
        }

        [Category("GameResult")]
        [Test, TestCaseSource("GetWinMovesets")]
        public void ReturnCorrectWinState(List<Move> moves)
        {
            foreach (var move in moves)
            {
                game.Move(move);
            }

            Assert.That(Result.Win, Is.EqualTo(game.CheckResult()));
        }
 
        private static IEnumerable<List<Move>> GetWinMovesets()
        {
            var users = new List<Move>();
            var vertical = new Move[] { new Move(0, 0), new Move(0, 2), new Move(1, 0), new Move(1, 2), new Move(2, 0) }.ToList();
            var horizontal = new Move[] { new Move(2, 2), new Move(1, 2), new Move(1, 1), new Move(0, 1), new Move(0, 0) }.ToList();
            var reverseDiagonal = new Move[] { new Move(2, 0), new Move(1, 2), new Move(1, 1), new Move(0, 1), new Move(0, 2) }.ToList();
            var diagonal = new Move[] { new Move(2, 0), new Move(0, 0), new Move(1, 2), new Move(1, 1), new Move(0, 2), new Move(2, 2) }.ToList();

            return new[] { vertical,horizontal,reverseDiagonal, diagonal };
        }

        [Test]
        public void returnCorrectBoardDataStringsByRow() {

            var move = new Move(1, 2);
            var expectedResult = new List<string> { "---", "--X", "---" };

            game.Move(move);

            Assert.That(expectedResult, Is.EquivalentTo(game.GetBoardDataStringsByRow()));

        }

    }
}