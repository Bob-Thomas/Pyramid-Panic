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
    public class LevelVictory : ILevel
    {
        private Level level;
        private Image overlay,backGround;
        private int pauseTime = 1;
        private float timer = 0;
        private Rectangle rectangle;
        private int index = -1;
        private string removeType;

        public string RemoveType
        {
            get { return this.removeType; }
            set { this.removeType = value; }
        }

        public int Index
        {
            set { this.index = value; }
        }

        public LevelVictory(Level level)
        {
            this.level = level;
            backGround = new Image(this.level.Game,Vector2.Zero , @"PlaySceneAssets/background/Background2");
            this.overlay = new Image(this.level.Game, new Vector2(120f, 100f) , @"PlaySceneAssets/overlay/Congratulation");
            rectangle = new Rectangle((int)overlay.Rectangle.X + 290, (int)overlay.Rectangle.Y + 243, overlay.Rectangle.Width / 10, overlay.Rectangle.Height / 15);
        }
        public void Update(GameTime gameTime)
        {
            this.timer += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (Input.DetectKeydown(Keys.Enter))
            {
                Score.Lives = 3;
                Score.Points = 0;
                level.Game.GameState = new StartScene(this.level.Game);

            }
        }

        public void Draw(GameTime gameTime)
        {
            this.level.Game.GraphicsDevice.Clear(Color.Red);
            this.backGround.Draw(gameTime);
            this.overlay.Draw(gameTime);
        }
    }
}
