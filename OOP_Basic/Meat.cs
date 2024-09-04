using Food_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meat_
{
    // Class for meat, derived from Food
    public class Meat : Food
    {
        public Meat(decimal weight, decimal energy) : base(weight, energy) { }
    }
}
