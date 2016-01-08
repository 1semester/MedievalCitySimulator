using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using IrrKlang;

namespace MedCitySim
{
    class Mine : Building
    {
        /// <summary>
        /// the fields that is used in this class
        /// </summary>
        protected ISoundEngine engine;
        private bool canBuild = true;
        private int speed;
        private int miners;
        public static float workInterval = 5f;
        private float workCooldown;
        public static bool miner = false;
        /// <summary>
        /// the constructor is used to create instanses of the class
        /// </summary>
        /// <param name="imagePath"></param>
        /// <param name="startposition"></param>
        /// <param name="speed"></param>
        public Mine(string imagePath, Vector2D startposition, int speed) : base (imagePath, startposition)
        {
            this.speed = speed;
        }
        /// <summary>
        /// used to determin the work for the building
        /// </summary>
        protected override void Work()
        {
            miners = 0;
            foreach (GameObject go in GameWorld.objs)
            {
                var citizen = go as Citizen;


                if (citizen != null && citizen.currentAssignment == Citizen.Assignment.miner)
                {
                    miners++;

                }
            }
            GameWorld.Iron += miners;

        }
        /// <summary>
        /// checks the collision and determins if you can or cannot place the building
        /// </summary>
        /// <param name="other"></param>
        protected override void OnCollision(GameObject other)
        {
            if (other is Building || other is UserInterface)
            {
                canBuild = false;
            }
            else if (other is Mountain)
            {
                canBuild = true;
            }
        }
        /// <summary>
        /// Cost is used to pull resource from GameWorld
        /// </summary>
        protected override void Cost()
        {
            GameWorld.Lumber -= 50;
            GameWorld.Stone -= 10;
            GameWorld.Stone -= 2;
            base.Cost();
        }
        /// <summary>
        /// update every loop and run the work method after the object is placed
        /// </summary>
        /// <param name="currentFPS"></param>
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
                    miner = true;
                }
                else if (true)
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
                    workCooldown += workInterval;
                }
            }

            base.Update(currentFPS);
        }
        /// <summary>
        /// used to play a sound every time you cant build a building 
        /// </summary>
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
