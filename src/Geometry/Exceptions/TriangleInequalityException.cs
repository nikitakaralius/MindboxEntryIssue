namespace Geometry.Exceptions;

internal sealed class TriangleInequalityException(double a, double b, double c) : Exception
{
    public override string Message =>
        $"Triangle with sides {FormatSides()} can not exist due to Triangle Inequality";

    public override string HelpLink =>
        "https://en.wikipedia.org/wiki/Triangle_inequality";

    private string FormatSides() => $"[{a}, {b}, {c}]";
}
