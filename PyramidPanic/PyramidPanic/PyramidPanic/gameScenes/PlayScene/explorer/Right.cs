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
            this.angle = this.angle = -(float)Math.PI * 2;
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
            this.explorer.Position += new Vector2(this.explorer.Speed, 0f);
            if (ExplorerManager.CollisionDetectionWalls())
            {
                int geheelAantalmalen32 = (int)this.explorer.Position.X / 32;
                this.explorer.Position =(this.explorer.Position.X >= 0) ? new Vector2(geheelAantalmalen32 * 32, this.explorer.Position.Y):
                                                                          new Vector2((geheelAantalmalen32 -1 )* 32, this.explorer.Position.Y);
                if (Input.DetectKeyUp(Keys.D))
                {
                    this.explorer.State = new Idle(this.explorer, this.angle);
                }
            }
            if (Input.DetectKeyUp(Keys.D))
            {
                float modulo = (this.explorer.Position.X >= 0) ? this.explorer.Position.X % 32 : 32 + this.explorer.Position.X % 32;
                Console.WriteLine(modulo);
                if (modulo >= (32f - this.explorer.Speed))
                {
                    int geheelAantalmalen32 = (int)this.explorer.Position.X / 32;
                    this.explorer.Position = (this.explorer.Position.X >= 0) ? new Vector2((geheelAantalmalen32 +1) * 32, this.explorer.Position.Y):
                                                                                new Vector2(geheelAantalmalen32 * 32,this.explorer.Position.Y);
                    this.explorer.State = new Idle(this.explorer,this.angle);
                }
            }
            base.Update(gameTime);
        }

        //draw
        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }


    }
}
