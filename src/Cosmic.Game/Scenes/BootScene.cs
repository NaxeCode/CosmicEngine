using Cosmic.Engine.Scenes;
using Cosmic.Engine.Rendering;
using System;
using System.Diagnostics;
namespace Cosmic.Game.Scenes;

public sealed class BootScene : IScene
{
    private SceneContext? _context;
    public bool HasRequestedTransition { get; private set; }

    public Type? NextSceneType { get; private set; }
    public void Draw(IRenderer2D renderer)
    {
        // Empty for now
    }

    public void OnEnter(SceneContext context)
    {
        Debug.WriteLine("Boot OnEnter();");
        _context = context;
        HasRequestedTransition = false;
        NextSceneType = null;
    }

    public void OnExit()
    {
        Debug.WriteLine("Boot OnExit();");
        // Nothing for now
    }

    public void Update(float deltaTime)
    {
        if (_context == null)
            return;

        if (_context.Input.IsActionPressed("Confirm"))
        {
            HasRequestedTransition = true;
            NextSceneType = typeof(EmptyScene);
        }
    }
}
