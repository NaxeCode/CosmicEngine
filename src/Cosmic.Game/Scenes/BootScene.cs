using Cosmic.Engine.Scenes;
using Cosmic.Engine.Rendering;
using System;
using System.Numerics;
using Cosmic.Engine.World;

namespace Cosmic.Game.Scenes;

public sealed class BootScene : IScene
{
    private SceneContext? _context;

    private readonly Camera2D _camera = new();
    private const int TileSize = 16;
    
    public bool HasRequestedTransition { get; private set; }
    public Type? NextSceneType { get; private set; }
    
    public void OnEnter(SceneContext context)
    {
        _context = context;
        HasRequestedTransition = false;
        NextSceneType = null;
        
        // Temp, center camera @ world origin 0,0
        _camera.Position = new Vector2(0, 0);
        _camera.Zoom = 1f;
    }
    
    public void Draw(IRenderer2D renderer)
    {
        if (_context == null) return;

        var vp = renderer.Viewport;
        
        // World pass:
        renderer.BeginWorld(_camera);
        
        // World background grid-ish fill
        renderer.FillRect(new IntRect(-1000, -1000, 2000, 2000), ColorRgba.CosmicBlue);
        
        // Hovered tile highlight
        var p = _context.Input.Pointer;
        var worldPos = _camera.ScreenToWorld(p.X, p.Y, vp);

        var (tx, ty) = TileMath.WorldToTile(worldPos, TileSize);
        var tileTopLeft = TileMath.TileToWorld(tx, ty, TileSize);

        renderer.FillRect(
            new IntRect((int)tileTopLeft.X, (int)tileTopLeft.Y, TileSize, TileSize),
            ColorRgba.White);
        
        renderer.End();
        
        // UI Pass:
        renderer.BeginUi();
        
        // Draw a tiny cursor marker in screen space so you can verify pointer conversion
        renderer.FillRect(
            new IntRect(p.X - 2, p.Y - 2, 4, 4),
            ColorRgba.CosmicPurple);
        
        renderer.End();
    }

    public void Update(float deltaTime)
    {
        if (_context == null)
            return;

        if (_context.Input.IsActionJustPressed("Confirm"))
        {
            HasRequestedTransition = true;
            NextSceneType = typeof(EmptyScene);
        }
        
        _camera.Position += new System.Numerics.Vector2(20f * deltaTime, 0f);
    }
    
    public void OnExit()
    {
        Console.WriteLine("Boot OnExit();");
        // Nothing for now
    }
}
