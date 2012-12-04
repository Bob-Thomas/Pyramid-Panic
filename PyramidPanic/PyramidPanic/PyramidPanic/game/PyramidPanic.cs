using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace PyramidPanic
{
    public class PyramidPanic : Microsoft.Xna.Framework.Game
    {
        //fields
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private IStateGame gameState;

        public IStateGame GameState
        {
            get { return this.gameState; }
            set { this.gameState = value; }
        }
        public SpriteBatch SpriteBatch
        {
            get { return this.spriteBatch;  }

        }
        public PyramidPanic()
        {
            this.graphics = new GraphicsDeviceManager(this);
            this.Content.RootDirectory = "Content";
            this.IsFixedTimeStep = true;
            TargetElapsedTime = TimeSpan.FromSeconds(1.0f / 60.0f);
     
        }


        protected override void Initialize()
        {
            this.IsMouseVisible = true;
            this.Window.Title = "Pyramid Panic";
            this.graphics.PreferredBackBufferWidth = 640;
            this.graphics.PreferredBackBufferHeight = 480;
            this.graphics.ApplyChanges();          
            base.Initialize();
        }

        protected override void LoadContent()
        {

            this.spriteBatch = new SpriteBatch(GraphicsDevice);
            this.gameState = new StartScene(this);

        }
        protected override void UnloadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            gameState.update(gameTime);
            Input.update();
            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Goldenrod);
            this.spriteBatch.Begin();
            this.gameState.draw(gameTime);
            this.spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
