﻿using System;
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
        private static List<GameObject> toAdd = new List<GameObject>();
        private static List<GameObject> toRemove = new List<GameObject>();
        private Rectangle displayRectangle = new Rectangle();
        private float currentFPS;
        private BufferedGraphics backBuffer;
        private DateTime endTime;
        private int lumber = 100;
        private int iron = 100;
        private int stone = 100;

       

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
        internal static List<GameObject> Objs
        {
            get
            {
                return Objs;
            }
        }
        #region Ressources
        public int Lumber
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

        public int Iron
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

        public int Stone
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

        

        
        #endregion
        public GameWorld(Graphics dc, Rectangle displayRectangle)
        {
            SetupWorld();
            this.displayRectangle = displayRectangle;
            this.backBuffer = BufferedGraphicsManager.Current.Allocate(dc, displayRectangle);
            this.dc = backBuffer.Graphics;
        }
        public void SetupWorld()
        {
            House house = new House(@"Sprites\Hus.png", new Vector2D(200, 200));
           
            objs.Add(house);
           Citizen lars = new Citizen(@"Sprites\rsz_cop1.png", new Vector2D(10, 10), "lars", true, Citizen.assignment.farmer);
            objs.Add(lars);
        
           


            //endTime skal kaldes sidst!
            endTime = DateTime.Now;
        }
        public void GameLoop()
        {

            foreach (GameObject go in toRemove)
            {
                Objs.Remove(go);
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
            
            this.currentFPS = fps;
            foreach (GameObject go in objs)
            {
                go.Update(currentFPS);
            }
        }
        private void Draw()
        {
            dc.Clear(Color.White);
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
    }
}
