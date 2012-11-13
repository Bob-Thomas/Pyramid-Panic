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
        static KeyboardState ks, oks;
        static MouseState ms, oms;
        static GamePadState gps, ogps;
        //constructor
        static Input()
        {
            ks = Keyboard.GetState();
            ms = Mouse.GetState();
            oms = ms;
            gps = GamePad.GetState(PlayerIndex.One);
            ogps = gps;

        }

        //Update
        public static void update()
        {
            oks = ks;
            ks = Keyboard.GetState();
            

        }
        
        // level detector
        public static bool DetectKeydown(Keys key)
        {
            
            return ks.IsKeyDown(key);
            
        }
        public static bool EdgeDetectKeyDown(Keys key)
        {
            return (ks.IsKeyDown(key) && oks.IsKeyUp(key));
        }

        //draw
        
    }
}
