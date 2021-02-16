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
        public Vector2 dir = new Vector2(1, 0);

 
        public GameObject(Program program)
        {
            this.program = program;
        }

        // why do we have a general one and a specific one?

        public GameObject(Program program, Vector2 pos, Vector2 dir = new Vector2())
        {

            this.pos = pos;
            this.dir = dir;
            this.program = program;
        }

        public virtual void Update()
        {

        }

        public virtual void Draw()
        {

        }

        public float GetRotation()
        {
            return MathF.Atan2(dir.Y, dir.X) * (180.0f / MathF.PI);
        }

        public void SetRotation(float rot)
        {
            dir = new Vector2(
                MathF.Cos(rot * (MathF.PI / 180.0f)),
                MathF.Sin(rot * (MathF.PI / 180.0f))
            );
        }

        public void Rotate(float amount)
        {
            float rot = GetRotation() + amount;
            SetRotation(rot);
        }

    }
}
