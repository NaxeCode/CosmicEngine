using Cosmic.Engine.Input;
using Cosmic.Engine.Platform.MonoGame;
using Cosmic.Engine.Scenes;
using Cosmic.Game.Scenes;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace Cosmic.Game.Startup;

public static class GameCompositionRoot
{
    public static SceneManager Build()
    {
        var actionMap = new Dictionary<string, Keys>
        {
            { "Confirm", Keys.Enter }
        };

        IInputSource input = new MgInputSource(actionMap);

        IScene SceneFactory(Type type)
        {
            if (type == typeof(BootScene))
                return new BootScene();

            if (type == typeof(EmptyScene))
                return new EmptyScene();

            throw new InvalidOperationException($"Unknown scene type: {type}");
        };

        return new SceneManager(
            SceneFactory,
            input,
            typeof(BootScene)
        );
    }
}
