using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentTracker
{
    ///Todo - create a wire up with txt file
    /// <summary>
    /// Method save Data to text file
    /// </summary>
    public class TextDataConnection:Idataconnection
    {
        public const string PrizesFile = "PrizeModel.csv";
        public const string PersonFile = "PersonModel.csv";
        public const string TeamModelFile = "TeamModel.csv";
        public const string TournamentModelFile = "TournamentModel.csv";
        public const string MatchupModelFile = "MatchupModel.csv";
        public const string MatchupEntryModelFile = "MatchupEntryModel.csv";

        public PersonModel CreatePlayer(PersonModel Model)
        {
            List<PersonModel> Players = PersonFile.FullFilePath().LoadFile().ConvertToPersonModel();

            int currentId = 0;
            if(Players.Count == 0)
            {
                currentId = Players.OrderByDescending(x => x.id).First().id + 1;
            }

            Model.id = currentId;

            Players.Add(Model);
            Players.SaveToPersonFile(PersonFile);

            return Model;
        }

        public PrizeModel CreatePrize(PrizeModel Model)
        {
            //Load the text file
            // take data to List<Prize> 
            //Find the max(id)
            //Add the new record with next id(max+1)
            //convert the Prizes to List<string>
            //save the list<String> to text file

            List<PrizeModel> Prizes = PrizesFile.FullFilePath().LoadFile().ConvertToPrizeModel();

            //Find the max(id)
            int currentId = 1;
            if(Prizes.Count < 0)
            {
                 currentId = Prizes.OrderByDescending(x => x.Id).First().Id + 1;

            }
            

            Model.Id = currentId;

            Prizes.Add(Model);

            Prizes.SaveToPrizeFile(PrizesFile);

            return Model;


        }

        public TeamModel CreateTeam(TeamModel Model)
        {
            List<TeamModel> teams = TeamModelFile.FullFilePath().LoadFile().ConvertToTeamModels(PersonFile);

            int currentId = 1;
            if (teams.Count < 0)
            {
                currentId = teams.OrderByDescending(x => x.Id).First().Id + 1;

            }


            Model.Id = currentId;

            teams.Add(Model);

            teams.SaveToTeamModelFile(TeamModelFile);

            return Model;

        }

        public TournamentModel CreateTournament(TournamentModel Model)
        {
            List<TournamentModel> tournament = TournamentModelFile.
                                                FullFilePath().
                                                LoadFile().
                                                ConvertToTournamentsModel(
                                                TeamModelFile,
                                                PersonFile,
                                                PrizesFile);
            int currentId = 1;
            if (tournament.Count < 0)
            {
                currentId = tournament.OrderByDescending(x => x.Id).First().Id + 1;

            }


            Model.Id = currentId;


            //Todo -- save the previous id of rounds as our logic dont take track of such things

            Model.SaveRoundsTofile(MatchupEntryModelFile, MatchupModelFile);

            tournament.Add(Model);

            tournament.SaveToTournamentModelFile(TournamentModelFile);

            return Model;

        }

        public List<PersonModel> GetPerson_All()
        {
            return PersonFile.FullFilePath().LoadFile().ConvertToPersonModel();

        }

        public List<TeamModel> GetTeam_All()
        {
            return TeamModelFile.FullFilePath().LoadFile().ConvertToTeamModels(PersonFile);
        }

        public List<TournamentModel> GetTournament_All()
        {
            return TournamentModelFile.FullFilePath().
                    LoadFile().ConvertToTournamentsModel(TeamModelFile, PersonFile, PrizesFile);
        }

    }
}
