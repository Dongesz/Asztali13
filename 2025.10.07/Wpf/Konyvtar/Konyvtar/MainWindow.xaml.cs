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
using MySql.Data.MySqlClient;
namespace Konyvtar
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
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(Id.Text == "")
            {
                MessageBox.Show("Kerem adjon meg egy könyvId-t!");
                return;
            }
            else if(!int.TryParse(Id.Text, out int szam))
            {
                MessageBox.Show("Kerem szamot adjon meg!");
                return;
            }
                string kapcsolatstring = "server=localhost;database=konyvtar;uid=root;pwd=;";
            try
            {
                using (MySqlConnection conn = new MySqlConnection(kapcsolatstring))
                {
                    conn.Open();
                    string sql = $"SELECT cim,szerzo from `konyv` WHERE konyv_id = {Id.Text}";
                    using(MySqlDataReader reader = new MySqlCommand(sql, conn).ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Cim.Content = reader.GetString("cim");
                            Szerzo.Content = reader.GetString("szerzo");
                        }
                        else
                        {
                            MessageBox.Show("Nincs ilyen könyv!");
                        }
                    }
       
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hiba történt!: {ex}");
            }
        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            if (Id.Text == "")
            {
                MessageBox.Show("Kerem adjon meg egy könyvId-t!");
                return;
            }
            else if (!int.TryParse(Id.Text, out int szam))
            {
                MessageBox.Show("Kerem szamot adjon meg!");
                return;
            }
            string kapcsolatstring = "server=localhost;database=konyvtar;uid=root;pwd=;";
            try
            {
                using (MySqlConnection conn = new MySqlConnection(kapcsolatstring))
                {
                    conn.Open();
                    List<Konyv> konyvek = new List<Konyv>();
                    string sql = $"SELECT * FROM `konyv`";
                    using (MySqlDataReader reader = new MySqlCommand(sql, conn).ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int konyv_id = reader.GetInt32("konyv_id");
                            string cim = reader.GetString("cim");
                            string szerzo = reader.GetString("szerzo");
                            int kiadas_ev = reader.GetInt32("kiadas_ev");
                            int ar = reader.GetInt32("ar");
                            string kategoria = reader.GetString("kategoria");

                            konyvek.Add(new Konyv(konyv_id, cim, szerzo, kiadas_ev, ar, kategoria));
                        }
                        
                    }
                    dataGrid.ItemsSource = konyvek;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hiba történt!: {ex}");
            }
        }
    }
}