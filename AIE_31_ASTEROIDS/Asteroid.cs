using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using Raylib_cs;

namespace AIE_32_ASTEROIDS
{
    class Asteroid
    {
        public Vector2 pos = new Vector2();
        public Vector2 dir = new Vector2();
        public float radius = 40;

        public int asteroidDestroyScoreAmount = 50;

        Program program;

        public Asteroid(Program program, Vector2 pos, Vector2 dir, float radius) 
            // Constructor - so calling this function, call the class? object instantiation?
        {
            this.program = program;
            this.pos = pos;
            this.dir = dir;
        }

        public void Update()
        {
            pos += dir;

            //wrap around the screen
            if (pos.X < 0) pos.X = program.windowWidth;
            if (pos.X > program.windowWidth) pos.X = 0;
            if (pos.Y < 0) pos.Y = program.windowHeight;
            if (pos.Y > program.windowHeight) pos.Y = 0;
        }

        public void Draw()
        {
            Color c = new Color(255, 255, 255, 100);
            
            //Raylib.DrawCircle((int)pos.X, (int)pos.Y, radius, Color.WHITE);

            Raylib.DrawCircle((int)pos.X, (int)pos.Y, radius, c);
        }
    }
}
