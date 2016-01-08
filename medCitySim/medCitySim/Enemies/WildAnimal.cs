using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedCitySim
{
    class WildAnimal : Enemy
    {
        private Vector2D currentWaypoint;
      
        /// <summary>
        /// makes the constructor for WildAnimal 
        /// </summary>
        /// <param name="imagePath"> imagepath for sprite</param>
        /// <param name="position"> start position in vector2D</param>
        public WildAnimal(string imagePath, Vector2D position) : base(imagePath, position)
        {
            FindWaypoint();
        }
        /// <summary>
        ///  checks collision aginst other objects 
        /// </summary>
        /// <param name="other"> all other objects</param>
        protected override void OnCollision(GameObject other)
        {

            if (other is Citizen)
            {
                var citizen = other as Citizen;
                if (citizen != null)
                {
                    if (citizen.currentAssignment == Citizen.Assignment.soldier)
                    {
                        GameWorld.ToRemove.Add(this);
                    }
                    else
                    {
                        GameWorld.ToRemove.Add(other);
                    }
                }

            }
        }
        /// <summary>
        /// finds the first instance of a citizen  and walks towards it
        /// </summary>
        public void FindWaypoint()
        {
            Citizen soldier = GameWorld.objs.OfType<Citizen>().FirstOrDefault();

           

            if (soldier != null)
            {
                currentWaypoint = soldier.Position;

                return;
            }
           
        
        }
        /// <summary>
        /// the function for animals to attack 
        /// </summary>
        public static void AnimalAttack()
        {

            for (int i = 0; i < 5 * GameWorld.daycount; i++)
            {
                Random rnd = new Random();
                int spawnpoint = rnd.Next(0, 4);
                switch (spawnpoint)
                {
                    case 0:
                        float spawnPointX = -9;
                        float spawnPointY = 200;
                        GameWorld.ToAdd.Add(new Raider(@"Sprites\Citizens\WildAnimal.png", new Vector2D(spawnPointX, spawnPointY)));
                        break;
                    case 1:
                        spawnPointX = 700;
                        spawnPointY = 765;
                        GameWorld.ToAdd.Add(new Raider(@"Sprites\Citizens\WildAnimal.png", new Vector2D(spawnPointX, spawnPointY)));
                        break;
                    case 2:
                        spawnPointX = 400;
                        spawnPointY = 765;
                        GameWorld.ToAdd.Add(new Raider(@"Sprites\Citizens\WildAnimal.png", new Vector2D(spawnPointX, spawnPointY)));
                        break;
                    case 3:
                        spawnPointX = -9;
                        spawnPointY = 500;
                        GameWorld.ToAdd.Add(new Raider(@"Sprites\Citizens\WildAnimal.png", new Vector2D(spawnPointX, spawnPointY)));
                        break;

                }
            }
        }

        /// <summary>
        /// updates each loop
        /// </summary>
        /// <param name="currentFPS"> fps is calculated in gameworld</param>
        public override void Update(float currentFPS)
        {
            Vector2D deltaPosition = Position.Subtract(currentWaypoint);
            float distanceFromWaypoint = deltaPosition.Magnitude;
            if (distanceFromWaypoint < 10)
            {


                FindWaypoint();
            }


            deltaPosition.Normalize();

            Position.X += 1 / currentFPS * (deltaPosition.X * 125);
            Position.Y += 1 / currentFPS * (deltaPosition.Y * 125);
            base.Update(currentFPS);
        }
    }
}
