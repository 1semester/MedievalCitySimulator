using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MedCitySim
{
    class BuildMenu : GameObject
    {
        private Graphics dc;
       public BuildMenu(string imagePath, Vector2D startPosition) : base(imagePath, startPosition)
      // public BuildMenu(string imagePath, Vector2D position) : base (imagePath, position)
        {
        }
        public override void Update(float currentFPS)
        {
            if (Keyboard.IsKeyPressed(System.Windows.Forms.Keys.H))
            {
                if (GameWorld.Lumber >= 5 && GameWorld.Stone >= 5)
                {
                    GameWorld.ToAdd.Add(new House(@"Sprites\Buildings\House.png", (new Vector2D(200, 200)), 300, dc));
                    GameWorld.ToRemove.Add(this);
                    GameWorld.ToAdd.Add(new Button(@"Sprites\Buildsort.png", new Vector2D(992, 562)));
                }
                    
            }
            if (Keyboard.IsKeyPressed(System.Windows.Forms.Keys.C))
            {
                if (GameWorld.Lumber >= 5 && GameWorld.Stone >= 5)
                {
                    GameWorld.ToAdd.Add(new Church(@"Sprites\Buildings\Church.png", (new Vector2D(200, 200)), 300));
                    GameWorld.ToRemove.Add(this);
                    GameWorld.ToAdd.Add(new Button(@"Sprites\Buildsort.png", new Vector2D(992, 562)));
                }
                
            }
            if (Keyboard.IsKeyPressed(System.Windows.Forms.Keys.W))
            {
                if (GameWorld.Lumber >= 5 && GameWorld.Stone >= 5)
                {
                    GameWorld.ToAdd.Add(new Well(@"Sprites\Buildings\Well.png", (new Vector2D(200, 200)), 300));
                    GameWorld.ToRemove.Add(this);
                    GameWorld.ToAdd.Add(new Button(@"Sprites\Buildsort.png", new Vector2D(992, 562)));
                }
            }
            if (Keyboard.IsKeyPressed(System.Windows.Forms.Keys.F))
            {
                if (GameWorld.Lumber >= 5 && GameWorld.Stone >= 5)
                {
                    GameWorld.ToAdd.Add(new Farm(@"Sprites\Buildings\Farm.png", (new Vector2D(200, 200)), 300));
                    GameWorld.ToRemove.Add(this);
                    GameWorld.ToAdd.Add(new Button(@"Sprites\Buildsort.png", new Vector2D(992, 562)));
                }
            }
            if (Keyboard.IsKeyPressed(System.Windows.Forms.Keys.S))
            {
                if (GameWorld.Lumber >= 5 && GameWorld.Stone >= 5)
                {
                    GameWorld.ToAdd.Add(new CivilWatch(@"Sprites\Buildings\CivilWatch.png", (new Vector2D(200, 200)), 300));
                    GameWorld.ToRemove.Add(this);
                    GameWorld.ToAdd.Add(new Button(@"Sprites\Buildsort.png", new Vector2D(992, 562)));
                }
            }
            if (Keyboard.IsKeyPressed(System.Windows.Forms.Keys.L))
            {
                if (GameWorld.Lumber >= 5 && GameWorld.Stone >= 5)
                {
                    GameWorld.ToAdd.Add(new Lumbermill(@"Sprites\Buildings\LumberMill.png", (new Vector2D(200, 200)), 300));
                    GameWorld.ToRemove.Add(this);
                    GameWorld.ToAdd.Add(new Button(@"Sprites\Buildsort.png", new Vector2D(992, 562)));
                }
            }
            if (Keyboard.IsKeyPressed(System.Windows.Forms.Keys.Q))
            {
                if (GameWorld.Lumber >= 5 && GameWorld.Stone >= 5)
                {
                    GameWorld.ToAdd.Add(new Quarry(@"Sprites\Buildings\Quarry.png", (new Vector2D(200, 200)), 300));
                    GameWorld.ToRemove.Add(this);
                    GameWorld.ToAdd.Add(new Button(@"Sprites\Buildsort.png", new Vector2D(992, 562)));
                }
            }
            if (Keyboard.IsKeyPressed(System.Windows.Forms.Keys.B))
            {
                if (GameWorld.Lumber >= 5 && GameWorld.Stone >= 5)
                {
                    GameWorld.ToAdd.Add(new Blacksmith(@"Sprites\Buildings\Blacksmith.png", (new Vector2D(200, 200)), 300));
                    GameWorld.ToRemove.Add(this);
                    GameWorld.ToAdd.Add(new Button(@"Sprites\Buildsort.png", new Vector2D(992, 562)));
                }
            }
            if (Keyboard.IsKeyPressed(System.Windows.Forms.Keys.M))
            {
                if (GameWorld.Lumber >= 5 && GameWorld.Stone >= 5)
                {
                    GameWorld.ToAdd.Add(new Mine(@"Sprites\Buildings\Blacksmith.png", (new Vector2D(200, 200)), 300));
                    GameWorld.ToRemove.Add(this);
                    GameWorld.ToAdd.Add(new Button(@"Sprites\Buildsort.png", new Vector2D(992, 562)));
                }
            }

            if (Keyboard.IsKeyPressed(System.Windows.Forms.Keys.Escape))
            {
                GameWorld.ToRemove.Add(this);
                GameWorld.ToAdd.Add(new Button(@"Sprites\Buildsort.png", new Vector2D(992, 562)));

            }
            base.Update(currentFPS);
        }
        protected override void OnCollision(GameObject other)
        {
            //    throw new NotImplementedException();
        }
    }
}
