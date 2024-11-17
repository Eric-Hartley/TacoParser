using System;
using Xunit;

namespace LoggingKata.Test
{
    public class TacoParserTests
    {
        [Fact]
        public void ShouldReturnNonNullObject()
        {
            //Arrange
            var tacoParser = new TacoParser();

            //Act
            var actual = tacoParser.Parse("34.073638, -84.677017, Taco Bell Acwort...");

            //Assert
            Assert.NotNull(actual);

        }

        [Theory]
        [InlineData("34.073638, -84.677017, Taco Bell Acwort...", -84.677017)]
        [InlineData("34.035985, -84.683302, Taco Bell Acworth...", -84.683302)]
        [InlineData("33.524131,-86.724876, Taco Bell Birmingham...", -86.724876)]
        [InlineData("30.511463,-87.219719,Taco Bell Pensacola...", -87.219719)]
        [InlineData("33.205302,-87.569628,Taco Bell Tuscaloos...", -87.569628)]
        //Add additional inline data. Refer to your CSV file.
        public void ShouldParseLongitude(string line, double expected)
        {
            // TODO: Complete the test with Arrange, Act, Assert steps below.
            //       Note: "line" string represents input data we will Parse 
            //       to extract the Longitude.  
            //       Each "line" from your .csv file
            //       represents a TacoBell location

            //Arrange
            var tacoParser = new TacoParser();
            //Act
            var actual = tacoParser.Parse(line).Location.Longitude;
            //Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("34.073638, -84.677017, Taco Bell Acwort...", 34.073638)]
        [InlineData("34.035985, -84.683302, Taco Bell Acworth...", 34.035985)]
        [InlineData("33.524131,-86.724876, Taco Bell Birmingham...", 33.524131)]
        [InlineData("30.511463,-87.219719,Taco Bell Pensacola...", 30.511463)]
        [InlineData("33.205302,-87.569628,Taco Bell Tuscaloos...", 33.205302)]
        //TODO: Create a test called ShouldParseLatitude
        public void ShouldParseLatitude(string line, double expected)
        {
            // TODO: Complete the test with Arrange, Act, Assert steps below.
            //       Note: "line" string represents input data we will Parse 
            //       to extract the Latitude.  
            //       Each "line" from your .csv file
            //       represents a TacoBell location

            //Arrange
            var TacoParser = new TacoParser();
            //Act
            var actual = TacoParser.Parse(line).Location.Latitude;
            //Assert
            Assert.Equal(expected, actual);
        }

    }
}
