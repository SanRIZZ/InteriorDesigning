using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace InteriorDesigning
{
    public class Furniture
    {
        private string _Name;
        private double _Length;
        private double _Breadth;
        private double _Height;
        private Point _StartLocation;
        private List<Furniture> _Children;
        private double _Price;
        private List<string> _Materials;
        private string _Color;
        private string _Link;
        private Types _Type;
        private Wall _orient;

        private string _Size;
        private double _x_coord;
        private double _y_coord;

        public double X_coord
        {
            get { return _x_coord; }
            set { _x_coord = value; }
        }

        public double Y_coord
        {
            get { return _y_coord; }
            set { _y_coord = value; }
        }

        public string Size
        {
            get { return _Size; }
            set { _Size = value; }
        }

        public string Color
        {
            get { return _Color; }
            set { _Color = value; }
        }

        public Types Type
        {
            get { return _Type; }
            set { _Type = value; }
        }

        public string Link
        {
            get { return _Link; }
            set { _Link = value; }
        }

        public List<string> Materials
        {
            get { return _Materials; }
            set { _Materials =value; }
        }


        public double Price
        {
            get { return _Price; }
            set { _Price = value; }
        }


        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

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

        public Point StartLocation
        {
            get { return _StartLocation; }
            set { _StartLocation = value; }
        }

        public Wall Orient
        {
            get { return _orient; }
            set { _orient = value; }
        }

        public enum Types
        {
            Bed,
            BedSideTable,
            Chair,
            Mattress
        }
        

        public Furniture(string name, double length, double breadth, double height, double price, Types type, string size, Wall orient)
        {
            Name = name;
            Length = length;
            Breadth = breadth;
            Height = height;
            Price = price;
            Type = type;
            Size = size;
            Orient = orient;
        }

        public Furniture()
        {

        }

        public List<Furniture> Children
        {
            get { return _Children; }
            set { _Children = value; }
        }

        public Rectangle DrawFurniture()
        {
            Rectangle furniture = new Rectangle();
            furniture.Width = Breadth*5;
            furniture.Height = Length*5;
            furniture.Stroke = Brushes.Black;
            return furniture;
        }

        public enum Wall
        {
            North, East, West, South, Floor, Ceiling
        }

    }
}
