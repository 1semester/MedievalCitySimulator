using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedCitySim
{
    class Button : GameObject
    {
        public Button(string imagePath, Vector2D startPosition) : base(imagePath, startPosition)
        {

        }
        public override void Update(float currentFPS)
        {
            if (Keyboard.IsKeyPressed(System.Windows.Forms.Keys.B))
            {
                GameWorld.ToAdd.Add(new BuildMenu(@"Sprites\Buildings\BuildMenu.png", new Vector2D(992, 20)));
                GameWorld.ToRemove.Add(this);
            }
            if (Keyboard.IsKeyPressed(System.Windows.Forms.Keys.R))
            {
                if (GameWorld.Food >= 1 && GameWorld.CitizenPop < GameWorld.CitizenCap)
                {
                    GameWorld.ToAdd.Add(new Citizen(@"Sprites\rsz_cop1.png", new Vector2D(400, 400), "lars", true, Citizen.Assignment.unassigned));
                    GameWorld.Food -= 1;
                    GameWorld.CitizenPop += 1;
                }
            }
            if (Keyboard.IsKeyPressed(System.Windows.Forms.Keys.S))
            {

            }
        }
        protected override void OnCollision(GameObject other)
        {
            throw new NotImplementedException();
        }
    }
}
