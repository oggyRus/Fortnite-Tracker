using Fortnite_API.Objects.V1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    internal class SquadStats : IStatistics
    {
        public BrStatsV2V1SquadStats Stats { get; private set; }

        public DateTime LastModified { get; private set; }

        public Dictionary<string, string> IndividualStats { get; private set; }

        public Dictionary<string, string> VictoriesStats { get; private set; }

        public Dictionary<string, string> MatchStats { get; private set; }

        public SquadStats(BrStatsV2V1SquadStats stats)
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
                {"Top 3 times", Stats.Top3.ToString()},
                {"Top 6 times", Stats.Top6.ToString()},
                {"Minutes Played",Stats.MinutesPlayed.ToString()}
            };
        }
    }
}
