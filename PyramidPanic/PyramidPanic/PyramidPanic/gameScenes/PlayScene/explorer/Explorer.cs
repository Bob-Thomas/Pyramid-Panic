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
    public class Explorer : IAnimatedSprite
    {
        //fields
        private PyramidPanic game;
        private Vector2 position;
        private Vector2 startpos;
        private Texture2D texture, CollisionText;
        private Rectangle rectangle, CollisionRect;


        AnimatedSprite state;

        private float speed;
        //properties
        public float Speed
        {
            get { return this.speed; }
        }
        public Vector2 Position
        {
            get { return this.position; }

            set {
                this.position = value;
                this.rectangle.X = (int)this.position.X + 16;
                this.rectangle.Y = (int)this.position.Y + 16;
                this.CollisionRect.X = (int)this.position.X;
                this.CollisionRect.Y = (int)this.position.Y;
                }
        }

        public Vector2 StartPos
        {
            get { return this.startpos; }
        }
        public PyramidPanic Game
        {
            get { return this.game; }
        }
        public Rectangle Rectangle
        {
            get { return this.rectangle; }
        }
        public Rectangle CollisionRectangle
        {
            get { return this.CollisionRect; }
        }
        public Texture2D Texture
        {
            get { return this.texture; }
        }
        public AnimatedSprite State
        {
            get { return this.state; }
            set { this.state = value; }
        }
        //constructor
        public Explorer(PyramidPanic game,Vector2 position,float speed)
        {
            this.initialize();
            this.game = game;
            this.startpos = position;
            this.texture = this.game.Content.Load<Texture2D>(@"PlaySceneAssets\Player\Explorer");
            this.CollisionText = this.game.Content.Load<Texture2D>(@"PlaySceneAssets\Player\blokje");
            this.position = position;
            this.rectangle = new Rectangle((int)this.position.X + 16, (int)this.position.Y + 16, texture.Width/4, texture.Height);
            this.CollisionRect = new Rectangle((int)this.position.X, (int)this.position.Y, texture.Width/4, texture.Height);
            this.speed = speed;
            this.state = new Idle(this);
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
        public void Update(GameTime gameTime)
        {
            ExplorerManager.Explorer = this;
            ExplorerManager.CollisionDetectPickups();
            ExplorerManager.CollisionDetectScorpions();
            ExplorerManager.CollisionDetectBeetles();
            Score.maxAmount();
             this.state.Update(gameTime);
        }

        //draw
        public void Draw(GameTime gameTime)
        {
            this.state.Draw(gameTime);
        }


    }
}
