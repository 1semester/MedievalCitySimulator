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
            if (Keyboard.IsKeyPressed(System.Windows.Forms.Keys.C))
            {
                GameWorld.ToAdd.Add(new CitizenMenu(@"Sprites\rsz_cop1.png", new Vector2D(992, 600)));
                GameWorld.ToRemove.Add(this);
            }
            if (Keyboard.IsKeyPressed(System.Windows.Forms.Keys.R))
            {
                GameWorld.ToAdd.Add(new ResearchMenu(@"Sprites\Buildings\BuildMenu.png", new Vector2D(992, 20)));
                GameWorld.ToRemove.Add(this);
            }
        }
        protected override void OnCollision(GameObject other)
        {
            throw new NotImplementedException();
        }
    }
}
