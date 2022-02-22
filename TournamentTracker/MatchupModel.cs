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
        /// uniquely identify each matchup
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// Represents the Team which comes to play Tournament
        /// </summary>
        public List<MatchupEntryModel> Entries { get; set; } = new List<MatchupEntryModel>();

        /// <summary>
        /// Represents the Winner
        /// </summary>
        public int winnerId { get; set; }

        /// <summary>
        /// Represents the number of MatchupRound
        /// </summary>
        /// 
        public int MatchupRound { get; set; }

        public TeamModel winner { get; set; }

        public string DisPlayName
        {
            get
            {
                string output = " ";
                foreach(MatchupEntryModel me in Entries)
                {
                    if (me.TeamCompeting != null)
                    {


                        if (output.Length == 0)
                        {
                            output = me.TeamCompeting.TeamName;
                        }
                        else
                        {
                            output += $" vs. {me.TeamCompeting.TeamName}";
                        }
                    }
                    else
                    {
                        output = "Matchup not yet determined";
                        break;
                    }
                }
                return output;
            }
        }
    }
}
