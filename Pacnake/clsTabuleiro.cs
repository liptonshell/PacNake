﻿using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;

namespace Pacnake
{
    public class clsTabuleiro
    {
        public byte[,] actualBoard;

        //bytes de cada tabuleiro
        public byte[,] Board1 = {
                         { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                         { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                         { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                         { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                         { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                         { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                         { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                         { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                         { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                         { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                         { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                         { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                         { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                         { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                         { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                         { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                         { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                         { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                         { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                         { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                         { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}};

        public byte[,] Board2 = {                         
                        { 0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0},
                        { 0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0},
                        { 0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0},
                        { 0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0},
                        { 0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0},
                        { 0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0},
                        { 0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0},
                        { 0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0},
                        { 0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0},
                        { 0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0},
                        { 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
                        { 0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0},
                        { 0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0},
                        { 0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0},
                        { 0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0},
                        { 0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0},
                        { 0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0},
                        { 0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0},
                        { 0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0},
                        { 0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0},
                        { 0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0}};

        public byte[,] Board3 = {                         
                        { 0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0},
                        { 0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0},
                        { 0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0},
                        { 0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0},
                        { 0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0},
                        { 0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0},
                        { 0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0},
                        { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                        { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                        { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                        { 1,1,1,1,1,1,1,0,0,0,0,0,0,0,1,1,1,1,1,1,1},
                        { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                        { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                        { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                        { 0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0},
                        { 0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0},
                        { 0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0},
                        { 0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0},
                        { 0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0},
                        { 0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0},
                        { 0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0}};

        //Tabuleiros com parede

        public byte[,] Board4 = {                         
                        { 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
                        { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
                        { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
                        { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
                        { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
                        { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
                        { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
                        { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
                        { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
                        { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
                        { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
                        { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
                        { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
                        { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
                        { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
                        { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
                        { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
                        { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
                        { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
                        { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
                        { 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1}};

        public byte[,] Board5 = {                         
                        { 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
                        { 1,0,0,0,0,0,0,0,1,1,1,1,1,0,0,0,0,0,0,0,1},
                        { 1,0,0,0,0,0,0,0,1,1,1,1,1,0,0,0,0,0,0,0,1},
                        { 1,0,0,0,0,0,0,0,1,1,1,1,1,0,0,0,0,0,0,0,1},
                        { 1,0,0,0,0,0,0,0,1,1,1,1,1,0,0,0,0,0,0,0,1},
                        { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
                        { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
                        { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
                        { 1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1},
                        { 1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1},
                        { 1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1},
                        { 1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1},
                        { 1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1},
                        { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
                        { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
                        { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
                        { 1,0,0,0,0,0,0,0,1,1,1,1,1,0,0,0,0,0,0,0,1},
                        { 1,0,0,0,0,0,0,0,1,1,1,1,1,0,0,0,0,0,0,0,1},
                        { 1,0,0,0,0,0,0,0,1,1,1,1,1,0,0,0,0,0,0,0,1},
                        { 1,0,0,0,0,0,0,0,1,1,1,1,1,0,0,0,0,0,0,0,1},
                        { 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1}};

        public byte[,] Board6 = {                         
                        { 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
                        { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
                        { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
                        { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
                        { 1,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,1},
                        { 1,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,1},
                        { 1,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,1},
                        { 1,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,1},
                        { 1,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,1},
                        { 1,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,1},
                        { 1,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,1},
                        { 1,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,1},
                        { 1,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,1},
                        { 1,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,1},
                        { 1,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,1},
                        { 1,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,1},
                        { 1,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,1},
                        { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
                        { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
                        { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
                        { 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1}};

        Texture2D wall;

        public clsTabuleiro(int board)
        {
            //associaçao de cada tabuleiro a uma variavel
            switch (board)
            {
                case 0:
                    actualBoard = Board1;
                    break;
                case 1:
                    actualBoard = Board2;
                    break;
                case 2:
                    actualBoard = Board3;
                    break;
                case 3:
                    actualBoard = Board4;
                    break;
                case 4:
                    actualBoard = Board5;
                    break;
                case 5:
                    actualBoard = Board6;
                    break;
            }
        }

        public void loadContent(ContentManager Content)
        {
            //load da textura do bloco da parede
            wall = Content.Load<Texture2D>("box");
        }

        //Desenho dos tabuleiros
        public void draw(SpriteBatch spriteBatch)
        {
            for (int x = 0; x < 21; x++)
            {
                for (int y = 0; y < 21; y++)
                {
                    if (actualBoard[y, x] == 1)
                    {
                        spriteBatch.Draw(wall, new Rectangle(x * 30, y * 30, 30, 30), Color.Orange);
                    }
                }
            }
        }
    }
}