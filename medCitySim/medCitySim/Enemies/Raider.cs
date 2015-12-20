using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedCitySim
{
    class Raider : Enemy
    {

        private Vector2D currentWaypoint;
        Random rnd = new Random();

        public Raider(string imagePath, Vector2D position) : base(imagePath, position)
        {

            this.FindWaypoint();
        }

        protected override void OnCollision(GameObject other)
        {


            if (other is Citizen)
            {
                var citizen = other as Citizen;
                if (citizen != null)
                {
                    if(citizen.currentAssignment == Citizen.Assignment.soldier)
                    {
                        GameWorld.ToRemove.Add(this);
                    }
                    else
                    {
                        GameWorld.ToRemove.Add(other);
                    }
                }

            }
            //if (other is Citizen && Citizen.currentAssignment == Citizen.Assignment.civilWatch)
            //{
            //   Citizen.Assignment.
            //}
        }

        public void FindWaypoint()
        {
            Citizen soldier = GameWorld.objs.OfType<Citizen>().FirstOrDefault();

            //float First = rnd.Next(10, 800);
            //float second = rnd.Next(10, 800);
            //currentWaypoint = new Vector2D(First, second);

            if (soldier != null)
            {
                currentWaypoint = soldier.Position;

                return;
            }
            //if (soldier != null && currentWaypoint == soldier.Position)
            //{
            //    currentWaypoint = new Vector2D(500, 500);

            //    return;
            //}
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
