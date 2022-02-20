using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dapper;

namespace TournamentTracker
{
    public class SqlDataConnection : Idataconnection
    {
        public SqlDataConnection()
        {


        }

        /// <summary>
        /// what to do
        /// store the Prize in mssql Db
        /// establish the connection
        /// enable the connection to connect to db
        /// update all the entry in db that is available in our model class named as prizeModel
       /// </summary>
        /// <param name="Model"></param>
        public void  CreatePrize(PrizeModel Model)
        {

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionConfig.CnnString("TournamentTrackerDataBase")))
            {
                //DynamicParameter means the compiler does not check for the type of varible at compile time instead it puts 
                // them in run time.
                sqlConnection.Open();

                var p = new DynamicParameters();
                p.Add("@Placenumber", Model.PlaceNumber);
                p.Add("@PlaceName", Model.PlaceName);
                p.Add("@PrizeAmount", Model.PrizeAmount);
                p.Add("@PrizePercentage", Model.PrizePercentage);
                p.Add("@id", 0, dbType: System.Data.DbType.Int32, direction: System.Data.ParameterDirection.Output);


                SqlCommand cmd = new SqlCommand("spInsertTournamentPrize", sqlConnection);

                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(p);


                //save the id that we are providing to Db as Id act as a identifier in our model 
                //class design also.
                Model.Id = p.Get<int>("@id");

               

            }
        }

        /// <summary>
        /// what to do 
        /// establish the connectio to db
        /// enable the connection to connect to db
        /// add all the entity in db from Model class PersonModel
        /// store all the id as id is only way to identification
        /// 
        /// </summary>
        /// <param name="Model"></param>
        public void  CreatePlayer(PersonModel Model)
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionConfig.CnnString("TournamentTrackerDataBase")))
            {
                sqlConnection.Open();

                var p = new DynamicParameters();
                p.Add("@FirstName", Model.FirstName);
                p.Add("@LastName", Model.LastName);
                p.Add("@Email", Model.Email);
                p.Add("@CellPhoneNumber", Model.CellPhoneNumber);
                p.Add("@id", 0, dbType: System.Data.DbType.Int32, direction: System.Data.ParameterDirection.Output);


                SqlCommand command = new SqlCommand("spInsertPlayer", sqlConnection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add(p);

                command.ExecuteNonQuery();

                Model.id = p.Get<int>("@id");

                


            }

        }

        /// <summary>
        /// what to do
        /// create  a list of personmodel as output list
        /// establish connection with db
        /// connect to db
        /// run a stored procedure query get all the player details 
        /// store back to output list
        /// return the output list
        /// </summary>
        /// <returns></returns>
        public List<PersonModel> GetPerson_All()
        {
            List<PersonModel> output;

            using(SqlConnection sqlConnection = new SqlConnection(ConnectionConfig.CnnString("TournamentTrackerDataBase")))
            {
                output = sqlConnection.Query<PersonModel>("dbo.spGetPlayer_All").ToList();
                

            }
            return output;

        }

        /// <summary>
        /// what to do 
        /// establish the connection to db
        /// connect it to db
        /// populate the entity of teammodel
        /// get back the id
        /// </summary>
        /// <param name="Model"></param>
        public void  CreateTeam(TeamModel Model)
        {
            using(SqlConnection connection=new SqlConnection(ConnectionConfig.CnnString("TournamentTrackerDataBase")))
            {
                var p = new  DynamicParameters();
                p.Add("@TeamName", Model.TeamName);
                p.Add("@id", 0, dbType: System.Data.DbType.Int32, direction: System.Data.ParameterDirection.Output);

                connection.Open();
                connection.Execute("spTeams_Insert", p, commandType: System.Data.CommandType.StoredProcedure);
                

                Model.Id = p.Get<int>("@id");

                //as teammember is of type personmodel
                //therefore we have to populate the entity by using a new storedProcedure
                foreach(PersonModel tm in Model.Teammembers)
                {
                    p = new DynamicParameters();
                    p.Add("@TeamId", Model.Id);
                    p.Add("@PlayerId", tm.id);

                    connection.Execute("spTeamMembers_Insert", p, commandType: System.Data.CommandType.StoredProcedure);
                }
                

            }
        }

        /// <summary>
        /// what to do 
        /// get back a list of team that conatin information about teams and there member
        /// establish the connection
        /// get all the teams to a output list of teammodel class type
        /// get back the members based on specific team id and populate the teammebers 
        /// return back the list of teammodel output
        /// </summary>
        /// <returns></returns>
        public List<TeamModel> GetTeam_All()
        {
            List<TeamModel> output;

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionConfig.CnnString("TournamentTrackerDataBase")))
            {
                output = sqlConnection.Query<TeamModel>("dbo.spGetTeam_All").ToList();

                foreach(TeamModel tm in output)
                {
                    var p = new DynamicParameters();
                    p.Add("@Teamid", tm.Id);
                    tm.Teammembers = sqlConnection.Query<PersonModel>("spTeamMembers_GetByTeams",p,commandType:System.Data.CommandType.StoredProcedure).ToList();
                }


            }
            return output;
        }
        /// <summary>
        /// what to do
        /// establish connection to db
        /// connect to db
        /// add tournament name
        /// add tournament fee
        /// add tournament prizes
        /// add tournament entries
        /// add tournaments round infromation
        /// </summary>
        /// <param name="Model"></param>
        public void  CreateTournament(TournamentModel Model)
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionConfig.CnnString("TournamentTrackerDataBase")))
            {
                

                sqlConnection.Open();
                var p = new  DynamicParameters();
                //Add Tournament Name
                p.Add("@TournamentsName", Model.TournamentName);
                //Add Tournament Fee
                p.Add("@EntryFees", Model.EntryFees);
                p.Add("@id", 0, dbType: System.Data.DbType.Int32, direction: System.Data.ParameterDirection.Output);

                sqlConnection.Execute("spInsert_Tournaments", p, commandType: System.Data.CommandType.StoredProcedure);
                Model.Id = p.Get<int>("@id");

                //Add Tournament Prizes
                foreach(PrizeModel prize in Model.prizes)
                {
                    p = new DynamicParameters();
                    p.Add("@TournamentsId", Model.Id);
                    p.Add("@PrizeId", prize.Id);
                    p.Add("@id", 0, dbType: System.Data.DbType.Int32, direction: System.Data.ParameterDirection.Output);

                    sqlConnection.Execute("spDistributePrizes_Insert", p, commandType: System.Data.CommandType.StoredProcedure);



                }
                //Add Tournament Team Entries
                foreach(TeamModel Tm in Model.EnteredTeams)
                {
                    p = new DynamicParameters();
                    p.Add("@TournamentsId", Model.Id);
                    p.Add("@TeamId", Tm.Id);
                    p.Add("@id", 0, dbType: System.Data.DbType.Int32, direction: System.Data.ParameterDirection.Output);

                    sqlConnection.Execute("spTournamentsEntries_Insert", p, commandType: System.Data.CommandType.StoredProcedure);



                }

                //To do Add Rounds Information

                SaveTournamentRounds(sqlConnection, Model);
                TournamentLogic.UpdateTournamentsResult(Model);





            }

        }

        private  void SaveTournamentRounds(SqlConnection connection,TournamentModel Model)
        {
            //List<List<MatchupModel>> Rounds
            //List<MatchupModel> Entries
            //Loop Through the rounds
            //Loop Through the Matchup
            //save the Matchup
            //Loop through the Entries and save them.

            //Loop through the rounds
            foreach(List<MatchupModel> round in Model.Rounds)
            {
                //Loop through the MatchupModel
                foreach(MatchupModel Matchup in round)
                {
                    //save the Matchup
                    var p = new DynamicParameters();
                    p.Add("@MatchUpRounds", Matchup.MatchupRound);
                    p.Add("@TournamentId", Model.Id);
                    p.Add("@id", 0, dbType: System.Data.DbType.Int32, direction: System.Data.ParameterDirection.Output);

                    connection.Execute("spInsert_Matchups", p, commandType: System.Data.CommandType.StoredProcedure);

                    //getting back the id 
                    Matchup.id = p.Get<int>("@id");

                    //Loop through the MatchuEntry
                    foreach(MatchupEntryModel Entry in Matchup.Entries)
                    {
                        //Save the MatchupEntry
                        p = new DynamicParameters();
                        p.Add("@Matchupid", Matchup.id);
                        if(Entry.ParentMatchup == null)
                        {
                            p.Add("@ParentMatchupid", null);
                        }
                        else
                        {
                            p.Add("@ParentMatchupid", Entry.ParentMatchup);

                        }
                        if (Entry.TeamCompeting == null)
                        {
                            p.Add("@Teamcompetingid", null);
                        }
                        else
                        {
                            p.Add("@Teamcompetingid", Entry.TeamCompeting);

                        }
                        p.Add("@id", 0, dbType: System.Data.DbType.Int32, direction: System.Data.ParameterDirection.Output);
                        connection.Execute("spMatchupsEntries_Insert", p, commandType: System.Data.CommandType.StoredProcedure);


                    }
                }
            }
        }

        public List<TournamentModel> GetTournament_All()
        {
            List<TournamentModel> output = new List<TournamentModel>();
            try
            {
                SqlConnection connection = new System.Data.SqlClient.
                                                SqlConnection(ConnectionConfig.
                                                    CnnString(DataTypeenum.DataBase.ToString()));
                connection.Open();
                output=connection.Query<TournamentModel>("spTournamentview_All").ToList();
                //populate prizes
                foreach(TournamentModel t in output)
                {
                    //populate prizes
                    t.prizes = connection.Query<PrizeModel>("spPrizes_GetbyTournaments").ToList();
                    //populate teams
                    t.EnteredTeams = connection.Query<TeamModel>("spTeam_getBytournament").ToList();
                    foreach(TeamModel team in t.EnteredTeams)
                    {
                        var k = new DynamicParameters();
                        k.Add("TeamId", team.Id);
                        team.Teammembers = connection.Query<PersonModel>("spTeamMembers_GetByTeam").ToList();


                    }

                    var p = new DynamicParameters();
                    p.Add("@TournamentId", t.Id);
                    List<MatchupModel> matchups = connection.Query<MatchupModel>("spMatchups_GetByTournament", p, commandType: System.Data.CommandType.StoredProcedure).ToList();
                    foreach(MatchupModel m in matchups)
                    {
                        p = new DynamicParameters();
                        p.Add("@MatchupId", m.id);
                        m.Entries = connection.Query<MatchupEntryModel>("spMatchupEntries_GetByMatchups", p, commandType: System.Data.CommandType.StoredProcedure).ToList();
                        //Populate each entry (2 models)
                        //populate each Matchup(1 model)

                        List<TeamModel> allTeams = GetTeam_All();
                        if(m.winner.Id > 0)
                        {
                            m.winner = allTeams.Where(x => x.Id == m.winner.Id).First();
                        }
                        foreach(var me in m.Entries)
                        {
                            if(me.TeamCompeting.Id > 0)
                            {
                                me.TeamCompeting = allTeams.Where(x => x.Id == me.TeamCompeting.Id).First();

                            }
                            if(me.ParentMatchup.id > 0)
                            {
                                me.ParentMatchup = matchups.Where(x => x.id == me.ParentMatchup.id).First();
                            }
                        }
                        //round list<list<matchupModel>>

                        List<MatchupModel> currentrow = new List<MatchupModel>();
                        int currentRound = 1;

                        foreach(MatchupModel mp in matchups)
                        {
                            if(mp.MatchupRound > currentRound)
                            {
                                t.Rounds.Add(currentrow);
                                currentrow = new List<MatchupModel>();
                                currentRound += 1;

                            }
                            currentrow.Add(mp);
                        }
                        t.Rounds.Add(currentrow);


                    }
                    return output;




                }
                return output;
                //populate teams

                //populate Rounds

            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return output;
            
            
        }
        /// <summary>
        /// what to do
        /// establish connection to db
        /// connect to db
        /// populate id and get back it
        /// populate winnerid
        /// populate the entry  to get infromation of matchupentrymodel
        /// </summary>
        /// <param name="model"></param>
        public void UpdateMatchup(MatchupModel model)
        {
            using (SqlConnection connection = new System.Data.SqlClient.SqlConnection(ConnectionConfig.CnnString("TournamentTrackerDataBase")))
            {
                connection.Open();
                var p = new DynamicParameters();
                if (model.winner != null)
                {


                    p.Add("@id", model.id);
                    p.Add("@winnerId", model.winnerId);
                    connection.Execute("spMatchups_Update", p, commandType: System.Data.CommandType.StoredProcedure);
                }
                foreach(MatchupEntryModel me in model.Entries)
                {
                    if (me.TeamCompeting != null)
                    {


                        p = new DynamicParameters();
                        p.Add("@id", me.Id);
                        p.Add("@TeamCompeteingid", me.TeamCompeting.Id);
                        p.Add("@score", me.Score);
                        connection.Execute("spMatchupEntries_Update", p, commandType: System.Data.CommandType.StoredProcedure);
                    }
                }



            }
            
        }
    }    

}
