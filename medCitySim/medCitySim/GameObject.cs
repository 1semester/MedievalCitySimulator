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
        protected Vector2D position;
        protected List<Image> animationFrames = new List<Image>();
        protected float currentFrameIndex;
        private RectangleF collisionbox;

        public RectangleF Collisionbox
        {
            get {return collisionbox;}

            set {collisionbox = value;}
        }

        public Vector2D Position
        {
            get
            {
                return position;
            }

            set
            {
                position = value;
            }
        }

        public GameObject(string imagePath,Vector2D position)
        {
            string[] imagePaths = imagePath.Split(';');
            this.animationFrames = new List<Image>();

            foreach (string path in imagePaths)
            {
                animationFrames.Add(Image.FromFile(path));
            }
            this.sprite = this.animationFrames[0];
            this.position = position;
        }
        public virtual void Update(float currentFPS)
        {

        }
        public virtual void Draw(Graphics dc)
        {
            dc.DrawImage(sprite, new PointF(position.X, position.Y));
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
            this.position = position;
        }
    }
}
