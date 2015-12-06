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
        public Criminal(string imagePath, Vector2D startPosition, bool gender, string name) : base(imagePath, startPosition)
        {
            this.gender = gender;
            this.name = name;
        }
    }
}
