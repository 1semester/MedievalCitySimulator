using System;
using System.Linq;
using IrrKlang;

namespace MedCitySim
{
    class Citizen : GameObject
    {
        protected ISoundEngine engine;
        private GameObject targetGo;
        private GameObject targetGoNext;
        public string Name { get; set; }
        public int Age { get; set; }
        public bool Gender { get; set; }


        Random rnd = new Random((int)DateTime.Now.Ticks);
        public Assignment currentAssignment;
        private Vector2D currentWaypoint;
        private byte hit;
        private Storage storage;

        /// <summary>
        /// is the assignment enum for what kind of citizen they are
        /// </summary>
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
/// <summary>
/// is the constructor for citizens
/// </summary>
/// <param name="imagePath">the image path for the sprite</param>
/// <param name="position"> the startposition in vector2D</param>
/// <param name="Name">name for future plans</param>
/// <param name="Gender"> gender for future plans  </param>
/// <param name="assignment"> what type of citizen they are</param>
        public Citizen(string imagePath, Vector2D position, string Name, bool Gender, Assignment assignment) : base(imagePath, position)
        {
            Hunger = 0;
            Age = 0;
            this.currentAssignment = assignment;
            this.FindWaypoint();
            this.storage = GameWorld.objs.OfType<Storage>().FirstOrDefault();
            hit = 0;
        }
        /// <summary>
        /// switches on the citzens assignment and gives them their current
        /// waypoint and destination
        /// </summary>
        private void FindWaypoint()
        {
            switch (currentAssignment)
            {
                case Assignment.lumberJack:

                    Lumbermill Lumbermill = GameWorld.objs.OfType<Lumbermill>().FirstOrDefault();



                    if (Lumbermill != null && currentWaypoint != Lumbermill.Position)
                    {
                        currentWaypoint = Lumbermill.Position;

                        return;
                    }
                    if (storage != null && currentWaypoint == Lumbermill.Position)
                    {
                        currentWaypoint = storage.Position;

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


                   
                    if (targetGo != null)
                    {

                        currentWaypoint = targetGo.Position;
                    }
                    if (targetGoNext == null || GameWorld.objs.Contains(targetGo) == false && currentWaypoint == targetGoNext.Position)
                    {
                        var soldiers = GameWorld.objs.OfType<Building>().ToArray();

                        targetGoNext = soldiers.Length > 0 ? soldiers[rnd.Next(0, soldiers.Length)] : null;
                    }
                    if (targetGo==null)
                    {
                        currentWaypoint = targetGoNext.Position;
                    }
                   
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
                        currentWaypoint = storage.Position;

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
                        currentWaypoint = storage.Position;

                        return;
                    }
                    break;
                case Assignment.soldier:
                    if (targetGo == null || GameWorld.objs.Contains(targetGo) == false)
                    {
                        var soldiers = GameWorld.objs.OfType<Raider>().ToArray();

                        targetGo = soldiers.Length > 0 ? soldiers[rnd.Next(0, soldiers.Length)] : null;
                       
                    }
                    if (targetGo != null && currentWaypoint!=targetGo.Position)
                    {

                        currentWaypoint = targetGo.Position;
                    }
                    
                    if (targetGoNext == null || GameWorld.objs.Contains(targetGo) == false && currentWaypoint==targetGoNext.Position)
                    {
                        var soldiers = GameWorld.objs.OfType<Building>().ToArray();

                        targetGoNext = soldiers.Length > 0 ? soldiers[rnd.Next(0, soldiers.Length)] : null;
                    }
                        if (targetGo == null && currentWaypoint !=targetGoNext.Position)
                        {

                            currentWaypoint = targetGoNext.Position;
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
                        currentWaypoint = storage.Position;

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
                        currentWaypoint = storage.Position;

                        return;
                    }
                    break;
                case Assignment.unassigned:

                    float first = rnd.Next(100, 800);
                    float second = rnd.Next(100, 800);
                    currentWaypoint = new Vector2D(first, second);
                    return;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            
        }
        /// <summary>
        /// loopes the objs list trough  and finds the objs citizen and  makes them eat 5 food
        ///  each from the food ressource , if they cant eat their amount  their hunger will go up by one. 
        /// </summary>
        public void Eat()
        {
            

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
               

            }

        }
        /// <summary>
        /// checks if the citizen is starving and their age and gives it a chance of death based on the algorithm
        ///  and then the random generates a number if the number is within the deathchance they will die. 
        /// </summary>
        /// <param name="Age"> is their current age which is 0 at instanstiation  and goes up by one by each day</param>
        /// <param name="Hunger"> hunger is when they can't eat their hunger will go up by one</param>
        public void RiskOfDeath(int Age, int Hunger)
        {
            if (GameWorld.dayCooldown >= 120)
            {
                Age++;
                Eat();
                //
                foreach (GameObject go in GameWorld.objs)
                {
                    var citizen = go as Citizen;


                    if (citizen != null)
                    {

                        float deathChance = Age * (1 + Hunger / 10);


                        float output = (float)rnd.NextDouble();

                        if (output * 100 < deathChance)
                        {
                            GameWorld.ToRemove.Add(this);
                        }

                    }


                }

            }
        }

        /// <summary>
        ///  updates each loop.
        /// </summary>
        /// <param name="currentFPS"> the fps which the game runs is calculated in gameworld </param>
        public override void Update(float currentFPS)
        {
            Vector2D deltaPosition = Position.Subtract(currentWaypoint);
            float distanceFromWaypoint = deltaPosition.Magnitude;
            if (distanceFromWaypoint < 10)
            {


                FindWaypoint();
            }


            RiskOfDeath(Age, Hunger);
            deltaPosition.Normalize();
           
            if (Witch.witchAlive == false)
            {
                Position.X += 1 / currentFPS * (deltaPosition.X * 100);
                Position.Y += 1 / currentFPS * (deltaPosition.Y * 100);

            }
            else if (Witch.witchAlive == true)
            {
                Position.X += 1 / currentFPS * (deltaPosition.X * 50);
                Position.Y += 1 / currentFPS * (deltaPosition.Y * 50);

            }


            if (currentAssignment == Assignment.soldier)
            {
                Position.X += 1 / currentFPS * (deltaPosition.X * 135);
                Position.Y += 1 / currentFPS * (deltaPosition.Y * 135);
            }




            base.Update(currentFPS);
        }
        /// <summary>
        /// looops and checks collision
        /// </summary>
        /// <param name="other"> checks collision with this obejct against all other objects </param>
        protected override void OnCollision(GameObject other)
        {
            foreach (GameObject go in GameWorld.objs)
            {
                    if (other is Raider && currentAssignment == Assignment.soldier)
                    {
                        hit++;
                    }


                if (other is Raider || other is WildAnimal)
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
                       

                        if (hit == 160 && (currentAssignment == Assignment.soldier))
                        {
                            GameWorld.ToRemove.Add(this);

                        }


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
                            WitchDies();
                            Witch.witchAlive = false;
                            GameWorld.ToRemove.Add(other);
                        }
                    }

                }
                //base.OnCollision(other);
            }
        }
        /// <summary>
        /// when the witch dies  it plays a sound.
        /// </summary>
        protected void WitchDies()
        {
            try
            {
                
                    
                engine = new ISoundEngine();
                engine.Play2D("Media/wololo.mp3", false);
                
            }
            catch (Exception ex) { }
        }
    }
}
