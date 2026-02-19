using System;
using System.Collections.Generic;
using System.Text;

namespace Cosmic.Engine.Rendering;
public sealed class NullRenderer2D : IRenderer2D
{

    public static readonly NullRenderer2D Instance = new();
    private NullRenderer2D() { }
    public ViewportInfo Viewport { get; }
    public void BeginFrame()
    {
        throw new NotImplementedException();
    }

    public void EndFrame()
    {
        throw new NotImplementedException();
    }

    public void Clear(ColorRgba color)
    {
        throw new NotImplementedException();
    }

    public void Begin()
    {
        throw new NotImplementedException();
    }

    public void FillRect(IntRect rect, ColorRgba color)
    {
        throw new NotImplementedException();
    }

    public void End()
    {
        throw new NotImplementedException();
    }
}
