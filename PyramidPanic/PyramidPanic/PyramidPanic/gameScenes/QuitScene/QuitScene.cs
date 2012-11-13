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
    public class QuitScene : IStateGame
    {
        //fields
        private PyramidPanic game;
        //constructor
        public QuitScene(PyramidPanic game)
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
        }

        //update
        public void update(GameTime gameTime)
        {

        }
        //draw
        public void draw(GameTime gameTime)
        {
            game.GraphicsDevice.Clear(Color.GreenYellow);
        }
    }
}
