using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedCitySim
{
    abstract class Building : GameObject
    {
        protected List<Citizen> citizens;

        public Building(string imagepPath, Vector2D startPosition): base (imagepPath,startPosition)
        {

        }
        protected virtual void Work()
        {
        }
        protected virtual void Cost()
        {

        }
    }
}
