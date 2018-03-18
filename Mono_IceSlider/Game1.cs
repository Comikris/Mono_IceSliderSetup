using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace Mono_IceSlider
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Player player;
        Texture2D playerTexture;
        Texture2D wallTexture;
        Texture2D iceTexture;
        Texture2D iceSolidTexture;
        Texture2D waterTexture;
        Texture2D finishTexture;
        Vector2 playerPosition;
        List<Wall> TheWalls;
        List<Ice> TheIce;
        List<Water> TheWater;
        Finish TheFinish;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 480;
            graphics.PreferredBackBufferHeight = 270;
            Content.RootDirectory = "Content";
            
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            FileLoader fl = new FileLoader();
            TheWalls = new List<Wall>();
            TheIce = new List<Ice>();
            TheWater = new List<Water>();

            fl.LoadLevel("C:/Users/Kris/Documents/Visual Studio 2015/Mono_IceSlider/Mono_IceSlider/Levels/level_two.xml", this, TheWalls, TheIce);
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            Animation playerAnimation = new Animation();
            playerTexture = Content.Load<Texture2D>("Player_char");
            wallTexture = Content.Load<Texture2D>("Wall");
            waterTexture = Content.Load<Texture2D>("Water");
            iceTexture = Content.Load<Texture2D>("sprIceBlock");
            finishTexture = Content.Load<Texture2D>("Finish");
            playerAnimation.Initialize(playerTexture, Vector2.Zero, 16, 16, 0, 30, Color.White, 1f, true);
            player.Initialize(playerAnimation);

        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            player.Update(gameTime, this);
            UpdateIce();

            if ( TheWalls.Count == 0)
            {

            }
            base.Update(gameTime);
        }

        public void UpdateIce()
        {
            for (int i = TheIce.Count - 1; i >= 0; i--)
            {
                TheIce[i].Update(player);
                if (TheIce[i].Active == false)
                {
                    AddWater(TheIce[i].Position.X, TheIce[i].Position.Y);
                    TheIce.RemoveAt(i);
                }
            }
        }

        public void ResetLevel()
        {
            TheWalls = new List<Wall>();
            TheIce = new List<Ice>();
            TheWater = new List<Water>();
        }

        public void AddWater(float x, float y)
        {
            Water newWater = new Water(x, y);
            TheWater.Add(newWater);
        }

        public void AddExit(float x, float y)
        {
            TheFinish = new Finish(x, y);
        }

        public void AddPlayer(float x, float y)
        {
            player = new Player(x, y);
        }

        public bool IsPlayerCollideWithWall(int moveX, int moveY)
        {
            Rectangle PlayerMask = player.Mask;
            PlayerMask.X += moveX;
            PlayerMask.Y += moveY;

            foreach ( Wall aWall in TheWalls)
            {
                Rectangle WallMask = new Rectangle((int)aWall.Position.X, (int)aWall.Position.Y, 16, 16);
                if ( WallMask.Intersects(PlayerMask) )
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Gray);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            // player.Draw(spriteBatch);
            foreach(Wall wall in TheWalls)
            {
                spriteBatch.Draw(wallTexture, wall.Position, null, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
            }

            foreach (Ice ice in TheIce)
            {
                if ( ice.Active ) spriteBatch.Draw(iceTexture, ice.Position, null, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
            }

            foreach (Water water in TheWater)
            {
                if (water.Active) spriteBatch.Draw(waterTexture, water.Position, null, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
            }

            spriteBatch.Draw(finishTexture, TheFinish.Position, null, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
            spriteBatch.Draw(playerTexture, player.Position, null, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
