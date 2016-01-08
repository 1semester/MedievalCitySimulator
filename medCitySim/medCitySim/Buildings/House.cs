using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using IrrKlang;

namespace MedCitySim
{
    class House : Building
    {
        /// <summary>
        /// the fields that is used in this class
        /// </summary>
        protected ISoundEngine engine;
        private bool canBuild = true;
        private int speed;
        /// <summary>
        /// the constructor is used to create instanses of the class
        /// </summary>
        /// <param name="imagePath"></param>
        /// <param name="startposition"></param>
        /// <param name="speed"></param>
        public House(string imagePath, Vector2D startposition, int speed) : base(imagePath, startposition)
        {
            this.speed = speed;
        }
        /// <summary>
        /// used to determin the work for the building
        /// </summary>
        protected override void Work()
        {
            base.Work();
        }
        /// <summary>
        /// checks the collision and determins if you can or cannot place the building
        /// </summary>
        /// <param name="other"></param>
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
        /// <summary>
        /// Cost is used to pull resource from GameWorld
        /// </summary>
        protected override void Cost()
        {
            GameWorld.Lumber -= 30;
            GameWorld.Stone -= 15;
            base.Cost();
        }
        /// <summary>
        /// update every loop
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
                    GameWorld.CitizenCap += 4;
                    if (!ResearchMenu.ImprovedHouse)
                    {
                        GameWorld.CitizenCap += 4;
                    }
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
