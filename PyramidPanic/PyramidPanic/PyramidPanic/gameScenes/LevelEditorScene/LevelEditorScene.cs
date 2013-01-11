using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Storage;

namespace PyramidPanic
{
    public class LevelEditorScene : IStateGame
    {
        //fields
        private PyramidPanic game;
        //constructor
        public LevelEditorScene(PyramidPanic game)
        {
            this.game = game;
            this.Editor();
            this.initialize();
        }
        public void Editor()
        {
        }
        //initialize
        public void initialize()
        {
            this.Loadcontent();
        }
        //load content
        public void Loadcontent()
        {
        }

        //update
        public void update(GameTime gameTime)
        {
            if (Input.EdgeDetectKeyDown(Keys.Escape))
            {
                this.game.GameState = new StartScene(this.game);
            }

        }
        //draw
        public void draw(GameTime gameTime)
        {
            game.GraphicsDevice.Clear(Color.Red);
        }
    }
}
