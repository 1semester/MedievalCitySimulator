using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedCitySim
{
    class Forest : GameObject
    {
        /// <summary>
        /// The forest class is made solely to make sure the player only can build lumbermills on the forest.
        /// </summary>
        /// <param name="imagePath"></param>
        /// <param name="startPosition"></param>
        public Forest(string imagePath, Vector2D startPosition) : base(imagePath, startPosition)
        {

        }
    }
}
