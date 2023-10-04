using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    internal class Food
    {
        public Position pos { get; set; }
        public char GetSymbol { get { return '*'; } }

        public Food(int FieldHeight, int FieldWidth) 
        {
            pos = new Position(x: new Random().Next(1,FieldWidth-1), y: new Random().Next(1, FieldHeight-1));
        }
    }
}
