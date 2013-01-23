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
    public class LevelPlay : ILevel
    {
        private Level level;

        public LevelPlay(Level level)
        {
            this.level = level;
        }
        public void Update(GameTime gameTime)
        {
            if (Input.DetectKeydown(Keys.Escape))
            {
                this.level.LevelState = this.level.LevelPaused;
            }
            foreach (Scorpion scorpion in this.level.ScorpionList)
            {
                scorpion.Update(gameTime);
            }
            foreach (Beetle beetle in this.level.BeetleList)
            {
                beetle.Update(gameTime);
            }
            if (this.level.Explorer != null)
            {
                this.level.Explorer.Update(gameTime);
            }
            /*MovingBlockManager.Explorer = this.level.Explorer;
            foreach (MovingBlock block in this.level.MovingBlocks)
            {
                block.Update(gameTime, this.level.Explorer);
            }*/
        }

        public void Draw(GameTime gameTime)
        {
        }
    }
}
