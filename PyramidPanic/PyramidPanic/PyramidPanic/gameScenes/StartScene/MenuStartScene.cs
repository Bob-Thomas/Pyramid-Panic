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
        private enum buttonState { Start, Load, Help, Scores, Editor, Quit };
        //fields
        private Image start, load, help, scores, editor, quit;
        private buttonState buttonstate;
        private Color buttonColorActive = Color.Goldenrod;
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
        public void update(GameTime gametime)
        {
            if (Input.EdgeDetectKeyDown(Keys.Right))
            {
               this.buttonstate ++;
            }
            if (Input.EdgeDetectKeyDown(Keys.Left))
            {
                this.buttonstate--;
            }

            if (this.buttonstate > buttonState.Quit)
            {
                buttonstate = buttonState.Start;
            }
            if (this.buttonstate < buttonState.Start)
            {
                buttonstate = buttonState.Quit;
            }
            if (Input.EdgeDetectKeyDown(Keys.Enter) && this.buttonstate == buttonState.Start )
            {
                this.game.GameState = new PlayScene(game);
            }
            if (Input.EdgeDetectKeyDown(Keys.Enter) && this.buttonstate == buttonState.Load )
            {
                this.game.GameState = new LoadScene(game);
            }
            if (Input.EdgeDetectKeyDown(Keys.Enter) && this.buttonstate == buttonState.Scores )
            {
                this.game.GameState = new ScoreScene(game);
            }
            if (Input.EdgeDetectKeyDown(Keys.Enter) && this.buttonstate == buttonState.Help)
            {
                this.game.GameState = new HelpScene(game);
            }
            if (Input.EdgeDetectKeyDown(Keys.Enter) && this.buttonstate == buttonState.Editor)
            {
                this.game.GameState = new LevelEditorScene(game);
            }
            if (Input.EdgeDetectKeyDown(Keys.Enter) && this.buttonstate == buttonState.Quit)
            {
                this.game.GameState = new QuitScene(game);
            }
            

             if (Input.MouseRectangle().Intersects(this.start.Rectangle))
             {
                 this.buttonstate = buttonState.Start;
                 if (Input.MouseEdgeDetectPressLeft() && this.buttonstate == buttonState.Start)
                 {
                     this.game.GameState = new PlayScene(this.game);
                 }
                 
             }
             else
             if (Input.MouseRectangle().Intersects(this.load.Rectangle))
             {
                 this.buttonstate = buttonState.Load;
                 if (Input.MouseEdgeDetectPressLeft() && this.buttonstate == buttonState.Load)
                 {
                     this.game.GameState = new LoadScene(this.game);
                 }
             }
             else
                 if (Input.MouseRectangle().Intersects(this.help.Rectangle))
             {
                 this.buttonstate = buttonState.Help;
                 if (Input.MouseEdgeDetectPressLeft() && this.buttonstate == buttonState.Help)
                 {
                     this.game.GameState = new HelpScene(this.game);
                 }
             }
             else
             if (Input.MouseRectangle().Intersects(this.scores.Rectangle))
             {
                 this.buttonstate = buttonState.Scores;
                 if (Input.MouseEdgeDetectPressLeft() && this.buttonstate == buttonState.Scores)
                 {
                     this.game.GameState = new ScoreScene(this.game);
                 }
             }
             else
             if (Input.MouseRectangle().Intersects(this.editor.Rectangle))
             {
                 this.buttonstate = buttonState.Editor;
                 if (Input.MouseEdgeDetectPressLeft() && this.buttonstate == buttonState.Editor)
                 {
                     this.game.GameState = new LevelEditorScene(this.game);
                 }
             }
             else
                 if (Input.MouseRectangle().Intersects(this.quit.Rectangle))
                 {
                     this.buttonstate = buttonState.Quit;
                     if (Input.MouseEdgeDetectPressLeft() && this.buttonstate == buttonState.Quit)
                     {
                         this.game.GameState = new QuitScene(this.game);
                     }
                 }
                 
        }

        //draw
        public void draw(GameTime gametime)
        {
            Color buttonColorStart = Color.White;
            Color buttonColorLoad = Color.White;
            Color buttonColorHelp = Color.White;
            Color buttonColorEditor = Color.White;
            Color buttonColorScores = Color.White;
            Color buttonColorQuit = Color.White;

            switch(this.buttonstate)
            {
                case buttonState.Start:
                    buttonColorStart = this.buttonColorActive;
                    break;
                case buttonState.Load:
                    buttonColorLoad = this.buttonColorActive;
                    break;
                case buttonState.Help:
                    buttonColorHelp = this.buttonColorActive;
                    break;
                case buttonState.Editor:
                    buttonColorEditor = this.buttonColorActive;
                    break;
                case buttonState.Scores:
                    buttonColorScores = this.buttonColorActive;
                    break;
                case buttonState.Quit:
                    buttonColorQuit = this.buttonColorActive;
                    break;

            }
            this.start.Draw(this.game.SpriteBatch, buttonColorStart);
            this.load.Draw(this.game.SpriteBatch, buttonColorLoad);
            this.help.Draw(this.game.SpriteBatch, buttonColorHelp);
            this.scores.Draw(this.game.SpriteBatch, buttonColorScores);
            this.editor.Draw(this.game.SpriteBatch, buttonColorEditor);
            this.quit.Draw(this.game.SpriteBatch, buttonColorQuit);

        }
    }
}
