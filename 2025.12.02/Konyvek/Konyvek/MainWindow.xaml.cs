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

namespace Konyvek
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    class Konyv
    {
        public string Cím { get; set; }
        public string Szerző { get; set; }
        public int Oldalszám { get; set; }
        public string Műfaj { get; set; }
        public bool Elerhető { get; set; }

        public Konyv(string cím, string szerző, int oldalszám, string műfaj, bool elerhető)
        {
            Cím = cím;
            Szerző = szerző;
            Oldalszám = oldalszám;
            Műfaj = műfaj;
            Elerhető = elerhető;
        }
    }
    public partial class MainWindow : Window
    {
        List<Konyv> konyvek = new List<Konyv>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            konyvek.Clear();
            konyvek.Add(new Konyv ("1984", "George Orwell", 328, "Sci-fi", true));
            konyvek.Add(new Konyv ("harry potter", "jk Rowling", 453, "Fantasy", false));
            konyvek.Add(new Konyv ("friday 13", "Donald Trump", 624, "Horror", true));
            konyvek.Add(new Konyv ("egri csillagok", "Gardonyi Géza", 566, "Drama", true));

            dataGrid.ItemsSource = konyvek;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(konyvek.Count().ToString());
        }
    }
}