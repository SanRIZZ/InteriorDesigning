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

        private Door _Door;
        private Window _Window;
        private Bed _Bed;

        private Furniture.Wall _Door_orient;
        private Furniture.Wall _Window_orient;

        private double _Door_X;
        private double _Door_Y;

        private double _Window_X;
        private double _Window_Y;


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

        public Door Door
        {
            get { return _Door; }
            set { _Door = value; }
        }

        public Window Window
        {
            get { return _Window; }
            set { _Window = value; }
        }

        public Bed Bed
        {
            get { return _Bed; }
            set { _Bed = value; }
        }

        public Furniture.Wall Door_orient
        {
            get { return _Door_orient; }
            set { _Door_orient = value; }
        }

        public Furniture.Wall Window_orient
        {
            get { return _Window_orient; }
            set { _Window_orient = value; }
        }

        public double Door_X
        {
            get { return _Door_X; }
            set { _Door_X = value; }
        }

        public double Door_Y
        {
            get { return _Door_Y; }
            set { _Door_Y = value; }
        }

        public double Window_X
        {
            get { return _Window_X; }
            set { _Window_X = value; }
        }

        public double Window_Y
        {
            get { return _Window_Y; }
            set { _Window_Y = value; }
        }

        public List<Furniture> Furnitures
        {
            get { return _Furnitures; }
            set { _Furnitures = value; }
        }

        public Room(double length, double Breadth, double height)
        {
            Length = length;
            Breadth = Breadth;
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
            foreach (Furniture fr in Furnitures)
            {

                Rectangle furniture = new Rectangle();
                furniture.Height = (Length * 12) * 5;
                furniture.Width = (Breadth * 12) * 5;
                furniture.Stroke = Brushes.Black;
            }
        }

        public void emptyRoomDimensionConstraint()
        {
            if (Length > 10.0)
                Length = 10.0;
            if (Breadth > 10.0)
                Breadth = 10.0;
            if (Height > 5.0)
                Height = 5.0;
            if (Length < 2.5)
                Length = 2.5;
            if (Breadth < 2.5)
                Breadth = 2.5;
            if (Height < 2.5)
                Height = 2.5;
        }

        public void doorPlacementConstraint()
        {
            //if door orientation is in ceiling or floor then randomly select a wall
            if (Door_orient == Furniture.Wall.Ceiling || Door_orient == Furniture.Wall.Floor)
            {
                while (!(Door_orient == Furniture.Wall.Ceiling || Door_orient == Furniture.Wall.Floor))
                {
                    Random random = new Random();
                    Door_orient = (Furniture.Wall)(random.Next(0, 4));
                }
            }

            //negative coordinate not allowed
            if (Door_X < 0.0)
                Door_X = 0.0;
            if (Door_Y < 0.0)
                Door_Y = 0.0;

            //if x coord of door make the door pop out of wall sideways, fix it
            if ((Door_orient == Furniture.Wall.North || Door_orient == Furniture.Wall.South) && Door_X + Door.Length > Length)
                Door_X = Length - Door.Length;
            if ((Door_orient == Furniture.Wall.East || Door_orient == Furniture.Wall.West) && Door_X + Door.Height > Breadth)
                Door_X = Breadth - Door.Length;

            //if y coord of door makes the door pop out of wall up or down and
            //if the door is not touching the floor, fix it
            if (Door_Y + Door.Height != Height)
                Door_Y = Height - Door.Height;
        }

        public void windowPlacementConstraint()
        {
            //if window orientation is in ceiling or floor then randomly select a wall
            if (Window_orient == Furniture.Wall.Ceiling || Window_orient == Furniture.Wall.Floor)
            {
                while (Window_orient == Furniture.Wall.Ceiling || Window_orient == Furniture.Wall.Floor)
                {
                    Random random = new Random();
                    Window_orient = (Furniture.Wall)(random.Next(0, 4));
                }
            }

            //if there is door on that wall then select a different wall
            if (Window_orient == Door_orient)
            {
                while (Window_orient == Door_orient)
                {
                    Random random = new Random();
                    Window_orient = (Furniture.Wall)(random.Next(0, 4));
                }
            }

            //negative coordinate not allowed
            if (Window_X < 0.0)
                Window_X = 0.0;
            if (Window_Y < 0.0)
                Window_Y = 0.0;

            //if x coord of door make the window pop out of wall sideways, fix it
            if ((Window_orient == Furniture.Wall.North || Window_orient == Furniture.Wall.South) && Window_X + Window.Length > Length)
                Window_X = Length - Window.Length;
            if ((Window_orient == Furniture.Wall.East || Window_orient == Furniture.Wall.West) && Window_X + Window.Length > Breadth)
                Window_X = Breadth - Window.Length;

            //if y coord of window makes the window pop out of wall up or down
            if (Window_Y + Window.Height > Height)
                Window_Y = Height - Window.Height;
        }

        public void doorDimensionConstraint()
        {
            if (Door.Height > Height)
                Door.Height = Height;
        }

        public void windowDimensionConstraint()
        {
            if ((Window_orient == Furniture.Wall.North || Window_orient == Furniture.Wall.South) && Window.Length > Length)
                //if the window length is greater than room length set window length to room length
                Window.Length = Length;
            if ((Window_orient == Furniture.Wall.East || Window_orient == Furniture.Wall.West) && Window.Length > Breadth)
                //if the window length is greater than room breadth set window breadth to room breadth
                if (Window.Height > Height)
                    //if window height is greater than room height then set window height to room height
                    Window.Height = Height;
        }

        public void emptyRoomConstraint()
        {
            emptyRoomDimensionConstraint();
            doorDimensionConstraint();
            windowDimensionConstraint();
            doorPlacementConstraint();
            windowPlacementConstraint();
        }

        public bool doesBedFit()
        {
            if (Bed.Orient == Furniture.Wall.North || Bed.Orient == Furniture.Wall.South)
                if (Bed.Length > Breadth)
                    return false;
            if (Bed.Breadth > Length)
                return false;

            else if (Bed.Orient == Furniture.Wall.East || Bed.Orient == Furniture.Wall.West)
            {
                if (Bed.Length > Length)
                    return false;
                if (Bed.Breadth > Breadth)
                    return false;
                return true;
            }

            return false;
        }

        //checks if the same bed can be reoriented or need to be changed with smaller bed
        public bool reorientOrChangeBed()
        {
            //true means reorientation worked
            //false means needs to get smaller bed
            if ((Bed.Orient == Furniture.Wall.North || Bed.Orient == Furniture.Wall.South) && !(doesBedFit()))
                Bed.Orient = Furniture.Wall.East;
            if (!(doesBedFit()))
                return false;
            if ((Bed.Orient == Furniture.Wall.East || Bed.Orient == Furniture.Wall.West) && !(doesBedFit()))
                Bed.Orient = Furniture.Wall.North;
            if (!(doesBedFit()))
                return false;
            return true;
        }

        public void bedDimensionConstraint()
        {
            //check if the bed fits into the room or not and change bed size accordingly
            if (Bed.Orient == Furniture.Wall.North || Bed.Orient == Furniture.Wall.South)
            {
                if (Bed.Length > Breadth)
                    Bed.Length = Breadth;
                if (Bed.Breadth > Length)
                    Bed.Breadth = Length;

                else if (Bed.Orient == Furniture.Wall.East || Bed.Orient == Furniture.Wall.West)
                    if (Bed.Length > Length)
                        Bed.Length = Length;
                if (Bed.Breadth > Breadth)
                    Bed.Breadth = Breadth;

                //readjust bed dimension based on basic dimension constraints of bed
                Bed.dimensionConstraint();
            }
        }

        //checks if the current coordinate of bed violets spatial constraints
        //returns true or false
        public bool bedPlacementConstraint()
        {
            if (Bed.Orient == Furniture.Wall.North)
            {
                if (Bed.X_coord + Bed.Breadth > Length || Bed.Y_coord + Length > Breadth)
                    return false;
            }
            if (Bed.Orient == Furniture.Wall.East)
            {
                if (Bed.X_coord > Length || Bed.Y_coord + Bed.Breadth > Breadth)
                    return false;
            }
            if (Bed.Orient == Furniture.Wall.West)
            {
                if (Bed.X_coord + Bed.Length > Length || Bed.Y_coord > Breadth)
                    return false;
            }
            if (Bed.Orient == Furniture.Wall.South)
            {
                if (Bed.X_coord > Length || Bed.Y_coord > Breadth)
                    return false;
            }
            return true;
        }
       
    } 
}

