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

        // a bed, bedside table, a dresser, chair

        // tall room tall headboard 


    }
}
