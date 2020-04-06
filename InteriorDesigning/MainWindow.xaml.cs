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
                Fill();
            }
            else
            {
                MessageBox.Show("Please enter valid input.");
            }
        }

        public List<Furniture> Beds()
        {
            List<Furniture> beds = new List<Furniture>();
            // Standard beg sizes
            Furniture bedTwin = new Furniture("Twin", 6.25, 3.17, 3);
            Furniture bedTwinXL = new Furniture("TwinXL", 6.67, 3.17, 3);
            Furniture bedFull = new Furniture("Full", 6.25, 4.42, 3);
            Furniture bedQueen = new Furniture("Queen", 6.67, 5, 3); 
            Furniture bedKing = new Furniture("King", 6.67, 6.33, 3);
            Furniture bedCaliforniaKing = new Furniture("California King", 7, 6, 3);
            beds.Add(bedTwin);
            beds.Add(bedTwinXL);
            beds.Add(bedFull);
            beds.Add(bedQueen);
            beds.Add(bedKing);
            beds.Add(bedCaliforniaKing);
            return beds;
        }

        public void Fill()
        {
            List<Furniture> beds = Beds();
            Random rnd = new Random();
            Furniture bed = beds[rnd.Next(0, beds.Count())];
            Rectangle rect = bed.DrawFurniture();
            var grid = new Grid();
            grid.Children.Add(rect);
            grid.Children.Add(new TextBlock() { Text = bed.Name, Margin = new Thickness(50, 50, 50, 50) });
            cvOutput.Children.Add(grid);
            Canvas.SetLeft(rect, 55);
        }
    }
}
