using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedCitySim
{
    abstract class Enemy : GameObject
    {
        //To enemies har dmg og health, det er Raider og WildAnimal.
      
        public Enemy(string imagePath, Vector2D position) : base(imagePath, position)
        {

        }
        public override void Update(float fps)
        {

        }

        protected override void OnCollision(GameObject other)
        {
            base.OnCollision(other);
        }
    }
}
