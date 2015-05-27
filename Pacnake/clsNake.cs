using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using System.Collections;

namespace Pacnake
{
    public class clsNake
    {
        //GraphicsDeviceManager graphics;

        SpriteFont Font;
        Texture2D Nake1, Tail1, Food, bg, wall, actualNake;
        Texture2D Nake2, Tail2, Nake3, Tail3, actualTail;

        string direction;

        //elementos corpo da cobra
        ArrayList elementY = new ArrayList();
        ArrayList elementX = new ArrayList();

        //elementos Comida
        ArrayList foodY = new ArrayList();
        ArrayList foodX = new ArrayList();

        int updates = 0;
        int speed = 10;//velocidade
        int pontos = 0;

        bool lost = false;

        clsTabuleiro tab;

        Random d;

        int textHead, textTail;

        public clsNake()
        {
            //adiçao e podiçao inicial cada parte da cobra
            elementX.Add(2);
            elementY.Add(2);
            elementX.Add(3);
            elementY.Add(2);

            tab = new clsTabuleiro(/*numero do mapa -1*/ 1);

            //gera comida inicial
            d = new Random();
            getPosition();

            textHead = 1;
            textTail = 1;
        }



        public void loadContent(ContentManager Content)
        {
            //load das texturas
            Nake1 = Content.Load<Texture2D>("Tail1");
            Tail1 = Content.Load<Texture2D>("Tail2");

            Nake2 = Content.Load<Texture2D>("Tail3");
            Tail2 = Content.Load<Texture2D>("Tail4");

            Nake3 = Content.Load<Texture2D>("Tail5");
            Tail3 = Content.Load<Texture2D>("Tail6");

            Change();

            Food = Content.Load<Texture2D>("pera");
            bg = Content.Load<Texture2D>("menu");
            Font = Content.Load<SpriteFont>("MyFont");
            wall = Content.Load<Texture2D>("box");
            tab.loadContent(Content);
        }

        public void update()
        {

            if (lost == false)
            {

                int i = 1;
                while (i < elementX.Count)
                {
                    //caso morda uma das partes do corpo
                    if (elementX[i].ToString() == elementX[0].ToString() && elementY[i].ToString() == elementY[0].ToString())
                    {
                        lost = true;
                    }
                    i++;
                }

                KeyboardState ks = Keyboard.GetState();
                //direcçoes
                if (ks.IsKeyDown(Keys.Left))
                {
                    if (direction != "r") direction = "l";
                }
                if (ks.IsKeyDown(Keys.Right))
                {
                    if (direction != "l") direction = "r";
                }
                if (ks.IsKeyDown(Keys.Up))
                {
                    if (direction != "d") direction = "u";
                }
                if (ks.IsKeyDown(Keys.Down))
                {
                    if (direction != "u") direction = "d";
                }
                //mudança textura ingame
                if (ks.IsKeyDown(Keys.D1))
                {
                    textHead = 1;
                }
                if (ks.IsKeyDown(Keys.D2))
                {
                    textHead = 2;
                }
                if (ks.IsKeyDown(Keys.D3))
                {
                    textHead = 3;
                }
                if (ks.IsKeyDown(Keys.D4))
                {
                    textTail = 1;
                }
                if (ks.IsKeyDown(Keys.D5))
                {
                    textTail = 2;
                }
                if (ks.IsKeyDown(Keys.D6))
                {
                    textTail = 3;
                }
                Change();
                //movimento
                if (updates == speed)
                {
                    if (direction == "d")
                    {
                        elementX.Insert(0, elementX[0]);
                        elementX.RemoveAt(elementX.Count - 1);

                        elementY.Insert(0, Convert.ToInt16(elementY[0]) + 1);
                        elementY.RemoveAt(elementY.Count - 1);
                    }
                    if (direction == "u")
                    {
                        elementX.Insert(0, elementX[0]);
                        elementX.RemoveAt(elementX.Count - 1);

                        elementY.Insert(0, Convert.ToInt16(elementY[0]) - 1);
                        elementY.RemoveAt(elementY.Count - 1);
                    }
                    if (direction == "l")
                    {
                        elementX.Insert(0, Convert.ToInt16(elementX[0]) - 1);
                        elementX.RemoveAt(elementX.Count - 1);

                        elementY.Insert(0, elementY[0]);
                        elementY.RemoveAt(elementY.Count - 1);
                    }

                    if (direction == "r")
                    {
                        elementX.Insert(0, Convert.ToInt16(elementX[0]) + 1);
                        elementX.RemoveAt(elementX.Count - 1);

                        elementY.Insert(0, elementY[0]);
                        elementY.RemoveAt(elementY.Count - 1);
                    }
                    //Colision();
                    if (Colision())
                    {
                        lost = true;
                    }
                    updates = 0;
                }
                else
                {
                    updates++;
                }


                i = 0;
                while (i < foodX.Count)
                {
                    if (foodX[i].ToString() == elementX[0].ToString() && foodY[i].ToString() == elementY[0].ToString())
                    {
                        //remoçao comida
                        foodX.RemoveAt(i);
                        foodY.RemoveAt(i);

                        //Adiçao parte na cobra
                        elementX.Add(-1);
                        elementY.Add(-1);

                        //adiçao pontos
                        pontos += 10;

                        //coloçaos comida seguinte
                        getPosition();
                    }
                    i++;
                }

                //warp (aparecer no outro lado da tela)
                if (Convert.ToInt16(elementX[0]) < 0) { elementX[0] = 600 / 30; }
                if (Convert.ToInt16(elementX[0]) > 600 / 30) { elementX[0] = 0; }
                if (Convert.ToInt16(elementY[0]) < 0) { elementY[0] = 600 / 30; }
                if (Convert.ToInt16(elementY[0]) > 600 / 30) { elementY[0] = 0; }
            }
            else
            {

            }
        }

