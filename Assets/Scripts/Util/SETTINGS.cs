using UnityEngine;

public static class SETTINGS
{
    public static readonly float TileSizeX = 1.6454f;
    public static readonly float TileSizeY = 1.9f;
    public static readonly float EdgeSize = TileSizeY / 2f;
    public static readonly Vector2 TileOffset = new Vector2(TileSizeX, TileSizeY * 0.75f);
    public static readonly Vector2 TileOffsetOdd = new Vector2(EdgeSize, 0f);
    public static readonly Vector2 ROffset = new Vector2(0f, -EdgeSize);
    public static readonly Vector2 QOffset = new Vector2(Mathf.Sqrt((EdgeSize * EdgeSize) - (0.25f * EdgeSize * EdgeSize)), EdgeSize/2f);
    public static readonly Vector2 SOffset = new Vector2(-Mathf.Sqrt((EdgeSize * EdgeSize) - (0.25f * EdgeSize * EdgeSize)), EdgeSize/2f);

    public static bool PlayerCanMove = true;
    //r -edge
    //q = 1/2 edge up, edge^2 - 1/2 edge ^2 all rt right
    //s = 1/2 edge up, opposite of q left



}
