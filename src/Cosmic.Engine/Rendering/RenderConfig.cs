namespace Cosmic.Engine.Rendering;

public sealed class RenderConfig
{
    
    public int InternalWidth { get; }
    public int InternalHeight { get; }

    public RenderConfig(int internalWidth, int internalHeight)
    {
        InternalWidth = internalWidth;
        InternalHeight = internalHeight;
    }

    public static RenderConfig StardewLike => new RenderConfig(400, 225);
}