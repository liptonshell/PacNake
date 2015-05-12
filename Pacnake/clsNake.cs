using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;

namespace Pacnake
{
    class clsNake
    {
        Texture2D Nake;
        int pX1 = 1, pY1 = 1;
        clsTabuleiro go;

        public void inicialize()
        {
            go = new clsTabuleiro();
        }

        public void loadContent(ContentManager Content)
        {
            Nake = Content.Load<Texture2D>("Man1");
        }

        public void unloadContent()
        {
            Nake.Dispose();
        }

        public void update()
        {
            //if (Keyboard.GetState().IsKeyDown(Keys.Down))
            //{
            //    if (go.CanGo(pX1, pY1 + 1))
            //    {
            //        pY1++;
            //    }
            //}
            //if (Keyboard.GetState().IsKeyDown(Keys.Up))
            //{
            //    if (go.CanGo(pX1, pY1 - 1))
            //    {
            //        pY1--;
            //    }
            //}
            //if (Keyboard.GetState().IsKeyDown(Keys.Left))
            //{
            //    if (go.CanGo(pX1 - 1, pY1))
            //    {
            //        pX1--;
            //    }
            //}

            //if (Keyboard.GetState().IsKeyDown(Keys.Right))
            //{
            //    if (go.CanGo(pX1 + 1, pY1))
            //    {
            //        pX1++;
            //    }
            //}
        }

/// <summary>
/// /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/// </summary>


        KeyboardState keyboardState;
        GamePadState gamepadState;


        public enum Direction
        {
            Up,
            Down,
            Left,
            Right,
            Null
        }
        
        public Vector2 position;
        // private Texture2D sprite;
        private Direction direction;
        public int score;
        public int playerIndex;
        public int PacManAtual = 0;

        public void draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Nake, new Vector2(pX1 * 30, pY1 * 30), Color.White);
        }

        // Simplifica a escrita da função dos botões do teclado e comando
        public void LerTeclas()
        {
            keyboardState = Keyboard.GetState();
            if (playerIndex == 1)
                gamepadState = GamePad.GetState(PlayerIndex.One);
            else if (playerIndex == 2)
                gamepadState = GamePad.GetState(PlayerIndex.Two);
        }

        private Direction GetDirectionByKeyState()
        {
            LerTeclas();

            if (playerIndex == 1)
            {
                // Baixo
                if ((keyboardState.IsKeyDown(Keys.Down) || gamepadState.IsButtonDown(Buttons.DPadDown)))
                    return Direction.Down;
                // Cima
                else if (keyboardState.IsKeyDown(Keys.Up) || gamepadState.IsButtonDown(Buttons.DPadUp))
                    return Direction.Up;
                // Esquerda
                else if (keyboardState.IsKeyDown(Keys.Left) || gamepadState.IsButtonDown(Buttons.DPadLeft))
                    return Direction.Left;
                // Direita
                else if (keyboardState.IsKeyDown(Keys.Right) || gamepadState.IsButtonDown(Buttons.DPadRight))
                    return Direction.Right;
                // Caso nenhuma tecla esteja a ser pressionada
                else return Direction.Null;
            }
            else
            {
                // Baixo
                if ((keyboardState.IsKeyDown(Keys.S) || gamepadState.IsButtonDown(Buttons.DPadDown)))
                    return Direction.Down;
                // Cima
                else if (keyboardState.IsKeyDown(Keys.W) || gamepadState.IsButtonDown(Buttons.DPadUp))
                    return Direction.Up;
                // Esquerda
                else if (keyboardState.IsKeyDown(Keys.A) || gamepadState.IsButtonDown(Buttons.DPadLeft))
                    return Direction.Left;
                // Direita
                else if (keyboardState.IsKeyDown(Keys.D) || gamepadState.IsButtonDown(Buttons.DPadRight))
                    return Direction.Right;
                // Caso nenhuma tecla esteja a ser pressionada
                else return Direction.Null;
            }
        }

        private void AutoMove(Direction direction)
        {
            if (direction == Direction.Down)
            {
                if (go.CanGo((int)position.X, (int)position.Y + 1))
                {

                    position.Y++;
                    //Comer(board);
                }
            }
            else if (direction == Direction.Up)
            {
                // Cima
                if (go.CanGo((int)position.X, (int)position.Y - 1))
                {

                    position.Y--;
                    //Comer(board);
                }
            }
            else if (direction == Direction.Left)
            {

                // Warp da esquerda para a direita
                //if (position.X == 0 && position.Y == 9)
                //    position.X = 21;

                if (go.CanGo((int)position.X - 1, (int)position.Y))
                {
                    position.X--;
                    //Comer(board);

                }
            }
            else if (direction == Direction.Right)
            {
                //// Warp da direita para a esquerda
                //if (position.X == 20 && position.Y == 9)
                //    position.X = -1;

                if (go.CanGo((int)position.X + 1, (int)position.Y))
                {
                    position.X++;
                    //Comer(board);

                }
            }
            else if (direction == Direction.Null) return;
        }

        public void HumanMove(float lastHumanMove)
        {
            LerTeclas();
            int movementSize = 1;

            if (lastHumanMove >= 1f / 100f)
            {
                if (GetDirectionByKeyState() == Direction.Null)
                {
                    AutoMove(direction);
                    return;
                }

                if (playerIndex == 1)
                {
                    // Baixo
                    if (keyboardState.IsKeyDown(Keys.Down) || gamepadState.IsButtonDown(Buttons.DPadDown))
                    {
                        if (go.CanGo((int)position.X, (int)position.Y + movementSize))
                        {
                            PacManAtual = 1;
                            direction = Direction.Down;
                            position.Y += movementSize;
                            //Comer(board);
                        }
                    }
                    // Cima
                    else if (keyboardState.IsKeyDown(Keys.Up) || gamepadState.IsButtonDown(Buttons.DPadUp))
                    {
                        if (go.CanGo((int)position.X, (int)position.Y - movementSize))
                        {
                            PacManAtual = 2;
                            direction = Direction.Up;
                            position.Y -= movementSize;
                            //Comer(board);
                        }
                    }
                    // Esquerda
                    else if (keyboardState.IsKeyDown(Keys.Left) || gamepadState.IsButtonDown(Buttons.DPadLeft))
                    {
                        //Vector2 vPosition = Auxiliares.Screen2Matrix(position);

                        //// Warp da esquerda para a direita
                        //if (vPosition.X == 0 && vPosition.Y == 9)
                        //    position.X = 21 * 30;
                        /*else*/ if (go.CanGo((int)position.X - movementSize, (int)position.Y))
                        {
                            PacManAtual = 3;
                            direction = Direction.Left;
                            position.X -= movementSize;
                            //Comer(board);
                        }
                    }
                    // Direita
                    else if (keyboardState.IsKeyDown(Keys.Right) || gamepadState.IsButtonDown(Buttons.DPadRight))
                    {
                        //Vector2 vPosition = Auxiliares.Screen2Matrix(position);

                        // Warp da direita para a esquerda
                        //if (vPosition.X == 20 && vPosition.Y == 9)
                        //    position.X = -3;
                        /*else */if (go.CanGo((int)position.X + movementSize, (int)position.Y))
                        {
                            PacManAtual = 0;
                            direction = Direction.Right;
                            position.X += movementSize;
                            //Comer(board);
                        }
                    }
                }
            }
        }
    }
}
