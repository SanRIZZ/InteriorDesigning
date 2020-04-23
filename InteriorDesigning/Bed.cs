using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteriorDesigning
{
    public class Bed : Furniture
    {
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

        public enum BedTypes
        {
            Twin,
            TwinXL,
            Full,
            FullXL,
            Queen,
            King,
            CaliforniaKing
        }

        private BedTypes _BedType;

        public BedTypes BedType
        {
            get { return _BedType; }
            set { _BedType = value; }
        }

        public Bed(string name, double length, double breadth, double height, BedTypes type, double price) :
            base(name, length, breadth, height, price)
        {
            BedType = type;
            //if(length <= 77 && breadth <= 39)
            //{
            //    BedType = BedTypes.Twin;
            //}
            //else if(length <= 80 && breadth <= 39)
            //{
            //    BedType = BedTypes.TwinXL;
            //}
            //else if(length <= 75 && breadth <= 54)
            //{
            //    BedType = BedTypes.Full;
            //}
            //else if (length <= 80 && breadth <= 54)
            //{
            //    BedType = BedTypes.FullXL;
            //}
            //else if (length <= 80 && breadth <= 60)
            //{
            //    BedType = BedTypes.Queen;
            //}
            //else if(length <= 80 && breadth <= 76)
            //{
            //    BedType = BedTypes.King;
            //}
            //else if (length <= 84 && breadth <= 72)
            //{
            //    BedType = BedTypes.CaliforniaKing;
            //}
        }

        public void dimensionConstraint()
        {
            if (Length > 2.74)
                Length = 2.74;
            if (Breadth > 2.74)
                Breadth = 2.74;
            if (Height > 1.0)
                Height = 1.0;

            if (Height < 0.15)
                Height = 0.15;
            if (Breadth < 0.71)
                Breadth = 0.71;
            if (Length < 1.32)
                Length = 1.32;
        }

    }
}
