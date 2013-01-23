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
    public class LevelPaused : ILevel
    {
        private Level level;
        private Image overlay;

      
        public LevelPaused(Level level)
        {
            this.level = level;
            this.overlay = new Image(this.level.Game, new Vector2(0,0), @"PlaySceneAssets/overlay/pauseOverlay");
        }
        public void Update(GameTime gameTime)
        {
            if (Input.EdgeDetectKeyDown(Keys.Enter))
            {
                this.level.LevelState = this.level.levelplay;
            }
            if (Input.EdgeDetectKeyDown(Keys.Escape))
            {
                this.level.Game.GameState = new StartScene(this.level.Game);
            }
        }

        public void Draw(GameTime gameTime)
        {
            this.overlay.Draw(gameTime);
        }
    }
}
