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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Film> filmek = new List<Film>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void FilmekBetoltese(object sender, RoutedEventArgs e)
        {
            filmek.Clear();
            filmek.Add(new Film("Csillagok haboruja", "sci-fi", 121, 8.6));
            filmek.Add(new Film("Titanic", "drama", 195, 7.8));
            filmek.Add(new Film("A Gyuruk Ura", "fantasy", 201, 8.8));
            filmek.Add(new Film("Matrix", "sci-fi", 136, 8.7));
            filmek.Add(new Film("Shrek", "animacio", 90, 7.9));
            dataGrid.ItemsSource = filmek;
        }

        private void FilmekSzama(object sender, RoutedEventArgs e)
        {
            if (!(filmek.Count > 0))
            {
                MessageBox.Show("A lista ures!");
                return;
            }
            MessageBox.Show($"Filmek szama: {filmek.Count.ToString()}");
        }

        private void LeghosszabbFilm(object sender, RoutedEventArgs e)
        {
            if (!(filmek.Count > 0))
            {
                MessageBox.Show("A lista ures!");
                return;
            }
            MessageBox.Show($"Leghosszabb film: {filmek.MaxBy(x => x.Hossz).Cim}");
        }

        private void AtlagErtekeles(object sender, RoutedEventArgs e)
        {
            if (!(filmek.Count > 0))
            {
                MessageBox.Show("A lista ures!");
                return;
            }
            MessageBox.Show($"Ertekelesek atlaga: {filmek.Average(x => x.Ertekeles)}");
        }
    }
}