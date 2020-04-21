using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows.Controls;

namespace InteriorDesigning
{
    public class Room
    {
        private double _Length;
        private double _Breadth;
        private double _Height;
        private List<Furniture> _Furnitures;

        public double Length
        {
            get { return _Length; }
            set { _Length = value; }
        }

        public double Breadth
        {
            get { return _Breadth; }
            set { _Breadth = value; }
        }

        public double Height
        {
            get { return _Height; }
            set { _Height = value; }
        }

        public List<Furniture> Furnitures
        {
            get { return _Furnitures; }
            set { _Furnitures = value; }
        }

        public Room(double length, double breadth, double height)
        {
            Length = length;
            Breadth = breadth;
            Height = height;

        }

        public Rectangle DrawRoom()
        {
            Rectangle room = new Rectangle();
            room.Width = Breadth * 50;
            room.Height = Length * 50;
            room.Stroke = Brushes.Black;
            return room;
        }

        public void FillFurnitures(Rectangle room)
        {
            foreach(Furniture fr in Furnitures)
            {
                
                Rectangle furniture = new Rectangle();
                furniture.Height = (Length * 12)*5;
                furniture.Width = (Breadth * 12)*5;
                furniture.Stroke = Brushes.Black;
            }
        }
    }
}

