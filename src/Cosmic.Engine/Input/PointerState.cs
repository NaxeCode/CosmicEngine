namespace Cosmic.Engine.Input;

public readonly struct PointerState
{

    public readonly int X;
    public readonly int Y;
    public readonly bool LeftDown;
    public readonly bool LeftJustPressed;
    public readonly bool LeftJustReleased;

    public PointerState(int x, int y, bool leftDown, bool leftJustPressed, bool leftJustReleased)
    {
        X = x;
        Y = y;
        LeftDown = leftDown;
        LeftJustPressed = leftJustPressed;
        LeftJustReleased = leftJustReleased;
    }
}