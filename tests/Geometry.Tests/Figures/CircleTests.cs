using FluentAssertions;
using Geometry.Figures;

namespace Geometry.Tests.Figures;

public class CircleTests
{
    [Fact]
    public void Constructor_RadiusIsCorrect_ShouldCreateTriangle()
    {
        // Arrange
        const double radius = 5;

        // Act
        var circle = new Circle(radius);

        // Assert
        circle
           .Radius
           .Should()
           .Be(radius);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-5)]
    public void Constructor_WrongRadius_ShouldThrowException(double radius)
    {
        // Act
        var create = () => new Circle(radius);

        // Assert
        create
           .Should()
           .Throw<ArgumentOutOfRangeException>();
    }

    [Theory]
    [InlineData(1, Math.PI)]
    [InlineData(5, 78.54)]
    [InlineData(6.25, 122.72)]
    public void Area_RadiusIsPositive_ShouldCalculateArea(double radius, double expectedArea)
    {
        // Arrange
        var circle = new Circle(radius);

        // Act
        var area = circle.Area;

        // Assert
        area
           .Should()
           .BeApproximately(expectedArea, 0.005);
    }
}
