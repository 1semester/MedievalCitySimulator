using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedCitySim
{
    class CitizenMenu : GameObject
    {
        public CitizenMenu(string imagePath, Vector2D startPosition) : base (imagePath, startPosition)
        {

        }
        public override void Update(float currentFPS)
        {
            if (Keyboard.IsKeyPressed(System.Windows.Forms.Keys.R))
            {
                if (GameWorld.Food >= 1 && GameWorld.CitizenPop < GameWorld.CitizenCap)
                {
                    GameWorld.ToAdd.Add(new Citizen(@"Sprites\rsz_cop1.png", new Vector2D(400, 400), "lars", true, Citizen.Assignment.unassigned));
                    GameWorld.CitizenPop += 1;
                    GameWorld.ToRemove.Add(this);
                    GameWorld.ToAdd.Add(new Button(@"Sprites\Button.png", new Vector2D(999, 614)));
                }
            }
            if (Keyboard.IsKeyPressed(System.Windows.Forms.Keys.W))
            {
               // GameWorld.ToAdd.Add(new Citizen(@"Sprites\rsz_cop1.png", new Vector2D(700, 700), "lars", true, Citizen.Assignment.civilWatch));
                GameWorld.ToAdd.Add(new Raider(@"Sprites\rsz_cop1.png", new Vector2D(100, 100)));
                //GameWorld.ToRemove.Add(this);
            }
            base.Update(currentFPS);
        }
    }
}
