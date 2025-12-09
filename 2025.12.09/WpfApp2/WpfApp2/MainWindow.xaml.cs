using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Urhajo> urhajok = new List<Urhajo>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void AdatokBetoltese(object sender, RoutedEventArgs e)
        {
            urhajok = new List<Urhajo>()
            {
                new Urhajo("Falcon-9", 7, 550000, 87, "SpaceX", "Sikeres", 2020),
                new Urhajo("Orion-X1", 4, 820000, 73, "NASA", "Folyamatban", 2023),
                new Urhajo("StarRider", 12, 910000, 66, "Boeing", "Sikeres", 2019),
                new Urhajo("SolarWind", 3, 300000, 92, "ESA", "Sikertelen", 2018),
                new Urhajo("Galaxy-Cruiser", 18, 1200000, 54, "Blue Origin", "Sikeres", 2022),
                new Urhajo("Nova-Prime", 10, 760000, 80, "Roscosmos", "Sikeres", 2017),
                new Urhajo("Pioneer-VII", 6, 640000, 70, "NASA", "Folyamatban", 2024),
                new Urhajo("Titan-Hawk", 14, 1050000, 48, "SpaceX", "Sikeres", 2021),
                new Urhajo("CosmoJet", 5, 430000, 93, "JAXA", "Sikertelen", 2016),
                new Urhajo("Nebula-FX", 11, 870000, 60, "ESA", "Sikeres", 2020)
            };
            dataGrid.ItemsSource = urhajok;
        }

        private void HanyUrhajo(object sender, RoutedEventArgs e)
        {
            if (!(urhajok.Count > 0))
            {
                MessageBox.Show("A lista ures!");
                return;
            }
            MessageBox.Show($"Az urhajok szama: {urhajok.Count}");
        }

        private void LegnagyobbHatotav(object sender, RoutedEventArgs e)
        {
            if (!(urhajok.Count > 0))
            {
                MessageBox.Show("A lista ures!");
                return;
            }
            MessageBox.Show($"Legnagyobb hatotavu urhajo: {urhajok.MaxBy(x => x.MaxHatotav).Nev}");
        }

        private void SikeresKuldetes(object sender, RoutedEventArgs e)
        {
            if (!(urhajok.Count > 0))
            {
                MessageBox.Show("A lista ures!");
                return;
            }
            dataGrid.ItemsSource = urhajok.Where(x => x.KuldetesStatus == "Sikeres").ToList();
        }
    }
}