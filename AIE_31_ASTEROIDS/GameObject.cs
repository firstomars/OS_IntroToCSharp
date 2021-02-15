using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace AIE_32_ASTEROIDS
{
    class GameObject
    {
        protected Program program;
        
        public Vector2 pos = new Vector2();

        public GameObject(Program program)
        {
            this.program = program;
        }

        // why do we have a general one and a specific one?

        public GameObject(Program program, Vector2 pos)
        {
            this.pos = pos;
            this.program = program;
        }

        public virtual void Update()
        {

        }

        public virtual void Draw()
        {

        }

    }
}
