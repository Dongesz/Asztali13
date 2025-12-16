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

namespace bevasarlolista
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    
    public class ItemModel
    {
        public string Item {  get; set; }
        public int Quantity { get; set; }
        public int UnitPrice { get; set; }
        public required string Category { get; set; }

    }
    public partial class MainWindow : Window
    {
        List<ItemModel> termekek = new List<ItemModel>() {
            new ItemModel{ Item="Tej", Quantity=5, UnitPrice=450, Category="A" },
        new ItemModel{ Item="Kenyer", Quantity=10, UnitPrice=350, Category="B" },
        new ItemModel{ Item="Sajt", Quantity=2, UnitPrice=1200, Category="A" },
        new ItemModel{ Item="Alma", Quantity=20, UnitPrice=200, Category="C" },
        new ItemModel{ Item="Narancs", Quantity=15, UnitPrice=300, Category="C" },
        new ItemModel{ Item="Hús", Quantity=3, UnitPrice=2500, Category="D" },
        new ItemModel{ Item="Csokoládé", Quantity=7, UnitPrice=900, Category="B" },
        new ItemModel{ Item="Kenyér 2", Quantity=1, UnitPrice=450, Category="B" },
        new ItemModel{ Item="Tej 2", Quantity=12, UnitPrice=400, Category="A" },
        new ItemModel{ Item="Sajt 2", Quantity=5, UnitPrice=1500, Category="D" }
        };
        public MainWindow()
        {
            InitializeComponent();
            dataGrid.ItemsSource = termekek;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            var ablak = new Hozzaadas();
            ablak.Show();
        }
    }
}