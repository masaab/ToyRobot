using System;
using Xunit;

namespace ToyRobot.Tests
{
    public class TestToyRobot
    {
        [Theory]
        [InlineData("Output: 4,4,EAST")]
        public void TestDirection(string expectedString)
        {
            Program p = new Program("PLACE",1,2,Directions.east);

            p.MoveToy("MOVE");
            p.MoveToy("MOVE");
            p.MoveToy("LEFT");
            p.MoveToy("MOVE");
            p.MoveToy("MOVE");
            p.MoveToy("MOVE");
            p.MoveToy("RIGHT");
            p.MoveToy("MOVE");

            string output = p.GetOutput();

            Assert.Equal(expectedString, output);
        }
    }
}
