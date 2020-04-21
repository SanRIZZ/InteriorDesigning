using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
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
        private GeneticAlgorithm<Furniture> ga;
        private Random rnd;
        private float mutationRate = 0.01f;
        string targetString = "To be, or not to be, that is the question.";
        int populationSize = 200;
        public MainWindow()
        {
            InitializeComponent();
            rnd = new Random();
            ga = new GeneticAlgorithm<Furniture>(populationSize, targetString.Length, rnd, GetRandomFurniture, FitnessFunction, mutationRate);
            
            while(ga.BestFitness != 1)
            {
                ga.NewGeneration();
                if (ga.BestFitness == 1)
                {
                    this.IsEnabled = false;
                }
                lbxOutput.Items.Add(ga.BestGenes.ToString());
            }
        }

        private Furniture GetRandomFurniture()
        {
            int i = rnd.Next(Beds().Count);
            return Beds()[i];
        }

        private float FitnessFunction(int index)
        {
            float score = 0;
            DNA<Furniture> dna = ga.Population[index];
            for(int i = 0; i < dna.Genes.Length; i++)
            {
                // need fitness stuff

                //if(some case)
                //{
                //    score += 1;
                //}
                score /= targetString.Length;
            }
            return score;
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

        public List<Furniture> Beds()
        {
            List<Furniture> beds = new List<Furniture>();
            // Standard beg sizes
            Furniture bedTwin = new Furniture("Gloucester Tufted Upholstered Low Profile Twin Bed", 75, 39, 25, 500, Furniture.Types.Bed, "Twin");
            bedTwin.Color = "taupe";
            List<string> material = new List<string>();
            material.Add("wood");
            material.Add("polyester");
            material.Add("foam");
            bedTwin.Materials = material;
            bedTwin.Link = "https://www.wayfair.com/furniture/pdp/greyleigh-gloucester-tufted-upholstered-low-profile-standard-bed-w001553030.html?piid=239528200%2C239528311";
            Furniture bedTwinXL = new Furniture("TwinXL", 80, 39, 25, 1000, Furniture.Types.Bed, "TwinXL");
            Furniture bedFull = new Furniture("Full", 75, 54, 25, 1255.99, Furniture.Types.Bed, "Full");
            Furniture bedQueen = new Furniture("Queen", 80, 60, 25, 1500, Furniture.Types.Bed, "Queen");
            Furniture bedKing = new Furniture("King", 76, 80, 25, 1800, Furniture.Types.Bed, "King");
            Furniture bedCaliforniaKing = new Furniture("California King", 84, 72, 3, 2000, Furniture.Types.Bed, "California King");
            beds.Add(bedTwin);
            beds.Add(bedTwinXL);
            beds.Add(bedFull);
            beds.Add(bedQueen);
            beds.Add(bedKing);
            beds.Add(bedCaliforniaKing);
            return beds;
        }

        public List<Furniture> OpenData()
        {
            List<Furniture> furnitures = new List<Furniture>();
            using (var reader = new StreamReader(@"C:\test.csv"))
            {
                List<string> listA = new List<string>();
                List<string> listB = new List<string>();
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(';');

                    listA.Add(values[0]);
                    listB.Add(values[1]);
                }
            }
        }

        public List<Furniture> Chairs()
        {
            List<Furniture> chairs = new List<Furniture>();

            return chairs;
        }

        public List<Furniture> BedSideTable()
        {
            List<Furniture> bedSideTables = new List<Furniture>();
            //https://www.wayfair.com/furniture/pdp/brayden-studio-hoyne-1-drawer-nightstand-w000472658.html
            Furniture table = new Furniture("Hoyne 1 Drawer Nightstand", 21.26, 17.12, 24.01, 101.99, Furniture.Types.BedSideTable, "");

            // https://www.wayfair.com/furniture/pdp/zipcode-design-altus-1-drawer-nightstand-w001261818.html?piid=1487511403
            Furniture table2 = new Furniture("Altus 1 Drawer Nightstand", 14.92, 11.85, 19.06, 67.99, Furniture.Types.BedSideTable, "");

            // https://www.wayfair.com/furniture/pdp/george-oliver-ormond-mid-century-2-drawer-nightstand-w002588088.html
            Furniture table3 = new Furniture("Ormond Mid-Century 2 Drawer Nightstand", 18, 15, 23.98, 119.99, Furniture.Types.BedSideTable, "");

            bedSideTables.Add(table);
            bedSideTables.Add(table2);
            bedSideTables.Add(table3);
            return bedSideTables;
        }

        public void Fill(Room room)
        {
            List<Furniture> beds = Rules.BedRules(room, Beds());
            Random rnd = new Random();
            Furniture bed = beds[rnd.Next(0, beds.Count())];
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
