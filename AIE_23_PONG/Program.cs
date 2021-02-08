using System;
using Raylib_cs;
using System.Numerics;

namespace AIE_23_PONG
{

    class Ball
    {
        public Vector2 pos = new Vector2();
        public Vector2 dir = new Vector2();
        public float speed = 5.0f;
        public float radius = 10.0f;
    }


    class Program
    {
        int windowWidth = 800;
        int windowHeight = 450;
        Ball ball;

        static void Main(string[] args)
        {
            Program p = new Program(); // what does this do?
            p.RunProgram();
        }

        void RunProgram()
        {
            Raylib.InitWindow(windowWidth, windowHeight, "Pong");

            LoadGame();

            while (!Raylib.WindowShouldClose())
            {
                Update();
                Draw();
            }

            Raylib.CloseWindow();
        }

        void LoadGame()
        {
            ball = new Ball();
            ball.pos.X = windowWidth / 2;
            ball.pos.Y = windowHeight / 2;
            ball.dir.X = 0.707f;
            ball.dir.Y = 0.707f;

        }

        void Update()
        {
            ball.pos.X += ball.dir.X * ball.speed;
            ball.pos.Y += ball.dir.Y * ball.speed;
        }

        void Draw() 
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.DARKGREEN);
            Raylib.EndDrawing();
            Raylib.DrawCircle((int)ball.pos.X, (int)ball.pos.Y, ball.radius, Color.DARKBLUE);
        }

    }

}
