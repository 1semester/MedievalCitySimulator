using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedCitySim
{
    abstract class Enemy : GameObject
    {
        
      /// <summary>
      /// constructor for superclass
      /// </summary>
      /// <param name="imagePath"> imagepath for sprite</param>
      /// <param name="position"> startposition in vector2D</param>
        public Enemy(string imagePath, Vector2D position) : base(imagePath, position)
        {

        }
        /// <summary>
        /// updates each loop
        /// </summary>
        /// <param name="fps">fps is calculated in gameworld</param>
        public override void Update(float fps)
        {

        }
        /// <summary>
        /// used from base class  for colssion  migh be redundant
        /// </summary>
        /// <param name="other"></param>
        protected override void OnCollision(GameObject other)
        {
            base.OnCollision(other);
        }
    }
}
