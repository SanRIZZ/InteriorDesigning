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

        public static List<Bed> BedRules(Room room, List<Bed> beds)
        {
            var viableBeds = new List<Bed>();
            if (room.Length <= 10 && room.Breadth <= 7)
            {
                viableBeds = (List<Bed>)beds.
                    Where(
                        t => t.BedType == Bed.BedTypes.Twin
                        || t.BedType == Bed.BedTypes.TwinXL
                    ).ToList<Bed>();
            }
            else if (room.Length <= 12 && room.Breadth <= 10)
            {
                viableBeds = (List<Bed>)beds.
                    Where(
                         t => !(t.BedType == Bed.BedTypes.CaliforniaKing || t.BedType == Bed.BedTypes.King)
                    ).ToList<Bed>();
            }
            else if(room.Length <= 13 && room.Breadth <= 13)
            {
                viableBeds = (List<Bed>)beds.
                    Where(
                        t => !(t.BedType == Bed.BedTypes.CaliforniaKing)
                    ).ToList<Bed>();
            }
            else
            {
                return beds;
            }
            return viableBeds;
        }

        // a bed, bedside table, a dresser, chair

        // tall room tall headboard 


    }
}
