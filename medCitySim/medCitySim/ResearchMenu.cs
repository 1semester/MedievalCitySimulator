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
        private static bool well = true;
        private static bool windmill = true;
        private static bool improvedHouse = true;
        public static bool animalBreed = true;
        public static bool sawmill = true;
        public static bool sawmillTwo = true;
        public static bool mineUpgrade = true;
        public static bool mineUpgradeTwo = true;
        public static bool quarryUpgrade = true;
        public static bool quarryUpgradeTwo = true;

        public static bool Well
        {
            get
            {
                return well;
            }
        }
        internal static bool ImprovedHouse
        {
            get
            {
                return improvedHouse;
            }
        }

        public override void Update(float currentFPS)
        {

            if (Keyboard.IsKeyPressed(System.Windows.Forms.Keys.D))
            {
                if (GameWorld.Iron >= 20 && well == true)
                {
                    Cost();
                    well = false;
                    GameWorld.ToAdd.Add(new Button(@"Sprites\Button.png", new Vector2D(992, 562)));
                }
                else
                {
                    CantResearch();
                }
            }

            if (Keyboard.IsKeyPressed(System.Windows.Forms.Keys.H))
            {
                if (GameWorld.Iron >= 20 && improvedHouse == true)
                {
                    //change house sprite
                    GameWorld.ToRemove.Add(this);
                    improvedHouse = false;
                    Cost();

                    GameWorld.ToAdd.Add(new Button(@"Sprites\Button.png", new Vector2D(992, 562)));
                    BuildSound();
                }
                else
                {
                    CantResearch();
                }
            }

            if (Keyboard.IsKeyPressed(System.Windows.Forms.Keys.F))
            {
                if (GameWorld.Iron >= 20 && animalBreed == true)
                {
                    Farm.workInterval -= 1f;
                    Cost();
                    animalBreed = false;
                    GameWorld.ToRemove.Add(this);
                    GameWorld.ToAdd.Add(new Button(@"Sprites\Button.png", new Vector2D(992, 562)));
                }
                else
                {
                    CantResearch();
                }
            }

            if (Keyboard.IsKeyPressed(System.Windows.Forms.Keys.A))
            {
                if (GameWorld.Iron >= 20 && windmill == true)
                {
                    Farm.workInterval -= 1f;
                    Cost();
                    windmill = false;
                    GameWorld.ToRemove.Add(this);
                    GameWorld.ToAdd.Add(new Button(@"Sprites\Button.png", new Vector2D(992, 562)));
                }
                else
                {
                    CantResearch();
                }
            }

            if (Keyboard.IsKeyPressed(System.Windows.Forms.Keys.L))
            {
                if (GameWorld.Iron >= 20 && sawmill == true)
                {
                    Lumbermill.workInterval -= 1f;
                    Cost();
                    sawmill = false;
                    GameWorld.ToRemove.Add(this);
                    GameWorld.ToAdd.Add(new Button(@"Sprites\Button.png", new Vector2D(992, 562)));
                }
                else
                {
                    CantResearch();
                }
            }
            if (Keyboard.IsKeyPressed(System.Windows.Forms.Keys.U))
            {
                if (GameWorld.Iron >= 20 && sawmillTwo == true)
                {
                    Lumbermill.workInterval -= 1f;
                    Cost();
                    sawmillTwo = false;
                    GameWorld.ToRemove.Add(this);
                    GameWorld.ToAdd.Add(new Button(@"Sprites\Button.png", new Vector2D(992, 562)));
                }
                else
                {
                    CantResearch();
                }
            }

            if (Keyboard.IsKeyPressed(System.Windows.Forms.Keys.M))
            {
                if (GameWorld.Iron >= 20 && mineUpgrade == true)
                {
                    Mine.workInterval -= 1f;
                    Cost();
                    mineUpgrade = false;
                    GameWorld.ToRemove.Add(this);
                    GameWorld.ToAdd.Add(new Button(@"Sprites\Button.png", new Vector2D(992, 562)));
                }
                else
                {
                    CantResearch();
                }

            }
            if (Keyboard.IsKeyPressed(System.Windows.Forms.Keys.E))
            {
                if (GameWorld.Iron >= 20 && mineUpgradeTwo == true)
                {
                    Mine.workInterval -= 1f;
                    Cost();
                    mineUpgradeTwo = false;
                    GameWorld.ToRemove.Add(this);
                    GameWorld.ToAdd.Add(new Button(@"Sprites\Button.png", new Vector2D(992, 562)));
                }
                else
                {
                    CantResearch();
                }
            }
            if (Keyboard.IsKeyPressed(System.Windows.Forms.Keys.Q))
            {
                if (GameWorld.Iron >= 20 && quarryUpgrade == true)
                {
                    Quarry.workInterval -= 1f;
                    Cost();
                    quarryUpgrade = false;
                    GameWorld.ToRemove.Add(this);
                    GameWorld.ToAdd.Add(new Button(@"Sprites\Button.png", new Vector2D(992, 562)));
                }
                else
                {
                    CantResearch();
                }
            }

            if (Keyboard.IsKeyPressed(System.Windows.Forms.Keys.R))
            {
                if (GameWorld.Iron >= 20 && quarryUpgradeTwo == true)
                {
                    Quarry.workInterval -= 1f;
                    quarryUpgradeTwo = false;
                    Cost();
                    GameWorld.ToRemove.Add(this);
                    GameWorld.ToAdd.Add(new Button(@"Sprites\Button.png", new Vector2D(992, 562)));
                }
                else
                {
                    CantResearch();
                }
            }

            if (Keyboard.IsKeyPressed(System.Windows.Forms.Keys.Escape))
            {
                GameWorld.ToRemove.Add(this);
                GameWorld.ToAdd.Add(new Button(@"Sprites\Button.png", new Vector2D(992, 562)));

            }

        }
        
        protected void CantResearch()
        {
            try
            {
                engine = new ISoundEngine();
                engine.Play2D("Media/efx_NO-Fabio_Farinelli-955789468.mp3", false);
            }
            catch (Exception ex) { }
        }
        public void Cost()
        {
            GameWorld.Iron -= 20;
        }
        protected void BuildSound()
        {
            try
            {
                engine = new ISoundEngine();
                engine.Play2D("Media/Construction.mp3", false);
            }
            catch (Exception ex) { }
        }
    }
}
