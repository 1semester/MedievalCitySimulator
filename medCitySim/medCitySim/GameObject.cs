using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MedCitySim
{
    abstract class GameObject
    {
        public Image sprite;
        protected Vector2D startPosition;
        protected List<Image> animationFrames = new List<Image>();
        protected float currentFrameIndex;
        private RectangleF collisionbox;

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
            string[] imagePaths = imagePath.Split(';');
            this.animationFrames = new List<Image>();

            foreach (string path in imagePaths)
            {
                animationFrames.Add(Image.FromFile(path));
            }
            this.sprite = this.animationFrames[0];
            this.startPosition = startPosition;
        }
        public virtual void Update(float currentFPS)
        {

        }
        public virtual void Draw(Graphics dc)
        {
            dc.DrawImage(sprite, new PointF(startPosition.X, startPosition.Y));
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
