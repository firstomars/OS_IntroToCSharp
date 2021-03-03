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

        int selectedTileId = -1;

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
            if (Raylib.IsMouseButtonPressed(MouseButton.MOUSE_LEFT_BUTTON))
            {
                //mouse position
                Vector2 mousePos = Raylib.GetMousePosition();
                
                //change value of selectedTileID - this will then get picked up by the Draw() if statements
                selectedTileId = GetTileID(mousePos);
            }
        }

        public int GetTileID(int row, int col)
        {
            return row * map.GetLength(1) + col;
        }

        public int GetTileID(Vector2 pos)
        {
            int row = GetYPosToRow(pos.Y);
            int col = GetXPosToCol(pos.X);
            return GetTileID(row, col);
        }

        public TileType GetTileValue(Vector2 pos)
        {
            int row = GetYPosToRow(pos.Y);
            int col = GetXPosToCol(pos.X);
            return GetTileValue(row, col);
        }

        public int GetYPosToRow(float yPos)
        {
            //Get row pos by taking ypos of player (e.g. 100) and dividing it by the tile height
            // map offset takes into account the top corner of where we gen. the map
            return (int)(yPos / tileHeight);
        }

        public int GetXPosToCol(float xPos)
        {
            return (int)(xPos / tileWidth);
        }

        public void DrawTile(int row, int col)
        {
            int tileId = GetTileID(row, col);

            if( tileId == selectedTileId )
            {
                //this will remove tile
            }
            else
            {
                Color color = Color.WHITE;

                if (map[row, col] == TileType.DESERT) color = Color.YELLOW;
                if (map[row, col] == TileType.GRASS) color = Color.LIME;
                if (map[row, col] == TileType.TREE) color = Color.GREEN;
                if (map[row, col] == TileType.WATER) color = Color.BLUE;

                var rect = GetTileRect(row, col);

                Raylib.DrawRectangleRec(rect, color);
            }
        }

        void DrawSelectedTile()
        {
            // draw selected tile
            if (selectedTileId >= 0)
            {
                int selectedRow = selectedTileId / map.GetLength(1);
                int selectedCol = selectedTileId % map.GetLength(1);
                var rect = GetTileRect(selectedRow, selectedCol);
                Raylib.DrawRectangleLinesEx(rect, 2, Color.WHITE);
            }
        }

        public void Draw()
        {
            for (int row = 0; row < map.GetLength(0); row++)
            {
                for (int col = 0; col < map.GetLength(1); col++)
                {

                    DrawTile(row, col);
                }
            }
            DrawSelectedTile();
        }

        public Rectangle GetTileRect(int row, int col)
        {
            float xPos = (col * tileWidth);
            float yPos = (row * tileHeight);
            return new Rectangle(xPos, yPos, tileWidth, tileHeight);
        }


        public TileType GetTileValue(int row, int col)
        {
            return map[row, col];
        }

        //public int FindMatchingTile(int mouseTileID)
        //{
        //    for (int row = 0; row < map.GetLength(0); row++)
        //    {
        //        for (int col = 0; col < map.GetLength(1); col++)
        //        {
        //            if (mouseTileID == GetTileID(row, col))
        //            {
        //                return GetTileID(row, col);
        //            }
        //        }
        //    }

        //    return -1;
    }
}
