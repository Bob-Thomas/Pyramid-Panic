﻿using System;
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
        private Panel panel;
        private List<Scorpion> scorpionList;
        private List<Image> treasures;
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
            this.treasures = new List<Image>();
            this.scorpionList = new List<Scorpion>();
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
            
           
            
        }
        private Tile loadTile(char blockElement, int x , int y)
        {
            switch (blockElement)
            {
                case 'v':
                    this.treasures.Add(new Image(this.game, new Vector2(x, y), @"PlaySceneAssets\pushable\Block_vert"));
                    return new Tile(this.game, @"transparant", new Vector2(x, y), TileCollision.Passable, 'v');
                case 'h':
                    this.treasures.Add(new Image(this.game, new Vector2(x, y), @"PlaySceneAssets\pushable\Block_hor"));
                    return new Tile(this.game, @"transparant", new Vector2(x, y), TileCollision.Passable, 'h');

                case 's':
                    this.scorpionList.Add(new Scorpion(this.game, new Vector2(x, y), 2.0f));
 	                 return new Tile(this.game, @"Transparant", new Vector2(x, y), TileCollision.Passable, 's');

                case 'q':
                    this.treasures.Add(new Image(this.game, new Vector2(x, y), @"PlaySceneAssets\pickups\Scarab"));
                    return new Tile(this.game, @"transparant", new Vector2(x, y), TileCollision.Passable, 'q');
                case 'p':
                    this.treasures.Add(new Image(this.game, new Vector2(x, y), @"PlaySceneAssets\pickups\Potion"));
                    return new Tile(this.game, @"transparant", new Vector2(x, y), TileCollision.Passable, 'p');
                case 'c':
                    this.treasures.Add(new Image(this.game, new Vector2(x, y), @"PlaySceneAssets\pickups\Treasure2"));
                    return new Tile(this.game, @"transparant", new Vector2(x, y), TileCollision.Passable, 'c');
                case 'a':
                    this.treasures.Add(new Image(this.game, new Vector2(x, y), @"PlaySceneAssets\pickups\Treasure1"));
                    return new Tile(this.game, @"transparant", new Vector2(x, y), TileCollision.Passable, 'a');
                case '@':
                    this.background = new Image(this.game, new Vector2(x,y),@"PlaySceneAssets\background\Background2");
                    return new Tile(this.game, @"Wall2", new Vector2(x, y), TileCollision.Notpassable, '@');

                case 'x':
                    return new Tile(this.game, @"Wall1", new Vector2(x, y), TileCollision.Notpassable, 'x');
                case 'i':
                    return new Tile(this.game, @"Wall2", new Vector2(x, y), TileCollision.Passable, 'i');
                case 'y':
                    return new Tile(this.game, @"Wall2", new Vector2(x, y), TileCollision.Notpassable, 'y');
                case 'w':
                    return new Tile(this.game,@"Block",new Vector2(x,y),TileCollision.Notpassable,'w');
                case '.':
                        return new Tile(this.game,@"transparant", new Vector2(x,y),TileCollision.Passable,'.');
                case 'd':
                        this.treasures.Add(new Image(this.game, new Vector2(x, y), @"PlaySceneAssets\tiles\Door"));
                        return new Tile(this.game, @"transparant", new Vector2(x, y), TileCollision.Notpassable, 'd');
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
            foreach (Image image in this.treasures)
            {
                image.Draw(gametime);
            }
            
            
        }
    }
}
