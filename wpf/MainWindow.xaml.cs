using Fortnite_API;
using Fortnite_API.Objects;
using Fortnite_API.Objects.V1;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private BrStatsV2V1AccountType accountType;
        private Platforms statsPlatform;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string text = textBox.Text;
            var stats = GetStats(text);
            StatsWindow statsWindow;
            if (stats.IsSuccess)
            {
                switch (statsPlatform)
                {
                    case Platforms.Overall:
                        statsWindow = new StatsWindow(stats.Data.Stats.All);
                        break;
                    case Platforms.Gamepad:
                        statsWindow = new StatsWindow(stats.Data.Stats.Gamepad);
                        break;
                    case Platforms.KeyboardMouse:
                        statsWindow = new StatsWindow(stats.Data.Stats.KeyboardMouse);
                        break;
                    case Platforms.Touch:
                        statsWindow = new StatsWindow(stats.Data.Stats.Touch);
                        break;
                    default:
                        throw new ArgumentException();

                }
                statsWindow.Show();
                Close();
            }
            else
            {
                MessageBox.Show(stats.Error);
            }
        }
        private ApiResponse<BrStatsV2V1> GetStats(string nickname)
        {
            var apiClient = new FortniteApiClient("8fed1f89-661c-497f-b463-5ac3c75c3115");
            var stats = apiClient.V1.Stats.GetBrV2Id(x =>
            {
                x.Name = nickname;
                x.AccountType = accountType;
            });
            return stats;
        }

        private void RadioButton_Checked_AccountType(object sender, RoutedEventArgs e)
        {
            RadioButton chkBox = (RadioButton)sender;
            switch (chkBox.Content.ToString())
            {
                case "Epic Games":
                    accountType = BrStatsV2V1AccountType.Epic;
                    break;
                case "Xbox Live":
                    accountType = BrStatsV2V1AccountType.XBL;
                    break;
                case "PlayStation/Nintendo":
                    accountType = BrStatsV2V1AccountType.PSN;
                    break;
                default:
                    throw new ArgumentException();
            }
        }

        private void RadioButton_Checked_Platform(object sender, RoutedEventArgs e)
        {
            RadioButton chkBox = (RadioButton)sender;
            switch (chkBox.Content.ToString())
            {
                case "Overall":
                    statsPlatform = Platforms.Overall;
                    break;
                case "Gamepad":
                    statsPlatform = Platforms.Gamepad;
                    break;
                case "Keyboard/Mouse":
                    statsPlatform = Platforms.KeyboardMouse;
                    break;
                case "Touch":
                    statsPlatform = Platforms.Touch;
                    break;
                default:
                    throw new ArgumentException();
            }
        }
    }
}