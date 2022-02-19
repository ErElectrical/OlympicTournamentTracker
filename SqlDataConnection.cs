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
        public PrizeModel CreatePrize(PrizeModel Model)
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


                Model.Id = p.Get<int>("@id");

                return Model;

            }
        }


        public PersonModel CreatePlayer(PersonModel Model)
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

                return Model;


            }

        }

        public List<PersonModel> GetPerson_All()
        {
            List<PersonModel> output;

            using(SqlConnection sqlConnection = new SqlConnection(ConnectionConfig.CnnString("TournamentTrackerDataBase")))
            {
                output = sqlConnection.Query<PersonModel>("dbo.spGetPlayer_All").ToList();
                

            }
            return output;

        }

        public TeamModel CreateTeam(TeamModel Model)
        {
            using(SqlConnection connection=new SqlConnection(ConnectionConfig.CnnString("TournamentTrackerDataBase")))
            {
                var p = new  DynamicParameters();
                p.Add("@TeamName", Model.TeamName);
                p.Add("@id", 0, dbType: System.Data.DbType.Int32, direction: System.Data.ParameterDirection.Output);

                connection.Open();
                connection.Execute("spTeams_Insert", p, commandType: System.Data.CommandType.StoredProcedure);
                

                Model.Id = p.Get<int>("@id");

                foreach(PersonModel tm in Model.Teammembers)
                {
                    p = new DynamicParameters();
                    p.Add("@TeamId", Model.Id);
                    p.Add("@@PlayerId", tm.id);

                    connection.Execute("spTeamMembers_Insert", p, commandType: System.Data.CommandType.StoredProcedure);
                }
                return Model;

            }
        }

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

        public TournamentModel CreateTournament(TournamentModel Model)
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
                return Model;



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
