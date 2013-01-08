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
    public class Score
    {
        private static int points;
        private static int scarabAmount;
        private static int lives;


        public static int Points
        {
            get { return points; }
            set { points = value; }
        }

        public static int ScarabAmount
        {
            get { return scarabAmount; }
            set { scarabAmount = value; }
        }

        public static int Lives
        {
            get { return lives; }
            set { lives = value; }
        }
       

        public static void initialize()
        {
            points = 0;
            scarabAmount = 0;
            lives = 3;

        }
        public static void maxAmount()
        {
            if (lives <= 0)
            {
                lives = 0;
            }
        }

    }
        
}
