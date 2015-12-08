using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace MedCitySim
{
    class Citizen :GameObject
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public bool Gender { get; set; }
        public bool morning = false;
        private Vector2D currentnode;
        Random rnd = new Random();

        internal enum assignment
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

        public Citizen(string imagePath, Vector2D startPosition, string Name, bool Gender, Enum assignment) : base(imagePath,startPosition)
        {
            Hunger = 0;
            Age = 0;
        }

        

        public void RiskOfDeath(int Age, int Hunger)
        {

            if (morning = true)
            {
                float deathChance = Age * (1 + Hunger / 10);//  Age*hunger/100??



                float output = (float)rnd.NextDouble();
                if (output * 100 > deathChance)
                {
                    //no death occcured

                }
                else if (output * 100 < deathChance)
                {
                    //GameWorld.ToRemove(this);
                }

            }
        }

        public Vector2D WaypointWalk()
        {

           
           // int startwaypoint=currentnode;
           // int slutwaypoint=nextpoint;
            int first = rnd.Next(10, 600);  // x koordinat for waypoint  citizen skal mod
            int second = rnd.Next(10, 600); // y koordinat for waypoint  citizen skal mod
          return  new Vector2D(first, second);


        }

        public override void Update(float currentFPS)
        {
            Vector2D velocity = StartPosition.Subtract(WaypointWalk());
            velocity.Normalize();

            StartPosition.X += 1/currentFPS*(velocity.X*1000);
            StartPosition.Y += 1 / currentFPS * (velocity.Y * 1000);

            base.Update(currentFPS);
        }
    }
}
