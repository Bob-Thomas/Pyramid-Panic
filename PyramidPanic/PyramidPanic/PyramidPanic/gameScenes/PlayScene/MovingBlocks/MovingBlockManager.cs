using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;

namespace PyramidPanic
{
    public class MovingBlockManager
    {
        //Fields        
        private static Level level;
        private static Explorer explorer;

        //Properties
        public static Level Level
        {
            set { level = value; }
        }
        public static Explorer Explorer
        {
            set { explorer = value; }
        }

        public static void CollisionDectectExplorerMovingBlockDown(MovingBlock block)
        {   
            if (explorer.CollisionRectangle.Intersects(block.Rectangle) && 
                    explorer.State.ToString() == "PyramidPanic.Down" &&
                        explorer.CollisionRectangle.Bottom < block.Rectangle.Top + 4)          //+4 anders bij het teruglopen en weer omhoog gaan loopt de explorer door het steentje
            {
                level.Tiles[(int)block.CurrentIndex.X, (int)block.CurrentIndex.Y].TileCollision = TileCollision.Passable;
                block.State = new MovingBlockDown(block);
            }
        }

        //Omhoog duwen van blokje
        public static void CollisionDectectExplorerMovingBlockUp(MovingBlock block)                 //§
        {
            if (explorer.CollisionRectangle.Intersects(block.Rectangle) &&
                        explorer.State.ToString() == "PyramidPanic.Up" &&
                            explorer.CollisionRectangle.Top > block.Rectangle.Bottom - 4)        //-4 anders bij het teruglopen en weer omhoog gaan loopt de explorer door het steentje
            {
                level.Tiles[(int)block.CurrentIndex.X, (int)block.CurrentIndex.Y].TileCollision = TileCollision.Passable;
                block.State = new MovingBlockUp(block);
            }
        }


        //§ nieuw explorer blokkeert het pad van de teruglopende steen omhoog en omlaag
        public static void CollisionDectectExplorerGoBackUp(MovingBlock block)
        {
            if (explorer.CollisionRectangle.Intersects(block.Rectangle))
            {
                if ( explorer.State.ToString() == "PyramidPanic.Idle"  ||
                     explorer.State.ToString() == "PyramidPanic.Left" ||
                     explorer.State.ToString() == "pp.ExplorerWalkRight")
                {
                    if (explorer.CollisionRectangle.Bottom - 2 < block.Rectangle.Top || //Steen blokkeren als steen naar boven gaat en explorer blokkeert pad
                        explorer.CollisionRectangle.Top + 2 > block.Rectangle.Bottom)   //Steen blokkeren als steen naar beneden gaat en explorer blokkeert pad
                    {
                        block.State = new MovingBlockIdleOffPlace(block);
                    }

                }
            }
        }

        public static void DeCollisionDectectExplorerMovingBlockDown(MovingBlock block)  //§ alles nieuw
        {
            if ( !explorer.CollisionRectangle.Intersects(block.Rectangle))
            {
                if (block.Location.Y > block.StartLocation.Y)
                {
                    block.State = new MovingBlockGoBackUp(block);
                }
                else if (block.Location.Y < block.StartLocation.Y)
                {
                    block.State = new MovingBlockGoBackDown(block);  //§
                }
            }
        }

        public static void SetBackOnPlaceGoingUp(MovingBlock block)     //§ zorgt ervoor dat een omhooggaande steen weer op de startpositie terecht komt
        {
            if (block.Location.Y < block.StartLocation.Y)               //Zou 1 methode kunnen worden met de onderstaande SetBackOnPlaceGoingDown(MovingBlock block)
            {
                block.Location = block.StartLocation;
                level.Tiles[(int)block.CurrentIndex.X, (int)block.CurrentIndex.Y].TileCollision = TileCollision.Notpassable;
                block.State = new MovingBlockIdle(block);
            }
        }

        public static void SetBackOnPlaceGoingDown(MovingBlock block) //§ nieuw zorgt ervoor dat een omlaaggaande steen weer op de startpositie terecht komt
        {
            if (block.Location.Y > block.StartLocation.Y)
            {
                block.Location = block.StartLocation;
                level.Tiles[(int)block.CurrentIndex.X, (int)block.CurrentIndex.Y].TileCollision = TileCollision.Notpassable;
                block.State = new MovingBlockIdle(block);
            }
        }

        public static bool CollisionDectectionWalls(MovingBlock block)  //§ nieuw blokkeert een movingblock als hij de muur raakt
        {
            
            if ( block.Location.Y > block.BorderBottom )
            {
                explorer.Position = new Vector2(block.CurrentIndex.X * 32, (block.CurrentIndex.Y - 1) * 32);
                block.Location = new Vector2(block.CurrentIndex.X * 32, (block.CurrentIndex.Y) * 32);
                explorer.State = new IdleMovingBlockIdle(explorer, "Down");
                return true;
            }
             if ( block.Location.Y < block.BorderTop )
            {
                explorer.Position = new Vector2(block.CurrentIndex.X * 32, (block.CurrentIndex.Y + 2) * 32);
                block.Location = new Vector2(block.CurrentIndex.X * 32, (block.CurrentIndex.Y + 1) * 32);
                explorer.State = new IdleMovingBlockIdle(explorer, "Up");
                return true;
            }   
        return false;
        }

        public static void CollisionGridDown()  // Zoekt waar naar onderen een 'w' steen staat
        {
            foreach (MovingBlock block in level.MovingBlocks)
            {
                for (int i = (int)(block.Location.Y / 32) + 1; i < level.Tiles.GetLength(1); i++)
                {
                    if (level.Tiles[(int)(block.StartLocation.X / 32), i].TileCollision == TileCollision.Notpassable)
                    {
                        block.BorderBottom = (i - 1) * 32;
                        break;
                    }
                }
            }
        }

        public static bool CDMovingblockScorpion(MovingBlock block)
        {
            foreach (Scorpion scorpion in level.ScorpionList)
            {
                if (block.ColRectScorpion.Intersects(scorpion.ColRect))
                {
                    return true;
                }
            }
            return false;
        }

        public static void CollisionGridUp()        //Zoekt waar naar boven een 'w' steen staat
        {
            foreach (MovingBlock block in level.MovingBlocks)
            {
                for (int i = (int)(block.Location.Y / 32) - 1; i >= 0; i--)
                {
                    if (level.Tiles[(int)(block.StartLocation.X / 32), i].TileCollision == TileCollision.Notpassable)
                    {
                        block.BorderTop = (i + 1) * 32;
                        break;
                    }
                }
            }
        }
    }
}
