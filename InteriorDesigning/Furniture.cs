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
    public abstract class Furniture
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

        public string Color
        {
            get { return _Color; }
            set { _Color = value; }
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

       
        

        public Furniture(string name, double length, double breadth, double height, double price)
        {
            Name = name;
            Length = length;
            Breadth = breadth;
            Height = height;
            Price = price;
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

    }
}
