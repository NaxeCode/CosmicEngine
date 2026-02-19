using System;
using Cosmic.Engine.Input;
using Cosmic.Engine.Rendering;

namespace Cosmic.Engine.Scenes;

public sealed class SceneManager
{
    private readonly Func<Type, IScene> _sceneFactory;
    private readonly SceneContext _context;

    private IScene _current;

    public SceneManager(Func<Type, IScene> sceneFactory, IInputSource input, Type startingSceneType)
    {
        _sceneFactory = sceneFactory;

        _context = new SceneContext(this, input);

        _current = _sceneFactory(startingSceneType);

        _current.OnEnter(_context);
    }

    public IScene Current => _current;

    public void Update(float deltaTime)
    {
        _context.Input.Update();
        _current.Update(deltaTime);

        if (_current.HasRequestedTransition)
        {
            var nextType = _current.NextSceneType;

            if (nextType == null)
                throw new InvalidOperationException("Scene requested transition but NextSceneType was null.");

            SwitchTo(nextType);
        }
    }
    
    public void Draw(IRenderer2D renderer)
    {
        _current.Draw(renderer);
    }

    private void SwitchTo(Type nextSceneType)
    {
        _current.OnExit();
        _current = _sceneFactory(nextSceneType);
        _current.OnEnter(_context);
    }
}
