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
        public void CompleteTournament(TournamentModel Model)
        {
            List<TournamentModel> tournaments = ConnectionConfig.TournamentModelFile.
                                               FullFilePath().
                                               LoadFile().
                                               ConvertToTournamentsModel();
            tournaments.Remove(Model);
            tournaments.SaveToTournamentModelFile();
            TournamentLogic.UpdateTournamentsResult(Model);

        }

        public void  CreatePlayer(PersonModel Model)
        {
            //list of personModel conatin all players information available in personfile
            List<PersonModel> Players = ConnectionConfig.PersonFile.FullFilePath().LoadFile().ConvertToPersonModel();
            
            //set id zero because at start we dont have any id for player
            int currentId = 0;
            //check weather we have player available in player list because no way to provide a null to id
            if(Players.Count == 0)
            {
                //provide first id to current id and as many time if condition exists increase the id by 1
                //so that we will get unique id every time
                currentId = Players.OrderByDescending(x => x.id).First().id + 1;
            }
            //store the id to our personmodel id
            Model.id = currentId;
            //add the model to player list
            Players.Add(Model);
            //save the data to required text file
            Players.SaveToPersonFile();

            
        }

        public void CreatePrize(PrizeModel Model)
        {
            //Load the text file
            // take data to List<Prize> 
            //Find the max(id)
            //Add the new record with next id(max+1)
            //convert the Prizes to List<string>
            //save the list<String> to text file

            List<PrizeModel> Prizes = ConnectionConfig.PrizesFile.FullFilePath().LoadFile().ConvertToPrizeModel();

            //Find the max(id)
            int currentId = 1;
            if(Prizes.Count < 0)
            {
                 currentId = Prizes.OrderByDescending(x => x.Id).First().Id + 1;

            }
            

            Model.Id = currentId;

            Prizes.Add(Model);

            Prizes.SaveToPrizeFile();

          


        }

        /// <summary>
        /// what to do
        /// create a varible for teams of teammodel
        /// initialse the currennt id with value 1
        /// check wethere the teams are available or not
        /// if available populate the id and increase it by 1 at the time we donot instance all teams id
        /// save back the get id to our model
        /// add that model to our list
        /// save the model to text file
        /// </summary>
        /// <param name="Model"></param>
        public void CreateTeam(TeamModel Model)
        {
            List<TeamModel> teams = ConnectionConfig.TeamModelFile.FullFilePath().LoadFile().ConvertToTeamModels();

            int currentId = 1;
            if (teams.Count < 0)
            {
                currentId = teams.OrderByDescending(x => x.Id).First().Id + 1;

            }


            Model.Id = currentId;

            teams.Add(Model);

            teams.SaveToTeamModelFile();

     

        }

        /// <summary>
        /// what to do
        /// create a varible for tournament of tournament model
        /// initialse the currennt id with value 1
        /// check wethere the tournaments are available or not
        /// if available populate the id and increase it by 1 at the time we donot instance all teams id
        /// save back the get id to our model
        /// add that model to our list
        /// save the model to text file
        /// </summary>
        /// <param name="Model"></param>

        public void CreateTournament(TournamentModel Model)
        {
            List<TournamentModel> tournament = ConnectionConfig.TournamentModelFile.
                                                FullFilePath().
                                                LoadFile().
                                                ConvertToTournamentsModel();
            int currentId = 1;
            if (tournament.Count < 0)
            {
                currentId = tournament.OrderByDescending(x => x.Id).First().Id + 1;

            }


            Model.Id = currentId;


            //Todo -- save the previous id of rounds as our logic dont take track of such things

            Model.SaveRoundsTofile();

            tournament.Add(Model);

            TournamentLogic.UpdateTournamentsResult(Model);


            tournament.SaveToTournamentModelFile();

            

        }

        public List<PersonModel> GetPerson_All()
        {
            return ConnectionConfig.PersonFile.FullFilePath().LoadFile().ConvertToPersonModel();

        }

        public List<TeamModel> GetTeam_All()
        {
            return ConnectionConfig.TeamModelFile.FullFilePath().LoadFile().ConvertToTeamModels();
        }

        public List<TournamentModel> GetTournament_All()
        {
            return ConnectionConfig.TournamentModelFile.FullFilePath().
                    LoadFile().ConvertToTournamentsModel();
        }

        public void UpdateMatchup(MatchupModel model)
        {
            model.UpdateMatchupToFile();
        }

       
    }
}
