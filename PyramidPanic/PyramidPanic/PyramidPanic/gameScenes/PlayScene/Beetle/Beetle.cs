﻿using System;
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
    public class Beetle : IAnimatedSprite
    {
        //Field
        private PyramidPanic game;
        private Texture2D texture;
        private Vector2 position;
        private Rectangle rectangle;
        private Rectangle colRect;
        private IBeetle state;
        private float speed;
        private float top;
        private float bottom;
        private WalkUP walkUp;
        private WalkDown walkDown;


        //Properties
        public WalkDown WalkDown
        {
            get { return this.walkDown; }
        }

        public WalkUP WalkUp
        {
            get { return this.walkUp; }
        }

        public float Top
        {

            get { return this.top; }
            set { this.top = value; }
        }
        public float Bottom
        {
            get { return this.bottom; }
            set { this.bottom = value; }
        }
        public float Speed
        {
            get { return this.speed; }
        }

        public Vector2 Position
        {
            get { return this.position; }
            set
            {
                this.position = value;
                this.rectangle.X = (int)this.position.X + 16;
                this.rectangle.Y = (int)this.position.Y + 16;
                this.colRect.Y = (int)this.position.Y;
                this.colRect.X = (int)this.position.X;
            }
        }

        public Rectangle ColRect
        {
            get { return this.colRect; }
        }
        public PyramidPanic Game
        {
            get { return this.game; }
        }

        public Texture2D Texture
        {
            get { return this.texture; }
        }

        public Rectangle Rectangle
        {
            get { return this.rectangle; }
        }

        public IBeetle State
        {
            get { return this.state; }
            set { this.state = value; }
        }


        //De constructor
        public Beetle(PyramidPanic game, Vector2 position, float speed)
        {
            this.game = game;
            this.texture = game.Content.Load<Texture2D>(@"PlaySceneAssets\Enemy's\Beetle");
            this.position = position;
            this.speed = speed;
            this.rectangle = new Rectangle((int)this.position.X, (int)this.position.Y, this.texture.Width / 4, this.texture.Height);
            this.colRect = new Rectangle((int)this.position.X, (int)this.position.Y, this.texture.Width / 4, this.texture.Height);
            this.walkDown = new WalkDown(this);
            this.walkUp = new WalkUP(this);
            this.state = new WalkUP(this);
        }

        //Update
        public void Update(GameTime gameTime)
        {
            this.state.Update(gameTime);
        }

        //Draw methode
        public void Draw(GameTime gameTime)
        {
            this.state.Draw(gameTime);
        }
    }
}