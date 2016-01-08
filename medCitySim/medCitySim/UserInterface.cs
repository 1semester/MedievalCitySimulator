using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedCitySim
{
    class UserInterface : GameObject
    {
        /// <summary>
        /// solely a visual class, made to be drawn for player appreciation.
        /// </summary>
        /// <param name="imagePath"></param>
        /// <param name="startPosition"></param>
        public UserInterface(string imagePath, Vector2D startPosition) : base (imagePath, startPosition)
        {

        }
    }
}
