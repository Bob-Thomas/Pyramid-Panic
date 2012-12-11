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
    public enum TileCollision { Passable, Notpassable }
    public class Tile
    {
        private PyramidPanic game;
        private Texture2D texture;
        private Vector2 position;
        private TileCollision tileCollision;
        private Rectangle rectangle;
        private char charItem;
        public Rectangle Rectangle
        {
            get { return this.rectangle; }
            set { this.rectangle = value; }
        }
        public TileCollision TileCollision
        {
            get { return this.tileCollision;  }
        }
        
        public Tile(PyramidPanic game,string tileName
                                    ,Vector2 position,TileCollision tileCollision,char charItem)
        {
            this.game = game;
            this.tileCollision = tileCollision;
            this.texture = game.Content.Load<Texture2D>(@"PlaySceneAssets\tiles\"+tileName);
            this.position = position;
            this.rectangle = new Rectangle((int)this.position.X, (int)this.position.Y, texture.Width, texture.Height);
            this.charItem = charItem;
        }
        public void draw(GameTime gametime)
        {
            game.SpriteBatch.Draw(this.texture, this.position, Color.White);
        }
    }
}
