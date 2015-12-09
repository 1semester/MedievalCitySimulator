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
        public Button(string imagePath, Vector2D position) : base (imagePath, position)
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
            if (Keyboard.IsKeyDown(System.Windows.Forms.Keys.B))
            {
                GameWorld.ToAdd.Add(new BuildMenu(@"Sprite\BygHus.png", (new Vector2D(2011, 993))));
            }
            base.Update(fps);
        }
    }
}
