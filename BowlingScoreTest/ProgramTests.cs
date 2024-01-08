using BowlingScore;
using System.Reflection;

namespace BowlingScoreTest
{

    public class ProgramTests
    {
        [Test]
        public void ParseFrameScores_ValidInput_ReturnsIntArray()
        {
            // Arrange
            string input = "5 3";

            var programType = typeof(Program);
            var parseFrameScoresMethod = programType.GetMethod("ParseFrameScores", BindingFlags.NonPublic | BindingFlags.Static);

            // Act
            var result = parseFrameScoresMethod.Invoke(null, new object[] { input });


            // Assert
            Assert.That(result, Is.Not.Null);
            int[] resultArray = (int[])result;
            Assert.That(resultArray?.Length, Is.EqualTo(2));
            Assert.That(resultArray[0], Is.EqualTo(5));
            Assert.That(resultArray[1], Is.EqualTo(3));
        }

        [Test]
        public void ParseFrameScores_InvalidInput_ReturnsNull()
        {
            // Arrange
            string input = "invalid input";

            // Act
            var programType = typeof(Program);
            var parseFrameScoresMethod = programType.GetMethod("ParseFrameScores", BindingFlags.NonPublic | BindingFlags.Static);
            var result = parseFrameScoresMethod.Invoke(null, new object[] { input });

            // Assert
            Assert.Null(result);
        }

        [Test]
        public void ParseFrameScores_IncompleteInput_ReturnsNull()
        {
            // Arrange
            string input = "5";

            // Act
            var programType = typeof(Program);
            var parseFrameScoresMethod = programType.GetMethod("ParseFrameScores", BindingFlags.NonPublic | BindingFlags.Static);
            var result = parseFrameScoresMethod.Invoke(null, new object[] { input });

            // Assert
            Assert.Null(result);
        }
    }
}
