using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedCitySim
{
    class Raider : Enemy
    {
        private int health;
        private int dmg;
        public Raider(string imagePath, Vector2D startPostition, int health, int dmg) : base(imagePath, startPostition)
        {
            this.health = health;
            this.dmg = dmg;
        }
    }
}
