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
    public class ExplorerManager
    {
        private static Level level;
        private static Explorer explorer;

        public static Level Level
        {
            set { level = value; }
        }
        public static Explorer Explorer
        {
            set { explorer = value; }
        }

        public static bool CollisionDetectionWalls()
        {
            for (int i = 0; i < level.Tiles.GetLength(0); i++)
            {
                for (int j = 0; j < level.Tiles.GetLength(1); j++)
                {
                    if (level.Tiles[i,j].TileCollision == TileCollision.Notpassable)
                    {
                        if (explorer.CollisionRectangle.Intersects(level.Tiles[i, j].Rectangle))
                        {
                            return true;    
                        }
                    }
                }

            }
            return false;
        }


        public static void CollisionDetectPickups()
        {
            foreach (Treasure treasure in level.Treasures)
            {
                if (explorer.CollisionRectangle.Intersects(treasure.Rectangle))
                {
                    switch (treasure.Character)
                    {
                            // ankh = 10 cat = 100 scarab = 50 + scarab = potion = 0
                        case 'a': Score.Points += 50;
                                  Score.ScarabAmount += 1;
                            break;

                        case 'b': Score.Lives +=1;
                            break;
                        case 'c': Score.Points += 100;
                            break;
                        case 'd': Score.Points += 10;
                            break;

                    }
                    
                    level.Treasures.Remove(treasure);
                    break;
                }
                }

            }

        public static void CollisionDetectScorpions()
        {
            foreach (Scorpion scorpion in level.ScorpionList)
            {
                if(explorer.CollisionRectangle.Intersects(scorpion.ColRect))
                {
                    level.levelpause.RemoveType = "scorpion";
                    level.LevelState = level.levelpause;
                    level.levelpause.Index = level.ScorpionList.IndexOf(scorpion);
                    Score.Lives -= 1;
                    break;
                }
               
 
            }

        }
        public static void CollisionDetectBeetles()
        {
            foreach (Beetle beetle in level.BeetleList)
            {
                if (explorer.CollisionRectangle.Intersects(beetle.ColRect))
                {
                    level.levelpause.RemoveType = "beetle";
                    level.levelpause.Index = level.BeetleList.IndexOf(beetle);
                    level.LevelState = level.levelpause;
                    Score.Lives -= 1;
                    break;
                }
               
            }

        }
           
        }
        


    }
