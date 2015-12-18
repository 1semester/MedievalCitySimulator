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
           
        
            if (Keyboard.IsKeyPressed(System.Windows.Forms.Keys.C))
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
            if (Keyboard.IsKeyPressed(System.Windows.Forms.Keys.F))
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
            if (Keyboard.IsKeyPressed(System.Windows.Forms.Keys.S))
            {
                if (GameWorld.Food >= 1 && GameWorld.CitizenPop < GameWorld.CitizenCap)
                {
                    GameWorld.Food--;
                    GameWorld.CitizenPop++;
                    GameWorld.ToAdd.Add(new Citizen(@"Sprites\rsz_cop1.png", new Vector2D(400, 400), "lars", true, Citizen.Assignment.civilWatch));
                    GameWorld.ToRemove.Add(this);
                    GameWorld.ToAdd.Add(new Button(@"Sprites\Button.png", new Vector2D(999, 614)));
                }
            }
            if (Keyboard.IsKeyPressed(System.Windows.Forms.Keys.L))
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
            if (Keyboard.IsKeyPressed(System.Windows.Forms.Keys.Q))
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
            if (Keyboard.IsKeyPressed(System.Windows.Forms.Keys.B))
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
            if (Keyboard.IsKeyPressed(System.Windows.Forms.Keys.M))
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

            if (Keyboard.IsKeyPressed(System.Windows.Forms.Keys.Escape))
            {
                GameWorld.ToRemove.Add(this);
                GameWorld.ToAdd.Add(new Button(@"Sprites\Button.png", new Vector2D(999, 614)));

            }
            base.Update(currentFPS);
        }
    }
}