using Cosmic.Engine.Input;
using Microsoft.Xna.Framework.Input;

namespace Cosmic.Engine.Platform.MonoGame;

public sealed class MgInputSource : IInputSource
{

    private readonly Dictionary<string, Keys> _map;

    public MgInputSource(Dictionary<string, Keys> map)
    {
        _map = map;
    }

    public bool IsActionPressed(string action)
    {
        if (!_map.TryGetValue(action, out var key))
            return false;

        var state = Keyboard.GetState();

        return state.IsKeyDown(key);
    }
}
