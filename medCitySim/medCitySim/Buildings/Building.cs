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
        public Building(string imagepPath, Vector2D position): base (imagepPath,position)
        {
        }
        protected virtual void Work()
        {
        }
        protected virtual void Cost()
        {
        }
        protected void BuildSound()
        {
            try
            {
                engine = new ISoundEngine();
                engine.Play2D("Media/Construction.mp3", false);
            }
            catch(Exception ex) { }
        }
    }
}
