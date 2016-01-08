using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedCitySim
{
    class Mountain : GameObject
    {
        /// <summary>
        /// The mountain class is made solely to make sure that the player only can build the Quarry and Mine
        /// </summary>
        /// <param name="imagePath"></param>
        /// <param name="startPosition"></param>
        public Mountain(string imagePath, Vector2D startPosition) : base(imagePath, startPosition)
        {
        }
    }
}
