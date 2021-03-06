using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentTracker
{
    public class TournamentModel
    {
        public event EventHandler<DateTime> onTournamentComplete;

        public int Id { get; set;  }
        /// <summary>
        /// Represents name of Tournament
        /// </summary>
        public string TournamentName { get; set; }

        /// <summary>
        /// Entryfees
        /// </summary>
        public decimal EntryFees { get; set;  }

        /// <summary>
        /// All teams that Play innn Tournamnet
        /// </summary>
        public List<TeamModel> EnteredTeams { get; set; } = new List<TeamModel>();

        /// <summary>
        /// Prizes that get in tournamnet
        /// </summary>
        public List<PrizeModel> prizes { get; set; } = new List<PrizeModel>();

        /// <summary>
        /// Represents The team that Matchup
        /// </summary>
        public List<List<MatchupModel>> Rounds { get; set; } = new List<List<MatchupModel>>();

        public void CompleteTournament()
        {
            onTournamentComplete?.Invoke(this, DateTime.Now);
        }
    }
}
