using Food_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plants_
{
    // Class for plants, derived from Food
    public class Plants : Food
    {
        public Plants(decimal weight, decimal energy) : base(weight, energy) { }
    }
}
