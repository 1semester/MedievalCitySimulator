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
        protected int dmg;
        protected int health;

        public int Dmg
        {
            get
            {
                return dmg;
            }

            set
            {
                dmg = value;
            }
        }

        public int Health
        {
            get
            {
                return health;
            }

            set
            {
                health = value;
            }
        }
        public Enemy(string imagePath, Vector2D startPosition) : base(imagePath, startPosition)
        {

        }
        public void Update(float fps)
        {

        }
    }
}
