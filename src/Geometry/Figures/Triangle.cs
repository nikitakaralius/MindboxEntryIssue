using Geometry.Abstractions;
using Geometry.Exceptions;

namespace Geometry.Figures;

public sealed record Triangle : IFigure
{
    public double A { get; }
    public double B { get; }
    public double C { get; }

    public Triangle(double a, double b, double c)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(a);
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(b);
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(c);

        if (!DoesTriangleExist(a, b, c))
            throw new TriangleInequalityException(a, b, c);

        A = a;
        B = b;
        C = c;
    }

    public double Area
    {
        get
        {
            double HeronsFormula()
            {
                double semiPerimeter = (A + B + C) / 2;
                return Math.Sqrt(semiPerimeter * (semiPerimeter - A) * (semiPerimeter - B) * (semiPerimeter - C));
            }

            return HeronsFormula();
        }
    }

    public bool IsRightAngled
    {
        get
        {
            bool InversePythagoreanTheorem()
            {
                Span<double> sides = [A, B, C];
                sides.Sort();
                return Math.Abs(sides[2] * sides[2] - (sides[0] * sides[0] + sides[1] * sides[1])) < 1E-5;
            }

            return InversePythagoreanTheorem();
        }
    }

    private static bool DoesTriangleExist(double a, double b, double c)
    {
        Span<double> sides = [a, b, c];
        sides.Sort();
        return sides[2] < sides[0] + sides[1];
    }
}
