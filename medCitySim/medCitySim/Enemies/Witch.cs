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
        public Witch(string imagePath, Vector2D startPosition, bool gender, string name) : base(imagePath, startPosition)
        {
            this.name = name;
            this.gender = gender;
        }
    }
}
