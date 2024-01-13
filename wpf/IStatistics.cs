using Fortnite_API.Objects.V1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public interface IStatistics
    {
        public DateTime LastModified { get; }
        public Dictionary<string, string> IndividualStats { get; }
        public Dictionary<string, string> VictoriesStats { get; }
        public Dictionary<string, string> MatchStats { get; }

        public void SetIndividualStats();
        public void SetVictoryStats();
        public void SetMatchStats();
    }
}