using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedCitySim
{
    class ResearchMenu : GameObject
    {
        //private Graphics dc;
        public ResearchMenu(string imagePath, Vector2D startPosition) : base(imagePath, startPosition) { }
        bool bunker = true;
        public static bool well = true;
        bool wall = true;
        bool windmill = true;
        bool sewer = true;
        bool waterManagement = true;
        public static bool improvedHouse = true;
        bool animalBreed = true;
        bool sawmill = true;
        bool sawmillTwo = true;
        bool mineUpgrade = true;
        bool mineUpgradeTwo = true;
        bool quarryUpgrade = true;
        bool quarryUpgradeTwo = true;
        public override void Update(float currentFPS)
        {
            if (well == true)
            {
                if (Keyboard.IsKeyPressed(System.Windows.Forms.Keys.Q))
                {
                    if (GameWorld.Lumber >= 10 && GameWorld.Stone >= 10)
                    {
                        well = false;
                        {
                            //GameWorld.ToAdd.Add(new House(@"", (new Vector2D(200, 200)), 300, dc));
                            GameWorld.ToAdd.Add(new Button(@"Sprites\Buildsort.png", new Vector2D(992, 562)));
                        }
                    }
                }
            }
            if (waterManagement == true)
            {
                if (Keyboard.IsKeyPressed(System.Windows.Forms.Keys.R))
                {
                    if (GameWorld.Lumber >= 10 && GameWorld.Stone >= 10)
                    {
                        //Water management?
                        GameWorld.ToAdd.Add(new Button(@"Sprites\Buildsort.png", new Vector2D(992, 562)));
                    }
                }
            }
            if (sewer == true)
            {
                if (Keyboard.IsKeyPressed(System.Windows.Forms.Keys.A))
                {
                    if (GameWorld.Lumber >= 10 && GameWorld.Stone >= 10)
                    {
                        //Sewers, fights pest
                        GameWorld.ToAdd.Add(new Button(@"Sprites\Buildsort.png", new Vector2D(992, 562)));
                    }
                }
            }
            if (improvedHouse == true)
            {
                if (Keyboard.IsKeyPressed(System.Windows.Forms.Keys.S))
                {
                    if (GameWorld.Lumber >= 10 && GameWorld.Stone >= 10)
                    {
                        //GameWorld.ToAdd.Add(new House(@"", (new Vector2D(200, 200)), 300, dc));
                        //change house sprite
                        GameWorld.ToAdd.Add(new Button(@"Sprites\Buildsort.png", new Vector2D(992, 562)));
                    }
                }
            }
            if (animalBreed == true)
            {
                if (Keyboard.IsKeyPressed(System.Windows.Forms.Keys.D))
                {
                    if (GameWorld.Lumber >= 10 && GameWorld.Stone >= 10)
                    {
                        Farm.workInterval -= 1f;
                        //GameWorld.ToAdd.Add(new House(@"", (new Vector2D(200, 200)), 300, dc));
                        animalBreed = false;
                        GameWorld.ToRemove.Add(this);
                        GameWorld.ToAdd.Add(new Button(@"Sprites\Buildsort.png", new Vector2D(992, 562)));
                    }
                }
            }
            if (windmill == true)
            {
                if (Keyboard.IsKeyPressed(System.Windows.Forms.Keys.F))
                {
                    if (GameWorld.Lumber >= 10 && GameWorld.Stone >= 10)
                    {
                        Farm.workInterval -= 1f;
                        //GameWorld.ToAdd.Add(new House(@"", (new Vector2D(200, 200)), 300, dc));
                        windmill = false;
                        GameWorld.ToRemove.Add(this);
                        GameWorld.ToAdd.Add(new Button(@"Sprites\Buildsort.png", new Vector2D(992, 562)));
                    }
                }
            }
            if (sawmill == true)
            {
                if (Keyboard.IsKeyPressed(System.Windows.Forms.Keys.Z))
                {
                    if (GameWorld.Lumber >= 10 && GameWorld.Stone >= 10)
                    {
                        Lumbermill.workInterval -= 1f;
                        //GameWorld.ToAdd.Add(new House(@"", (new Vector2D(200, 200)), 300, dc));
                        sawmill = false;
                        GameWorld.ToRemove.Add(this);
                        GameWorld.ToAdd.Add(new Button(@"Sprites\Buildsort.png", new Vector2D(992, 562)));
                    }
                }
            }
            if (sawmillTwo == true)
            {
                if (Keyboard.IsKeyPressed(System.Windows.Forms.Keys.X))
                {
                    if (GameWorld.Lumber >= 10 && GameWorld.Stone >= 10)
                    {
                        Lumbermill.workInterval -= 1f;
                        //GameWorld.ToAdd.Add(new House(@"", (new Vector2D(200, 200)), 300, dc));
                        sawmillTwo = false;
                        GameWorld.ToRemove.Add(this);
                        GameWorld.ToAdd.Add(new Button(@"Sprites\Buildsort.png", new Vector2D(992, 562)));
                    }
                }
            }
            if (mineUpgrade == true)
            {
                if (Keyboard.IsKeyPressed(System.Windows.Forms.Keys.C))
                {
                    if (GameWorld.Lumber >= 10 && GameWorld.Stone >= 10)
                    {
                        Mine.workInterval -= 1f;
                        //GameWorld.ToAdd.Add(new House(@"", (new Vector2D(200, 200)), 300, dc));
                        mineUpgrade = false;
                        GameWorld.ToRemove.Add(this);
                        GameWorld.ToAdd.Add(new Button(@"Sprites\Buildsort.png", new Vector2D(992, 562)));
                    }
                }
            }
            if (mineUpgradeTwo == true)
            {
                if (Keyboard.IsKeyPressed(System.Windows.Forms.Keys.V))
                {
                    if (GameWorld.Lumber >= 10 && GameWorld.Stone >= 10)
                    {
                        Mine.workInterval -= 1f;
                        //GameWorld.ToAdd.Add(new House(@"", (new Vector2D(200, 200)), 300, dc));
                        mineUpgradeTwo = false;
                        GameWorld.ToRemove.Add(this);
                        GameWorld.ToAdd.Add(new Button(@"Sprites\Buildsort.png", new Vector2D(992, 562)));
                    }
                }
            }
            if (quarryUpgrade == true)
            {
                if (Keyboard.IsKeyPressed(System.Windows.Forms.Keys.T))
                {
                    if (GameWorld.Lumber >= 10 && GameWorld.Stone >= 10)
                    {
                        Quarry.workInterval -= 1f;
                        //GameWorld.ToAdd.Add(new House(@"", (new Vector2D(200, 200)), 300, dc));
                        quarryUpgrade = false;
                        GameWorld.ToRemove.Add(this);
                        GameWorld.ToAdd.Add(new Button(@"Sprites\Buildsort.png", new Vector2D(992, 562)));
                    }
                }
            }
            if (quarryUpgradeTwo == true)
            {
                if (Keyboard.IsKeyPressed(System.Windows.Forms.Keys.G))
                {
                    if (GameWorld.Lumber >= 10 && GameWorld.Stone >= 10)
                    {
                        Quarry.workInterval -= 1f;
                        //GameWorld.ToAdd.Add(new House(@"", (new Vector2D(200, 200)), 300, dc));
                        quarryUpgradeTwo = false;
                        GameWorld.ToRemove.Add(this);
                        GameWorld.ToAdd.Add(new Button(@"Sprites\Buildsort.png", new Vector2D(992, 562)));
                    }
                }
            }
            if (Keyboard.IsKeyPressed(System.Windows.Forms.Keys.Escape))
            {
                GameWorld.ToRemove.Add(this);
                GameWorld.ToAdd.Add(new Button(@"Sprites\Buildsort.png", new Vector2D(992, 562)));

            }
        }
    }
}
