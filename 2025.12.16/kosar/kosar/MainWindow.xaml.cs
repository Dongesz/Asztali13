using System.IO;
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

namespace kosar
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    
    public class jatekos
    {
        public string JatekosNeve { get; set; }
        public string Csapat {  get; set; }
        public int LejatszottMeccsek { get; set; }
        public double PontAtlag {  get; set; }
        public double LepattanoAtlag { get; set; }
        public double HatekonysagiMutato { get; set; }

        public jatekos(string jatekosNeve, string csapat, int lejatszottMeccsek, double pontAtlag, double lepattanoAtlag, double hatekonysagiMutato)
        {
            JatekosNeve = jatekosNeve;
            Csapat = csapat;
            LejatszottMeccsek = lejatszottMeccsek;
            PontAtlag = pontAtlag;
            LepattanoAtlag = lepattanoAtlag;
            HatekonysagiMutato = hatekonysagiMutato;
        }
        public jatekos(string sor)
        {
            string[] darabok = sor.Split(',');
            JatekosNeve = darabok[0];
            Csapat = darabok[1];
            LejatszottMeccsek = int.Parse(darabok[2]);
            PontAtlag = double.Parse(darabok[3]);
            LepattanoAtlag = double.Parse(darabok[4]);
            HatekonysagiMutato = PontAtlag+LepattanoAtlag;
        }
    }
    public partial class MainWindow : Window
    {
        List<jatekos> jatekosok = new List<jatekos>();

        public MainWindow()
        {
            InitializeComponent();
            string[] sorok = File.ReadAllLines("Jatekosok.txt");
            foreach (string s in sorok.Skip(1))
            {
                jatekosok.Add(new jatekos(s));
            }
        }

        private void OsszesJatekos(object sender, RoutedEventArgs e)
        {
            dataGrid.ItemsSource = jatekosok;

        }

        private void TopThreeJatekos(object sender, RoutedEventArgs e)
        {
            if (jatekosok != null)
            {
                dataGrid.ItemsSource = jatekosok.OrderByDescending(x => x.PontAtlag).Take(3);
            }
            else MessageBox.Show("Nincsenek jatekosok az adatbazisban!");
        }

        private void PontatlagHatekonysagmin20(object sender, RoutedEventArgs e)
        {
            if (jatekosok != null)
            {
                dataGrid.ItemsSource = jatekosok.Where(x => x.HatekonysagiMutato >= 20 && x.PontAtlag >= 20);
            }
            else MessageBox.Show("Nincsenek jatekosok az adatbazisban!");
        }

        private void LegtobbMeccs(object sender, RoutedEventArgs e)
        {
            if (jatekosok != null)
            {
                var legtobbMeccs = jatekosok.Max(x => x.LejatszottMeccsek);
                dataGrid.ItemsSource = jatekosok.Where(x => x.LejatszottMeccsek == legtobbMeccs);
            }
            else MessageBox.Show("Nincsenek jatekosok az adatbazisban!");
        }

        private void CsapatAtlagPont(object sender, RoutedEventArgs e)
        {
            if (jatekosok != null)
            {
                dataGrid.ItemsSource = jatekosok
                    .GroupBy(x => x.Csapat)
                    .Select(x => new { Csapat = x.Key, Atlag = x.Average(x => x.PontAtlag) });
            }
            else MessageBox.Show("Nincsenek jatekosok az adatbazisban!");
        }

        private void CsapatAtlagHatekonysag(object sender, RoutedEventArgs e)
        {
            if (jatekosok != null)
            {
                dataGrid.ItemsSource = jatekosok
                    .GroupBy(x => x.Csapat)
                    .Select(x => new { Csapat = x.Key, Atlag = x.Average(x => x.HatekonysagiMutato)});
            }
            else MessageBox.Show("Nincsenek jatekosok az adatbazisban!");
        }
    }
}