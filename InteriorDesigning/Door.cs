using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Shapes;

namespace InteriorDesigning
{
    class Door
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

        public Rectangle DrawDoor()
        {
            Rectangle door = new Rectangle();
            door.Width = 0;
            door.Height = Length * 50;
            door.Stroke = Brushes.Red;
            return door;
        }

        public void dimensionConstraint()
        {
            if (Height > 3.0)
                Height = 3.0;
            if (Height < 2.0)
                Height = 2.0;
            if (Length > 1.5)
                Length = 1.5;
            if (Length < 1.0)
                Length = 1.0;
        }
    }
}
