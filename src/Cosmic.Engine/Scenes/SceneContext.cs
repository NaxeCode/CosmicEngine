using Cosmic.Engine.Input;

namespace Cosmic.Engine.Scenes;

public sealed class SceneContext
{
    public SceneManager SceneManager { get; }
    public IInputSource Input { get; }

    public SceneContext(SceneManager sceneManager, IInputSource input)
    {
        SceneManager = sceneManager;
        Input = input;
    }
}