        //funçao para mudança de texturas
        public void Change()
        {
            switch (textHead)
            {
                case 1:
                    actualNake = Nake1;
                    //actualTail = Tail1;
                    break;
                case 2:
                    actualNake = Nake2;
                    //actualTail = Tail2;
                    break;
                case 3:
                    actualNake = Nake3;
                    //actualTail = Tail3;
                    break;
            }

            switch (textTail)
            {
                case 1:
                    //actualNake = Nake1;
                    actualTail = Tail1;
                    break;
                case 2:
                    //actualNake = Nake2;
                    actualTail = Tail2;
                    break;
                case 3:
                    //actualNake = Nake3;
                    actualTail = Tail3;
                    break;

            }
        }

        public void draw(SpriteBatch spriteBatch)
        {
            //desenho BackGround
            spriteBatch.Draw(bg, new Rectangle(0, 0, 630, 630), Color.White);

            tab.draw(spriteBatch);

            int i = 0;
            while (i < elementX.Count)
            {
                //desenho Corpo
                spriteBatch.Draw(actualTail, new Rectangle((Convert.ToInt16(elementX[i])) * 30, Convert.ToInt16(elementY[i]) * 30, 30, 30), Color.White);
                i++;
            }
            //desenho cabeça
            spriteBatch.Draw(actualNake, new Rectangle(Convert.ToInt16(elementX[0]) * 30, Convert.ToInt16(elementY[0]) * 30, 30, 30), Color.White);

            i = 0;
            while (i < foodX.Count)
            {
                //desenho comida
                spriteBatch.Draw(Food, new Rectangle(Convert.ToInt16(foodX[i]) * 30, Convert.ToInt16(foodY[i]) * 30, 30, 30), Color.White);
                i++;
            }

            if (lost)
            {
                spriteBatch.DrawString(Font, "PERDEU.\nConseguiu: " + pontos.ToString() + " pontos", new Vector2(50, 630 / 2), Color.White);
            }

            spriteBatch.DrawString(Font, "Pontos: " + pontos.ToString(), new Vector2(10, 10), Color.White);
        }

        public void getPosition()
        {
            int x = d.Next(0, 630 / 30);
            int y = d.Next(0, 630 / 30);
            if (tab.actualBoard[x, y] != 1)
            {
                foodX.Add(x);
                foodY.Add(y);
            }
            else getPosition();
        }
        public bool Colision()
        {
            int x = Convert.ToInt16(elementX[0]);
            int y = Convert.ToInt16(elementY[0]);

            Console.WriteLine("x=" + x + "y=" + y);

            if (x >= 0 && y >= 0)
            {
                if (x <= 600 / 30 && y <= 600 / 30)
                {
                    if (tab.actualBoard[x, y] == 1)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}