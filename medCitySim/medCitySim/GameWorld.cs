﻿using System;
using System.Collections.Generic;

using System.Drawing;

using IrrKlang;

namespace MedCitySim
{
    class GameWorld
    {

        //commit comment
        private Graphics dc;
        public static int citizenPop;
        private static int citizenCap = 4;
        //private List<GameObject> objs = new List<GameObject>();
        public static List<GameObject> objs = new List<GameObject>();
        private static List<GameObject> toAdd = new List<GameObject>();
        private static List<GameObject> toRemove = new List<GameObject>();
        private Rectangle window = new Rectangle();
        private static Rectangle displayRectangle = new Rectangle();
        private float currentFPS;
        private BufferedGraphics backBuffer;
        private DateTime endTime;
        private static int lumber = 150;
        private static int iron = 100;
        private static int stone = 150;
        private static int food = 10;
        private string cantBuild = "You cant build there!";
        public static float dayInterval = 120f;
        public static float dayCooldown;
        public static int daycount = 1;
        public static bool nightTime = false;
        private bool spawning = true;

        

        private ISoundEngine engine;
        private void StartSounds()
        {
            try
            {
                engine = new ISoundEngine();
                engine.Play2D("Media/Song1.mp3", true);
                //engine.Play2D("Media/Song2.mp3", false);
                //engine.Play2D("Media/Song3.mp3", true);
            }
            catch (Exception ex) { }
        }


        internal static List<GameObject> ToAdd
        {
            get
            {
                return toAdd;
            }

            set
            {
                toAdd = value;
            }
        }

        internal static List<GameObject> ToRemove
        {
            get
            {
                return toRemove;
            }

            set
            {
                toRemove = value;
            }
        }
        //internal static List<GameObject> Objs { get; private set; }
        public static List<GameObject> Objs { get; set; }
        internal static int Lumber
        {
            get
            {
                return lumber;
            }

            set
            {
                lumber = value;
            }
        }

        internal static int Iron
        {
            get
            {
                return iron;
            }

            set
            {
                iron = value;
            }
        }

        internal static int Stone
        {
            get
            {
                return stone;
            }

            set
            {
                stone = value;
            }
        }

        internal static Rectangle DisplayRectangle
        {
            get
            {
                return displayRectangle;
            }

            set
            {
                displayRectangle = value;
            }
        }

        internal string CantBuild
        {
            get
            {
                return cantBuild;
            }

            set
            {
                cantBuild = value;
            }
        }

        internal static int Food
        {
            get
            {
                return food;
            }

            set
            {
                food = value;
            }
        }

        internal static int CitizenPop
        {
            get
            {
                return citizenPop;
            }

            set
            {
                citizenPop = value;
            }
        }

        internal static int CitizenCap
        {
            get
            {
                return citizenCap;
            }

            set
            {
                citizenCap = value;
            }
        }
        /// <summary>
        /// This function displays the rectangles on sprites.
        /// </summary>
        /// <param name="dc"></param>
        /// <param name="displayRectangle"></param>
        public GameWorld(Graphics dc, Rectangle displayRectangle)
        {
            Objs = objs;
            SetupWorld();
            this.window = displayRectangle;
            this.backBuffer = BufferedGraphicsManager.Current.Allocate(dc, displayRectangle);
            this.dc = backBuffer.Graphics;
        }
        /// <summary>
        /// This function runs everything that will be drawn and started when the game is launched
        /// </summary>
        public void SetupWorld()
        {
            daycount = 1;
            //TimeOfDay.Start();
            //Font e = new Font("Ressourcer", 16);
            //dc.DrawString(string.Format("Wood: {0}  Iron: {1}  Stone: {2}  Food: {3}", Lumber, Iron, Stone, Food), e, Brushes.Black, 200, 0);
            objs.Add(new UserInterface(@"Sprites\UserInterface.png", (new Vector2D(0, 0))));
            objs.Add(new Background(@"Sprites\Background.png", (new Vector2D(0, 41))));
            objs.Add(new Mountain(@"Sprites\Mountain.png", new Vector2D(0, 41)));
            objs.Add(new Forest(@"Sprites\TreeLineLeft.png", new Vector2D(0, 91)));
            objs.Add(new Forest(@"Sprites\TreeLineRight.png", new Vector2D(932, 91)));
            objs.Add(new Button(@"Sprites\Button.png", (new Vector2D(999, 614))));
            objs.Add(new Storage(@"Sprites\Buildings\StorageLille.png", (new Vector2D(496, 466))));

            StartSounds();


            //endTime skal kaldes sidst!
            endTime = DateTime.Now;
        }
        /// <summary>
        /// Makes sure everything based on inputs is updated within the game.
        /// </summary>
        public void GameLoop()
        {

            //timeOfDay2.Second.
            foreach (GameObject go in toRemove)
            {
                objs.Remove(go);
            }
            objs.AddRange(ToAdd);
            toAdd.Clear();
            toRemove.Clear();
            DateTime startTime = DateTime.Now;
            TimeSpan deltaTime = startTime - endTime;
            int milliSeconds = deltaTime.Milliseconds > 0 ? deltaTime.Milliseconds : 1;
            currentFPS = 1000 / milliSeconds;
            Update(currentFPS);
            Draw();
            endTime = DateTime.Now;


        }
        /// <summary>
        /// This function updates everything regarding timers and handles the spawning of raiders and wildanimals.
        /// It also updates citizen population along with the keyboard class.
        /// </summary>
        /// <param name="fps"></param>
        private void Update(float fps)
        {
            float dayTime = 1f / currentFPS;
            dayCooldown += dayTime;


            if (dayCooldown >= 120)//skal ændres til 120 !! det her er debug tid
            {
                spawning = true;
                if (spawning==true)
                {
                    
                Raider.Raid();
                }
                daycount++;
                dayCooldown -= dayInterval;
            }
            if (dayCooldown>=60.000000 && dayCooldown <=60.100000&& spawning==true)
            {
                WildAnimal.AnimalAttack();
                spawning = false;
            }





            citizenPop = 0;
            Keyboard.Update();
            this.currentFPS = fps;
            foreach (GameObject go in objs)
            {
                go.Update(currentFPS);
                if (go is Citizen)
                {
                    citizenPop++;
                }
            }
        }
        /// <summary>
        /// This function draws all the strings we want to be shown on the screen when the game is launched.
        /// </summary>
        private void Draw()
        {
            dc.Clear(Color.Beige);

            foreach (GameObject go in objs)
            {
                go.Draw(dc);
            }
            Font e = new Font("Ressourcer", 16);
            dc.DrawString(string.Format("{0}", Food), e, Brushes.Yellow, 36, 7);
            dc.DrawString(string.Format("{0}", Lumber), e, Brushes.Yellow, 142, 7);
            dc.DrawString(string.Format("{0}", Stone), e, Brushes.Yellow, 252, 7);
            dc.DrawString(string.Format("{0}", Iron), e, Brushes.Yellow, 357, 7);
            dc.DrawString(string.Format("{0}/{1}", citizenPop, citizenCap), e, Brushes.Yellow, 1180, 7);
            dc.DrawString(string.Format("Day: {0}", daycount), e, Brushes.Yellow, 1020, 7);
#if DEBUG
            Font f = new Font("Yellow", 16);
            dc.DrawString(string.Format("FPS: {0}", currentFPS), f, Brushes.Black, 400, 7);
            dc.DrawString(string.Format("Daytimer: {0}", dayCooldown), f, Brushes.Black, 400, 20);
#endif




            try
            {
                backBuffer.Render();
            }
            catch (Exception)
            {
            }
        }
    }
}
