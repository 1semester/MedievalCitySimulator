using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using IrrKlang;


namespace MedCitySim
{
    class Lumbermill : Building
    {
        protected ISoundEngine engine;
        private bool canBuild = true;
        private int speed;
        private int lumberjacks;
        private float workCooldown;
        public static bool lumberjack = false;
        public static float workInterval = 5;

        public Lumbermill(string imagePath, Vector2D startposition, int speed) : base(imagePath,startposition)
        {
            this.speed = speed;
        }
        protected override void Work()
        {
            lumberjacks = 0;
            
            foreach (GameObject go in GameWorld.objs)
            {
                var citizen = go as Citizen;


                if (citizen != null && citizen.currentAssignment == Citizen.Assignment.lumberJack)
                {
                    lumberjacks++;

                }
            }
            GameWorld.Lumber += lumberjacks;

        }
        protected override void OnCollision(GameObject other)
        {
            if (other is Building || other is UserInterface || other is Mountain || other is Forest)
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
            GameWorld.Lumber -= 50;
            GameWorld.Stone -= 10;
            GameWorld.Iron -= 2;
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
                    lumberjack = true;
                }
                else if (!canBuild)
                {
                    CantBuild();
                }
            }
            if (Keyboard.IsKeyPressed(System.Windows.Forms.Keys.Escape))
            {
                if (speed > 0)
                {
                    GameWorld.ToRemove.Add(this);
                }
            }
            if (speed == 0)
            {
                float deltaTime = 1f / currentFPS;

                workCooldown -= deltaTime;
                
                if (workCooldown <= 0)
                {
                    Work();
                    
                    workCooldown += WorkTimer(workInterval);
                }
            }

            base.Update(currentFPS);
        }
        protected void CantBuild()
        {
            try
            {
                engine = new ISoundEngine();
                engine.Play2D("Media/efx_NO-Fabio_Farinelli-955789468.mp3", false);
            }
            catch (Exception ex) { }
        }
    }
}
