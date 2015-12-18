using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using IrrKlang;

namespace MedCitySim
{
    class GameWorld
    {

        //commit comment
        private Graphics dc;
        private static int citizenPop;
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
        private static int lumber = 20;
        private static int iron = 20;
        private static int stone = 20;
        private static int food = 5;
        private string cantBuild = "You cant build there!";
        public static float dayInterval = 300f;
        private float dayCooldown;
        private int daycount;
        private bool nightTime = false;
        #region Get and Sets.

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

        #endregion
        public GameWorld(Graphics dc, Rectangle displayRectangle)
        {
           Objs = objs;
            SetupWorld();
            this.window = displayRectangle;
            this.backBuffer = BufferedGraphicsManager.Current.Allocate(dc, displayRectangle);
            this.dc = backBuffer.Graphics;
        }
        public void SetupWorld()
        {
            daycount = 1;
            //TimeOfDay.Start();
            //Font e = new Font("Ressourcer", 16);
            //dc.DrawString(string.Format("Wood: {0}  Iron: {1}  Stone: {2}  Food: {3}", Lumber, Iron, Stone, Food), e, Brushes.Black, 200, 0);
            objs.Add(new UserInterface(@"Sprites\UserInterface.png", (new Vector2D(0, 0))));
            objs.Add(new Background(@"Sprites\Background.png", (new Vector2D(0, 30))));
            objs.Add(new Button(@"Sprites\Button.png", (new Vector2D(992,562))));

            StartSounds();
            
            Citizen lars = new Citizen(@"Sprites\rsz_cop1.png", new Vector2D(400, 400), "lars", true, Citizen.Assignment.farmer);
            objs.Add(lars);

            //endTime skal kaldes sidst!
            endTime = DateTime.Now;
        }
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
            UpdateAnimations(currentFPS);
            Draw();
            endTime = DateTime.Now;
            float dayTime = 1f / currentFPS;

            dayCooldown += dayTime;
            if (dayCooldown <240)
            {
                nightTime = false;
            }
            if (dayCooldown >= 240)
            {
                nightTime = true;
            }

            if (dayCooldown >= 300)
            {

                daycount++;
                dayCooldown -= dayInterval;
            }
        }
        private void Update(float fps)
        {
            Keyboard.Update();
            this.currentFPS = fps;
            foreach (GameObject go in objs)
            {
                go.Update(currentFPS);
            }
        }
        private void Draw()
        {
            dc.Clear(Color.Beige);
#if DEBUG
            Font f = new Font("Yellow", 16);
            dc.DrawString(string.Format("FPS: {0}", currentFPS), f, Brushes.Black, 0, 0);
#endif

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




            backBuffer.Render();
        }
        private void UpdateAnimations(float currentFPS)
        {

        }
        public static void PrintStringOnScreen(string s, Graphics dc)
        {
            Font f = new Font("Yellow", 16);
            dc.DrawString(string.Format(s), f, Brushes.Red, GameWorld.DisplayRectangle.Width / 2, GameWorld.DisplayRectangle.Height / 2);
        }

        public static bool positionOcuppied(Vector2D position)
        {
            Rectangle rect = new Rectangle();
            rect.X = Convert.ToInt32(position.X);
            rect.Y = Convert.ToInt32(position.Y) ;

           rect.Width = rect.Height = 1;
            
            
            foreach (GameObject go in objs)
            {
                if (go is Background)
                    continue;
                if (go is Citizen)
                    continue;
                if (go is UserInterface)
                    continue;
                if (go.CollisionBox.IntersectsWith(rect))
                {
                     return true;
                }
                    
               
            }
            return false;
        }
    }
}
