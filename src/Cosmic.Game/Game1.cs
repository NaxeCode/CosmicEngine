using System;
using Cosmic.Engine.Platform.MonoGame;
using Cosmic.Engine.Rendering;
using Cosmic.Engine.Scenes;
using Cosmic.Game.Startup;
using Microsoft.Xna.Framework;

namespace Cosmic.Game;

public class Game1 : Microsoft.Xna.Framework.Game
{
    private GraphicsDeviceManager _graphics;
    private SceneManager _scenes;
    private MgRenderer2D _renderer;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        _graphics.PreferredBackBufferWidth = 1280;
        _graphics.PreferredBackBufferHeight = 720;

        _graphics.ApplyChanges();
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here
        _scenes = GameCompositionRoot.Build();

        base.Initialize();
    }

    protected override void LoadContent()
    {
        // TODO: use this.Content to load your game content here
        _renderer = new MgRenderer2D(GraphicsDevice, RenderConfig.StardewLike);
    }

    protected override void Update(GameTime gameTime)
    {
        var dt = (float)gameTime.ElapsedGameTime.TotalSeconds;

        _scenes.Update(dt);

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        // GraphicsDevice.Clear(Color.CornflowerBlue);
        
        _renderer.BeginFrame();
        _renderer.Clear(new ColorRgba(Color.Azure.R, Color.Azure.G, Color.Azure.B, Color.Azure.A));
        _renderer.Begin();
        
        _scenes.Draw(_renderer);
        
        _renderer.End();
        _renderer.EndFrame();

        base.Draw(gameTime);
    }
}
