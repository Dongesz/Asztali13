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
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OsszesJatekos(object sender, RoutedEventArgs e)
        {

        }
    }
}