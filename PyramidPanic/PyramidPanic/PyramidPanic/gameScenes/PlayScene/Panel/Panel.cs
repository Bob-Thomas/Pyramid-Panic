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
            this.LoadContent();
        }
        public void LoadContent()
        {
            this.images.Add(new Image(this.game,this.position,@"PlaySceneAssets\Panel\Panel"));
            this.images.Add(new Image(this.game, this.position+ new Vector2(2.5f*32,0f), @"PlaySceneAssets\Panel\Lives"));
            this.images.Add(new Image(this.game, this.position + new Vector2(7.5f * 32, 0f), @"PlaySceneAssets\Panel\Scarab"));

        }
        public void update()
        {
        }
        public void Draw(GameTime gameTime)
        {
            foreach (Image image in this.images)
            {
                image.Draw(gameTime);
            }
            this.game.SpriteBatch.DrawString(this.font, "1", this.position + new Vector2(3.8f*32,-2f), Color.Gold);
            this.game.SpriteBatch.DrawString(this.font, "0", this.position + new Vector2(8.5f * 32, -2f), Color.Gold);
            this.game.SpriteBatch.DrawString(this.font, "0", this.position + new Vector2(16.5f * 32, -2f), Color.Gold);
        }
    }
}
