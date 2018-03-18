using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mono_IceSlider
{
    abstract class Entity
    {
        public Vector2 Position;
        public Texture2D Sprite;
        public Rectangle Mask;
        public bool Active;

        public Entity(float x, float y)
        {
            Position = new Vector2(x, y);
            Mask = new Rectangle((int)Position.X, (int)Position.Y, 16, 16);
            Active = true;
        }
    }
}
