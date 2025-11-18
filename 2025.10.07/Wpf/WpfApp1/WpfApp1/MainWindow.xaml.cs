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
        private int kattintas = 0;
        public MainWindow()
        {
            InitializeComponent();
            Gomb g1 = new Gomb();
        }

        private void gomb_Click(object sender, RoutedEventArgs e)
        {
            kattintas++;
            gomb.Content = kattintas;
        }
    }
}