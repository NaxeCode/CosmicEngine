using Cosmic.Engine.Rendering;
using Cosmic.Engine.Scenes;
using Cosmic.Game.Startup;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace CosmicEngine;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SceneManager _scenes;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
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
    }

    protected override void Update(GameTime gameTime)
    {
        var dt = (float)gameTime.ElapsedGameTime.TotalSeconds;

        _scenes.Update(dt);

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        _scenes.Draw(NullRenderer2D.Instance);

        base.Draw(gameTime);
    }
}
