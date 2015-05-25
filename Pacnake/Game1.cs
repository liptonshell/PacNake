using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Pacnake
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Game
    {
        public GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        clsTabuleiro Tab;
        clsNake Pac;
        //clsStain stain;


        public Game1()
            : base()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferHeight = 750;
            graphics.PreferredBackBufferWidth = 750;
            graphics.ApplyChanges();

            IsMouseVisible = true;

            Tab = new clsTabuleiro();
            Pac=new clsNake();
            //stain = new clsStain();
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            Pac.inicialize();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            Tab.loadContent(Content);
            Pac.loadContent(Content);
        }


        protected override void UnloadContent()
        {

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

            Tab.draw(spriteBatch);
            //Pac.draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
