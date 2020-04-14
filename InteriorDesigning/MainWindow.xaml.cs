using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace InteriorDesigning
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // we will multiply by 100 scale for pixel to inches

        private void BtnGenerate_Click(object sender, RoutedEventArgs e)
        {
            cvOutput.Children.Clear();
            double length = 0;
            double breadth = 0;
            double height = 0;

            if (double.TryParse(tbxLength.Text, out length)
                && double.TryParse(tbxBreadth.Text, out breadth)
                && double.TryParse(tbxHeight.Text, out height)
                )
            {
                Room room = new Room(length, breadth, height);
                cvOutput.Children.Add(room.DrawRoom());
                Fill(room);
            }
            else
            {
                MessageBox.Show("Please enter valid input.");
            }
        }

        public static List<Bed> Beds()
        {
            List<Bed> beds = new List<Bed>();
            // Standard beg sizes
            Bed bedTwin = new Bed("Gloucester Tufted Upholstered Low Profile Twin Bed", 75, 39, 25, Bed.BedTypes.Twin, 500);
            bedTwin.Color = "taupe";
            List<string> material = new List<string>();
            material.Add("wood");
            material.Add("polyester");
            material.Add("foam");
            bedTwin.Materials = material;
            bedTwin.Link = "https://www.wayfair.com/furniture/pdp/greyleigh-gloucester-tufted-upholstered-low-profile-standard-bed-w001553030.html?piid=239528200%2C239528311";
            Bed bedTwinXL = new Bed("TwinXL", 80, 39, 25, Bed.BedTypes.TwinXL, 1000);
            Bed bedFull = new Bed("Full", 75, 54, 25, Bed.BedTypes.Full, 1255.99);
            Bed bedQueen = new Bed("Queen", 80, 60, 25, Bed.BedTypes.Queen, 1500);
            Bed bedKing = new Bed("King", 76, 80, 25, Bed.BedTypes.King, 1800);
            Bed bedCaliforniaKing = new Bed("California King", 84, 72, 3, Bed.BedTypes.CaliforniaKing, 2000);
            beds.Add(bedTwin);
            beds.Add(bedTwinXL);
            beds.Add(bedFull);
            beds.Add(bedQueen);
            beds.Add(bedKing);
            beds.Add(bedCaliforniaKing);
            return beds;
        }

        public void Fill(Room room)
        {
            List<Bed> beds = Rules.BedRules(room,Beds());
            Random rnd = new Random();
            Bed bed = beds[rnd.Next(0, beds.Count())];
            Rectangle rect = bed.DrawFurniture();
            var canvas = new Canvas();
            canvas.Children.Add(rect);
            //Hyperlink hlink = new Hyperlink();
            //if (bed.Link != null)
            //       hlink.NavigateUri = new Uri(bed.Link);
            int margin = int.MaxValue;
            while(margin >= room.Length*12*5)
            {
                margin = rnd.Next(((int)room.Length)*12*2);
                if (margin >= room.Breadth * 12 * 5 - rect.Width)
                {
                    margin = int.MaxValue;
                }
            }
            TextBlock txtDescription = new TextBlock()
            {
                Text = "Name:" + bed.Name
                        + "\r\n" + "Materials:" + bed.Materials
                        + "\r\n" + "color:" + bed.Color
                        + "\r\n" + "Link:" + bed.Link
                ,
                Margin = new Thickness(margin+ rect.Width/3, rect.Height / 2 - 20, 0, 0),
                Name = "txtDescription",
                TextWrapping = TextWrapping.Wrap,
                Width = 200,
                Height = 400
            };
            Canvas.SetLeft(rect, margin);
            canvas.Children.Add(txtDescription);
            cvOutput.Children.Add(canvas);
        }
        
    }
}
