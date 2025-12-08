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
        }
    }
}