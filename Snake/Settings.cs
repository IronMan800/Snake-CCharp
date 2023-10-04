using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    internal class Settings
    {
        public int NumberSkinSnake { get; set; }
        public int FieldHeight { get; set; }
        public int FieldWidth { get; set; }
        int gameSpeed;
        public int GameSpeed
        {
            get
            {
                if (gameSpeed == 5)
                    return 100;
                else if (gameSpeed == 4)
                    return 400;
                else if (gameSpeed == 3)
                    return 600;
                else if (gameSpeed == 2)
                    return 800;
                else
                    return 1000;
            }
            set
            {
                
                if (value < 5 && value > 0)
                    gameSpeed = value;
                else
                    gameSpeed = 2;

            }
        }
        public Settings()
        {
            FieldHeight = 50;
            FieldWidth = 50;
            GameSpeed = 2;
            NumberSkinSnake = 3;
        }
        public Settings(int FieldHeight, int FieldWidth, int GameSpeed, int NumberSkinSnake)
        {
            this.FieldHeight = FieldHeight;
            this.FieldWidth = FieldWidth;
            this.GameSpeed = GameSpeed;
            this.NumberSkinSnake = NumberSkinSnake;
        }

        public char[] ReturnSkinSnake()
        {
            switch(NumberSkinSnake)
            {
                case 1:
                    return new char[] { '᛭', 'ᛜ' };
                case 2:
                    return new char[] { '☻', '☼' };
                default:
                    return new char[] { '@', 'o' };
            }
        }
    }
}
