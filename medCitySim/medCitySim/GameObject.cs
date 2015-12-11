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
        private RectangleF collisionBox;

        public RectangleF CollisionBox
        {
            get
            {
                return new RectangleF(position.X, position.Y, sprite.Width, sprite.Height);
            }
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

        public GameObject(string imagePath, Vector2D startPosition)
        public GameObject(string imagePath,Vector2D position)
        {
            string[] imagePaths = imagePath.Split(';');
            this.animationFrames = new List<Image>();

            foreach (string path in imagePaths)
            {
                animationFrames.Add(Image.FromFile(path));
            }
            this.sprite = this.animationFrames[0];
            this.position = startPosition;
            this.position = position;
        }
        public virtual void Update(float currentFPS)
        {
            CheckCollosion();
        }
        public virtual void Draw(Graphics dc)
        {
            dc.DrawImage(sprite, position.X, position.Y, sprite.Width, sprite.Height);
            dc.DrawRectangle(new Pen(Brushes.Red), CollisionBox.X, CollisionBox.Y, CollisionBox.Width, CollisionBox.Height);
            dc.DrawImage(sprite, new PointF(position.X, position.Y));
        }
        public void UpdateAnimations(float currentFPS)
        {

        }
        public bool IsCollidingWith(GameObject other)
        {
            //return (CollisionBox.IntersectsWith(other.CollisionBox));
            if ((CollisionBox.IntersectsWith(other.CollisionBox)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void CheckCollosion()
        {
            foreach (GameObject go in GameWorld.Objs)
            {
                if (go != this)
                {
                    if (this.IsCollidingWith(go))
                    {
                        OnCollision(go);
                    }
                }
            }
        }
        protected virtual void OnCollision(GameObject other)
        {
            
            this.position = position;
        }
    }
}
