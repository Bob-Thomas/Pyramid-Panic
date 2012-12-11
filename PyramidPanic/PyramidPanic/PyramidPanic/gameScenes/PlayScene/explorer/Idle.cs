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
    public class Idle : AnimatedSprite
    {
        //fields
        private Explorer explorer;
        //properties

        //constructor
        public Idle(Explorer explorer)
            : base(explorer)
        {
            this.explorer = explorer;
            i = 1;
            
        }

        public Idle(Explorer explorer, float angle)
            : base(explorer)
        {
            this.explorer = explorer;
            this.angle = angle;
            i = 1;
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
            //base.Update(gameTime);
            if(Input.DetectKeydown(Keys.W))
            {
                this.explorer.State = new Up(this.explorer);
            }
            if (Input.DetectKeydown(Keys.S))
            {
                this.explorer.State = new Down(this.explorer);
            }
            if (Input.DetectKeydown(Keys.A))
            {
                this.explorer.State = new Left(this.explorer);
            }
            if (Input.DetectKeydown(Keys.D))
            {
                this.explorer.State = new Right(this.explorer);
            }
        }

        //draw
        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }


    }
}
