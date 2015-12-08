using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedCitySim
{
    class CivilWatch : Building
    {
        private int speed;

        public CivilWatch(string imagePath, Vector2D startposition, int speed) : base(imagePath, startposition)
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
                startPosition.X -= (1 / currentFPS) * speed;
            }
            if (Keyboard.IsKeyDown(System.Windows.Forms.Keys.D))
            {
                startPosition.X += (1 / currentFPS) * speed;
            }
            if (Keyboard.IsKeyDown(System.Windows.Forms.Keys.W))
            {
                startPosition.Y -= (1 / currentFPS) * speed;
            }
            if (Keyboard.IsKeyDown(System.Windows.Forms.Keys.S))
            {
                startPosition.Y += (1 / currentFPS) * speed;
            }
            if (Keyboard.IsKeyDown(System.Windows.Forms.Keys.Space))
            {
                speed = 0;
            }
            base.Update(currentFPS);
        }
    }
}
