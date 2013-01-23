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
    public class HelpScene : IStateGame
    {
        //fields
        private PyramidPanic game;
        private Image background;
        private Texture2D text,text1,text2;
        private Rectangle rectangle1, rectangle2;
        private Vector2 position;
        //constructor
        public HelpScene(PyramidPanic game)
        {
            this.game = game;
            this.background = new Image(this.game,Vector2.Zero,@"PlaySceneAssets/background/Background3");
            this.text = game.Content.Load<Texture2D>(@"PlaySceneAssets/helper/help");
            this.text1 = game.Content.Load<Texture2D>(@"PlaySceneAssets/Player/blokje");
            this.text2 = game.Content.Load<Texture2D>(@"PlaySceneAssets/Player/blokje");
            this.rectangle1 = new Rectangle(300,0,40,40);
            this.rectangle2 = new Rectangle(295,420,40,40);
            this.position = Vector2.Zero;
            this.initialize();
        }

        //initialize
        public void initialize()
        {
            this.Loadcontent();
        }
        //load content
        public void Loadcontent()
        {
        }

        //update
        public void update(GameTime gameTime)
        {
            
            if (Input.EdgeDetectKeyDown(Keys.Escape))
            {
                this.game.GameState = new StartScene(this.game);
            }
            if (this.position.Y >= 0)
            {
                this.position.Y = 0;
            }
            if (this.position.Y <= -300)
            {
                this.position.Y = -300;
            }
            if (Input.MouseRectangle().Intersects(rectangle1))
            {
                this.position.Y += 2;
            }
            
            if (Input.MouseRectangle().Intersects(rectangle2))
            {
                this.position.Y -= 2;
            }
            Console.WriteLine(this.position.Y);
        }
        //draw
        public void draw(GameTime gameTime)
        {
            game.GraphicsDevice.Clear(Color.Black);
            this.background.Draw(gameTime);
            this.game.SpriteBatch.Draw(text, position, Color.White);    
        }
    }
}
