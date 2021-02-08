using System;
using Raylib_cs;

namespace AIE_29_GameSettings_RL
{
    class Program
    {
        GameSettings c = new GameSettings();
        Sprite s = new Sprite();
        
        static void Main(string[] args)
        {
            Program p = new Program();
            p.RunProgram();
        }

        public void RunProgram()
        {
            Raylib.InitWindow(c.windowWidth, c.windowHeight, c.windowTitle);

            while (!Raylib.WindowShouldClose())
            {
                LoadGame();
                Update();
                Draw();
                s.Draw();
            }

            Raylib.CloseWindow();
        }

        public void LoadGame()
        {
            s = new Sprite();
            s.pos.X = c.windowWidth / 2;
            s.pos.Y = c.windowHeight / 2;
        }

        public void Update()
        {

        }

        public void Draw()
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.BLACK);
            Raylib.EndDrawing();
            //s.DrawRectangle();
        }


        
    }
}
