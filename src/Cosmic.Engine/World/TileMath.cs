using System.Numerics;

namespace Cosmic.Engine.World;

public static class TileMath
{

    public static (int X, int Y) WorldToTile(Vector2 worldPos, int tileSize)
    {
        var tx = (int)MathF.Floor(worldPos.X / tileSize);
        var ty = (int)MathF.Floor(worldPos.Y / tileSize);
        return (tx, ty);
    }

    public static Vector2 TileToWorld(int tileX, int tileY, int tileSize)
    {
        return new Vector2(tileX * tileSize, tileY * tileSize);
    }
}