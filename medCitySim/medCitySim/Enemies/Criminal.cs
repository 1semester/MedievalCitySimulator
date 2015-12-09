using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedCitySim
{
    class Criminal : Enemy
    {
        private string name;
        private bool gender;
        public Criminal(string imagePath, Vector2D position, bool gender, string name) : base(imagePath, position)
        {
            this.gender = gender;
            this.name = name;
        }
    }
}
