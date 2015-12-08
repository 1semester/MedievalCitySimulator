using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MedCitySim
{
    class Button : GameObject
    {
        //private ButtonState state;
        //private enum ButtonState
        //{
        //    None = 0,
        //    Hover,
        //    Pressed
        //}
        public Button(Vector2D startPosition, string imagePath) : base (imagePath, startPosition)
        {
            
            //this.sprite = this.animationFrames[0];
        }
        public override void Draw(Graphics dc)
        {
            base.Draw(dc);
            //dc.DrawRectangle(new Pen(Brushes.Red), CollisionBox.X, CollisionBox.Y, CollisionBox.Width, CollisionBox.Height);
        }
        public override void Update(float fps)
        {
            base.Update(fps);
        }
    }
}
