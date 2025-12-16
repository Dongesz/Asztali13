using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace bevasarlolista
{
    /// <summary>
    /// Interaction logic for Hozzaadas.xaml
    /// </summary>
    public partial class Hozzaadas : Window
    {

        public ItemModel ujtermek { get; set; }

        public Hozzaadas()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ujtermek = ItemModel(margarin.Text, int.Parse(mennyiseg.Text), int.Parse(egysegar.Text), tipush.SelectedValue.ToString());
        }
    }
}
