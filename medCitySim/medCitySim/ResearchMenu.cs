using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IrrKlang;

namespace MedCitySim
{
    class ResearchMenu : GameObject
    {
        protected ISoundEngine engine;
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
                if (Keyboard.IsKeyPressed(System.Windows.Forms.Keys.D))
                {
                    if (GameWorld.Lumber >= 10 && GameWorld.Stone >= 10)
                    {
                        well = false;
                        
                            //GameWorld.ToAdd.Add(new House(@"", (new Vector2D(200, 200)), 300, dc));
                            GameWorld.ToAdd.Add(new Button(@"Sprites\Button.png", new Vector2D(992, 562)));

                    }
                    else
                    {
                        CantResserach();
                    }
                }
            }
            if (improvedHouse == true)
            {
                if (Keyboard.IsKeyPressed(System.Windows.Forms.Keys.H))
                {
                    if (GameWorld.Lumber >= 10 && GameWorld.Stone >= 10)
                    {
                        //change house sprite
                        GameWorld.ToRemove.Add(this);
                        GameWorld.ToAdd.Add(new Button(@"Sprites\Button.png", new Vector2D(992, 562)));
                    }

                    else
                    {
                        CantResserach();
                    }
                }
            }
            if (animalBreed == true)
            {
                if (Keyboard.IsKeyPressed(System.Windows.Forms.Keys.F))
                {
                    if (GameWorld.Lumber >= 10 && GameWorld.Stone >= 10)
                    {
                        Farm.workInterval -= 1f;
                        animalBreed = false;
                        GameWorld.ToRemove.Add(this);
                        GameWorld.ToAdd.Add(new Button(@"Sprites\Button.png", new Vector2D(992, 562)));
                    }
                    else
                    {
                        CantResserach();
                    }
                }
            }
            if (windmill == true)
            {
                if (Keyboard.IsKeyPressed(System.Windows.Forms.Keys.A))
                {
                    if (GameWorld.Lumber >= 10 && GameWorld.Stone >= 10)
                    {
                        Farm.workInterval -= 1f;
                        windmill = false;
                        GameWorld.ToRemove.Add(this);
                        GameWorld.ToAdd.Add(new Button(@"Sprites\Button.png", new Vector2D(992, 562)));
                    }
                    else
                    {
                        CantResserach();
                    }
                }
            }
            if (sawmill == true)
            {
                if (Keyboard.IsKeyPressed(System.Windows.Forms.Keys.L))
                {
                    if (GameWorld.Lumber >= 10 && GameWorld.Stone >= 10)
                    {
                        Lumbermill.workInterval -= 1f;
                        sawmill = false;
                        GameWorld.ToRemove.Add(this);
                        GameWorld.ToAdd.Add(new Button(@"Sprites\Button.png", new Vector2D(992, 562)));
                    }
                    else
                    {
                        CantResserach();
                    }
                }
            }
            if (sawmillTwo == true)
            {
                if (Keyboard.IsKeyPressed(System.Windows.Forms.Keys.U))
                {
                    if (GameWorld.Lumber >= 10 && GameWorld.Stone >= 10)
                    {
                        Lumbermill.workInterval -= 1f;
                        sawmillTwo = false;
                        GameWorld.ToRemove.Add(this);
                        GameWorld.ToAdd.Add(new Button(@"Sprites\Button.png", new Vector2D(992, 562)));
                    }
                    else
                    {
                        CantResserach();
                    }
                }
            }
            if (mineUpgrade == true)
            {
                if (Keyboard.IsKeyPressed(System.Windows.Forms.Keys.M))
                {
                    if (GameWorld.Lumber >= 10 && GameWorld.Stone >= 10)
                    {
                        Mine.workInterval -= 1f;
                        mineUpgrade = false;
                        GameWorld.ToRemove.Add(this);
                        GameWorld.ToAdd.Add(new Button(@"Sprites\Button.png", new Vector2D(992, 562)));
                    }
                    else
                    {
                        CantResserach();
                    }
                }
            }
            if (mineUpgradeTwo == true)
            {
                if (Keyboard.IsKeyPressed(System.Windows.Forms.Keys.E))
                {
                    if (GameWorld.Lumber >= 10 && GameWorld.Stone >= 10)
                    {
                        Mine.workInterval -= 1f;
                        mineUpgradeTwo = false;
                        GameWorld.ToRemove.Add(this);
                        GameWorld.ToAdd.Add(new Button(@"Sprites\Button.png", new Vector2D(992, 562)));
                    }
                    else
                    {
                        CantResserach();
                    }
                }
            }
            if (quarryUpgrade == true)
            {
                if (Keyboard.IsKeyPressed(System.Windows.Forms.Keys.Q))
                {
                    if (GameWorld.Lumber >= 10 && GameWorld.Stone >= 10)
                    {
                        Quarry.workInterval -= 1f;
                        quarryUpgrade = false;
                        GameWorld.ToRemove.Add(this);
                        GameWorld.ToAdd.Add(new Button(@"Sprites\Button.png", new Vector2D(992, 562)));
                    }
                    else
                    {
                        CantResserach();
                    }
                }
            }
            if (quarryUpgradeTwo == true)
            {
                if (Keyboard.IsKeyPressed(System.Windows.Forms.Keys.R))
                {
                    if (GameWorld.Lumber >= 10 && GameWorld.Stone >= 10)
                    {
                        Quarry.workInterval -= 1f;
                        quarryUpgradeTwo = false;
                        GameWorld.ToRemove.Add(this);
                        GameWorld.ToAdd.Add(new Button(@"Sprites\Button.png", new Vector2D(992, 562)));
                    }
                    else
                    {
                        CantResserach();
                    }
                }
            }
            if (Keyboard.IsKeyPressed(System.Windows.Forms.Keys.Escape))
            {
                GameWorld.ToRemove.Add(this);
                GameWorld.ToAdd.Add(new Button(@"Sprites\Button.png", new Vector2D(992, 562)));

            }

        }


        protected void CantResserach()
        {
            try
            {
                engine = new ISoundEngine();
                engine.Play2D("Media/efx_NO-Fabio_Farinelli-955789468.mp3", false);
            }
            catch (Exception ex) { }
        }
    }
}
