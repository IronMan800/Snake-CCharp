using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    internal interface ISnake
    {
        public Vector VectorMove { get; set; }

        public void Move(List<Food> listFood);
        public void RotateMove(Vector vector);
        public void AddBody(Settings settings);
    }
}
