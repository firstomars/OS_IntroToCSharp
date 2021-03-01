using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using Raylib_cs;

namespace AIE_54_PACMAN
{
    class Player
    {
        //Program program;
        Vector2 pos;// = new Vector2(); - why don't need this?
        Vector2 dir = new Vector2(0,0);
        //Vector2 velocity = new Vector2(0, 0);

        public Player(Vector2 position)
        {
            //this.program = program;
            this.pos = position;
        }

        public virtual void Update()
        {
            if (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT))         dir = new Vector2(-1, 0);
            if (Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT))        dir = new Vector2(1, 0);
            if (Raylib.IsKeyDown(KeyboardKey.KEY_UP))           dir = new Vector2(0, -1);
            if (Raylib.IsKeyDown(KeyboardKey.KEY_DOWN))         dir = new Vector2(0, 1);
            pos += dir;
        }

        public virtual void Draw()
        {
            Raylib.DrawCircle((int)pos.X, (int)pos.Y, 12, Color.YELLOW);
        }
    }
}
