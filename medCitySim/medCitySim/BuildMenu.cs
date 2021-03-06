﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using IrrKlang;

namespace MedCitySim
{
    class BuildMenu : GameObject
    {
        protected ISoundEngine engine;
        private Graphics dc;
        public BuildMenu(string imagePath, Vector2D startPosition) : base(imagePath, startPosition)
        {
        }
        /// <summary>
        /// The update in the buildmenu checks for when the player presses one of the assigned keys, that is used for the class
        /// </summary>
        /// <param name="currentFPS"></param>
        public override void Update(float currentFPS)
        {
            if (Keyboard.IsKeyPressed(System.Windows.Forms.Keys.H))
            {
                if (GameWorld.Lumber >= 30 && GameWorld.Stone >= 15)
                {
                    GameWorld.ToAdd.Add(new House(@"Sprites\Buildings\House.png", (new Vector2D(200, 200)), 300));
                    GameWorld.ToRemove.Add(this);
                    GameWorld.ToAdd.Add(new Button(@"Sprites\Button.png", new Vector2D(999, 614)));
                }
                else
                {
                    CantBuild();
                }

            }
            if (Keyboard.IsKeyPressed(System.Windows.Forms.Keys.C))
            {
                if (GameWorld.Lumber >= 25 && GameWorld.Stone >= 75)
                {
                    GameWorld.ToAdd.Add(new Church(@"Sprites\Buildings\Church.png", (new Vector2D(200, 200)), 300));
                    GameWorld.ToRemove.Add(this);
                    GameWorld.ToAdd.Add(new Button(@"Sprites\Button.png", new Vector2D(999, 614)));
                }
                else
                {
                    CantBuild();
                }

            }
            if (Keyboard.IsKeyPressed(System.Windows.Forms.Keys.W))
            {
                if (GameWorld.Lumber >= 25 && GameWorld.Stone >= 50 && GameWorld.Iron >= 10 && ResearchMenu.Well == false)
                {
                    GameWorld.ToAdd.Add(new Well(@"Sprites\Buildings\WellLille.png", (new Vector2D(200, 200)), 300));
                    GameWorld.ToRemove.Add(this);
                    GameWorld.ToAdd.Add(new Button(@"Sprites\Button.png", new Vector2D(999, 614)));
                }
                else
                {
                    CantBuild();
                }
            }
            if (Keyboard.IsKeyPressed(System.Windows.Forms.Keys.F))
            {
                if (GameWorld.Lumber >= 50 && GameWorld.Stone >= 25 && GameWorld.Iron >= 2)
                {
                    GameWorld.ToAdd.Add(new Farm(@"Sprites\Buildings\Farm.png", (new Vector2D(200, 200)), 300));
                    GameWorld.ToRemove.Add(this);
                    GameWorld.ToAdd.Add(new Button(@"Sprites\Button.png", new Vector2D(999, 614)));
                }
                else
                {
                    CantBuild();
                }
            }
            if (Keyboard.IsKeyPressed(System.Windows.Forms.Keys.T))
            {
                if (GameWorld.Lumber >= 25 && GameWorld.Stone >= 50 && GameWorld.Iron >= 15)
                {
                    GameWorld.ToAdd.Add(new CivilWatch(@"Sprites\Buildings\WatchTowerLille.png", (new Vector2D(200, 200)), 300));
                    GameWorld.ToRemove.Add(this);
                    GameWorld.ToAdd.Add(new Button(@"Sprites\Button.png", new Vector2D(999, 614)));
                }
                else
                {
                    CantBuild();
                }
            }
            if (Keyboard.IsKeyPressed(System.Windows.Forms.Keys.L))
            {
                if (GameWorld.Lumber >= 50 && GameWorld.Stone >= 10 && GameWorld.Iron >= 2)
                {
                    GameWorld.ToAdd.Add(new Lumbermill(@"Sprites\Buildings\LumberMill.png", (new Vector2D(200, 200)), 300));
                    GameWorld.ToRemove.Add(this);
                    GameWorld.ToAdd.Add(new Button(@"Sprites\Button.png", new Vector2D(999, 614)));
                }
                else
                {
                    CantBuild();
                }
            }
            if (Keyboard.IsKeyPressed(System.Windows.Forms.Keys.Q))
            {
                if (GameWorld.Lumber >= 50 && GameWorld.Stone >= 10 && GameWorld.Iron >= 2)
                {
                    GameWorld.ToAdd.Add(new Quarry(@"Sprites\Buildings\Quarry.png", (new Vector2D(200, 200)), 300));
                    GameWorld.ToRemove.Add(this);
                    GameWorld.ToAdd.Add(new Button(@"Sprites\Button.png", new Vector2D(999, 614)));
                }
                else
                {
                    CantBuild();
                }
            }
            if (Keyboard.IsKeyPressed(System.Windows.Forms.Keys.O))
            {
                if (GameWorld.Lumber >= 50 && GameWorld.Stone >= 50 && GameWorld.Iron >= 20)
                {
                    GameWorld.ToAdd.Add(new Blacksmith(@"Sprites\Buildings\Blacksmith.png", (new Vector2D(200, 200)), 300));
                    GameWorld.ToRemove.Add(this);
                    GameWorld.ToAdd.Add(new Button(@"Sprites\Button.png", new Vector2D(999, 614)));
                }
                else
                {
                    CantBuild();
                }
            }
            if (Keyboard.IsKeyPressed(System.Windows.Forms.Keys.M))
            {
                if (GameWorld.Lumber >= 10 && GameWorld.Stone >= 50 && GameWorld.Iron >= 2)
                {
                    GameWorld.ToAdd.Add(new Mine(@"Sprites\Buildings\IronMineLille.png", (new Vector2D(200, 200)), 300));
                    GameWorld.ToRemove.Add(this);
                    GameWorld.ToAdd.Add(new Button(@"Sprites\Button.png", new Vector2D(999, 614)));
                }
                else
                {
                    CantBuild();
                }
            }

            if (Keyboard.IsKeyPressed(System.Windows.Forms.Keys.Escape))
            {
                GameWorld.ToRemove.Add(this);
                GameWorld.ToAdd.Add(new Button(@"Sprites\Button.png", new Vector2D(999, 614)));

            }
            base.Update(currentFPS);
        }
        /// <summary>
        /// This method holds the sound that is played, when the player cant build, or if there isnt enough ressources
        /// </summary>
        protected void CantBuild()
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
