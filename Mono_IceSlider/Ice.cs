using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mono_IceSlider
{
    class Ice : Entity
    {
        public string State;
        public Ice(float x, float y) : base(x, y)
        {
            State = "Idle";
        }

        public void Update(Player player)
        {
            Rectangle PlayerMask = player.Mask;
            if ( State == "Idle")
            {
                if ( PlayerMask.Intersects(Mask) )
                {
                    State = "Breaking";
                }
            }

            if ( State == "Breaking")
            {
                if (!PlayerMask.Intersects(Mask))
                {
                    Active = false;
                }
            }
        }
    }
}
