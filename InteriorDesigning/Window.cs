using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteriorDesigning
{
    public class Window
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

        public void dimensionConstraint()
        {
            if (Length > 10.0 * 39.3701)
                Length = 10.0 * 39.3701;
            if (Length < 0.5 * 39.3701)
                Length = 0.5 * 39.3701;
            if (Height > 5.0 * 39.3701)
                Height = 5.0 * 39.3701;
            if (Height < 0.5 * 39.3701)
                Height = 0.5 * 39.3701;
        }
    }
}
