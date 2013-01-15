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
    public class LevelGameOver : ILevel
    {
        private Level level;
        private Image overlay;
        private int pauseTime = 1;
        private float timer = 0;
        private Texture2D text;
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

        public LevelGameOver(Level level)
        {
            this.level = level;
            this.text = this.level.Game.Content.Load<Texture2D>(@"PlaySceneAssets/Player/blokje");
            this.overlay = new Image(this.level.Game, new Vector2(0,0), @"PlaySceneAssets/overlay/GameOver");
            rectangle = new Rectangle((int)overlay.Rectangle.X + 290, (int)overlay.Rectangle.Y + 243, overlay.Rectangle.Width / 10, overlay.Rectangle.Height / 15);
        }
        public void Update(GameTime gameTime)
        {
            this.timer += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (Input.MouseRectangle().Intersects(rectangle)&&Input.MouseEdgeDetectPressLeft())
            {
                PlayScene.LevelNumber = 0;
                level.Game.GameState = new StartScene(this.level.Game);

                
            }
        }

        public void Draw(GameTime gameTime)
        {

            this.overlay.Draw(gameTime);
        }
    }
}
