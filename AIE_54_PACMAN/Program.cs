using System;
using Raylib_cs;

namespace AIE_54_PACMAN
{
    class Program
    {
        public int windowWidth = 800;
        public int windowHeight = 1000;
        public string windowTitle = "PacMan";

        public string playerName = "TEST NAME";

        IGameState currentGameState;

        static void Main(string[] args)
        {
            Program program = new Program();
            program.RunGame();
        }

        void RunGame()
        {
            Raylib.InitWindow(windowWidth, windowHeight, windowTitle);
            Raylib.SetTargetFPS(60);

            LoadGame();

            while (!Raylib.WindowShouldClose())
            {
                Draw();
                Update();
                
            }

            Raylib.CloseWindow();
        }

        void LoadGame()
        {
            currentGameState = new MenuScreen(this);
        }

        void Update()
        {
            if (currentGameState != null)
            {
                currentGameState.Update();
            }
        }

        void Draw()
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.BLACK);

            if (currentGameState != null)
            {
                currentGameState.Draw();
            }

            Raylib.EndDrawing();
            Raylib.DrawFPS(10, windowHeight - 30);
        }

        public void ChangeGameState(IGameState newGameState)
        {
            currentGameState = newGameState;
        }
    }
}
