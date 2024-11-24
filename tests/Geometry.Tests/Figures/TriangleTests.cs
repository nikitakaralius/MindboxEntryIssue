using FluentAssertions;
using Geometry.Exceptions;
using Geometry.Figures;

namespace Geometry.Tests.Figures;

public class TriangleTests
{
    [Fact]
    public void Constructor_SidesAreValid_ShouldCreateTriangle()
    {
        // Arrange
        const double a = 3, b = 4, c = 5;

        // Act
        var triangle = new Triangle(a, b, c);

        // Assert
        triangle.A.Should().Be(a);
        triangle.B.Should().Be(b);
        triangle.C.Should().Be(c);
    }

    [Theory]
    [InlineData(-1, 2, 3)]
    [InlineData(1, -2, 3)]
    [InlineData(1, 2, -3)]
    [InlineData(0, 2, 3)]
    [InlineData(1, 0, 3)]
    [InlineData(1, 2, 0)]
    public void Constructor_OneOfSideIsNegativeOrZero_ShouldThrowArgumentOutOfRangeException(double a, double b, double c)
    {
        // Act
        var create = () => new Triangle(a, b, c);

        // Assert
        create
           .Should()
           .Throw<ArgumentOutOfRangeException>();
    }

    [Theory]
    [InlineData(1, 2, 3)]
    [InlineData(1, 10, 12)]
    public void Constructor_InvalidTriangleSides_ShouldThrowTriangleInequalityException(double a, double b, double c)
    {
        // Act
        var create = () => new Triangle(a, b, c);

        // Assert
        create
           .Should()
           .Throw<TriangleInequalityException>();
    }

    [Fact]
    public void Area_TriangleInvalid_ShouldReturnCorrectArea()
    {
        // Arrange
        var triangle = new Triangle(3, 4, 5);

        // Act
        var area = triangle.Area;

        // Assert
        area
           .Should()
           .Be(6.0);
    }

    [Fact]
    public void IsRightAngled_RightTriangle_ShouldBeTrue()
    {
        // Arrange
        var triangle = new Triangle(3, 4, 5);

        // Act
        var isRight = triangle.IsRightAngled;

        // Assert
        isRight
           .Should()
           .BeTrue();
    }

    [Fact]
    public void IsRightAngled_NonRightTriangle_ShouldBeFalse()
    {
        // Arrange
        var triangle = new Triangle(2, 2, 3);

        // Act
        var isRight = triangle.IsRightAngled;

        // Assert
        isRight
           .Should()
           .BeFalse();
    }
}
