using Cosmic.Engine.Rendering;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Cosmic.Engine.Platform.MonoGame;

public sealed class MgRenderer2D : IRenderer2D
{
    private readonly GraphicsDevice _graphicsDevice;
    private readonly SpriteBatch _spriteBatch;
    
    private readonly Texture2D _pixel;
    private readonly RenderTarget2D _internalTarget;
    
    private ViewportInfo _viewport;
    public ViewportInfo Viewport => _viewport;
    public void BeginWorld(Camera2D camera)
    {
        var vp = _viewport;

        var halfW = vp.InternalWidth / 2f;
        var halfH = vp.InternalHeight / 2f;

        var tx = -camera.Position.X;
        var ty = -camera.Position.Y;

        var transform = Matrix.CreateTranslation(tx, ty, 0f) * Matrix.CreateScale(camera.Zoom, camera.Zoom, 1f) *
                        Matrix.CreateTranslation(halfW, halfH, 0f);
        
        _spriteBatch.Begin(samplerState: SamplerState.PointClamp, transformMatrix: transform);
    }

    public void BeginUi()
    {
        _spriteBatch.Begin(samplerState: SamplerState.PointClamp);
    }

    public MgRenderer2D(GraphicsDevice graphicsDevice, RenderConfig config)
    {
        _graphicsDevice = graphicsDevice;
        _spriteBatch = new SpriteBatch(graphicsDevice);

        _pixel = new Texture2D(graphicsDevice, 1, 1);
        _pixel.SetData(new[] { Color.White });

        _internalTarget = new RenderTarget2D(graphicsDevice, config.InternalWidth, config.InternalHeight, false,
            SurfaceFormat.Color, DepthFormat.None, 0, RenderTargetUsage.DiscardContents);

        RecalculateViewport(config.InternalWidth, config.InternalHeight);
    }

    public void BeginFrame()
    {
        _graphicsDevice.SetRenderTarget(_internalTarget);
    }

    public void EndFrame()
    {
        _graphicsDevice.SetRenderTarget(null);

        var dest = new Rectangle(_viewport.OffsetX, _viewport.OffsetY, _viewport.InternalWidth * _viewport.Scale,
            _viewport.InternalHeight * _viewport.Scale);
        
        _spriteBatch.Begin(samplerState: SamplerState.PointClamp);
        _spriteBatch.Draw(_internalTarget, dest, Color.White);
        _spriteBatch.End();
    }

    public void Clear(ColorRgba color)
    {
        _graphicsDevice.Clear(new Color(color.R, color.G, color.B, color.A));
    }

    public void FillRect(IntRect rect, ColorRgba color)
    {
        var xnaRect = new Rectangle(rect.X, rect.Y, rect.Width, rect.Height);
        var xnaColor = new Color(color.R, color.G, color.B, color.A);
        
        _spriteBatch.Draw(_pixel, xnaRect, xnaColor);
    }

    public void End()
    {
        _spriteBatch.End();
    }

    public void OnWindowSizeChanged(int windowWidth, int windowHeight)
    {
        RecalculateViewport(_internalTarget.Width, _internalTarget.Height, windowWidth, windowHeight);
    }

    public void RecalculateViewport(int internalW, int internalH)
    {
        var pp = _graphicsDevice.PresentationParameters;
        RecalculateViewport(internalW, internalH, pp.BackBufferWidth, pp.BackBufferHeight);
    }

    public void RecalculateViewport(int internalW, int internalH, int windowW, int windowH)
    {
        var scaleX = windowW / internalW;
        var scaleY = windowH / internalH;

        var scale = Math.Max(1, Math.Min(scaleX, scaleY));

        var destW = internalW * scale;
        var destH = internalH * scale;

        var offsetX = (windowW - destW) / 2;
        var offsetY = (windowH - destH) / 2;

        _viewport = new ViewportInfo(internalW, internalH, windowW, windowH, scale, offsetX, offsetY);
    }
}