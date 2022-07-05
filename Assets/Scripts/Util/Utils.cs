using System;
using UnityEngine;

public static class Utils
{
    private static readonly float TileSizeY = 1.9f;
    private static readonly float EdgeSize = TileSizeY / 2f;
    private static readonly Vector2 ROffset = new(0f, -EdgeSize);

    private static readonly Vector2 QOffset = new(Mathf.Sqrt(EdgeSize * EdgeSize - 0.25f * EdgeSize * EdgeSize),
        EdgeSize / 2f);

    private static readonly Vector2 SOffset = new(-Mathf.Sqrt(EdgeSize * EdgeSize - 0.25f * EdgeSize * EdgeSize),
        EdgeSize / 2f);
    
    private static readonly Hex[] AxialVectors =
    {
        new() {q = 1, r = 0}, new() {q = 1, r = -1}, new() {q = 0, r = -1}, new() {q = -1, r = 0},
        new() {q = -1, r = 1}, new() {q = 0, r = 1}
    };

    public static Vector2 AxialToVector2(Hex axial)
    {
        return axial.q * QOffset + axial.r * ROffset + (-axial.q - axial.r) * SOffset;
    }

    public static Hex AxialDirection(int direction)
    {
        return AxialVectors[direction];
    }

    public static Hex AxialAdd(Hex axial, Hex vector)
    {
        return new Hex {q = axial.q + vector.q, r = axial.r + vector.r};
    }

    public static Hex AxialNeighbour(Hex axial, int direction)
    {
        return AxialAdd(axial, AxialDirection(direction));
    }

    public static Hex CubeToAxial(CubeFrac cubeFrac)
    {
        return new Hex {q = (int) cubeFrac.q, r = (int) cubeFrac.r};
    }

    public static CubeFrac FracToCube(Frac frac)
    {
        return new CubeFrac {q = frac.q, r = frac.r, s = -frac.q - frac.r};
    }

    public static Hex MouseToWorldHex()
    {
        var worldPosition = Camera.main!.ScreenToWorldPoint(Input.mousePosition);
        return CoordinateToWorldHex(worldPosition);
    }

    public static CubeFrac CubeRound(CubeFrac cubeFrac)
    {
        var q = Mathf.RoundToInt(cubeFrac.q);
        var r = Mathf.RoundToInt(cubeFrac.r);
        var s = Mathf.RoundToInt(cubeFrac.s);

        var qDiff = Mathf.Abs(q - cubeFrac.q);
        var rDiff = Mathf.Abs(r - cubeFrac.r);
        var sDiff = Mathf.Abs(s - cubeFrac.s);

        if (qDiff > rDiff && qDiff > sDiff) return new CubeFrac {q = -r - s, r = r, s = s};
        if (rDiff > sDiff) return new CubeFrac {q = q, r = -q - s, s = s};
        return new CubeFrac {q = q, r = r, s = -q - r};
    }

    public static Hex CoordinateToWorldHex(Vector3 worldPosition)
    {
        var q = (Mathf.Sqrt(3f) / 3f * worldPosition.x + 1f / 3f * worldPosition.y) / 0.95f;
        var r = -(2f / 3f * worldPosition.y / 0.95f);
        return CubeToAxial(CubeRound(FracToCube(new Frac {q = q, r = r})));
    }

    public static bool CompareHexes(Hex firstHex, Hex secondHex)
    {
        return firstHex.q == secondHex.q && firstHex.r == secondHex.r;
    }

    public static int DistanceBetweenHexes(Hex firstHex, Hex secondHex)
    {
        var axialSubbed = AxialSubtract(firstHex, secondHex);
        return (Math.Abs(axialSubbed.q) + Math.Abs(axialSubbed.q + axialSubbed.r) + Math.Abs(axialSubbed.r)) / 2;
    }

    public static Hex AxialSubtract(Hex firstAxial, Hex secondAxial)
    {
        return new Hex {q = firstAxial.q - secondAxial.q, r = firstAxial.r - secondAxial.r};
    }

    public static Vector2 Vector3ToVector2(Vector3 input)
    {
        return new Vector2(input.x, input.y);
    }
}

public struct Hex
{
    public int q;
    public int r;
}

public struct Frac
{
    public float q;
    public float r;
}

public struct CubeFrac
{
    public float q;
    public float r;
    public float s;
}