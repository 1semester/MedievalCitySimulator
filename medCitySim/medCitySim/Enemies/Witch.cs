using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedCitySim
{
    class Witch : Enemy
    {
        private string name;
        private bool gender;
        
        public Witch(string imagePath, Vector2D position, bool gender, string name) : base(imagePath, position)
        {
            Citizen.witch = true;
            this.name = name;
            this.gender = gender;
        }
        protected override void OnCollision(GameObject other)
        {
            throw new NotImplementedException();
        }
        public override void Update(float fps)
        {

            base.Update(fps);
        }
    }
}
