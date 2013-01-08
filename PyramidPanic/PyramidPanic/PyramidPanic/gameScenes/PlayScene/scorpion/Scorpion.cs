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
    public class Scorpion : IAnimatedSprite
    {
        //Field
        private PyramidPanic game;
        private Texture2D texture;
        private Texture2D collisionText;
        private Vector2 position;
        private Rectangle rectangle;
        private IScorpion state;
        private Rectangle colRect;
        private float speed;
        private float right, left;
        private WalkLeft walkLeft;
        private WalkRight walkRight;


        //Properties
        public float Left
        {

            get { return this.left; }
            set { this.left = value; }
        }
        public float Right
        {
            get { return this.right; }
            set { this.right = value; }
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
                this.colRect.X = (int)this.position.X;
                this.colRect.Y = (int)this.position.Y;
            }
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

        public Rectangle ColRect
        {
            get { return this.colRect; }
        }

        public IScorpion State
        {
            get { return this.state; }
            set { this.state = value; }
        }

        public WalkLeft WalkLeft
        {
            get { return this.walkLeft; }
        }

        public WalkRight WalkRight
        {
            get { return this.walkRight; }
        }

        //De constructor
        public Scorpion(PyramidPanic game, Vector2 position, float speed)
        {
            this.game = game;
            this.texture = game.Content.Load<Texture2D>(@"PlaySceneAssets\Enemy's\Scorpion");
            this.collisionText = this.game.Content.Load<Texture2D>(@"PlaySceneAssets\Player\blokje");
            this.position = position;
            this.speed = speed;
            this.rectangle = new Rectangle((int)this.position.X, (int)this.position.Y, this.texture.Width / 4, this.texture.Height);
            this.colRect = new Rectangle((int)this.position.X, (int)this.position.Y, this.texture.Width / 4, this.texture.Height);
            this.walkLeft = new WalkLeft(this);
            this.walkRight = new WalkRight(this);
            this.state = this.walkRight;
        }

        //Update
        public void Update(GameTime gameTime)
        {
            this.state.Update(gameTime);
        }

        //Draw methode
        public void Draw(GameTime gameTime)
        {
            this.game.SpriteBatch.Draw(this.collisionText, this.ColRect,null, Color.Red, 0f, Vector2.Zero, SpriteEffects.None, 1f);
            this.state.Draw(gameTime);
        }
    }
}