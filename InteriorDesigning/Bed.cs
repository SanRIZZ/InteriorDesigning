using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteriorDesigning
{
    public class Bed: Furniture
    {
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



    }
}
