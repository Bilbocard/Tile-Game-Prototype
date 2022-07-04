using UnityEngine;

public static class Settings
{
    private static readonly float TileSizeY = 1.9f;
    private static readonly float EdgeSize = TileSizeY / 2f;
    public static readonly Vector2 ROffset = new(0f, -EdgeSize);

    public static readonly Vector2 QOffset = new(Mathf.Sqrt(EdgeSize * EdgeSize - 0.25f * EdgeSize * EdgeSize),
        EdgeSize / 2f);

    public static readonly Vector2 SOffset = new(-Mathf.Sqrt(EdgeSize * EdgeSize - 0.25f * EdgeSize * EdgeSize),
        EdgeSize / 2f);
    //r -edge
    //q = 1/2 edge up, edge^2 - 1/2 edge ^2 all rt right
    //s = 1/2 edge up, opposite of q left
}