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
    class Cim
    {
        public string cim { get; set; }
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
            if (konyvek.Count > 0)
            {
                MessageBox.Show(konyvek.Count().ToString());
            }
            else
            {
                MessageBox.Show("A lista üres!");
            }
            
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (konyvek.Count > 0)
            {
                MessageBox.Show(konyvek.MaxBy(x => x.Oldalszám).Cím);
            }
            else
            {
                MessageBox.Show("A lista üres!");
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (konyvek.Count > 0)
            {
                double avg = konyvek.Average(x => x.Oldalszám);
                MessageBox.Show(avg.ToString());
            }
            else
            {
                MessageBox.Show("A lista üres!");
            }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            if (konyvek.Count > 0)
            {
                dataGrid.ItemsSource = konyvek.Where(x => x.Elerhető);
            }
            else
            {
                MessageBox.Show("A lista üres!");
            }
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            if (konyvek.Count > 0)
            {
                List<Cim> cimek = new List<Cim>();
                foreach (var item in konyvek)
                {
                    cimek.Add(new Cim{cim = item.Cím});
                }
                dataGrid.ItemsSource = cimek;
            }
            else
            {
                MessageBox.Show("A lista üres!");
            }
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            if (konyvek.Count > 0)
            {
                dataGrid.ItemsSource = konyvek.OrderBy(x => x.Szerző);
            }
            else
            {
                MessageBox.Show("A lista üres!");
            }
        }

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dataGrid.SelectedItem != null && dataGrid.SelectedItem is Konyv) 
            progressBar.Value = ((Konyv)dataGrid.SelectedItem).Oldalszám;
        }
    }
}