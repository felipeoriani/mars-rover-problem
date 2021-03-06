using Xunit;

namespace Mars.Tests
{
    public class RoverTests
    {
        [Theory]
        [InlineData('N', 'L', 'W')]
        [InlineData('N', 'R', 'E')]
        [InlineData('N', 'M', 'N')]
        [InlineData('S', 'L', 'E')]
        [InlineData('S', 'R', 'W')]
        [InlineData('S', 'M', 'S')]
        [InlineData('E', 'L', 'N')]
        [InlineData('E', 'R', 'S')]
        [InlineData('E', 'M', 'E')]
        [InlineData('W', 'L', 'S')]
        [InlineData('W', 'R', 'N')]
        [InlineData('W', 'M', 'W')]
        public void Rover_must_move_to_orientation(char orientation, char movement, char expected) 
        {
            var rover = new Rover("5 5", $"3 3 {orientation}");
            rover.Move(movement);

            Assert.Equal(expected, rover.Orientation);
        }

        [Theory]
        [InlineData("5 5", "1 2 N", "LMLMLMLMM", "1 3 N")]
        [InlineData("5 5", "3 3 E", "MMRMMRMRRM", "5 1 E")]
        [InlineData("5 5", "2 1 N", "MRMMRM", "4 1 S")]
        [InlineData("5 5", "4 4 N", "LLMMMMMLMMM", "5 0 E")]
        [InlineData("10 10", "1 1 N", "LRMMMMMRMMMMLMMRMMMMR", "9 8 S")]
        [InlineData("100 100", "85 45 N", "MMMMMMRMMMMMMMMMLMMMMMMMLMMMMMMMMMMMMMMMMMMMMMMMMRMMMMMMMLMMMMMMRLMLMLMLMLMMMLMMMMMMR", "61 59 W")]
        public void Rover_must_move(string size, string position, string movement, string expectedPositio)
        {
            var rover = new Rover(size, position);
            var result = rover.Move(movement);

            Assert.Equal(expectedPositio, result);
        }
    }
}
