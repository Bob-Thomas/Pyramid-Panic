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
    public class Left : AnimatedSprite
    {
        //fields
        private Explorer explorer;
        //properties

        //constructor
        public Left(Explorer explorer) : base(explorer)
        {
            this.explorer = explorer;
            this.angle = (float)Math.PI;
            this.i = 0;
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
            this.explorer.Position += new Vector2(-this.explorer.Speed, 0);
            if (ExplorerManager.CollisionDetectionWalls())
            {
                int geheelAantalmalen32 = (int)this.explorer.Position.X / 32;
                this.explorer.Position = new Vector2((geheelAantalmalen32 * 32)+ 1 * 32, this.explorer.Position.Y);
                if (Input.DetectKeyUp(Keys.A))
                {
                    this.explorer.State = new Idle(this.explorer, 0f);
                }
            }
            if (Input.DetectKeyUp(Keys.A))
            {
                float modulo = this.explorer.Position.X % 32;
                if (modulo >= 32 - this.explorer.Speed)
                {
                    int geheelAantalmalen32 = (int)this.explorer.Position.X / 32;
                    this.explorer.Position = new Vector2((geheelAantalmalen32 * 32) + 1 * 32, this.explorer.Position.Y);
                    this.explorer.State = new Idle(this.explorer, this.angle);
                }
            }
            
        }

        //draw
        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }


    }
}
