using System.Collections.Generic;
using System.Linq;

namespace Snake
{
    public enum Vector { Up, Down, Left, Right }

    internal class Snake : ISnake
    {
        public Vector VectorMove { get; set; } = Vector.Up;
        public List<SnakeBody> body { get; set; } = new List<SnakeBody>();

        public Snake(Settings settings)
        {
            for (int i = 0; i < 6; i++)
            {
                if (i == 0)
                    body.Add(new SnakeBody(true, new Position(25, 25), VectorMove, settings));
                else
                    body.Add(new SnakeBody(false, new Position(25, 25 + i), settings));
            }
        }

        public void Move(List<Food> listFood)
        {
            
            for (int i = body.Count - 1; i > 0; i--)
            {
                body[i].pos = body[i - 1].pos;
                body[i].VectorMove = body[i-1].VectorMove;
            }
            body[0].NextPosition(VectorMove, listFood);
            /*
            for (int i = 0; i < body.Count(); i++)
            {
                if (body[i].ItHead)
                    body[i].NextPosition(VectorMove);
                else
                    body[i].pos = body[i - 1].pos;
                    
            }
            */
        }

        public void RotateMove(Vector vector)
        {

            switch (vector)
            {
                case Vector.Up:
                    if (VectorMove != Vector.Down)
                        VectorMove = vector;
                    else
                        break;
                    break;
                case Vector.Down:
                    if (VectorMove != Vector.Up)
                        VectorMove = vector;
                    else
                        break;
                    break;
                case Vector.Left:
                    if (VectorMove != Vector.Right)
                        VectorMove = vector;
                    else
                        break;
                    break;
                case Vector.Right:
                    if (VectorMove != Vector.Left)
                        VectorMove = vector;
                    else
                        break;
                    break;
            }
        }

        public void AddBody(Settings settings)
        {
            SnakeBody lastBody = body.Last();
            if (lastBody.VectorMove == Vector.Up)
                body.Add(new SnakeBody(false, new Position(lastBody.pos.X - 1, lastBody.pos.Y), settings));
            if (lastBody.VectorMove == Vector.Down)
                body.Add(new SnakeBody(false, new Position(lastBody.pos.X + 1, lastBody.pos.Y), settings));
            if (lastBody.VectorMove == Vector.Left)
                body.Add(new SnakeBody(false, new Position(lastBody.pos.X, lastBody.pos.Y - 1), settings));
            if (lastBody.VectorMove == Vector.Right)
                body.Add(new SnakeBody(false, new Position(lastBody.pos.X, lastBody.pos.Y + 1), settings));



        }
    }
}
