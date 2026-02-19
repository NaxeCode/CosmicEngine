namespace Cosmic.Engine.Rendering;

public readonly struct ColorRgba
{
    public readonly byte R;
    public readonly byte G;
    public readonly byte B;
    public readonly byte A;

    public ColorRgba(byte r, byte g, byte b, byte a = 255)
    {
        R = r;
        G = g;
        B = b;
        A = a;
    }

    public static ColorRgba Black => new(0, 0, 0, 255);
    public static ColorRgba White => new(255, 255, 255, 255);
    public static ColorRgba CosmicBlue => new(18, 32, 64, 255);
    public static ColorRgba CosmicPurple => new(58, 32, 86, 255);
}