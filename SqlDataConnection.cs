﻿using System;
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
                p.Add("@TournamentsName", Model.TournamentName);
                p.Add("@EntryFees", Model.EntryFees);
                p.Add("@id", 0, dbType: System.Data.DbType.Int32, direction: System.Data.ParameterDirection.Output);

                sqlConnection.Execute("spInsert_Tournaments", p, commandType: System.Data.CommandType.StoredProcedure);
                Model.Id = p.Get<int>("@id");

                foreach(PrizeModel prize in Model.prizes)
                {
                    p = new DynamicParameters();
                    p.Add("@TournamentsId", Model.Id);
                    p.Add("@PrizeId", prize.Id);
                    p.Add("@id", 0, dbType: System.Data.DbType.Int32, direction: System.Data.ParameterDirection.Output);

                    sqlConnection.Execute("spDistributePrizes_Insert", p, commandType: System.Data.CommandType.StoredProcedure);



                }

                foreach(TeamModel Tm in Model.EnteredTeams)
                {
                    p = new DynamicParameters();
                    p.Add("@TournamentsId", Model.Id);
                    p.Add("@TeamId", Tm.Id);
                    p.Add("@id", 0, dbType: System.Data.DbType.Int32, direction: System.Data.ParameterDirection.Output);

                    sqlConnection.Execute("spTournamentsEntries_Insert", p, commandType: System.Data.CommandType.StoredProcedure);



                }
                return Model;



            }

        }
    }    

}
