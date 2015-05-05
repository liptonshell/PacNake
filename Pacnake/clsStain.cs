using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pacnake
{
    class clsStain
    {
        Texture2D stain1, stain2, stain3;
        int score;
        clsTabuleiro board;

        public void inicialize()
        {
            board = new clsTabuleiro();
        }


        public void loadContent(ContentManager Content)
        {
            stain1 = Content.Load<Texture2D>("pera");
        }


        public void unloadContent()
        {
            stain1.Dispose();
        }


        public void draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(stain1, new Vector2(30, 30), Color.White);
            spriteBatch.Draw(stain1, new Vector2(200, 30), Color.White);
            spriteBatch.Draw(stain1, new Vector2(30, 500), Color.White);
        }
        
    }
}
