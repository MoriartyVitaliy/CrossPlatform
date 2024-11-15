using Lab1.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Tests
{
    public class KnightMoveCalculatorTests
    {
        private readonly IKnightMoveCalculator _calculator;

        public KnightMoveCalculatorTests()
        {
            _calculator = new KnightMoveCalculator();
        }

        [Fact]
        public void GetMinimumMoves_OneMove_ReturnsOne()
        {
            var start = (1, 1); // a1
            var end = (2, 3);   // b3
            var result = _calculator.GetMinimumMoves(start, end);
            Assert.Equal("1", result);
        }

        [Fact]
        public void GetMinimumMoves_TwoMoves_ReturnsTwo()
        {
            var start = (1, 1); // a1
            var end = (3, 4);   // d4
            var result = _calculator.GetMinimumMoves(start, end);
            Assert.Equal("NO", result);
        }

        [Fact]
        public void GetMinimumMoves_Unreachable_ReturnsNo()
        {
            var start = (1, 1); // a1
            var end = (8, 8);   // h8
            var result = _calculator.GetMinimumMoves(start, end);
            Assert.Equal("NO", result);
        }
    }
}
