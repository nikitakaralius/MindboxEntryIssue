using Geometry.Abstractions;

namespace Geometry.Figures;

public sealed record Circle : IFigure
{
    public double Radius { get; }

    private Circle(double radius)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(radius);
        Radius = radius;
    }

    public double Area => Math.PI * Radius * Radius;
}
