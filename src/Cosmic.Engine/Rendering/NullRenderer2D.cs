using System;
using System.Collections.Generic;
using System.Text;

namespace Cosmic.Engine.Rendering;
public sealed class NullRenderer2D : IRenderer2D
{

    public static readonly NullRenderer2D Instance = new();
    private NullRenderer2D() { }
}
