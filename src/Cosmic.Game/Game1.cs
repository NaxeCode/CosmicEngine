using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace CosmicEngine;

public class Game1 : Game
{

    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        playerTexture = Content.Load<Texture2D>("assets/spritesheet");
        playerPosition = new Vector2(100, 100);

        // TODO: use this.Content to load your game content here
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        var keyboard = Keyboard.GetState();

        if (keyboard.IsKeyDown(Keys.Right))
            playerPosition.X += 200f * (float)gameTime.ElapsedGameTime.TotalSeconds;

        if (keyboard.IsKeyDown(Keys.Left))
            playerPosition.X -= 200f * (float)gameTime.ElapsedGameTime.TotalSeconds;

        if (keyboard.IsKeyDown(Keys.Up))
            playerPosition.Y -= 200f * (float)gameTime.ElapsedGameTime.TotalSeconds;

        if (keyboard.IsKeyDown(Keys.Down))
            playerPosition.Y += 200f * (float)gameTime.ElapsedGameTime.TotalSeconds;

        // TODO: Add your update logic here

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        _spriteBatch.Begin();

        _spriteBatch.Draw(playerTexture, playerPosition, Color.White);

        _spriteBatch.End();
        // TODO: Add your drawing code here

        base.Draw(gameTime);
    }
}
