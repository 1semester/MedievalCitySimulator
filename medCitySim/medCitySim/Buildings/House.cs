using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MedCitySim
{
    class House : Building
    {
        private Graphics dc;
        //private static List<Citizen> population = new List<Citizen>(4);
        private bool canBuild = true;
        private int speed;
        public House(string imagePath, Vector2D startposition, int speed, Graphics dc) : base(imagePath, startposition)
        {
            this.dc = dc;
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
            else if (other is Background)
            {
                canBuild = true;
            }
        }
        protected override void Cost()
        {
            GameWorld.Lumber -= 30;
            GameWorld.Stone -= 15;
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
                    GameWorld.CitizenCap += 4;
                }
            }
            if (Keyboard.IsKeyPressed(System.Windows.Forms.Keys.Escape))
            {
                if (speed > 0)
                {
                    GameWorld.ToRemove.Add(this);
                }
            }

            //if (ResearchMenu.ImprovedHouse == false)
            //{
            //    foreach (GameObject go in GameWorld.objs)
            //    {
            //        var house = go as House;


            //        if (house != null)
            //        {
            //            GameWorld.CitizenCap = 4;
            //        }
            //    }
            //}


            base.Update(currentFPS);
        }
    }
}
