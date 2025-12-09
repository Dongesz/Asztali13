using Microsoft.Win32;
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

namespace WpfApp3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Kilepes(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Megnyitas(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == true)
            {
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(ofd.FileName);
                bitmap.EndInit();
                kep.Source = bitmap;
            }
        }

        private void Mentes(object sender, RoutedEventArgs e)
        {
            if (kep.Source is not BitmapSource bitmapSource) return;

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "PNG kép (*.png)|*.png";
            sfd.DefaultExt = ".png";

            if (sfd.ShowDialog() == true)
            {
                PngBitmapEncoder encoder = new PngBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(bitmapSource));

                using FileStream fs = new FileStream(sfd.FileName, FileMode.Create);
                encoder.Save(fs);
            }
        }

        private void Nagyitas(object sender, RoutedEventArgs e)
        {
            zoom.ScaleX *= 1.2;
            zoom.ScaleY *= 1.2;
        }

        private void Kicsinites(object sender, RoutedEventArgs e)
        {
            zoom.ScaleX *= 0.8;
            zoom.ScaleY *= 0.8;
        }
    }
}