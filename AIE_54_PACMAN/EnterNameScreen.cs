using System;
using System.Collections.Generic;
using System.Text;
using Raylib_cs;

namespace AIE_54_PACMAN
{
    class EnterNameScreen : IGameState
    {
        string nameInput = "";
        bool nameConfirmed = false;

        public EnterNameScreen(Program p) : base(p)
        {
            
        }

        public override void Update()
        {
            SaveNameInput();

            if (Raylib.IsKeyPressed(KeyboardKey.KEY_ENTER) && nameConfirmed == true)
            {
                program.ChangeGameState(new GameLevelScreen(program));
            }
        }

        public override void Draw()
        {
            DrawRequestForName();

            DrawNameInput();

            Raylib.DrawText("Press Enter to confirm your name.", program.windowWidth - 400, (program.windowHeight / 2) + 200, 30, Color.WHITE);
        }
        private void SaveNameInput()
        {
            var key = Raylib.GetCharPressed();
            while (key > 0)
            {
                if (key >= 32 && key <= 125)
                {
                    nameInput += (char)key;
                }
                key = Raylib.GetCharPressed(); //sets key back to next input

                nameConfirmed = true;
            }

            

            program.playerName = nameInput;

        }

        private void DrawNameInput()
        {
            Raylib.DrawText
                (nameInput.ToUpper(),
                program.windowWidth - 400,
                (program.windowHeight / 2) + 100,
                30, Color.YELLOW);
        }

        private void DrawRequestForName()
        {
            Raylib.DrawText
                ("What's your name?",
                program.windowWidth - 400,
                program.windowHeight / 2,
                40, Color.WHITE);
        }
    }
}
