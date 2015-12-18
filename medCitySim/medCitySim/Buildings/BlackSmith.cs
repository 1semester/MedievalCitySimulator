using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MedCitySim
{
    class Blacksmith : Building
    {
        private Graphics dc;
        private bool canBuild = true;
        private int speed;
        public static bool blacksmith = false;
        public Blacksmith(string imagePath, Vector2D startposition, int speed) : base(imagePath, startposition)
        {
            this.speed = speed;
        }
        protected override void Work()
        {
            base.Work();
        }
        protected override void OnCollision(GameObject other)
        {
            if (other is Building || other is UserInterface)
            {
                canBuild = false;
            }
            else
            {
                canBuild = true;
            }
        }
        protected override void Cost()
        {
            GameWorld.Lumber -= 5;
            GameWorld.Stone -= 5;
            base.Cost();
        }
        public override void Update(float currentFPS)
        {
            if (Keyboard.IsKeyDown(System.Windows.Forms.Keys.Left))
            {
                position.X -= (1 / currentFPS) * speed;
            }
            if (Keyboard.IsKeyDown(System.Windows.Forms.Keys.Right))
            {
                position.X += (1 / currentFPS) * speed;
            }
            if (Keyboard.IsKeyDown(System.Windows.Forms.Keys.Up))
            {
                position.Y -= (1 / currentFPS) * speed;
            }
            if (Keyboard.IsKeyDown(System.Windows.Forms.Keys.Down))
            {
                position.Y += (1 / currentFPS) * speed;
            }

            if (Keyboard.IsKeyPressed(System.Windows.Forms.Keys.Space))
            {
                if (canBuild == true && speed > 0)
                {
                    speed = 0;
                    Cost();
                    BuildSound();
                    blacksmith = true;
                }
            }
            if (Keyboard.IsKeyPressed(System.Windows.Forms.Keys.Escape))
            {
                if (speed > 0)
                {
                    GameWorld.ToRemove.Add(this);
                }
            }
            base.Update(currentFPS);
        }
    }
}
