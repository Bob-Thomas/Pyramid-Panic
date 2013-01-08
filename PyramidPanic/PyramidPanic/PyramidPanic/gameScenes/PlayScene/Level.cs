using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Storage;
namespace PyramidPanic
{
    public class Level
    {
        //fields
        private PyramidPanic game;
        private List<string> lines;
        private Tile[,] tiles;
        private Image background;
        private string levelPath;
        private Explorer explorer;
        private Panel panel;
        private List<Scorpion> scorpionList;
        private List<Beetle> beetleList;
        private List<Image> treasures;
        private const int GRIDWIDTH = 32;
        private const int GRIDHEIGHT = 32;

        public List<Beetle> BeetleList
        {
            get { return this.beetleList; }
        }
        public List<Scorpion> ScorpionList
        {
            get { return this.scorpionList; }
        }
        public Tile[,] Tiles
        {
            get { return this.tiles;  }
        }
        public List<Image> Treasures
        {
            get { return this.treasures; }
            set { this.treasures = value; }
        }
        


        //construction
        public Level(PyramidPanic game,int levelIndex)
        {
            this.game = game;
            this.levelPath = @"Content\PlaySceneAssets\Levels\"+levelIndex+".txt";
            this.loadAssets();
            Score.initialize();
        }
        private void loadAssets()
        {
            this.lines = new List<string>();
            this.treasures = new List<Image>();
            this.scorpionList = new List<Scorpion>();
            this.beetleList = new List<Beetle>();
            this.panel = new Panel(this.game, new Vector2(0, 448));
            StreamReader reader = new StreamReader(this.levelPath);
            string line = reader.ReadLine();
            int width = line.Length;
            
           
            while(line != null)
            {
                lines.Add(line);
                line = reader.ReadLine();
            }

            int height = lines.Count;
            this.tiles = new Tile[width, height];
            reader.Close();
            for (int row = 0; row < height; row++)
            {
                for (int column = 0; column < width; column++)
                {
                    char blockElement = this.lines[row][column];
                    this.tiles[column, row] = loadTile(blockElement, column * GRIDWIDTH, row * GRIDHEIGHT);
                }
            }
            BeetleManager.Level = this;
            ScorpionManager.Level = this;
            ExplorerManager.Level = this;
            
           
            
        }
        private Tile loadTile(char blockElement, int x , int y)
        {
            switch (blockElement)
            {
                case 'B':
                    this.beetleList.Add(new Beetle(this.game, new Vector2(x, y), 2.0f));
                    return new Tile(this.game, @"Transparant", new Vector2(x, y), TileCollision.Passable, 'b');
                case 'E':
                   this.explorer = new Explorer(this.game,new Vector2(x,y),2.5f);
                    return new Tile(this.game, @"Transparant", new Vector2(x, y), TileCollision.Passable, 'E');
                case 'S':
                    this.scorpionList.Add(new Scorpion(this.game, new Vector2(x, y), 2.0f));
 	                 return new Tile(this.game, @"Transparant", new Vector2(x, y), TileCollision.Passable, 's');

                case 'a':
                    this.treasures.Add(new Treasure('a',this.game, new Vector2(x, y),@"PlaySceneAssets\pickups\Scarab"));//scarab
                    return new Tile(this.game, @"transparant", new Vector2(x, y), TileCollision.Passable, 'a');
                case 'b':
                    this.treasures.Add(new Treasure('b',this.game, new Vector2(x, y), @"PlaySceneAssets\pickups\Potion"));//potions
                    return new Tile(this.game, @"transparant", new Vector2(x, y), TileCollision.Passable, 'b');
                case 'c':
                    this.treasures.Add(new Treasure('c',this.game, new Vector2(x, y), @"PlaySceneAssets\pickups\Treasure2"));//cat
                    return new Tile(this.game, @"transparant", new Vector2(x, y), TileCollision.Passable, 'c');
                case 'd':
                    this.treasures.Add(new Treasure('d',this.game, new Vector2(x, y), @"PlaySceneAssets\pickups\Treasure1"));//ankh
                    return new Tile(this.game, @"transparant", new Vector2(x, y), TileCollision.Passable, 'd');
                case '@':
                    this.background = new Image(this.game, new Vector2(x,y),@"PlaySceneAssets\background\Background2");
                    return new Tile(this.game, @"Wall2", new Vector2(x, y), TileCollision.Notpassable, '@');

                case 'x':
                    return new Tile(this.game, @"Wall1", new Vector2(x, y), TileCollision.Notpassable, 'x');
                case 'y':
                    return new Tile(this.game, @"Wall2", new Vector2(x, y), TileCollision.Notpassable, 'y');
                case 'w':
                    return new Tile(this.game,@"Block",new Vector2(x,y),TileCollision.Notpassable,'w');
                case '.':
                        return new Tile(this.game,@"transparant", new Vector2(x,y),TileCollision.Passable,'.');
                case 'D':
                        return new Tile(this.game, @"Door", new Vector2(x, y), TileCollision.Passable, 'd');
                default:
                    return new Tile(this.game, @"transparant", new Vector2(x, y), TileCollision.Passable, '.');
                    
                   
            }
        }
        public void update(GameTime gametime)
        {
            foreach (Scorpion scorpion in this.scorpionList)
            {
                scorpion.Update(gametime);
            }
            foreach (Beetle beetle in this.beetleList)
            {
                beetle.Update(gametime);
            }
            if (this.explorer != null)
            {
                this.explorer.Update(gametime);
            }
            panel.update(gametime);
        }
        public void draw(GameTime gametime)
        {
            this.background.Draw(gametime);
            this.panel.Draw(gametime);
            for (int row = 0; row < this.tiles.GetLength(1); row++)
            {
                for (int column = 0; column < this.tiles.GetLength(0); column++)
                {
                    this.tiles[column,row].draw(gametime);
                }
            }
            foreach (Scorpion scorpion in this.scorpionList)
            {
                scorpion.Draw(gametime);
            }
            foreach (Beetle beetle in this.beetleList)
            {
                beetle.Draw(gametime);
            }
            foreach (Image image in this.treasures)
            {
                image.Draw(gametime);
            }
            if (this.explorer != null)
            {
                this.explorer.Draw(gametime);
            }
            
            
        }
    }
}
