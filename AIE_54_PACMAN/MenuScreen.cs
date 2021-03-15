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

            int stringWidth = Raylib.MeasureText("PAC MAN", 50);
            Raylib.DrawText("PAC MAN", (program.windowWidth - stringWidth)/2, program.windowHeight / 2, 50, Color.WHITE);
            Raylib.DrawText("Press 'ENTER' to start...", 20, (program.windowHeight / 2) + 50, 25, Color.WHITE);
            Raylib.DrawText("Press 'SPACE' to view high scores...", 20, (program.windowHeight / 2) + 100, 25, Color.WHITE);

            

        }
    }
}
