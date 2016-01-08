
using System.Collections.Generic;

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
        /// <param name="imagePath"> Used to write the path for the image </param>
        /// <param name="startPosition"> The Vector2D class takes an X and a Y coordinate for where the sprites is drawn from </param>
        public GameObject(string imagePath, Vector2D startPosition)
        {
            string[] imagePaths = imagePath.Split(';');
            this.animationFrames = new List<Image>();

            foreach (string path in imagePaths)
            {
                animationFrames.Add(Image.FromFile(path));
            }
            this.sprite = this.animationFrames[0];
            this.position = startPosition;
        }
        /// <summary>
        /// The update checks for collision for each GameObject the inherrits this method.
        /// </summary>
        /// <param name="currentFPS"></param>
        public virtual void Update(float currentFPS)
        {
            CheckCollosion();
        }
        /// <summary>
        /// Draw uses the Graphics to draw the sprites
        /// </summary>
        /// <param name="dc"> the graphics </param>
        public virtual void Draw(Graphics dc)
        {
            dc.DrawImage(sprite, position.X, position.Y, sprite.Width, sprite.Height);
            dc.DrawRectangle(new Pen(Brushes.Red), CollisionBox.X, CollisionBox.Y, CollisionBox.Width, CollisionBox.Height);
        }
        /// <summary>
        /// Detects wether or not two GameObjects collide
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool IsCollidingWith(GameObject other)
        {
            if ((CollisionBox.IntersectsWith(other.CollisionBox)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Checks the collsion on GameObjects
        /// </summary>
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
        /// <summary>
        /// This method is virtual, so that all GameObjects can inherrit it, but dont have too.
        /// When inherrited, the individual GameObject has a unique string of code for the event.
        /// </summary>
        /// <param name="other"></param>
        protected virtual void OnCollision(GameObject other)
        {
        }
    }
}
