using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedCitySim
{
    class House : Building
    {
        public House(string imagePath, Vector2D startposition): base(imagePath, startposition)
        {

        }
        protected override void Work()
        {
            base.Work();
        }
        public override void OnCollision(GameObject other)
        {
            base.OnCollision(other);
        }
        protected override void Cost()
        {
            base.Cost();
        }
    }
}
