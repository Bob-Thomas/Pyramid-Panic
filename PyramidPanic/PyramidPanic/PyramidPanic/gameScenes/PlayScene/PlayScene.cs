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
    public class PlayScene : IStateGame
    {
        //fields
        private PyramidPanic game;
        private Level level;
        private static int levelNumber;

        public static int LevelNumber
        {
            get { return levelNumber; }
            set { levelNumber = value; }
        }
        //constructor
        public PlayScene(PyramidPanic game)
        {
            this.game = game;
            this.initialize();
        }

        //initialize
        public void initialize()
        {
            this.Loadcontent();
        }
        //load content
        public void Loadcontent()
        {
            this.level = new Level(this.game, levelNumber);
        }

        //update
        public void update(GameTime gameTime)
        {
            if (Score.isDead())
            {
                this.level.LevelState = level.LevelGameOver;
            }
            if (ExplorerManager.WalkOutOfLevel())
            {
                level.LevelState = level.LevelNextLevel;
            }
            this.level.update(gameTime);
        }
        //draw
        public void draw(GameTime gameTime)
        {
            this.game.GraphicsDevice.Clear(Color.White);
            this.level.draw(gameTime);
        }
    }
}
