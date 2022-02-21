using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentTracker
{
    /// <summary>
    /// InterFace Created for DataConnection
    /// As according to my requirement I have to save My data at DB and Txt file
    /// </summary>
    public interface Idataconnection
    {
        //refactor Idataconnection as we do not model back because probably we donot do anything

        /// <summary>
        /// Method inistite the prizemodel
        /// </summary>
        /// <param name="Model"></param>
        void CreatePrize(PrizeModel Model);

        /// <summary>
        /// Method initialize the personModel
        /// create player for tournaments
        /// </summary>
        /// <param name="Model"></param>
        void CreatePlayer(PersonModel Model);

        /// <summary>
        /// Method initialie the Teammodel class entity
        /// create a team of tournaments
        /// </summary>
        /// <param name="Model"></param>
        void CreateTeam(TeamModel Model);

        /// <summary>
        /// Method initialize the TournamentModel class entity
        /// create tournaments for various game
        /// </summary>
        /// <param name="Model"></param>
        void CreateTournament(TournamentModel Model);

        /// <summary>
        /// Method returns all teams that are playing in current tournaments
        /// </summary>
        /// <returns></returns>
        List<TeamModel> GetTeam_All();

        /// <summary>
        /// Method returns all the person that are playing in provided teams
        /// </summary>
        /// <returns></returns>
        List<PersonModel> GetPerson_All();

        /// <summary>
        /// Method provides the all tournaments that are currently in play
        /// </summary>
        /// <returns></returns>
        List<TournamentModel> GetTournament_All();

        /// <summary>
        /// Update the matchup of teams that are plaing in the round
        /// </summary>
        /// <param name="model"></param>
        void UpdateMatchup(MatchupModel model);

        void CompleteTournament(TournamentModel Model);
    }
}
