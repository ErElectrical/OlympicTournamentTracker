using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentTracker
{
    public class MatchupEntryModel
    {
        /// <summary>
        /// Unique identifier for MatchupEntryModel
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Represents one team in Matchup.
        /// </summary>
        public TeamModel TeamCompeting { get; set; }

        /// <summary>
        /// Represents id for teamcompeting
        /// </summary>
        public int TeamcompetingId { get; set; }

        /// <summary>
        /// Represents score for this Paricular team.
        /// </summary>
        public double Score { get; set; }

        /// <summary>
        /// Represents a Matchup from that team comes as winner
        /// 
        /// </summary>
        public MatchupModel ParentMatchup { get; set; }

        /// <summary>
        /// represents Parentmatchupid
        /// </summary>
        public int parentmatchupId { get; set; }

    }
}
