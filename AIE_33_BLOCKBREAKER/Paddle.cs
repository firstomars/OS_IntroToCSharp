using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using Raylib_cs;

namespace AIE_33_BLOCKBREAKER
{
    class Paddle
    {
        public Vector2 paddleSize = new Vector2(100, 10);
        public Vector2 paddlePos = new Vector2();
        public float paddleSpeed = 5.0f;

        public KeyboardKey leftKey;
        public KeyboardKey rightKey;
    }
}
