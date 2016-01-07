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
        //Random rnd = new Random((int)DateTime.Now.Ticks);

        public WildAnimal(string imagePath, Vector2D position) : base(imagePath, position)
        {
            FindWaypoint();
        }
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

        public void FindWaypoint()
        {
            Citizen soldier = GameWorld.objs.OfType<Citizen>().FirstOrDefault();

           

            if (soldier != null)
            {
                currentWaypoint = soldier.Position;

                return;
            }
           
        
        }

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
