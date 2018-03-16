using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mono_IceSlider
{
    class Level : ILevel
    {
        private List<Wall> MyWalls;
        private List<GenericIce> MyIce;
        private Player MyPlayer;
        private Finish MyFinish;
        public int ID;
        public string Name;

        public Level(int id, string name)
        {
            ID = id;
            Name = name;
        }

        public Player GetPlayer()
        {
            return MyPlayer;
        }

        public List<Wall> GetWalls()
        {
            return MyWalls;
        }

        public List<GenericIce> GetIce()
        {
            return MyIce;
        }

        public Finish GetFinish()
        {
            return MyFinish;
        }

        public void SetPlayer(Player aPlayer)
        {
            MyPlayer = aPlayer;
        }

        public void SetWalls(Wall aWall)
        {
            MyWalls.Add(aWall);
        }

        public void SetFinish(Finish aFinish)
        {
            MyFinish = aFinish;
        }

        public void SetIce(GenericIce aIce)
        {
            MyIce.Add(aIce);
        }
    }
}
