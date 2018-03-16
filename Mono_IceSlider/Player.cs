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
    class Player
    {
        public Animation MyAnimation;
        public Vector2 Position;
        KeyboardState currentKeyboardState;
        Rectangle Mask;
        float TargetPositionX;
        float TargetPositionY;
        float TileRange = 16;
        float MoveSpeed = 2;
        bool Moving;
        public bool Active;
        public int Width
        {
            get { return MyAnimation.FrameWidth; }
        }

        public int Height
        {
            get { return MyAnimation.FrameHeight; }
        }

        public void Initialize(Animation aAnimation, Vector2 aPosition)
        {
            MyAnimation = aAnimation;
            Position = aPosition;
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

            currentKeyboardState = Keyboard.GetState();
            if ( !Moving )
            {
                Idle();
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

        public void Idle()
        {
            if (currentKeyboardState.IsKeyDown(Keys.Right))
            {
                TargetPositionX = Position.X + TileRange;
                Moving = true;
            }

            else if (currentKeyboardState.IsKeyDown(Keys.Left))
            {
                TargetPositionX = Position.X - TileRange;
                Moving = true;
            }

            else if (currentKeyboardState.IsKeyDown(Keys.Up))
            {
                TargetPositionY = Position.Y - TileRange;
                Moving = true;
            }

            else if (currentKeyboardState.IsKeyDown(Keys.Down))
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
