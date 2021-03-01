using System;
using System.Collections.Generic;
using System.Text;

namespace AIE_54_PACMAN
{
    class IGameState
    {
        //parent GameState class - allow child game state classes to inherit from this class

        protected Program program;

        public IGameState(Program p)
        {
            this.program = p;
        }

        public virtual void Update()
        {

        }

        public virtual void Draw()
        {

        }
    }
}
