using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedCitySim
{
    class Citizen
    {
        public string Name { get; set; }
        public int Age { get; set; }
       public bool Gender { get; set; }
        public bool morning = false;

        private enum assignment
        {
            lumberJack,
            priest,
            smith,
            farmer,
            civilWatch,
            miner,
            unassigned
        };

        public int Hunger { get; set; }

        Citizen(string imagePath, Vector2D startPosition, string Name, bool Gender, Enum assignment)
        {
            Hunger = 0;
            Age = 0;
        }

        public void RiskOfDeath(int Age, int Hunger)
        {

            if (morning=true)
            {
             float deathChance = Age*(1+Hunger/10);
              float noDeathChance= 100 - deathChance;
                deathChance;
                noDeathChance;
                Random rnd= new Random();
            }
        }

           

       
       
    }
}
