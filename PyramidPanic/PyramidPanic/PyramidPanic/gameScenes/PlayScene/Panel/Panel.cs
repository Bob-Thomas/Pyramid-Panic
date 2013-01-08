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
    public class Panel
    {
        //fields
        private PyramidPanic game;
        private Vector2 position;
        private SpriteFont font;
        private List<Image> images;
       // private List<Treasure> liveAmount;

        public Panel(PyramidPanic game,Vector2 position)
        {
            
            this.game = game;
            this.position = position;
            this.initialize();
        }
        public void initialize()
        {
            this.font = this.game.Content.Load<SpriteFont>(@"fonts\font");
            this.images = new List<Image>();
           // this.liveAmount = new List<Treasure>();
            this.LoadContent();
        }
        public void LoadContent()
        {
            this.images.Add(new Image(this.game,this.position,@"PlaySceneAssets\Panel\Panel"));
            this.images.Add(new Treasure('/', this.game, this.position + new Vector2(1.9f * 32, 0f), @"PlaySceneAssets\Panel\Lives"));
            this.images.Add(new Image(this.game, this.position + new Vector2(7.5f * 32, 0f), @"PlaySceneAssets\Panel\Scarab"));

        }
        public void update(GameTime gameTime)
        {
               /* int space = 0;
                for (int i = 0; i < Score.Lives; i++)
                {
                    
                    space += 25;
                    this.liveAmount.Add(new Treasure('/',this.game, this.position + new Vector2(1.9f * 32, 0f)+new Vector2(space,0), @"PlaySceneAssets\Panel\Lives"));
                    foreach(Treasure lives in liveAmount)
                    {
                    if (liveAmount.Count() >= Score.Lives)
                    {
                        if(lives.Character == '/')
                        {
                        this.liveAmount.Remove(lives);
                        break;
                        }
                        
                    }
                    }
                }*/
            
        }
        public void Draw(GameTime gameTime)
        {
            foreach (Image image in this.images)
            {
                image.Draw(gameTime);
            }
           /* foreach (Treasure lives in this.liveAmount)
            {
                lives.Draw(gameTime);
            }*/
            this.game.SpriteBatch.DrawString(this.font, Score.Lives.ToString(), this.position + new Vector2(1.78f*32,-2.3f), Color.Gold);
            this.game.SpriteBatch.DrawString(this.font, Score.ScarabAmount.ToString(), this.position + new Vector2(8.5f * 32, -2f), Color.Gold);
            this.game.SpriteBatch.DrawString(this.font, Score.Points.ToString(), this.position + new Vector2(16.5f * 32, -2f), Color.Gold);
        }
    }
}
