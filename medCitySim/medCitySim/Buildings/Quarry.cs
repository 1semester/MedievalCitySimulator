using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedCitySim
{
    class Quarry : Building
    {
        private int speed;
        public Quarry(string imagePath, Vector2D startposition, int speed): base(imagePath, startposition)
        {
            this.speed = speed;
        }
        protected override void Work()
        {
            base.Work();
        }
        public override void OnCollision(GameObject other)
        {
            base.OnCollision(other);
        }
        protected override void Cost()
        {
            GameWorld.Lumber -= 2;
            GameWorld.Stone -= 3;
            base.Cost();
        }
        public override void Update(float currentFPS)
        {
            if (Keyboard.IsKeyDown(System.Windows.Forms.Keys.A))
            {
                position.X -= (1 / currentFPS) * speed;
            }
            if (Keyboard.IsKeyDown(System.Windows.Forms.Keys.D))
            {
                position.X += (1 / currentFPS) * speed;
            }
            if (Keyboard.IsKeyDown(System.Windows.Forms.Keys.W))
            {
                position.Y -= (1 / currentFPS) * speed;
            }
            if (Keyboard.IsKeyDown(System.Windows.Forms.Keys.S))
            {
                position.Y += (1 / currentFPS) * speed;
            }
            if (Keyboard.IsKeyDown(System.Windows.Forms.Keys.Space))
            {
                speed = 0;
            }
            base.Update(currentFPS);
        }
    }
}
