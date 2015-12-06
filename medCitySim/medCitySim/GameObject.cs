using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MedCitySim
{
    class GameObject
    {
        protected Image sprite;
        protected Vector2D startPosition;
        protected List<Image> animationFrames = new List<Image>();
        protected float currentFrameIndex;
        private RectangleF collisionbox;
        public string imagePath;

        public RectangleF Collisionbox
        {
            get {return collisionbox;}

            set {collisionbox = value;}
        }

        protected Vector2D StartPosition
        {
            get
            {
                return startPosition;
            }

            set
            {
                startPosition = value;
            }
        }

        public GameObject(string imagePath,Vector2D startPosition)
        {
            this.imagePath = imagePath;
            this.StartPosition = startPosition;
        }
        public void Update(float currentFPS)
        {

        }
        public void Draw(Graphics dc)
        {

        }
        public void UpdateAnimations(float currentFPS)
        {

        }
        public bool IsCollidingWith(GameObject other)
        {
            return true;
        }
        private void CheckCollosion()
        {

        }
        public virtual void OnCollision(GameObject other)
        {
            this.startPosition = startPosition;
        }
    }
}
