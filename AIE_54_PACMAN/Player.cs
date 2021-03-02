using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using Raylib_cs;

namespace AIE_54_PACMAN
{
    class Player
    {
        Vector2 position;// = new Vector2(); - why don't need this?
        Vector2 direction = new Vector2(0, 0);

        float maxSpeed = 4.0f;
        float speed = 4.0f;
        float lerpTime = 0;
        Vector2 startTilePos;
        Vector2 endTilePos;

        GameLevelScreen level;

        public Player(GameLevelScreen lev, Vector2 pos)
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


            if (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT)) direction = new Vector2(-1, 0);
            if (Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT)) direction = new Vector2(1, 0);
            if (Raylib.IsKeyDown(KeyboardKey.KEY_UP)) direction = new Vector2(0, -1);
            if (Raylib.IsKeyDown(KeyboardKey.KEY_DOWN)) direction = new Vector2(0, 1);

            //trying to get my head around this
            //once we reach endTile, we are resetting lerptime
            //this sets the startTile to the new Currenttile.
            //end tile is now set to the next tile

            //what is happening when there is now end tile set? 
            //there will always be an end tile set, it's just that the player speed = 0


            lerpTime += Raylib.GetFrameTime() * speed;
            if (lerpTime > 1 || speed == 0.0f)
            {
                lerpTime = 0;
                startTilePos = GetCurrentTilePos();
                endTilePos = GetNextTilePos();

                var endTileValue = level.GetTileValue(endTilePos);

                speed = maxSpeed;
                if (endTileValue == TileType.WALL)
                {
                    speed = 0.0f;
                }
            }

            position = Vector2.Lerp(startTilePos, endTilePos, lerpTime);

            int newCurrentTile = level.GetTileID(position);
            if(currentTile != newCurrentTile)
            {
                OnTileEnter(newCurrentTile);
            }
        }

        public void Draw()
        {
            Raylib.DrawCircle((int)position.X, (int)position.Y, 12, Color.YELLOW);
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
            var tileValue = level.GetTileValue(position);

            if (tileValue == TileType.DOT)
            {
                level.EatPacDot(position);
            }
        }
    }
}
