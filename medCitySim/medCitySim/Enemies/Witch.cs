using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedCitySim
{
    class Witch : Enemy
    {
        private string name;
        private bool gender;
        public static bool witchAlive = false;
        private Vector2D currentWaypoint;
        //private GameObject targetGo;
        Random rnd = new Random((int)DateTime.Now.Ticks);

        public Witch(string imagePath, Vector2D position, bool gender, string name) : base(imagePath, position)
        {
            witchAlive = true;
            this.name = name;
            this.gender = gender;
            this.FindWaypoint();
        }

        public void FindWaypoint()
        {




            float First = rnd.Next(10, 800);
            float second = rnd.Next(10, 800);
            currentWaypoint = new Vector2D(First, second);






        }





        protected override void OnCollision(GameObject other)
        {

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
            Position.X += 1 / currentFPS * (deltaPosition.X * 100);
            Position.Y += 1 / currentFPS * (deltaPosition.Y * 100);
            base.Update(currentFPS);
        }
    }
}
