using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace MedCitySim
{
    class GameWorld
    {

        //commit comment
        private Graphics dc;
        
        private List<GameObject> objs = new List<GameObject>();
        public static List<GameObject> objs = new List<GameObject>();
        private static List<GameObject> toAdd = new List<GameObject>();
        private static List<GameObject> toRemove = new List<GameObject>();
        private Rectangle window = new Rectangle();
        private static Rectangle displayRectangle = new Rectangle();
        private float currentFPS;
        private BufferedGraphics backBuffer;
        private DateTime endTime;
        private static int lumber = 100;
        private static int iron = 100;
        private static int stone = 100;
        private string cantBuild = "You cant build there!";
       

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
        internal static List<GameObject> Objs { get; private set; }
        public static List<GameObject> Objs { get; set; }
        #region Ressources
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
            objs.Add(new Background(@"Sprites\Background.png", (new Vector2D(0, 0))));
            objs.Add(new Button(@"Sprites\Buildsort.png", (new Vector2D(20, 20))));
            House house;
            house = new House(@"Sprites\Hus.png", new Vector2D(200, 200),50);

            objs.Add(house);
            
            Citizen lars = new Citizen(@"Sprites\rsz_cop1.png", new Vector2D(400, 400), "lars", true, Citizen.Assignment.lumberJack);
            objs.Add(lars);
        
           
            //objs.Add(new Button(@"Sprites\Buildsort.png", (new Vector2D(2121, 1313))));
            objs.Add(new House(@"Sprites\Hus.png", new Vector2D(200, 200), 50));


            //endTime skal kaldes sidst!
            endTime = DateTime.Now;
        }
        public void GameLoop()
        {

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
            Font e = new Font("Lort", 16);
            dc.DrawString(string.Format("Wood: {0}  Iron: {1}  Stone: {2}", Lumber, Iron, Stone), e, Brushes.Black, 200, 0);

            foreach (GameObject go in objs)
            {
                go.Draw(dc);
            }
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
    }
}
