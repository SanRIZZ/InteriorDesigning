using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteriorDesigning
{
    public static class Rules
    {
        

        public static void ChooseHero()
        {

        }

        public static void ChooseColor()
        {
            // do not use bold primary colors, use soothing shades and a restful palette of monochromatic tones
        }

        public static List<Furniture> BedRules(Room room, List<Furniture> beds)
        {
            var viableBeds = new List<Furniture>();
            if (room.Length <= 10 && room.Breadth <= 7)
            {
                viableBeds = (List<Furniture>)beds.
                    Where(
                        t => t.Size == "Twin"
                        || t.Size == "TwinXL"
                    ).ToList<Furniture>();
            }
            else if (room.Length <= 12 && room.Breadth <= 10)
            {
                viableBeds = (List<Furniture>)beds.
                    Where(
                         t => !(t.Size == "CaliforniaKing" || t.Size == "King")
                    ).ToList<Furniture>();
            }
            else if(room.Length <= 13 && room.Breadth <= 13)
            {
                viableBeds = (List<Furniture>)beds.
                    Where(
                        t => !(t.Size == "CaliforniaKing")
                    ).ToList<Furniture>();
            }
            else
            {
                return beds;
            }
            return viableBeds;
        }

        public static void bedDimensionConstraint(double Length, double Breadth, double Height)
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

        // a bed, bedside table, a dresser, chair

        // tall room tall headboard 

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

        //public enum BedTypes
        //{
        //    Twin,
        //    TwinXL,
        //    Full,
        //    FullXL,
        //    Queen,
        //    King,
        //    CaliforniaKing
        //}
    }
}
