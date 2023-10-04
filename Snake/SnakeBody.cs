using System.Collections.Generic;

namespace Snake
{

    

    internal class SnakeBody
    {
        public event GameOver EventGoingAbroad;
        public event AddAPoint EventAteFood;
        public bool ItHead { get; set; } = false;
        public char GetBodySymbol
        {
            get
            {
                if (ItHead)
                    return settings.ReturnSkinSnake()[0];
                else
                    return settings.ReturnSkinSnake()[1];
            }
        }
        public Position pos { get; set; }
        public Vector? VectorMove { get; set; }
        Settings settings;

        public SnakeBody(bool itHead, Position pos, Vector VectorMove, Settings settings)
        {
            ItHead = itHead;
            this.pos = pos;
            this.VectorMove = VectorMove;
            this.settings = settings;
        }
        public SnakeBody(bool itHead, Position pos, Settings settings)
        {
            ItHead = itHead;
            this.pos = pos;
            this.VectorMove = null;
            this.settings = settings;
        }

        public void NextPosition(Vector vector, List<Food> listFood)
        {

            switch (vector)
            {
                case Vector.Up:
                    if (pos.Y - 1 == 0)
                    {
                        EventGoingAbroad("Выход за границу карты");
                        break;
                    }
                    pos = new Position(pos.X, pos.Y - 1);
                    foreach (Food food in listFood)
                    {
                        if (food.pos.X == pos.X && food.pos.Y == pos.Y)
                        {
                            EventAteFood(food);
                            break;
                        }
                    }
                    break;
                case Vector.Down:
                    if (pos.Y + 1 == settings.FieldHeight - 1)
                    {
                        EventGoingAbroad("Выход за границу карты");
                        break;
                    }
                    pos = new Position(pos.X, pos.Y + 1);
                    foreach (Food food in listFood)
                    {
                        if (food.pos.X == pos.X && food.pos.Y == pos.Y)
                        {
                            EventAteFood(food);
                            break;
                        }
                    }
                    break;
                case Vector.Left:
                    if (pos.X - 1 == 0)
                    {
                        EventGoingAbroad("Выход за границу карты");
                        break;
                    }
                    pos = new Position(pos.X - 1, pos.Y);
                    foreach (Food food in listFood)
                    {
                        if (food.pos.X == pos.X && food.pos.Y == pos.Y)
                        {
                            EventAteFood(food);
                            break;
                        }       
                    }
                    break;
                case Vector.Right:
                    if (pos.X + 1 == settings.FieldWidth - 1)
                    {
                        EventGoingAbroad("Выход за границу карты");
                        break;
                    }
                    pos = new Position(pos.X + 1, pos.Y);
                    foreach (Food food in listFood)
                    {
                        if (food.pos.X == pos.X && food.pos.Y == pos.Y)
                        {
                            EventAteFood(food);
                            break;
                        }
                    }
                    break;
            }

        }
    }
}
