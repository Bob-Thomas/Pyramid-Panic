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
    public class Right : AnimatedSprite
    {
        //fields
        private Explorer explorer;
        //properties

        //constructor
        public Right(Explorer explorer) : base(explorer)
        {
            this.explorer = explorer;
        }
        //initialize
        public void initialize()
        {
            this.LoadContent();
        }

        //loadcontent
        public void LoadContent()
        {
        }

        //update
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            this.explorer.Position += new Vector2(this.explorer.Speed, 0);
            
        }

        //draw
        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }


    }
}
