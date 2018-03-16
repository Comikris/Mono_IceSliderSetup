using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mono_IceSlider
{
    interface ILevel
    {
        Player GetPlayer();
        List<Wall> GetWalls();
        List<GenericIce> GetIce();
        Finish GetFinish();

        void SetPlayer(Player aPlayer);
        void SetWalls(Wall aWall);
        void SetFinish(Finish aFinish);
        void SetIce(GenericIce aIce);
    }
}
