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

        Citizen(string imagePath, Vector2D startPosition, int Age, string Name, bool Gender, Enum assignment)
        {
            
        }

        public void RiskOfDeath(int Age, int Hunger)
        {
            
        }
       
    }
}
