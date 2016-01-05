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
        private GameObject targetGo;
        public string Name { get; set; }
        public int Age { get; set; }
        public bool Gender { get; set; }
       
       // private Vector2D currentnode;
        Random rnd = new Random();
        public Assignment currentAssignment;
        private Vector2D currentWaypoint;
        private byte hit;


        public enum Assignment
        {
            lumberJack,
            priest,
            smith,
            farmer,
            soldier,
            miner,
            mason,
            unassigned
        };

        public int Hunger { get; set; }

        public Citizen(string imagePath, Vector2D position, string Name, bool Gender, Assignment assignment) : base(imagePath,position)
        {
            Hunger = 0;
            Age = 0;
            this.currentAssignment = assignment;
            this.FindWaypoint();
            hit = 0;
        }

        private void FindWaypoint()
        {
            switch (currentAssignment)
            {
                case Assignment.lumberJack:
                
                   Lumbermill Lumbermill =GameWorld.objs.OfType<Lumbermill>().FirstOrDefault();

                  

                    if (Lumbermill != null && currentWaypoint!=Lumbermill.Position )
                    {
                        currentWaypoint = Lumbermill.Position;
                       
                        return;
                    }
                    if (Lumbermill != null && currentWaypoint == Lumbermill.Position )
                    {
                        currentWaypoint = new Vector2D(500, 500);

                        return;
                    }



                    break;
                case Assignment.priest:
                    Church church = GameWorld.objs.OfType<Church>().FirstOrDefault();
                    if (targetGo == null || GameWorld.objs.Contains(targetGo) == false)
                    {
                        var soldiers = GameWorld.objs.OfType<Witch>().ToArray();

                        targetGo = soldiers.Length > 0 ? soldiers[rnd.Next(0, soldiers.Length)] : null;
                    }
                   
                        if (Witch.witchAlive==true )
                        {
                            
                        currentWaypoint = targetGo.Position;
                        }

                    if (church != null && currentWaypoint != church.Position)
                    {
                        currentWaypoint = church.Position;

                        return;
                    }
                    //if (church != null && currentWaypoint == church.Position)
                    //{
                    //    currentWaypoint = new Vector2D(500, 500);

                    //    return;
                    //}
                    break;
                case Assignment.smith:
                    Blacksmith bs = GameWorld.objs.OfType<Blacksmith>().FirstOrDefault();



                    if (bs != null && currentWaypoint != bs.Position)
                    {
                        currentWaypoint = bs.Position;

                        return;
                    }
                    if (bs != null && currentWaypoint == bs.Position)
                    {
                        currentWaypoint = new Vector2D(500, 500);

                        return;
                    }
                    break;
                case Assignment.farmer:
                    Farm farm = GameWorld.objs.OfType<Farm>().FirstOrDefault();



                    if (farm != null && currentWaypoint != farm.Position)
                    {

                        currentWaypoint = farm.Position;
                        

                        return;
                    }
                    if (farm != null && currentWaypoint == farm.Position)
                    {
                        currentWaypoint = new Vector2D(500, 500);

                        return;
                    }
                    break;
                case Assignment.soldier:
                    if (targetGo == null || GameWorld.objs.Contains(targetGo) == false)
                    {
                        var soldiers = GameWorld.objs.OfType<Raider>().ToArray();

                        targetGo = soldiers.Length > 0 ? soldiers[rnd.Next(0, soldiers.Length)] : null;
                        if (targetGo!=null)
                        {
                            
                        currentWaypoint = targetGo.Position;
                        }
                    }

                    //Raider raider = GameWorld.objs.OfType<Raider>().FirstOrDefault();


                   
                    //if (raider ==null)
                    //{
                    //    float First = rnd.Next(100, 600);
                    //    float Second = rnd.Next(100, 600);
                    //    currentWaypoint = new Vector2D(First, Second);
                    //}
                    if (targetGo == null )
                    {
                        CivilWatch civilWatch = GameWorld.objs.OfType<CivilWatch>().FirstOrDefault();
                      
                        currentWaypoint = civilWatch.Position;
                    }
                   
                    break;
                case Assignment.miner:
                    Mine mine = GameWorld.objs.OfType<Mine>().FirstOrDefault();



                    if (mine != null && currentWaypoint != mine.Position)
                    {
                        currentWaypoint = mine.Position;

                        return;
                    }
                    if (mine != null && currentWaypoint == mine.Position)
                    {
                        currentWaypoint = new Vector2D(500, 500);

                        return;
                    }
                    break;
                case Assignment.mason:
                    Quarry quarry = GameWorld.objs.OfType<Quarry>().FirstOrDefault();



                    if (quarry != null && currentWaypoint != quarry.Position)
                    {
                        currentWaypoint = quarry.Position;

                        return;
                    }
                    if (quarry != null && currentWaypoint == quarry.Position)
                    {
                        currentWaypoint = new Vector2D(500, 500);

                        return;
                    }
                    break;
                case Assignment.unassigned:

               float   first=  rnd.Next(100, 800);
             float       second = rnd.Next(100, 800);
                 currentWaypoint= new Vector2D(first,second);
                    return;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            //this.currentWaypoint = new Vector2D(500,500);
        }

        public void Eat()
        {
            //int citizens = GameWorld.CitizenPop;
            //if (GameWorld.Food>=citizens*5)
            //{
            //    GameWorld.Food -= citizens * 5;
            //}
            //else if (GameWorld.Food <= citizens * 5)
            //{
               
                foreach (GameObject go in GameWorld.objs)
                {
                    var citizen = go as Citizen;

                    
                    if (citizen != null)
                    {
                        if (GameWorld.Food >= 5)
                        {
                            
                        GameWorld.Food -= 5;
                        }
                         else if (GameWorld.Food < 5)
                        {
                            Hunger++;
                        }

                    }
                //}
              
            }
           
        }

        public void RiskOfDeath(int Age, int Hunger)
        {
            if (GameWorld.dayCooldown>=300)
            {
                Age++;
                Eat();
                //
                foreach (GameObject go in GameWorld.objs)
                {
                    var citizen = go as Citizen;


                    if (citizen != null)
                    {
                      
                float deathChance = Age*(1 + Hunger/10); 


                float output = (float) rnd.NextDouble();
               
                 if (output*100 < deathChance)
                {
                    GameWorld.ToRemove.Add(this);
                }

                    }
                   

                }
               
            }
        }

        public override void Update(float currentFPS)
        {
            Vector2D deltaPosition = Position.Subtract(currentWaypoint);
            float distanceFromWaypoint = deltaPosition.Magnitude;
            if (distanceFromWaypoint < 10 )
            {
               
               
                FindWaypoint();
            }
          
          
            RiskOfDeath(Age,Hunger);
           deltaPosition.Normalize();
            //Vector2D newPosition = new Vector2D(10,10);
            if (Witch.witchAlive==false)
            {
            Position.X += 1/currentFPS*(deltaPosition.X*100);
          Position.Y += 1/currentFPS*(deltaPosition.Y*100);
                
            }
            else if (Witch.witchAlive==true)
            {
                Position.X += 1 / currentFPS * (deltaPosition.X * 50);
                Position.Y += 1 / currentFPS * (deltaPosition.Y * 50);
                
            }
           
            
            if (currentAssignment==Assignment.soldier)
            {
                Position.X += 1 / currentFPS * (deltaPosition.X * 135);
                Position.Y += 1 / currentFPS * (deltaPosition.Y * 135);
            }

           
            

            base.Update(currentFPS);
        }

        protected override void OnCollision(GameObject other)
        {
            foreach (GameObject go in GameWorld.objs)
            {

               
                if (other is Raider)
                {
                    var citizen = this as Citizen;
                    if (citizen != null)
                    {
                        
                        if (citizen.currentAssignment == Citizen.Assignment.soldier)
                        {
                           
                            GameWorld.ToRemove.Add(other);
                                
                            
                        }
                        //if (citizen.currentAssignment == Citizen.Assignment.soldier)
                        //{

                        //    GameWorld.ToRemove.Add(this);
                        //}
                        else
                        {
                           
                                GameWorld.ToRemove.Add(this);
                            
                        }
                    }

                }
                //var raider = go as Raider;


                //if (raider  != null && currentAssignment != Citizen.Assignment.civilWatch)
                //{
                //    GameWorld.ToRemove.Add(this);

                //}
            }
            foreach (GameObject go in GameWorld.objs)
            {
                if (other is Witch)
                {
                    var citizen = this as Citizen;
                    if (citizen != null)
                    {
                        if (citizen.currentAssignment == Citizen.Assignment.priest)
                        {
                            Witch.witchAlive = false;
                            GameWorld.ToRemove.Add(other);
                        }
                    }

                }
                //base.OnCollision(other);
            }
        }
    }
}
