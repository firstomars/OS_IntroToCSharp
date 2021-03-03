using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace AIE_54_PACMAN
{
    class Ghost
    {
        public Vector2 position;
        public int ghostWidth = 12;
        public int ghostHeight = 12;

        Vector2 direction = new Vector2(0, 0);

        float speed = 1.0f;
        float lerpTime = 0;
        Vector2 startTilePos;
        Vector2 endTilePos;

        Random rand = new Random();

        GameLevelScreen level;

        public Ghost(GameLevelScreen lev, Vector2 pos)
        {
            this.level = lev;
            this.position = pos;

            startTilePos = GetCurrentTilePos();
            endTilePos = GetNextTilePos();

        }

        Vector2 GetCurrentTilePos()
        {
            int row = level.GetYPosToRow(position.Y);
            int col = level.GetXPosToCol(position.X);

            var rect = level.GetTileRect(row, col);

            return new Vector2(rect.x + rect.width / 2, rect.y + rect.height / 2);
        }

        Vector2 GetNextTilePos()
        {
            int row = level.GetYPosToRow(position.Y) + (int)direction.Y;
            int col = level.GetXPosToCol(position.X) + (int)direction.X;

            var rect = level.GetTileRect(row, col);

            return new Vector2(rect.x + rect.width / 2, rect.y + rect.height / 2);
        }

        public void Update()
        {
            int currentTile = level.GetTileID(position);

            //trying to get my head around this
            //once we reach endTile, we are resetting lerptime
            //this sets the startTile to the new Currenttile.
            //end tile is now set to the next tile

            //what is happening when there is now end tile set? 
            //there will always be an end tile set, it's just that the player speed = 0
            //}

            lerpTime += Raylib.GetFrameTime() * speed;
            if (lerpTime > 1)
            {
                //get current location
                int row = level.GetYPosToRow(position.Y);
                int col = level.GetXPosToCol(position.X);

                //list of avail dirs
                List<Vector2> availDirs = new List<Vector2>();

                //work out what possible directions there are
                //is tileVal of tileUp/Down/Left/Right != TileType.WALL add to list if true
                if (level.GetTileValue(row + 1, col) != TileType.WALL)      availDirs.Add(new Vector2(0, 1));
                if (level.GetTileValue(row - 1, col) != TileType.WALL)      availDirs.Add(new Vector2(0, -1));
                if (level.GetTileValue(row, col - 1) != TileType.WALL)      availDirs.Add(new Vector2(-1, 0));
                if (level.GetTileValue(row, col + 1) != TileType.WALL)      availDirs.Add(new Vector2(1, 0));

                //randomly select an availDir
                int randomDirection = rand.Next(0,availDirs.Count);
                direction = availDirs.Count == 0 ? new Vector2(0,0) : availDirs[randomDirection];

                lerpTime = 0;
                startTilePos = GetCurrentTilePos();
                endTilePos = GetNextTilePos();

                var endTileValue = level.GetTileValue(endTilePos);
                Console.WriteLine(endTileValue);
            }

            position = Vector2.Lerp(startTilePos, endTilePos, lerpTime);

            int newCurrentTile = level.GetTileID(position);
            if (currentTile != newCurrentTile)
            {
                OnTileEnter(newCurrentTile);
            }
        }

        
        public void Draw()
        {
            Raylib.DrawRectangleRec(new Rectangle(position.X - 6, position.Y - 6, ghostWidth, ghostHeight), Color.ORANGE);
            DebugDraw();
        }

        public void DebugDraw()
        {
            //translate player position into row / col value
            var rect = level.GetTileRect(position);
            Raylib.DrawRectangleLinesEx(rect, 3, Color.YELLOW);

            Raylib.DrawCircle((int)startTilePos.X, (int)startTilePos.Y, 3, Color.RED);
            Raylib.DrawCircle((int)endTilePos.X, (int)endTilePos.Y, 3, Color.RED);
            Raylib.DrawLineEx(startTilePos, endTilePos, 3, Color.RED);
            Raylib.DrawCircle((int)position.X, (int)position.Y, 2, Color.BLACK);
        }

        void OnTileEnter(int tileId)
        {

        }
    }
}
