using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using IrrKlang;

namespace MedCitySim
{
    abstract class Building : GameObject
    {
        protected List<Citizen> citizens;
        protected ISoundEngine engine;
        private float workInterval;
        /// <summary>
        /// This construter makes sure that all buildings have an imagePath and a position.
        /// </summary>
        /// <param name="imagepPath"></param>
        /// <param name="position"></param>
        public Building(string imagepPath, Vector2D position): base (imagepPath,position){}
        /// <summary>
        /// All buildings have a unique work method.
        /// </summary>
        protected virtual void Work(){}
        /// <summary>
        /// All buildings have a unique Cost method.
        /// </summary>
        protected virtual void Cost(){}
        /// <summary>
        /// This method holds the sound that is played when the player builds a building.
        /// </summary>
        protected void BuildSound()
        {
            try
            {
                engine = new ISoundEngine();
                engine.Play2D("Media/Construction.mp3", false);
            }
            catch(Exception ex) { }
        }
        /// <summary>
        /// The worktimer controles the time it takes to make a ressource.
        /// </summary>
        /// <param name="WorkInterval"></param>
        /// <returns></returns>
        protected virtual float WorkTimer(float WorkInterval)
        {
            float WorkTimer = WorkInterval;
            if (Witch.witchAlive == true)
            {
                WorkTimer = WorkInterval * 2;
            }
            return WorkTimer;
        }
    }
}
