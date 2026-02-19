using Cosmic.Engine.Input;
using Microsoft.Xna.Framework.Input;

namespace Cosmic.Engine.Platform.MonoGame;

public sealed class MgInputSource : IInputSource
{

    private readonly Dictionary<string, Keys> _map;
    private readonly MgRenderer2D _renderer;

    private KeyboardState _previous;
    private KeyboardState _current;

    public MgInputSource(Dictionary<string, Keys> map, MgRenderer2D renderer)
    {
        _map = map;
        _renderer = renderer;

        _current = Keyboard.GetState();
        _previous = _current;
        
        _currMouse = Mouse.GetState();
        _prevMouse = _currMouse;
        _pointer = new PointerState(0, 0, false, false, false);
    }

    private MouseState _prevMouse;
    private MouseState _currMouse;

    private PointerState _pointer;
    public PointerState Pointer => _pointer;

    public void Update()
    {
        _previous = _current;
        _current = Keyboard.GetState();

        _prevMouse = _currMouse;
        _currMouse = Mouse.GetState();
        var windowX = _currMouse.X;
        var windowY = _currMouse.Y;
        
        // Converting window coords to internal coords
        var vp = _renderer.Viewport;

        var scale = Math.Max(1, vp.Scale);
        var internalX = (windowX - vp.OffsetX) / scale;
        var internalY = (windowY - vp.OffsetY) / scale;

        internalX = Math.Clamp(internalX, 0, vp.InternalWidth - 1);
        internalY = Math.Clamp(internalY, 0, vp.InternalHeight - 1);


        var leftDown = _currMouse.LeftButton == ButtonState.Pressed;
        var leftJustPressed = _currMouse.LeftButton == ButtonState.Pressed &&
                              _prevMouse.LeftButton == ButtonState.Released;
        var leftJustReleased = _currMouse.LeftButton == ButtonState.Released &&
                               _prevMouse.LeftButton == ButtonState.Pressed;

        _pointer = new PointerState(internalX, internalY, leftDown, leftJustPressed, leftJustReleased);
    }

    public bool IsActionPressed(string action)
    {
        if (!_map.TryGetValue(action, out var key))
            return false;

        return _current.IsKeyDown(key);
    }

    public bool IsActionJustPressed(string action)
    {
        if (!_map.TryGetValue(action, out var key))
            return false;

        return _current.IsKeyDown(key) && _previous.IsKeyUp(key);
    }

    public bool IsActionJustReleased(string action)
    {
        if (!_map.TryGetValue(action, out var key))
            return false;

        return _current.IsKeyUp(key) && _previous.IsKeyDown(key);
    }
}
