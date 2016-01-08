using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedCitySim
{
    class Button : GameObject
    {
        /// <summary>
        /// This class is made like a menu, so the player can use keybinds, to get into other menues.
        /// </summary>
        /// <param name="imagePath"></param>
        /// <param name="startPosition"></param>
        public Button(string imagePath, Vector2D startPosition) : base(imagePath, startPosition)
        {

        }
        /// <summary>
        /// The update method contains the keys, that are availeble in the button class.
        /// </summary>
        /// <param name="currentFPS"></param>
        public override void Update(float currentFPS)
        {
            if (Keyboard.IsKeyPressed(System.Windows.Forms.Keys.B))
            {
                GameWorld.ToAdd.Add(new BuildMenu(@"Sprites\Buildings\BuildMenu.png", new Vector2D(992, 20)));
                GameWorld.ToRemove.Add(this);
            }
            if (Keyboard.IsKeyPressed(System.Windows.Forms.Keys.C))
            {
                GameWorld.ToAdd.Add(new CitizenMenu(@"Sprites\CitizenMenu.png", new Vector2D(992, 30)));
                GameWorld.ToRemove.Add(this);
            }
            if (Blacksmith.worksmith == true)
            {
                if (Keyboard.IsKeyPressed(System.Windows.Forms.Keys.R))
                {
                    GameWorld.ToAdd.Add(new ResearchMenu(@"Sprites\ResearchMenu.png", new Vector2D(992, 30)));
                    GameWorld.ToRemove.Add(this);
                }
            }
        }
    }
}
