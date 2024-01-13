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
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для StatsWindow.xaml
    /// </summary>
    public partial class StatsWindow : Window
    {
        public BrStatsV2V1StatsPlatform Stats { get; }
        public StatsWindow(BrStatsV2V1StatsPlatform stats)
        {
            Stats = stats;
            InitializeComponent();
            AddStats(Mode.Overall, overall_matches);
            AddStats(Mode.Solo, solo_matches);
            AddStats(Mode.Duo, duo_matches);
            AddStats(Mode.Squad, squad_matches);
            AddStats(Mode.Ltm, ltm_matches);

        }
        private void AddStats(Mode mode, StackPanel panelToFill)
        {
            IStatistics statsToOutput = mode switch
            {
                Mode.Overall => new Overall(Stats.Overall),
                Mode.Solo => new SoloStats(Stats.Solo),
                Mode.Duo => new DuoStats(Stats.Duo),
                Mode.Squad => new SquadStats(Stats.Squad),
                Mode.Ltm => new LtmStats(Stats.Ltm),
                _ => throw new ArgumentException(),
            };
            foreach (var item in statsToOutput.VictoriesStats)
            {
                AddStat(item.Key, item.Value, panelToFill);

            }

            foreach (var item in statsToOutput.IndividualStats)
            {
                AddStat(item.Key, item.Value, panelToFill);
            }

            foreach (var item in statsToOutput.MatchStats)
            {
                AddStat(item.Key, item.Value, panelToFill);
            }
            AddStat("Last modified", statsToOutput.LastModified.ToString(), panelToFill);
        }
        private void AddStat(string name, string value, StackPanel panel)
        {
            TextBlock tb = new()
            {
                Text = $"{name} - > {value}"

            };
            panel.Children.Add(tb);
        }
    }
}