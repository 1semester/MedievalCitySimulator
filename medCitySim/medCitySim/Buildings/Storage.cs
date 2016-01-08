using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedCitySim
{
    class Storage : Building
    {
        /// <summary>
        /// the constructor is used to create instanses of the class
        /// </summary>
        /// <param name="imagePath"></param>
        /// <param name="startposition"></param>
        /// <param name="speed"></param>
        public Storage(string imagePath, Vector2D startposition) : base(imagePath, startposition)
        {
        }
        /// <summary>
        /// is not used in this building
        /// </summary>
        /// <param name="other"></param>
        protected override void OnCollision(GameObject other)
        {
        }
        /// <summary>
        /// is not used in this building
        /// </summary>
        /// <param name="currentFPS"></param>
        public override void Update(float currentFPS)
        {
            base.Update(currentFPS);
        }
    }
}
