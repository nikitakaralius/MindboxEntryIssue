using Geometry.Abstractions;

namespace Geometry.Figures;

public sealed record Circle : IFigure
{
    public double Radius { get; }

    public Circle(double radius)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(radius);
        Radius = radius;
    }

    public double Area => Math.PI * Radius * Radius;
}
