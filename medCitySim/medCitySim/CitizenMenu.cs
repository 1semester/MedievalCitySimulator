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
                    GameWorld.CitizenPop++;
                    GameWorld.Food--;
                    GameWorld.ToRemove.Add(this);
                    GameWorld.ToAdd.Add(new Button(@"Sprites\Buildsort.png", new Vector2D(992, 562)));
                }
            }
            if (Keyboard.IsKeyPressed(System.Windows.Forms.Keys.A))
            {
                //Claus her skal assignkode være!
            }
            if (Keyboard.IsKeyPressed(System.Windows.Forms.Keys.Escape))
            {
                GameWorld.ToRemove.Add(this);
                GameWorld.ToAdd.Add(new Button(@"Sprites\Buildsort.png", new Vector2D(992, 562)));

            }
            base.Update(currentFPS);
        }
    }
}
