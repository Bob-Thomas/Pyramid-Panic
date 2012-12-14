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
        


    }
}
