using MattEland.Shared.Numerics;
using NUnit.Framework;
using Shouldly;

namespace MattEland.Shared.Tests
{
    public class NumberTests
    {
        [Theory]
        [TestCase(7, 7)]
        [TestCase(4.2, 4)]
        [TestCase(3.1459, 3)]
        [TestCase(0, 0)]
        [TestCase(-1.5, -1)]
        [TestCase(9.999999999, 9)]
        public void DecimalFloorShouldProduceACorrectInteger(decimal value, int expected)
        {
            // Act
            int actual = value.ToInt();

            // Assert
            actual.ShouldBe(expected);
        }
    }
}