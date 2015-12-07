﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MedCitySim
{
    class GameWorld
    {

        //commit comment
        private Graphics dc;
        private static List<GameObject> objects;
        private static List<GameObject> toAdd = new List<GameObject>();
        private static List<GameObject> toRemove = new List<GameObject>();
        private Rectangle displayRectangle = new Rectangle();
        private float currentFPS;
        private BufferedGraphics backBuffer;
        private DateTime endTime;
        private int lumber = 100;
        private int iron = 100;
        private int stone = 100;

        public static List<GameObject> Objects
        {
            get
            {
                return objects;
            }

            set
            {
                objects = value;
            }
        }

        public static List<GameObject> ToAdd
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

        public static List<GameObject> ToRemove
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
            objects = new List<GameObject>();
        }
        public void SetupWorld()
        {
            Button test = new Button(new Vector2D(200, 200), "Buildsort.png;Buildrød.png");
            objects.Add(test);

            //endTime skal kaldes sidst!
            endTime = DateTime.Now;
        }
        public void GameLoop()
        {

            foreach (GameObject go in toRemove)
            {
                Objects.Remove(go);
            }
            objects.AddRange(ToAdd);
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
            foreach (GameObject go in objects)
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

            foreach (GameObject go in objects)
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
