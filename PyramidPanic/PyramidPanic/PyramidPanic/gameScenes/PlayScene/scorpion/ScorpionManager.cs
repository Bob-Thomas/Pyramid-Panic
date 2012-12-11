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
    public class ScorpionManager
    {
        //fields
        private static Level level;

        //properties
       public static Level Level
        {
            set
            {
                level = value;
                CollisionWallScorpionLeft();
                CollisionWallScorpionRight();

            }

        }

       public  static void CollisionWallScorpionLeft()
        {
            foreach (Scorpion scorpion in level.ScorpionList)
            {
                for (int i = (int)(scorpion.Position.X / 32); i >= 0; i--)
                {
                    if (level.Tiles[i,(int)(scorpion.Position.Y / 32)].TileCollision == TileCollision.Notpassable)
                    {
                        scorpion.Left = (i+1)* 32;
                        break;
                    }
                }
            }
        }
        public static void CollisionWallScorpionRight()
        {
            foreach (Scorpion scorpion in level.ScorpionList)
            {
                for (int i = (int)(scorpion.Position.X / 32); i <=20; i++)
                {
                    if (level.Tiles[i,(int)(scorpion.Position.Y / 32)].TileCollision == TileCollision.Notpassable)
                    {
                        scorpion.Right = (i-1)* 32;
                        break;
                    }
                }
            }
        }
    }
}