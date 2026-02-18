using Cosmic.Engine.Rendering;
using Cosmic.Engine.Scenes;
using System;
using System.Diagnostics;

namespace Cosmic.Game.Scenes;

public sealed class EmptyScene : IScene
{
    private SceneContext? _context;
    public bool HasRequestedTransition => false;

    public Type? NextSceneType => null;

    public void Draw(IRenderer2D renderer)
    {
        // Nothing
    }

    public void OnEnter(SceneContext context)
    {
        Debug.WriteLine("Empty OnEnter();");
        _context = context;
    }

    public void OnExit()
    {
        Debug.WriteLine("Empty OnExit();");
        // Nothing
    }

    public void Update(float deltaTime)
    {
        // Nothing
    }
}
