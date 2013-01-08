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
    public class WalkUP :AnimatedSprite, IBeetle
    {
        private Beetle beetle;
        
        //Constructor
        public WalkUP(Beetle beetle) : base(beetle)
        {
            this.beetle = beetle;
            this.angle = 0;
        }        
        
        public override void Update(GameTime gameTime)
        {
            //De beetle loopt naar rechts

            this.beetle.Position -= new Vector2(0f,this.beetle.Speed );
            if (this.beetle.Position.Y < this.beetle.Top)
            {
                this.beetle.State = this.beetle.WalkDown;
            }
            base.Update(gameTime);
            //Dit is de code voor de animatie van de sprite
            
        }
        
        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
    }
}