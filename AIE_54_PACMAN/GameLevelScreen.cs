using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using Raylib_cs;

namespace AIE_54_PACMAN
{
    //why do we create enum TileType outside of the GameLevelScreen class? 

    //I'm guessing because we'll mostly only need to access it during the game level screen cs, but other cs' may need to access it?
    // enum doesn't exist in a class?

    enum TileType
    {
        EMPTY,  //0
        WALL,   //1
        DOT,     //2
        PLAYERSTART
    }

    class GameLevelScreen : IGameState //child game state class inheriting from IGameState
    {
        //these are member variables now that they have been taken out of "draw". CAn be accessed by other functions in this class
        float tileWidth = 32;
        float tileHeight = 32;
        float mapOffsetX = 50;
        float mapOffsetY = 50;

        TileType[,] map;

        int score = 1000;
        int lives = 3;

        int numPacDots = 0;

        Player player;

        public GameLevelScreen(Program program) : base(program)
        {
            LoadLevel();
        }

        void LoadLevel()
        {
            //How does the below connect with TileType? Does 0 connect with Empty etc?

            int[,] tilemap = new int[,]
            { // 0 1 2 3 4 5 6 7 8 9
                {1,1,1,1,1,1,1,1,1,1},  // 0
                {1,0,0,0,0,0,0,0,0,1},  // 1
                {1,0,1,0,0,0,0,0,0,1},  // 2
                {1,0,1,0,1,1,1,0,0,1},  // 3
                {1,0,1,0,0,3,1,0,1,1},  // 4
                {1,0,1,1,1,0,1,0,0,1},  // 5
                {1,0,0,0,0,0,1,1,0,1},  // 6
                {1,0,0,0,0,0,1,1,0,1},  // 7
                {1,0,0,0,0,0,0,0,0,1},  // 8
                {1,1,1,1,1,1,1,1,1,1},  // 9
            };

            map = new TileType[tilemap.GetLength(0),tilemap.GetLength(1)];
            //0 refers to ...
            //1 refers to ...


            //this for loop copies the above 2D array data into "map" as defined at the top of the class
            for (int row = 0; row <tilemap.GetLength(0); row++)
            {
                for (int col = 0; col < tilemap.GetLength(1); col++)
                {
                    SetTileValue(row, col, (TileType)tilemap[row, col]);
                    //map[row, col] = (TileType)tilemap[row, col];
                }
            }

            //this for loop copies the above 2D array data into "map" as defined at the top of the class
            for (int row = 0; row < tilemap.GetLength(0); row++)
            {
                for (int col = 0; col < tilemap.GetLength(1); col++)
                {
                    var tileVal = GetTileValue(row, col);

                    if (tileVal == TileType.EMPTY)              SetTileValue(row, col, TileType.DOT);
                    
                    if (tileVal == TileType.PLAYERSTART)        CreatePlayer(row, col);
                }
            }
        }



        public void CreatePlayer(int row, int col)
        {
            var rect = GetTileRect(row, col);
            Vector2 pos = new Vector2(rect.x + (rect.width / 2), rect.y + (rect.height / 2));
            player = new Player(this, pos);
            SetTileValue(row, col, TileType.EMPTY);
        }

        public TileType GetTileValue(int row, int col)
        {
            return map[row, col];
        }

        public TileType GetTileValue(Vector2 pos)
        {
            int row = GetYPosToRow(pos.Y);
            int col = GetXPosToCol(pos.X);
            return GetTileValue(row, col);
        }

        public void SetTileValue(int row, int col, TileType newState)
        {
            var oldState = map[row, col];

            //what do the below && if statements mean!?
            if (newState == TileType.DOT && oldState != TileType.DOT)
            {
                numPacDots += 1;
            }

            else if (oldState == TileType.DOT && newState != TileType.DOT)
            {
                numPacDots -= 1;
            }
            
            map[row, col] = newState;
        }

        public void SetTileValue(Vector2 position, TileType value)
        {
            int row = GetYPosToRow(position.Y);
            int col = GetXPosToCol(position.X);
            SetTileValue(row, col, value);
        }

        public Rectangle GetTileRect(int row, int col)
        {
            float xPos = mapOffsetX + (col * tileWidth);
            float yPos = mapOffsetY + (row * tileHeight);
            return new Rectangle(xPos, yPos, tileWidth, tileHeight);
        }

        public Rectangle GetTileRect(Vector2 pos)
        {
            int row = GetYPosToRow(pos.Y);
            int col = GetXPosToCol(pos.X);
            return GetTileRect(row, col);
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

        public Color GetTileColor(int row, int col)
        {
            var tileValue = GetTileValue(row, col);
            if (tileValue == TileType.EMPTY) return Color.BLACK;
            if (tileValue == TileType.WALL) return Color.BLUE;
            if (tileValue == TileType.DOT) return Color.BLACK;

            return Color.PINK;
        }

        public int GetYPosToRow(float yPos)
        {
            //Get row pos by taking ypos of player (e.g. 100) and dividing it by the tile height
            // map offset takes into account the top corner of where we gen. the map
            return (int)((yPos - mapOffsetY) / tileHeight);
        }

        public int GetXPosToCol(float xPos)
        {
            return (int)((xPos - mapOffsetX) / tileWidth);
        }

        public override void Update()
        {
            player.Update();
        }

        public override void Draw()
        {
            DrawMap();
            DrawUI();
            player.Draw();
            player.DebugDraw();

            if (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT_CONTROL))
            {
                DebugDraw();
            }
        }

        private void DrawUI()
        {
            Raylib.DrawText($"SCORE: {score}", 10, 10, 10, Color.WHITE);
            Raylib.DrawText($"LIVES: {lives}", program.windowWidth - 80, 10, 10, Color.WHITE);
        }

        private void DrawMap()
        {
            for (int row = 0; row < map.GetLength(0); row++)
            {

                for (int col = 0; col < map.GetLength(1); col++)
                {
                    var tileValue = GetTileValue(row, col);
                    var tileColor = GetTileColor(row, col);
                    var rect = GetTileRect(row, col);

                    Raylib.DrawRectangleRec(rect, tileColor);
                    
                    if (tileValue == TileType.DOT)
                    {
                        int pacDotSize = 2;
                        Raylib.DrawCircle((int)(rect.x + (rect.width/2)), (int)(rect.y + (rect.height / 2)), pacDotSize, Color.WHITE);
                    }
                }
            }
        }

        void DebugDraw()
        {
            for (int row = 0; row <map.GetLength(0); row++)
            {
                for (int col = 0; col < map.GetLength(1); col++)
                {
                    var rect = GetTileRect(row, col);
                    var color = new Color(255, 255, 255, 125);

                    Raylib.DrawRectangleRec(rect, color);
                    Raylib.DrawRectangleLinesEx(rect, 1, Color.WHITE);

                    int tileID = GetTileID(row, col);
                    int tileVal = (int)GetTileValue(row, col);
                    
                    Raylib.DrawText(tileID.ToString(), (int)(rect.x+2), (int)rect.y, 10, Color.BLACK);
                    Raylib.DrawText(tileVal.ToString(), (int)(rect.x+2), (int)(rect.y + rect.height - 12), 10, Color.BLACK);
                }
            }
        }

        public void EatPacDot(Vector2 pos)
        {
            SetTileValue(pos, TileType.EMPTY);
            score += 10;

            if (numPacDots <= 0)
            {
                LoadLevel();
            }
        }
    }
}
