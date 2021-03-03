using System;
using Raylib_cs;

namespace AIE_51_TileMapEditor
{
    class Program
    {
        public int windowWidth = 800;
        public int windowHeight = 450;

        Tile tile;

        static void Main(string[] args)
        {
            Program program = new Program();
            program.RunGame();
        }

        void RunGame()
        {
            Raylib.InitWindow(windowWidth, windowHeight, "Straya");
            Raylib.SetTargetFPS(60);

            LoadGame();

            while(!Raylib.WindowShouldClose())
            {
                Update();
                Draw();
            }
        }

        void LoadGame()
        {
            tile = new Tile(this);
        }

        void Update()
        {
            tile.Update();
        }

        void Draw()
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.BLACK);

            if (tile != null)
            {
                tile.Draw();
            }

            Raylib.DrawFPS(windowWidth - 100, 20);
            Raylib.EndDrawing();
        }
    }
}
