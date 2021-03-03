using System;
using System.Collections.Generic;
using System.Text;

namespace AIE_55_GameStates
{
    class GameState
    {
        //child classes
        //splash screen
        //menu screen
        //playgame screen

        protected Program program;

        public GameState(Program p)
        {
            this.program = p;
        }

        public virtual void Update()
        {
            //leave empty as only important what child classes do
        }

        public virtual void Draw()
        {
            //leave empty as only important what child classes do
        }
    }
}
