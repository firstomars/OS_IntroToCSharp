using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using Raylib_cs;

namespace AIE_51_TileMapEditor
{
    enum TileType
    {
        WATER,
        DESERT,
        GRASS,
        TREE
    }
    class Tile
    {
        TileType[,] map;
        float tileWidth = 30;
        float tileHeight = 25;
        

        public Tile(Program program)
        {
            LoadLevel();
        }



        void LoadLevel()
        {
            int[,] tilemap = new int[,]
            {
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                {0,0,0,0,0,0,0,0,0,0,0,2,0,0,0,0 },
                {0,0,0,1,1,1,0,0,0,0,2,3,2,0,0,0 },
                {0,0,1,1,1,1,1,0,0,2,2,3,3,0,0,0 },
                {0,0,1,1,1,1,1,1,2,2,2,3,3,3,0,0 },
                {0,1,1,1,1,1,1,1,1,1,2,2,3,3,0,0 },
                {1,1,1,1,1,1,1,1,2,2,2,2,2,3,3,0 },
                {1,1,1,1,1,1,1,1,2,1,1,2,2,2,2,1 },
                {0,1,1,1,1,1,1,1,1,1,2,2,2,2,2,1 },
                {0,1,1,1,1,1,1,1,1,2,2,2,3,3,2,0 },
                {0,0,1,1,1,1,1,1,1,2,2,3,3,3,2,0 },
                {0,0,0,1,1,1,0,0,1,2,2,3,3,2,0,0 },
                {0,0,0,0,0,0,0,0,0,0,2,2,2,0,0,0 },
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                {0,0,0,0,0,0,0,0,0,0,3,3,3,0,0,0 },
                {0,0,0,0,0,0,0,0,0,0,0,2,2,0,0,0 },
            };

            //below lines copies array data into "TileType[,] map;
            map = new TileType[tilemap.GetLength(0), tilemap.GetLength(1)];
            for (int row = 0; row < tilemap.GetLength(0); row++)
            {
                for (int col = 0; col < tilemap.GetLength(1); col++)
                {
                    map[row, col] = (TileType)tilemap[row, col];
                }
            }
        }

        public void Update()
        {
            if (Raylib.IsMouseButtonDown(MouseButton.MOUSE_LEFT_BUTTON))
            {
                GetMousePosition();
                //Raylib.DrawText((map[row, col]).ToString(),);

                //need position of mouse
                //if mouse is clicked on tile
                //generate value and draw text on tile
            }
        }

        public void Draw()
        {
            for (int row = 0; row < map.GetLength(0); row++)
            {
                for (int col = 0; col < map.GetLength(1); col++)
                {
                    float xPos = col * tileWidth;
                    float yPos = row * tileHeight;

                    Color color = Color.WHITE;

                    if (map[row, col] == TileType.DESERT) color = Color.YELLOW;
                    if (map[row, col] == TileType.GRASS) color = Color.LIME;
                    if (map[row, col] == TileType.TREE) color = Color.GREEN;
                    if (map[row, col] == TileType.WATER) color = Color.BLUE;

                    int tileVal = (int)GetTileValue(row, col);

                    var textSize = Raylib.MeasureText(tileVal.ToString(), 10);

                    Raylib.DrawRectangle((int)xPos, (int)yPos, (int)tileWidth, (int)tileHeight, color);
                    Raylib.DrawText(tileVal.ToString(), (int)(xPos + tileWidth/2) - textSize/2, (int)(yPos + tileHeight/2) - 5, 10, Color.BLACK);
                    //Raylib.DrawText(tileVal.ToString(), (int)xPos, (int)yPos, 10, Color.BLACK);

                    //int tileID = row * map.GetLength(1) + col;
                    //Raylib.DrawText(tileID.ToString(), (int)xPos, (int)yPos, 10, Color.BLACK);
                    Raylib.DrawRectangleLines((int)xPos, (int)yPos, (int)tileWidth, (int)tileHeight, Color.BLACK);
                }
            }
        }

        public TileType GetTileValue(int row, int col)
        {
            return map[row, col];
        }
        
        public Vector2 GetMousePosition()
        {
            return Raylib.GetMousePosition();
        }
    }
}
