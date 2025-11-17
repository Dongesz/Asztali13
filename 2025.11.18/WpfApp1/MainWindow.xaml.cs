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
using System.Windows.Threading;


namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int score = 0;
        private int highscore = 0;
        private Random random = new Random();
        private DispatcherTimer timer;
        private Gomb currentActiveButton;
        private double difficulty = 2;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void InitializeGame()
        {
            GameGrid.Children.Clear();
            

            for (int i = 0; i < 9; i++)
            {
                var button = new Gomb();
                button.Click += Button_Click;
                button.ApplyTemplate(this);
                GameGrid.Children.Add(button);
            }
            ActivateRandomButton();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Gomb button && button == currentActiveButton)
            {
                score += button.CalculateScore();
                if (highscore < score)
                {
                    highscore = score;
                    HighScore.Text = $"High Score: {highscore}";
                }
                ScoreText.Text = $"Score: {score}";
                button.ResetButtonState();
                currentActiveButton = null;
                ActivateRandomButton();
            }
        }

        private void StartGameTimer()
        {
            timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(difficulty)
            };
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (currentActiveButton != null)
            {
                currentActiveButton.ChangeColor();
                //currentActiveButton.Content = "" + currentActiveButton.CurrentState;
                if(currentActiveButton.CurrentState==ButtonState.Red)
                {
                    score -= 5;
                    ScoreText.Text = $"Score: {score}";
                }else
                if (currentActiveButton.CurrentState == ButtonState.Inactive)
                {
                    currentActiveButton.ResetButtonState();
                    currentActiveButton = null;
                   
                    ActivateRandomButton();
                }
                EndGame();
                
            }
        }

        private void ActivateRandomButton()
        {
            if (currentActiveButton == null)
            {
                int index = random.Next(0, GameGrid.Children.Count);
                currentActiveButton = (Gomb)GameGrid.Children[index];
                currentActiveButton.Activate();
            }
        }

        private void StartGame(object sender, RoutedEventArgs e)
        {
            startgomb.Visibility = Visibility.Hidden;
            tittle.Visibility = Visibility.Hidden;
            diffslider.Visibility = Visibility.Hidden;
            difftxt.Visibility = Visibility.Hidden;
            ScoreText.Visibility = Visibility.Visible;
            GameGrid.Visibility = Visibility.Visible;

            InitializeGame();
            StartGameTimer();
        }
        private void EndGame()
        {
            if (score < 0)
            {
                ResetGame();
                ScoreText.Visibility = Visibility.Hidden;
                GameGrid.Visibility = Visibility.Hidden;
                startgomb.Visibility = Visibility.Visible;
                tittle.Visibility = Visibility.Visible;
                diffslider.Visibility = Visibility.Visible;
                difftxt.Visibility = Visibility.Visible;
            }
        }
       
        private void Difficulty(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            difficulty = diffslider.Value;
        }

        private void ResetGame()
        {
            if (currentActiveButton != null)
            {
                currentActiveButton.ResetButtonState();
                currentActiveButton = null;
            }

            if (timer != null)
            {
                timer.Stop();
                timer.Tick -= Timer_Tick;
                timer = null;
            }

            score = 0;
            GameGrid.Children.Clear();
            ScoreText.Text = $"Score: {score}";
        }

    }

    public enum ButtonState
    {
        Inactive,
        Green,
        Yellow,
        Red
    }

    
}