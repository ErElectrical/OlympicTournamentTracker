using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentTracker
{
    public class MatchupModel
    {
        /// <summary>
        /// Represents the Team which comes to play Tournament
        /// </summary>
        public List<MatchupEntryModel> Entries { get; set; }

        /// <summary>
        /// Represents the Winner
        /// </summary>
        public TeamModel winner { get; set; }

        /// <summary>
        /// Represents the number of MatchupRound
        /// </summary>
        public int MatchupRound { get; set; }
    }
}
