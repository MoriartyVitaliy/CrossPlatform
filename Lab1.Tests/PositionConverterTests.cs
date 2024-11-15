using Lab1.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Tests
{
    public class PositionConverterTests
    {
        private readonly IPositionConverter _converter;

        public PositionConverterTests()
        {
            _converter = new PositionConverter();
        }

        [Fact]
        public void Convert_ValidCoordinates_ReturnsCorrectTuple()
        {
            var result = _converter.Convert("a1");
            Assert.Equal((1, 1), result);

            result = _converter.Convert("h8");
            Assert.Equal((8, 8), result);
        }
    }
}
