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
    public class MenuStartScene
    {
        //fields
        private Image start, load, help, scores, editor, quit;
        private int top,left,space;
        private PyramidPanic game;

        //constructor
        public MenuStartScene(PyramidPanic game)
        {
            this.game = game;
            this.Initialize();
            
        }
        //initalaise
        private void Initialize()
        {
            this.top = 430;
            this.left = 4;
            this.space = 107;
            this.LoadContent();
        }

        //loadContent
        private void LoadContent()
        {
            this.start = new Image(this.game, new Vector2(this.left, this.top), "StartMenu//Button_start");
            this.load = new Image(this.game, new Vector2(this.left+space, this.top), "StartMenu//Button_load");
            this.help = new Image(this.game, new Vector2(this.left+space*2, this.top), "StartMenu//Button_help");
            this.scores = new Image(this.game, new Vector2(this.left+space*3, this.top), "StartMenu//Button_scores");
            this.editor = new Image(this.game, new Vector2(this.left+space*4, this.top), "StartMenu//Button_leveleditor");
            this.quit = new Image(this.game, new Vector2(this.left+space*5, this.top), "StartMenu//Button_quit");
        }
        //update
        public void update()
        {
        }

        //draw
        public void draw(GameTime gametime)
        {
            this.start.Draw(this.game.SpriteBatch);
            this.load.Draw(this.game.SpriteBatch);
            this.help.Draw(this.game.SpriteBatch);
            this.scores.Draw(this.game.SpriteBatch);
            this.editor.Draw(this.game.SpriteBatch);
            this.quit.Draw(this.game.SpriteBatch);

        }
    }
}
