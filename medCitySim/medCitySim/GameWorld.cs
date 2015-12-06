using System;
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
        private static List<GameObject> objects = new List<GameObject>();
        private static List<GameObject> toAdd = new List<GameObject>();
        private static List<GameObject> toRemove = new List<GameObject>();
        private Rectangle displayRectangle = new Rectangle();
        private float currentFPS;
        private BufferedGraphics backBuffer;
        private DateTime endTime;

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
        public GameWorld(Graphics dc, Rectangle displayRectangle)
        {

        }
        public void SetupWorld()
        {

        }
        public void GameLoop()
        {

        }
        private void Update(float currentFPS)
        {

        }
        private void Draw(Graphics dc)
        {

        }
        private void UpdateAnimations(float currentFPS)
        {

        }
    }
}
