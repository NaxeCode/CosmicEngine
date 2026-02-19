namespace Cosmic.Engine.Rendering;

public interface IRenderer2D
{
    ViewportInfo Viewport { get; }
    void BeginFrame();
    void EndFrame();
    void Clear(ColorRgba color);

    void Begin();

    void FillRect(IntRect rect, ColorRgba color);

    void End();
}
