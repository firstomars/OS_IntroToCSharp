using System;
using System.Collections.Generic;
using System.Text;
using Raylib_cs;

namespace AIE_54_PACMAN
{
    class EnterNameScreen : IGameState
    {
        
        public EnterNameScreen(Program p) : base(p)
        {
            
        }

        public override void Update()
        {
            //program.playerName = Console.ReadLine();
            //DrawPlayerName();

            if (Raylib.IsKeyPressed(KeyboardKey.KEY_SPACE)) // && at least one character entered
            {
                program.ChangeGameState(new GameLevelScreen(program));
            }
        }
        public override void Draw()
        {
            Raylib.DrawText
                ("What's your name?",
                program.windowWidth - 400,
                program.windowHeight / 2,
                40, Color.WHITE);
        }

        private void DrawPlayerName()
        {
            Raylib.DrawText(program.playerName, program.windowWidth - 400, (program.windowHeight / 2) + 100, 40, Color.WHITE);
        }



        void CollectName()
        {
            program.playerName = Console.ReadLine();
        }
    }
}
