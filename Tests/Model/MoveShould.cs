using System;
using System.Collections.Generic;
using NUnit.Framework;
using TicTacToeConsoleApp.Model;

namespace Tests.Model
{
    public class MoveShould
    {

        [Test]
        [TestCase(-5,1,Description = "Row outside boundary")]
        [TestCase(5, 1, Description = "Row outside boundary")]
        public void NotAllowPositionOutsideRowBoundary(int row, int column)
        {
            var ex = Assert.Throws<ArgumentOutOfRangeException>(delegate { new Move(row, column); });

            Assert.That(ex.ParamName, Is.EqualTo("Row input is outside of the board. Only 1 to 3 are allowed!"));
        }

        [Test]
        [TestCase(1, -5, Description = "Column outside boundary")]
        [TestCase(1, 5, Description = "Column outside boundary")]
        public void NotAllowPositionOutsideColumnBoundary(int row, int column)
        {
            var ex = Assert.Throws<ArgumentOutOfRangeException>(delegate { new Move(row, column); });

            Assert.That(ex.ParamName, Is.EqualTo("Column input is outside of the board. Only 1 to 3 are allowed!"));
        }
    }
}
