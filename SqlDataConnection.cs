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
    }    

}
