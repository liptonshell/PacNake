using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Pacnake
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;


        clsTabuleiro Tab;
        clsNake Pac;
        clsStain stain;

        public Game1()
            : base()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferHeight = 630;//750
            graphics.PreferredBackBufferWidth = 630;//700

            IsMouseVisible = true;

            Tab = new clsTabuleiro();
            Pac=new clsNake();
            stain = new clsStain();
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            Pac.inicialize();
            stain.inicialize();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            Tab.loadContent(Content);
            Pac.loadContent(Content);
            stain.loadContent(Content);
        }


        protected override void UnloadContent()
        {
            Tab.unloadContent();
            Pac.unloadContent();
            stain.unloadContent();
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            Pac.update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);


            spriteBatch.Begin();

            spriteBatch.Draw(Content.Load<Texture2D>("menu"), new Rectangle(0, 0, 630, 630), Color.White);
            Tab.draw(spriteBatch);
            Pac.draw(spriteBatch);
            stain.draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
