using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    internal class GameSnake : IGameSnake
    {
        GameController gameController;
        Settings settings;
        public GameSnake() 
        {
            
        }


        public void Start()
        {
            if (settings == null)
                settings = new Settings();
            gameController = new GameController(settings);
            gameController.Start();
        }

        public void Exit()
        {
            throw new NotImplementedException();
        }

        public void GameSettings()
        {
            throw new NotImplementedException();
        }
    }
}
