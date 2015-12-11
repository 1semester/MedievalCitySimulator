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
                GameWorld.ToAdd.Add(new BuildMenu(@"Sprites\BuildMenu.png", new Vector2D(40, 40)));
                GameWorld.ToRemove.Add(this);
            }
        }
        protected override void OnCollision(GameObject other)
        {
            throw new NotImplementedException();
        }
    }
}
