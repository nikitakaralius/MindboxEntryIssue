using Geometry.Abstractions;
using Geometry.Exceptions;

namespace Geometry.Figures;

public sealed record Triangle : IFigure
{
    public double A { get; }
    public double B { get; }
    public double C { get; }

    private Triangle(double a, double b, double c)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(a);
        ArgumentOutOfRangeException.ThrowIfNegative(b);
        ArgumentOutOfRangeException.ThrowIfNegative(c);

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

    public bool IsRight
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
