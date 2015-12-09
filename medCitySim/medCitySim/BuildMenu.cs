using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedCitySim
{
    class BuildMenu : GameObject
    {
        public BuildMenu(string imagePath, Vector2D position) : base (imagePath, position)
        {

        }
        public override void Update(float currentFPS)
        {
            if (Keyboard.IsKeyDown(System.Windows.Forms.Keys.H))
            {
                GameWorld.ToAdd.Add(new House(@"Sprites\Hus.png", (new Vector2D(200, 200)), 50));
            }
            base.Update(currentFPS);
        }
    }
}
