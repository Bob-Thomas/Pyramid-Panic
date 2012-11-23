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
    public class StartScene : IStateGame
    {
        //fields
        private PyramidPanic game;
        private Image background,title;
        private MenuStartScene menu;
        // constructor
        public StartScene(PyramidPanic game)
        {
            this.game = game;
            this.background = new Image(game, Vector2.Zero, "StartMenu//background");
            this.title = new Image(game, new Vector2(100f, 30f), "StartMenu//Title");
            this.menu = new MenuStartScene(this.game);
        }
        public void initialize()
        {
        }
        public void Loadcontent()
        {
        }
        //Update methode
        public void update(GameTime gameTime)
        {
            this.menu.update(gameTime);
            if (Input.EdgeDetectKeyDown(Keys.Escape))
            {
                this.game.Exit();
            }
        }
        //Draw metode
        public void draw(GameTime gameTime)
        {
            this.background.Draw(gameTime);
            this.title.Draw(gameTime);
            this.menu.draw(gameTime);
        }
    }
}
