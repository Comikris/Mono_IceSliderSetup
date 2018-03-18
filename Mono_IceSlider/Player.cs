using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mono_IceSlider
{
    class Player : Entity
    {
        public Animation MyAnimation;
        KeyboardState currentKeyboardState;
        float TargetPositionX;
        float TargetPositionY;
        float TileRange = 16;
        float MoveSpeed = 2;
        bool Moving;
        public bool Active;

        public Player(float x, float y) : base(x, y)
        {
            // Creating the position
        }

        public int Width
        {
            get { return MyAnimation.FrameWidth; }
        }

        public int Height
        {
            get { return MyAnimation.FrameHeight; }
        }

        public void Initialize(Animation aAnimation)
        {
            MyAnimation = aAnimation;
            Moving = false;
            TargetPositionX = Position.X;
            TargetPositionY = Position.Y;
            Active = true;
            Mask = new Rectangle(0, 0, 16, 16);
        }

        public void Update(GameTime gameTime, Game1 game)
        {
            MyAnimation.Position = Position;
            MyAnimation.Update(gameTime);
            Mask = new Rectangle((int)Position.X, (int)Position.Y, 16, 16);
            currentKeyboardState = Keyboard.GetState();
            if ( !Moving )
            {
                Idle(game);
            }
            else
            {
                MoveTo();
            }
        }

        public void MoveTo()
        {
            if ( Position.X != TargetPositionX)
            {
                if ( TargetPositionX < Position.X )
                {
                    Position.X -= MoveSpeed;
                }

                if (TargetPositionX > Position.X)
                {
                    Position.X += MoveSpeed;
                }
            }

            else if (Position.Y != TargetPositionY)
            {
                if (TargetPositionY < Position.Y)
                {
                    Position.Y -= MoveSpeed;
                }

                if (TargetPositionY > Position.Y)
                {
                    Position.Y += MoveSpeed;
                }
            }

            else
            {
                Moving = false;
            }
        }

        public void Idle(Game1 game)
        {
            if (currentKeyboardState.IsKeyDown(Keys.Right) && !game.IsPlayerCollideWithWall(16, 0))
            {
                TargetPositionX = Position.X + TileRange;
                Moving = true;
            }

            else if (currentKeyboardState.IsKeyDown(Keys.Left) && !game.IsPlayerCollideWithWall(-16, 0))
            {
                TargetPositionX = Position.X - TileRange;
                Moving = true;
            }

            else if (currentKeyboardState.IsKeyDown(Keys.Up) && !game.IsPlayerCollideWithWall(0, -16))
            {
                TargetPositionY = Position.Y - TileRange;
                Moving = true;
            }

            else if (currentKeyboardState.IsKeyDown(Keys.Down) && !game.IsPlayerCollideWithWall(0, 16))
            {
                TargetPositionY = Position.Y + TileRange;
                Moving = true;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            MyAnimation.Draw(spriteBatch);
        }
    }
}
