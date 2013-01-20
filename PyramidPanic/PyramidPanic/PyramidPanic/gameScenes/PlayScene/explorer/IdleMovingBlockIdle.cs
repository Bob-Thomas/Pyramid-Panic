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
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;

namespace PyramidPanic
{
    public class IdleMovingBlockIdle : AnimatedSprite, IState
    {
        //Fields
        private Explorer explorer;
        private Dictionary<string, float> directionDictionary;
        private string direction;

        //Properties


        //Constructor
        public IdleMovingBlockIdle(Explorer explorer, string direction) : base(explorer)
        {
            this.explorer = explorer;
            this.direction = direction;
            this.i = 1;
            this.directionDictionary = new Dictionary<string, float>()
            {
                {"Down", 0f},
                {"Left", 1f},
                {"Up", 2f},
                {"Right", 3f}
            };
            this.angle = this.directionDictionary[direction];
        }

        //Update       
        public override void Update(GameTime gameTime)
        {
            if (Input.DetectKeydown(Keys.A))
                this.explorer.State = new Left(this.explorer);
            if (Input.DetectKeydown(Keys.D))
                this.explorer.State = new Right(this.explorer);
            if (this.direction == "Down")  
            {                
                if (Input.DetectKeydown(Keys.W))
                    this.explorer.State = new Up(this.explorer);               
                if (Input.DetectKeyUp(Keys.W))
                    this.explorer.State = new Idle(this.explorer, 2f);
            }
            if (this.direction == "Up" )
            {
                if (Input.DetectKeyUp(Keys.W))
                    this.explorer.State = new Idle(this.explorer, 2f);
                if (Input.DetectKeydown(Keys.S))
                    this.explorer.State = new Down(this.explorer);
            }            
            base.Update(gameTime);
        }

        //Draw
        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
    }
}
