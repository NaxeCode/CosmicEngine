namespace Cosmic.Engine.Input;

public interface IInputSource
{
    PointerState Pointer { get; }
    void Update();
    bool IsActionPressed(string action);
    bool IsActionJustPressed(string action);
    bool IsActionJustReleased(string action);
}
