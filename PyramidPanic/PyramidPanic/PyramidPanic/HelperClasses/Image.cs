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
     public class Image
    {
         //Fields
         private Texture2D texture;
         private Rectangle rectangle;
         private Vector2 position;
         private PyramidPanic game;
         //Constructor
         public Image(PyramidPanic game,Vector2 position,string pathName)
         {
             this.game = game;
             this.position = position;
             this.texture = game.Content.Load<Texture2D>(pathName);
             this.rectangle = new Rectangle((int)this.position.X,(int)this.position.Y,this.texture.Width,this.texture.Height);
         }
         public void Draw(SpriteBatch spritebatch)
         {
             //Draw
             spritebatch.Draw(this.texture, this.rectangle, Color.White);
         }
    }
}
