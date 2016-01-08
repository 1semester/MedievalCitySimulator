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
       
        Random rnd = new Random((int)DateTime.Now.Ticks);
        /// <summary>
        /// constructor for witch
        /// </summary>
        /// <param name="imagePath"> imagepath for sprite</param>
        /// <param name="position">startposition</param>
        /// <param name="gender">what gender they are</param>
        /// <param name="name">and their name</param>
        public Witch(string imagePath, Vector2D position, bool gender, string name) : base(imagePath, position)
        {
            witchAlive = true;
            this.name = name;
            this.gender = gender;
            this.FindWaypoint();
        }
        /// <summary>
        /// just amkes the witch walk random  around  to make her harder to catch.
        /// </summary>
        public void FindWaypoint()
        {




            float First = rnd.Next(10, 800);
            float second = rnd.Next(10, 800);
            currentWaypoint = new Vector2D(First, second);






        }




        /// <summary>
        /// collision checks aginst all other objects but shes bugged so the check is made in citizen
        /// </summary>
        /// <param name="other"> the other objects to check against</param>
        protected override void OnCollision(GameObject other)
        {

        }

        /// <summary>
        /// updates each loop.
        /// </summary>
        /// <param name="currentFPS"></param>
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
