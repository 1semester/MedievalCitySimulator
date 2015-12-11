﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MedCitySim
{
    class Citizen :GameObject
    {
       // public string Name { get; set; }
       // public int Age { get; set; }
       //public bool Gender { get; set; }
       // public bool morning = false;

       // private enum assignment
       // {
       //     lumberJack,
       //     priest,
       //     smith,
       //     farmer,
       //     civilWatch,
       //     miner,
       //     unassigned
       // };

       // public int Hunger { get; set; }

       // Citizen(string imagePath, Vector2D startPosition, string Name, bool Gender, Enum assignment)
       // {
       //     Hunger = 0;
       //     Age = 0;
       // }

       // public void RiskOfDeath(int Age, int Hunger)
       // {

       //     if (morning=true)
       //     {
       //      float deathChance = Age*(1+Hunger/10);
       //       float noDeathChance= 100 - deathChance;
       //         deathChance;
       //         noDeathChance;
       //         Random rnd= new Random();
       //     }
       // }
        public string Name { get; set; }
        public int Age { get; set; }
        public bool Gender { get; set; }
        public bool morning = false;
        private Vector2D currentnode;
        Random rnd = new Random();
        private Assignment currentAssignment;
        private Vector2D currentWaypoint;
      

        internal enum Assignment
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

        public Citizen(string imagePath, Vector2D position, string Name, bool Gender, Assignment assignment) : base(imagePath,position)
        {
            Hunger = 0;
            Age = 0;
            this.currentAssignment = assignment;
            this.FindWaypoint();
        }

        private void FindWaypoint()
        {
            switch (currentAssignment)
            {
                case Assignment.lumberJack:
                   // List<GameObject> mylist =new List<GameObject>() ;
                  //  mylist = GameWorld.Objs;
                   House house =GameWorld.objs.OfType<House>().FirstOrDefault();

                  

                    if (house != null && currentWaypoint!=house.Position )
                    {
                        currentWaypoint = house.Position;
                       
                        return;
                    }
                    if (currentWaypoint==house.Position )
                    {
                        currentWaypoint = new Vector2D(500, 500);

                        return;
                    }



                    break;
                case Assignment.priest:
                    break;
                case Assignment.smith:
                    break;
                case Assignment.farmer:
                    break;
                case Assignment.civilWatch:
                    break;
                case Assignment.miner:
                    break;
                case Assignment.unassigned:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            this.currentWaypoint = new Vector2D(500,500);
        }


        public void RiskOfDeath(int Age, int Hunger)
        {
            if (morning = true)
            {
                float deathChance = Age*(1 + Hunger/10); //  Age*hunger/100??


                float output = (float) rnd.NextDouble();
                if (output*100 > deathChance)
                {
                    //no death occcured
                }
                else if (output*100 < deathChance)
                {
                    GameWorld.ToRemove.Add(this);
                }
            }
        }

        public override void Update(float currentFPS)
        {
            Vector2D deltaPosition = Position.Subtract(currentWaypoint);
            float distanceFromWaypoint = deltaPosition.Magnitude;
            if (distanceFromWaypoint < 10 )
            {
                //currentWaypoint = new Vector2D(500, 500);
               
                FindWaypoint();
            }
           

            deltaPosition.Normalize();

            Position.X += 1/currentFPS*(deltaPosition.X*100);
            Position.Y += 1/currentFPS*(deltaPosition.Y*100);

            base.Update(currentFPS);
        }
    }
}
