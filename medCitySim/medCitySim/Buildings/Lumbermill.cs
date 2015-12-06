using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedCitySim
{
    class Lumbermill : Building
    {
        public Lumbermill(string imagePath, Vector2D startposition) : base(imagePath,startposition)
        {

        }
        protected override void Work()
        {
            base.Work();
        }
        protected override void Cost()
        {
            base.Cost();
        }
        public override void OnCollision(GameObject other)
        {
            base.OnCollision(other);
        }

    }
}
