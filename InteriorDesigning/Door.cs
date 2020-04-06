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

    }
}
