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
    public static class Input
    {
        //fields
        private static KeyboardState ks, oks;
        private static MouseState ms, oms;
        private static GamePadState gps, ogps;
        private static Rectangle mouseRectangle;
        //constructor
        static Input()
        {
            ks = Keyboard.GetState();
            ms = Mouse.GetState();
            oms = ms;
            gps = GamePad.GetState(PlayerIndex.One);
            ogps = gps;
            mouseRectangle = new Rectangle((int)ms.X, (int)ms.Y, 1, 1);

        }

        //Update
        public static void update()
        {
            oks = ks;
            ks = Keyboard.GetState();
            oms = ms;
            ms = Mouse.GetState();
            mouseRectangle.X = ms.X;
            mouseRectangle.Y = ms.Y;
            

        }
        
        // level detector
        public static bool DetectKeydown(Keys key)
        {
            
            return ks.IsKeyDown(key);
            
        }
        public static bool DetectKeyUp(Keys key)
        {

            return ks.IsKeyUp(key);

        }
        public static bool EdgeDetectKeyDown(Keys key)
        {
            return (ks.IsKeyDown(key) && oks.IsKeyUp(key));
        }


        public static bool MouseEdgeDetectPressLeft()
        {
            return(ms.LeftButton == ButtonState.Pressed && oms.LeftButton == ButtonState.Released);
        }
        public static bool MouseEdgeDetectPressRight()
        {
            return (ms.LeftButton == ButtonState.Pressed && oms.LeftButton == ButtonState.Released);
        }
        public static Vector2 MousePos()
        {
            return (new Vector2(ms.X, ms.Y));
        }
        public static Rectangle MouseRectangle()
        {
            mouseRectangle.X = ms.X;
            mouseRectangle.Y = ms.Y;
            return mouseRectangle;
        }

        //draw
        
    }
}
