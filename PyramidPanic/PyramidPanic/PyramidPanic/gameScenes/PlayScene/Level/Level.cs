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
        private LevelPause levelPause;
        private LevelPlay levelPlay;
        private LevelGameOver levelGameOver;
        private LevelOpenDoor levelOpenDoor;
        private LevelNextLevel levelNextLevel;
        private LevelVictory levelVictory;
        private ILevel levelState;

        public LevelVictory LevelVictory
        {
            get { return this.levelVictory; }
        }
        public LevelGameOver LevelGameOver
        {
            get { return this.levelGameOver; }
        }
        public LevelNextLevel LevelNextLevel
        {
            get { return this.levelNextLevel; }
        }
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
        public Explorer Explorer
        {
            get { return this.explorer; }
        }
        public PyramidPanic Game
        {
            get { return this.game; }
        }
        public ILevel LevelState
        {
            set { this.levelState = value; }
        }
        public LevelPause levelpause
        {
            get { return this.levelPause; }
            set { this.levelPause = value; }
        }
        public LevelPlay levelplay
        {
            get { return this.levelPlay; }
            set { this.levelPlay = value; }
        }

        public LevelOpenDoor LevelOpenDoor
        {
            get { return this.levelOpenDoor; }
            set { this.levelOpenDoor = value; }
        }


        //construction
        public Level(PyramidPanic game,int levelIndex)
        {
            this.game = game;
            this.levelPath = @"Content\PlaySceneAssets\Levels\"+levelIndex+".txt";
            this.loadAssets();
            this.levelPlay = new LevelPlay(this);
            this.levelPause = new LevelPause(this);
            this.levelOpenDoor = new LevelOpenDoor(this);
            this.levelGameOver = new LevelGameOver(this);
            this.levelNextLevel = new LevelNextLevel(this);
            this.levelVictory = new LevelVictory(this);
            this.levelState = new LevelPlay(this);
            Score.Level = this;
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
            ExplorerManager.Explorer = this.explorer;
            
           
            
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
                        return new Tile(this.game, @"Door", new Vector2(x, y), TileCollision.Notpassable, 'D');
                default:
                    return new Tile(this.game, @"transparant", new Vector2(x, y), TileCollision.Passable, '.');
                    
                   
            }
        }
        public void update(GameTime gameTime)
        {
            this.levelState.Update(gameTime);
        }
        public void draw(GameTime gameTime)
        {
            this.background.Draw(gameTime);
            this.panel.Draw(gameTime);
            for (int row = 0; row < this.tiles.GetLength(1); row++)
            {
                for (int column = 0; column < this.tiles.GetLength(0); column++)
                {
                    this.tiles[column,row].draw(gameTime);
                }
            }
            foreach (Scorpion scorpion in this.scorpionList)
            {
                scorpion.Draw(gameTime);
            }
            foreach (Beetle beetle in this.beetleList)
            {
                beetle.Draw(gameTime);
            }
            foreach (Image image in this.treasures)
            {
                image.Draw(gameTime);
            }
            if (this.explorer != null)
            {
                this.explorer.Draw(gameTime);
            }
            this.levelState.Draw(gameTime);
            
        }
    }
}
