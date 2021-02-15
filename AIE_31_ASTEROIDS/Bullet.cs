using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using Raylib_cs;

namespace AIE_32_ASTEROIDS
{
    class Bullet : GameObject
    {
        public Vector2 dir = new Vector2();
        public float speed = 10;

        //Program program;
        //public Vector2 pos = new Vector2();


        public Bullet(Program program, Vector2 pos, Vector2 dir) : base(program, pos)
        {
            //this.program = program;
            //this.pos = pos;
            this.dir = dir;
        }

        public override void Update()
        {
            pos += dir * speed;

            if (pos.X < 0) pos.X = program.windowWidth;
            if (pos.X > program.windowWidth) pos.X = 0;
            if (pos.Y < 0) pos.Y = program.windowHeight;
            if (pos.Y > program.windowHeight) pos.Y = 0;
        }

        public override void Draw()
        {
            Raylib.DrawLine((int)pos.X, (int)pos.Y, (int)(pos.X - dir.X * speed), (int)(pos.Y - dir.Y * speed), Color.BROWN);

            //Raylib.DrawTriangle((new Vector2(0, 0)), new Vector2(80, 80), new Vector2(40, 40), Color.BLACK);

        }
    }
}
