using System;
using System.Collections.Generic;
using System.Threading;

namespace Snake
{
    //закончить
    public delegate void GameOver(string ReasonForLosing);
    public delegate void AddAPoint(object food);
    struct Position
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }
    }

    internal class GameController
    {

        
        private bool gameOver = false;
        protected static char[,] playingField;
        List<Food> foodList = new List<Food>();
        Settings settings;
        Snake snake;
        Window window;
        public int Score 
        {
            get { return score; }
            private set { if (value >= 0) score = value; else score = 0; } 
        }
        int score = 0;


        public GameController(Settings settings)
        {
            GameController.playingField = new char[settings.FieldHeight, settings.FieldWidth];
            window = new Window(settings.FieldHeight, settings.FieldWidth);
            snake = new Snake(settings);
            snake.body[0].EventGoingAbroad += GameOver;
            snake.body[0].EventAteFood += AddAPoint;
            this.settings = settings;

            for (int i = 0; i < 4; i++)
            {
                foodList.Add(new Food(settings.FieldHeight, settings.FieldWidth));
            }
        }

        public void Start()
        {
            bool start = true;
            
            //запуск цикличной логики игры
            // проверка на столкновения, сьедения и тд
            while (start && gameOver == false)
            {
                if (foodList.Count < 4)
                    AddFood();
                snake.Move(foodList);
                window.Draw(playingField, snake, Score, foodList);
                Thread.Sleep(settings.GameSpeed);
                if (Console.KeyAvailable)
                {
                    switch (Console.ReadKey(true).Key)
                    {
                        case ConsoleKey.UpArrow:
                            snake.RotateMove(Vector.Up);
                            break;
                        case ConsoleKey.DownArrow:
                            snake.RotateMove(Vector.Down);
                            break;
                        case ConsoleKey.LeftArrow:
                            snake.RotateMove(Vector.Left);
                            break;
                        case ConsoleKey.RightArrow:
                            snake.RotateMove(Vector.Right);
                            break;


                        case ConsoleKey.Escape:
                            start = false;
                            break;

                        default:
                            break;
                    }
                }
            }
        }

        public void GameOver(string ReasonForLosing)
        {
            gameOver = true;
            Console.Clear();
            Console.WriteLine(ReasonForLosing);
            Thread.Sleep(4000);
        }

        public void AddAPoint(object objectFood)
        {
            Food food = (Food)objectFood;
            foodList.Remove(food);
            Score += 1;
        }

        public void AddFood()
        {
            foodList.Add(new Food(settings.FieldHeight, settings.FieldWidth));
        }
    }
}
