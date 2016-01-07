using System;

using System.Linq;


namespace MedCitySim
{
    class Raider : Enemy
    {
        private GameObject targetGo;
        private Vector2D currentWaypoint;
        Random rnd = new Random((int)DateTime.Now.Ticks);

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

            if (targetGo == null || GameWorld.objs.Contains(targetGo) == false)
            {
                var soldiers = GameWorld.objs.OfType<Citizen>().ToArray();
                
                targetGo = soldiers.Length > 0 ? soldiers[rnd.Next(0, soldiers.Length)] : null;
            }



            //float First = rnd.Next(10, 800);
            //float second = rnd.Next(10, 800);
            //currentWaypoint = new Vector2D(First, second);

            if (targetGo != null)
            {
                currentWaypoint = targetGo.Position;

               
            }
           

                Building building = GameWorld.objs.OfType<Storage>().FirstOrDefault();

            if (targetGo == null && building!=null)
            {
                currentWaypoint = building.Position;
               
                Vector2D deltaPosition = Position.Subtract(currentWaypoint);
                    float distanceFromWaypoint = deltaPosition.Magnitude;
                if (distanceFromWaypoint<10)
                {
                currentWaypoint = new Vector2D(0, 350);
                    
                }
               
                if (distanceFromWaypoint >=500&& distanceFromWaypoint<=515 && currentWaypoint!= new Vector2D(0,350))
                    {
                    int raider = 0;
                    foreach (GameObject go in GameWorld.objs)
                    {
                        var citizen = go as Raider;

                        if (citizen != null)
                        {
                            raider++;

                        }


                    }
                    GameWorld.Food --;
                    GameWorld.Iron --;
                    GameWorld.Lumber --;
                    GameWorld.Stone --;
                    //GameWorld.Food -= raider;
                    //GameWorld.Iron -= raider;
                    //GameWorld.Lumber -= raider;
                    //GameWorld.Stone -= raider;

                    GameWorld.ToRemove.Add(this);
                        
                    }
               
                  
                
            }
        }

        public  static void Raid()
        {
           
                for (int i = 0; i < 5*GameWorld.daycount; i++)
                {
                    Random rnd = new Random();
                    int spawnpoint = rnd.Next(0, 4);
                    switch (spawnpoint)
                    {
                        case 0:
                            float spawnPointX = -9;
                            float spawnPointY = 200;
                            GameWorld.ToAdd.Add(new Raider(@"Sprites\Citizens\Raider.png", new Vector2D(spawnPointX, spawnPointY)));
                            break;
                        case 1:
                            spawnPointX = 700;
                            spawnPointY = 765;
                            GameWorld.ToAdd.Add(new Raider(@"Sprites\Citizens\Raider.png", new Vector2D(spawnPointX, spawnPointY)));
                            break;
                        case 2:
                            spawnPointX = 400;
                            spawnPointY = 765;
                            GameWorld.ToAdd.Add(new Raider(@"Sprites\Citizens\Raider.png", new Vector2D(spawnPointX, spawnPointY)));
                            break;
                        case 3:
                            spawnPointX = -9;
                            spawnPointY = 500;
                            GameWorld.ToAdd.Add(new Raider(@"Sprites\Citizens\Raider.png", new Vector2D(spawnPointX, spawnPointY)));
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
