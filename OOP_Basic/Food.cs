using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food_
{
    // Abstract base class for food
    public abstract class Food
    {
        private decimal energy; // Energy value of the food
        public decimal Weight { get; } // Weight of the food
        public decimal Energy
        {
            get => energy;
            set => energy = Math.Clamp(value, 0, 0.05m);
        }

        protected Food(decimal weight, decimal energy)
        {
            Weight = weight;
            Energy = energy;
        }
    }
}
