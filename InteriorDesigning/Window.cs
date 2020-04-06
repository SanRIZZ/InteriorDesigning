using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteriorDesigning
{
    class Window
    {
        private double _Length;
        private double _Height;

        public double Length
        {
            get { return _Length; }
            set { _Length = value; }
        }

        public double Height
        {
            get { return _Height; }
            set { _Height = value; }
        }
    }
}
