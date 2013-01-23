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
        private static int lives = 3;
        private static int points;
        private static int scarabAmount;
        private static bool doorsAreClosed;
        private static Level level;
        private static int maxPointDoors = 0;

        public static int MaxPointDoors
        {
            set {  maxPointDoors = value; }
        }
        public static Level Level
        {
            get { return level; }
            set { level = value; }
        }

        public static bool DoorsAreClosed
        {
            get { return doorsAreClosed; }
            set { doorsAreClosed = value; }
        }
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
            doorsAreClosed = true;
            if (PlayScene.LevelNumber == 0)
            {
                lives = 3;
                scarabAmount = 0;
            }
            maxPointDoors = 0;
            maxScoreLevel();

        }

        public static void maxScoreLevel()
        {
            foreach (Treasure treasure in level.Treasures)
            {
                switch (treasure.Character)
                {
                    case 'a':
                        maxPointDoors += 50;
                        break;
                    case 'b':
                        maxPointDoors += 0;
                        break;
                    case 'c':
                        maxPointDoors += 100;
                        break;
                    case 'd':
                        maxPointDoors += 10;
                        break;
                    default:
                        break;
                            
                }
            }
            maxPointDoors += points;
            maxPointDoors -= 200;
      
            Console.WriteLine("test" + maxPointDoors);
        }
        public static bool openDoors()
        {
            return (Score.points >= maxPointDoors) ? true : false;
        }

        public static bool isDead()
        {
            return (lives < 1) ? true : false;
        }

        public static bool completed()
        {
            return (PlayScene.LevelNumber == 11) ? true : false;
        }
    }
        
}
