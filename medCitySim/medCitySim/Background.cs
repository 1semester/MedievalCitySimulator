using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MedCitySim
{
    class Background : GameObject
    {
        /// <summary>
        /// The background is a class that is used to check for buildings if they can be build, in each buildings OnCollision method.
        /// </summary>
        /// <param name="imagePath"></param>
        /// <param name="startPosition"></param>
        public Background(string imagePath, Vector2D startPosition) : base (imagePath, startPosition){}
    }
}
