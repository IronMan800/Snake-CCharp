using System;
using System.Collections.Generic;

namespace Snake
{
    internal class Window
    {
        int fieldHeight;
        int fieldWidth;
        int score;
        public Window(int fieldHeight, int fieldWidth)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.SetWindowSize(135, 55);
            Console.Title = "Game Snake";
            this.fieldHeight = fieldHeight;
            this.fieldWidth = fieldWidth;
        }

        public void Draw(char[,] playingField, Snake snake, int Score, List<Food> foodList)
        {
            score = Score;
            Console.Clear();
            SettingBoundaries(playingField);
            foreach(Food food in foodList) 
            {
                playingField[food.pos.Y, food.pos.X] = food.GetSymbol;
            }

            foreach (SnakeBody body in snake.body)
            {
                playingField[body.pos.Y, body.pos.X] = body.GetBodySymbol;
            }


            for (int i = 0; i < fieldHeight; i++)
            {
                for (int j = 0; j < fieldWidth; j++)
                {
                    Console.Write(playingField[i, j]);
                }
                Console.WriteLine();
            }

            Console.SetCursorPosition(fieldWidth, 0);
            Console.Write("Score: " + Score);

        }

        void SettingBoundaries(char[,] playingField)
        {
            /*  ┏ ━ ┓
               
                ┃   ┃

                ┗ ━ ┛
            */
            for (int i = 0; i < fieldWidth; i++)
            {
                if (i == 0)
                    playingField[0, i] = '┏';
                else if (i == fieldWidth - 1)
                    playingField[0, i] = '┓';
                else
                    playingField[0, i] = '━';
            }

            for (int i = 1; i < fieldHeight; i++)
            {
                for (int j = 0; j < fieldWidth; j++)
                {
                    if (j == 0 || j == fieldWidth - 1)
                        playingField[i, j] = '┃';
                    else
                        playingField[i, j] = ' ';
                }
            }

            for (int i = 0; i < fieldHeight; i++)
            {
                if (i == 0)
                    playingField[fieldHeight - 1, i] = '┗';
                else if (i == fieldHeight - 1)
                    playingField[fieldHeight - 1, i] = '┛';
                else
                    playingField[fieldHeight - 1, i] = '━';
            }
        }
    }
}
