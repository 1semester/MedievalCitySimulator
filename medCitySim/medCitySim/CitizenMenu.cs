using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MedCitySim
{
    class CitizenMenu : GameObject
    {
        private Graphics dc;
        public CitizenMenu(string imagePath, Vector2D startPosition) : base (imagePath, startPosition)
        {

        }
        public override void Update(float currentFPS)
        {
           
        
            if (Keyboard.IsKeyPressed(System.Windows.Forms.Keys.P))
            {
                if (Church.priest == true)
                {
                if (GameWorld.Food >= 1 && GameWorld.CitizenPop < GameWorld.CitizenCap)
                {
                    GameWorld.Food--;
                    GameWorld.CitizenPop++;
                    GameWorld.ToAdd.Add(new Citizen(@"Sprites\rsz_cop1.png", new Vector2D(400, 400), "lars", true, Citizen.Assignment.priest));
                    GameWorld.ToRemove.Add(this);
                    GameWorld.ToAdd.Add(new Button(@"Sprites\Button.png", new Vector2D(999, 614)));
                    }
                }

            }
            if (Keyboard.IsKeyPressed(System.Windows.Forms.Keys.F))
            {
                if (Farm.farmer == true)
                {
                if (GameWorld.Food >= 1 && GameWorld.CitizenPop < GameWorld.CitizenCap)
                {
                    GameWorld.Food--;
                    GameWorld.CitizenPop++;
                    GameWorld.ToAdd.Add(new Citizen(@"Sprites\rsz_cop1.png", new Vector2D(400, 400), "lars", true, Citizen.Assignment.farmer));
                    GameWorld.ToRemove.Add(this);
                    GameWorld.ToAdd.Add(new Button(@"Sprites\Button.png", new Vector2D(999, 614)));
                }
                }
            }
            if (Keyboard.IsKeyPressed(System.Windows.Forms.Keys.T))
            {
                if (CivilWatch.soldier == true)
                {
                if (GameWorld.Food >= 1 && GameWorld.CitizenPop < GameWorld.CitizenCap)
                {
                    GameWorld.Food--;
                    GameWorld.CitizenPop++;
                    GameWorld.ToAdd.Add(new Citizen(@"Sprites\rsz_cop1.png", new Vector2D(400, 400), "lars", true, Citizen.Assignment.soldier));
                    GameWorld.ToRemove.Add(this);
                    GameWorld.ToAdd.Add(new Button(@"Sprites\Button.png", new Vector2D(999, 614)));
                }
                }
            }
            if (Keyboard.IsKeyPressed(System.Windows.Forms.Keys.L))
            {
                if (Lumbermill.lumberjack == true)
                {
                if (GameWorld.Food >= 1 && GameWorld.CitizenPop < GameWorld.CitizenCap)
                {
                    GameWorld.Food--;
                    GameWorld.CitizenPop++;
                    GameWorld.ToAdd.Add(new Citizen(@"Sprites\rsz_cop1.png", new Vector2D(400, 400), "lars", true, Citizen.Assignment.lumberJack));
                    GameWorld.ToRemove.Add(this);
                    GameWorld.ToAdd.Add(new Button(@"Sprites\Button.png", new Vector2D(999, 614)));
                }
                }
            }
            if (Keyboard.IsKeyPressed(System.Windows.Forms.Keys.A))
            {
                if (Quarry.mason == true)
                {
                if (GameWorld.Food >= 1 && GameWorld.CitizenPop < GameWorld.CitizenCap)
                {
                    GameWorld.Food--;
                    GameWorld.CitizenPop++;
                    GameWorld.ToAdd.Add(new Citizen(@"Sprites\rsz_cop1.png", new Vector2D(400, 400), "lars", true, Citizen.Assignment.mason));
                    GameWorld.ToRemove.Add(this);
                    GameWorld.ToAdd.Add(new Button(@"Sprites\Button.png", new Vector2D(999, 614)));
                }
                }
            }
            if (Keyboard.IsKeyPressed(System.Windows.Forms.Keys.S))
            {
                if (Blacksmith.blacksmith == true)
                {
                if (GameWorld.Food >= 1 && GameWorld.CitizenPop < GameWorld.CitizenCap)
                {
                    GameWorld.Food--;
                    GameWorld.CitizenPop++;
                    GameWorld.ToAdd.Add(new Citizen(@"Sprites\rsz_cop1.png", new Vector2D(400, 400), "lars", true, Citizen.Assignment.smith));
                    GameWorld.ToRemove.Add(this);
                    GameWorld.ToAdd.Add(new Button(@"Sprites\Button.png", new Vector2D(999, 614)));
                    }
                }
            }
            if (Keyboard.IsKeyPressed(System.Windows.Forms.Keys.M))
            {
                if (Mine.miner == true)
                {
                if (GameWorld.Food >= 1 && GameWorld.CitizenPop < GameWorld.CitizenCap)
                {
                    GameWorld.Food--;
                    GameWorld.CitizenPop++;
                    GameWorld.ToAdd.Add(new Citizen(@"Sprites\rsz_cop1.png", new Vector2D(400, 400), "lars", true, Citizen.Assignment.miner));
                    GameWorld.ToRemove.Add(this);
                    GameWorld.ToAdd.Add(new Button(@"Sprites\Button.png", new Vector2D(999, 614)));
                }
                }
            }

            if (Keyboard.IsKeyPressed(System.Windows.Forms.Keys.W))
            {
                //GameWorld.ToAdd.Add(new Citizen(@"Sprites\rsz_cop1.png", new Vector2D(500, 500), "lars", true, Citizen.Assignment.unassigned));
                GameWorld.ToAdd.Add(new Raider(@"Sprites\rsz_cop1.png", new Vector2D(100, 100)));
                // GameWorld.ToRemove.Add(this);
            }

            if (Keyboard.IsKeyPressed(System.Windows.Forms.Keys.Escape))
            {
                GameWorld.ToRemove.Add(this);
                GameWorld.ToAdd.Add(new Button(@"Sprites\Button.png", new Vector2D(999, 614)));

            }
            base.Update(currentFPS);
        }
    }
}