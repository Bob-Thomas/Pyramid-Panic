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
    public class Down : AnimatedSprite
    {
        //fields
        private Explorer explorer;
        //properties

        //constructor
        public Down(Explorer explorer)
            : base(explorer)
        {
            this.explorer = explorer;
            this.angle = (float)Math.PI / 2;
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
            this.explorer.Position += new Vector2(0f, this.explorer.Speed);
            //Collisiondetection met NotPassable objects
            if (ExplorerManager.CollisionDetectionWalls())
            {
                int geheelAantalmalen32 = (int)this.explorer.Position.Y / 32;
                this.explorer.Position = (this.explorer.Position.Y >= 0) ?
                    new Vector2(this.explorer.Position.X, geheelAantalmalen32 * 32) :
                    new Vector2(this.explorer.Position.X, (geheelAantalmalen32 - 1) * 32);
                if (Input.DetectKeyUp(Keys.Down))
                {
                    this.explorer.State = new Idle(this.explorer, (float)Math.PI / 2);
                }
            }
            //Blijf op het grid
            if (Input.DetectKeyUp(Keys.Down))
            {
                float modulo = (this.explorer.Position.Y >= 0) ?
                                this.explorer.Position.Y % 32 :
                                32 + this.explorer.Position.Y % 32;
                if (modulo >= (32f - this.explorer.Speed))
                {
                    int geheelAantalmalen32 = (int)this.explorer.Position.Y / 32;
                    this.explorer.Position = (this.explorer.Position.Y >= 0) ?
                        new Vector2(this.explorer.Position.X, (geheelAantalmalen32 + 1) * 32) :
                        new Vector2(this.explorer.Position.X, (geheelAantalmalen32) * 32);
                    this.explorer.State = new Idle(this.explorer, (float)Math.PI / 2);
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
