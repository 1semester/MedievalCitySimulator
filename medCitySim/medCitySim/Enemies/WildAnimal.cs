using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedCitySim
{
    class WildAnimal : Enemy
    {
        private int health;
        private int dmg;
        public WildAnimal(string imagePath, Vector2D startPosition, int health, int dmg) : base(imagePath, startPosition)
        {
            this.dmg = dmg;
            this.health = health;
        }
        protected override void OnCollision(GameObject other)
        {
            throw new NotImplementedException();
        }
    }
}
