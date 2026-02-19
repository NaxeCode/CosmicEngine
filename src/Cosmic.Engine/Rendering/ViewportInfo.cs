namespace Cosmic.Engine.Rendering;

public readonly struct ViewportInfo
{
    public readonly int InternalWidth;
    public readonly int InternalHeight;
    public readonly int WindowWidth;
    public readonly int WindowHeight;
    public readonly int Scale;
    public readonly int OffsetX;
    public readonly int OffsetY;

    public ViewportInfo(int internalWidth, int internalHeight, int windowWidth, int windowHeight, int scale,
        int offsetX, int offsetY)
    {
        InternalWidth = internalWidth;
        InternalHeight = internalHeight;
        
        WindowWidth = windowHeight;
        WindowHeight = windowHeight;

        Scale = scale;
        OffsetX = offsetX;
        OffsetY = offsetY;
    }
}