using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;

namespace Pacnake
{
    public enum Direction
    {
        Up,
        Down,
        Left,
        Right
    }

    public class clsNake
    {
        Texture2D Nake,Tail;
        int pX1 = 1, pY1 = 1;
        clsTabuleiro go;
        KeyboardState oldKeyState;

        public const float MoveSpeed = .2f;
        private float moveTimer;
        private DateTime lastUpdatedAt;
        private Direction direction;
        private List<Rectangle> parts;

        public clsNake()
        {
            parts = new List<Rectangle>();
            direction = Direction.Right;
        }

        public void inicialize()
        {
            go = new clsTabuleiro();
        }

        public void loadContent(ContentManager Content)
        {
            Nake = Content.Load<Texture2D>("Man2");
            Tail = Content.Load<Texture2D>("Tail2");
        }

        public void unloadContent()
        {
            Nake.Dispose();
        }

        public void update()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                if (go.CanGo(pX1, pY1 + 1))
                {
                    pY1++;
                }
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                if (go.CanGo(pX1, pY1 - 1))
                {
                    pY1--;
                }
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                if (go.CanGo(pX1 - 1, pY1))
                {
                    pX1--;
                }
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                if (go.CanGo(pX1 + 1, pY1))
                {
                    pX1++;
                }
            }
        }

        public void draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Nake, new Vector2(pX1 * 30, pY1 * 30), Color.White);
        }
    }
}