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
        Texture2D Nake1, Tail1, Food, bg,wall;
        string direction;

        //elementos corpo da cobra
        ArrayList elementY = new ArrayList();
        ArrayList elementX = new ArrayList();

        //elementos Comida
        ArrayList foodY = new ArrayList();
        ArrayList foodX = new ArrayList();

        int updates = 0;
        int speed = 7;//velocidade
        int pontos = 0;

        bool lost = false;

        clsTabuleiro tab;

        public clsNake()
        {
            //adiçao e podiçao inicial cada parte da cobra
            elementX.Add(2);
            elementY.Add(2);

            elementX.Add(3);
            elementY.Add(2);

            //gera comida inicial
            Random d = new Random();
            foodX.Add(d.Next(0, 630 / 30));
            foodY.Add(d.Next(0, 630 / 30));

            tab = new clsTabuleiro();
            
        }

        public void inicialize()
        {
            tab = new clsTabuleiro();
        }

        public void loadContent(ContentManager Content)
        {
            //load das texturas
            Nake1 = Content.Load<Texture2D>("Tail3");
            Tail1 = Content.Load<Texture2D>("Tail4");
            Food = Content.Load<Texture2D>("pera");
            bg = Content.Load<Texture2D>("menu");
            Font = Content.Load<SpriteFont>("MyFont");
            wall = Content.Load<Texture2D>("box");
            tab.loadContent(Content);
        }

        public void update()
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

            if (lost == false)
            {
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
                        Random d = new Random();
                        foodX.Add(d.Next(0, 630 / 30));
                        foodY.Add(d.Next(0, 630 / 30));
                    }
                    i++;
                }

                //warp (aparecer no outro lado da tela)
                if (Convert.ToInt16(elementX[0]) < 0) { elementX[0] = 630 / 30; }
                if (Convert.ToInt16(elementX[0]) > 630 / 30) { elementX[0] = 0; }
                if (Convert.ToInt16(elementY[0]) < 0) { elementY[0] = 630 / 30; }
                if (Convert.ToInt16(elementY[0]) > 630 / 30) { elementY[0] = 0; }
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
                spriteBatch.Draw(Tail1, new Rectangle(Convert.ToInt16(elementX[i]) * 30, Convert.ToInt16(elementY[i]) * 30, 30, 30), Color.White);
                i++;
            }
            //desenho cabeça
            spriteBatch.Draw(Nake1, new Rectangle(Convert.ToInt16(elementX[0]) * 30, Convert.ToInt16(elementY[0]) * 30, 30, 30), Color.White);

            i = 0;
            while (i < foodX.Count)
            {
                //desenho comida
                spriteBatch.Draw(Food, new Rectangle(Convert.ToInt16(foodX[i]) * 30, Convert.ToInt16(foodY[i]) * 30, 30, 30), Color.White);
                i++;
            }

            if (lost)
            {
                spriteBatch.DrawString(Font, "PERDEU.", new Vector2(50, 750 / 2), Color.White);
            }

            spriteBatch.DrawString(Font, "Pontos: " + pontos.ToString(), new Vector2(10, 10), Color.White);
        }
    }
}