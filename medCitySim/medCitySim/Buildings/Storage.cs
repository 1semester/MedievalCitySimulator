using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedCitySim
{
    class Storage : Building
    {
        public Storage(string imagePath, Vector2D startposition) : base(imagePath, startposition)
        {
        }
        protected override void Work()
        {
            base.Work();
        }
        protected override void OnCollision(GameObject other)
        {
        }
        protected override void Cost()
        {
            base.Cost();
        }
        public override void Update(float currentFPS)
        {
            base.Update(currentFPS);
        }
    }
}
