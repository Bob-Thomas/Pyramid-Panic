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
        private string levelPath;
        private const int GRIDWIDTH = 32;
        private const int GRIDHEIGHT = 32;
        


        //construction
        public Level(PyramidPanic game,int levelIndex)
        {
            this.game = game;
            this.levelPath = @"Content\PlaySceneAssets\Levels\0.txt";
            this.loadAssets();
        }
        private void loadAssets()
        {
            this.lines = new List<string>();
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
           
            
        }
        private Tile loadTile(char blockElement, int x , int y)
        {
            switch (blockElement)
            {
                case 'w':
                    return new Tile(this.game,@"Block",new Vector2(x,y),TileCollision.Notpassable,'w');
                case '.':
                        return new Tile(this.game,@"transparant", new Vector2(x,y),TileCollision.Passable,'.');
                default:
                    return new Tile(this.game, @"transparant", new Vector2(x, y), TileCollision.Passable, '.');
                    
                   
            }
        }
        public void update(GameTime gametime)
        {

        }
        public void draw(GameTime gametime)
        {
            for (int row = 0; row < this.tiles.GetLength(1); row++)
            {
                for (int column = 0; column < this.tiles.GetLength(0); column++)
                {
                    this.tiles[column,row].draw(gametime);
                }
            }
        }
    }
}
