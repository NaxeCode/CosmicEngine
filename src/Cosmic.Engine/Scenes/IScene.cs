using Cosmic.Engine.Rendering;

namespace Cosmic.Engine.Scenes;

public interface IScene
{
    void OnEnter(SceneContext context);
    void OnExit();

    void Update(float deltaTime);
    void Draw(IRenderer2D renderer);
    bool HasRequestedTransition { get; }

    Type? NextSceneType { get; }
}
