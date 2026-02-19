using System.Numerics;

namespace Cosmic.Engine.Rendering;

public sealed class Camera2D
{

    public Vector2 Position { get; set; } = Vector2.Zero;

    public float Zoom { get; set; } = 1f;

    public Vector2 ScreenToWorld(int screenX, int screenY, ViewportInfo viewport)
    {
        // screen coords are in INTERNAL pixels (not width pixels)
        var halfW = viewport.InternalWidth / 2f;
        var halfH = viewport.InternalHeight / 2f;

        var localX = (screenX - halfW) / Zoom;
        var localY = (screenY - halfH) / Zoom;

        return new Vector2(Position.X + localX, Position.Y + localY);
    }

    public Vector2 WorldToScreen(float worldX, float worldY, ViewportInfo viewport)
    {
        var halfW = viewport.InternalWidth / 2f;
        var halfH = viewport.InternalHeight / 2f;
        
        var localX = (worldX - halfW) * Zoom;
        var localY = (worldY - halfH) * Zoom;

        return new Vector2(localX + halfW, localY + halfW);
    }
}