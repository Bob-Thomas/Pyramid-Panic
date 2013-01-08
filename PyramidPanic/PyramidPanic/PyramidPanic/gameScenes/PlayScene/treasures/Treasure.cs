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
    public class Treasure : Image
    {
        //fields
        private char character;


        public char Character
        {
            get { return this.character; }
            set { this.character = value; }
        }
        //constructor
        public Treasure(char character,PyramidPanic game,Vector2 position,String pathName) : base(game,position,pathName)
        {
            this.character = character;
        }
    }
}
