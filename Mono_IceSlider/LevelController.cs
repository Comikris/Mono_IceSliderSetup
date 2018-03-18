using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mono_IceSlider
{
    class LevelController : ILevelController
    {
        public FileLoader MyFileLoader;
        public List<Level> Levels;
        public Game1 Game;
        public Level ActiveLevel;

        public void Initialize()
        {
            MyFileLoader = new FileLoader();
        }

        public void AddNewLevel(string filepath)
        {
            // MyFileLoader.LoadLevel(filepath, Game)
        }

        public void ExecuteLevel()
        {

        }

        public void RemoveActiveLevel()
        {
            throw new NotImplementedException();
        }

        public void SetActiveLevel(int id)
        {
            ActiveLevel = Levels[id];
        }
    }
}
