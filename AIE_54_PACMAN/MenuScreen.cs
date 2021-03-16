using System;
using System.Collections.Generic;
using System.Text;
using Raylib_cs;

namespace AIE_54_PACMAN
{
    class MenuScreen : IGameState
    {
        public MenuScreen(Program p) : base (p)
        {
            //loadlevel() from here
        }

        public override void Update()
        {
            if (Raylib.IsKeyPressed(KeyboardKey.KEY_ENTER))
            {
                program.ChangeGameState(new EnterNameScreen(program));
            }

            if (Raylib.IsKeyPressed(KeyboardKey.KEY_SPACE))
            {
                program.ChangeGameState(new HighScoreScreen(program));
            }
        }

        public override void Draw()
        {
            Raylib.ClearBackground(Color.BLUE);
            int stringTitleWidth = Raylib.MeasureText("PAC MAN", 50);
            var stringWidth = Raylib.MeasureTextEx(Raylib.GetFontDefault(), "Press 'ENTER' to play Pac Man...", 25, 1);
            
            Raylib.DrawText("PAC MAN", (program.windowWidth - stringTitleWidth)/2, 20, 50, Color.WHITE);
            Raylib.DrawText("Press 'ENTER' to play Pac Man...", (program.windowWidth - (int)stringWidth.X)/2, program.windowHeight - 200, 25, Color.WHITE);
            Raylib.DrawText("Press 'SPACE' for high scores...", (program.windowWidth - (int)stringWidth.X) / 2, program.windowHeight - 200 + (int)stringWidth.Y, 25, Color.WHITE);
        }
    }
}
