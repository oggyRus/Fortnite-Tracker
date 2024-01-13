using Fortnite_API.Objects.V1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    internal class DuoStats : IStatistics
    {
        public BrStatsV2V1DuoStats Stats { get; private set; }

        public DateTime LastModified { get; private set; }

        public Dictionary<string, string> IndividualStats { get; private set; }

        public Dictionary<string, string> VictoriesStats { get; private set; }

        public Dictionary<string, string> MatchStats { get; private set; }

        public DuoStats(BrStatsV2V1DuoStats stats)
        {
            Stats = stats;
            LastModified = Stats.LastModified;
            SetIndividualStats();
            SetVictoryStats();
            SetMatchStats();
        }

        public void SetIndividualStats()
        {
            IndividualStats = new Dictionary<string, string>()
            {
                {"KD", Stats.Kd.ToString()},
                {"Kills", Stats.Kills.ToString()},
                {"Death", Stats.Deaths.ToString()},
                {"Score", Stats.Score.ToString()},
                {"Score Per Minute", Stats.ScorePerMin.ToString()},
                {"Score Per Match", Stats.ScorePerMatch.ToString()},
                {"Players Outlived", Stats.PlayersOutlived.ToString()},
                {"Matches", Stats.Matches.ToString()}
            };
        }
        public void SetVictoryStats()
        {
            VictoriesStats = new Dictionary<string, string>()
            {
                {"Wins", Stats.Wins.ToString()},
                {"Win Rate", Stats.WinRate.ToString()},
            };
        }
        public void SetMatchStats()
        {
            MatchStats = new Dictionary<string, string>()
            {
                {"Top 5 times", Stats.Top5.ToString()},
                {"Top 12 times", Stats.Top12.ToString()},
                {"Minutes Played",Stats.MinutesPlayed.ToString()}
            };
        }
    }
}