namespace Cosmic.Engine.Rendering;

public interface IRenderer2D
{
    ViewportInfo Viewport { get; }
    void BeginWorld(Camera2D camera);
    void BeginUi();
    void BeginFrame();
    void EndFrame();
    void Clear(ColorRgba color);

    void FillRect(IntRect rect, ColorRgba color);

    void End();
}
