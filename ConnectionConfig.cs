using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace TournamentTracker
{
    /// <summary>
    /// Why static class need here
    /// Because that task we have to do at many times.
    /// </summary>
    public static  class ConnectionConfig
    {
        public const string PrizesFile = "PrizeModel.csv";
        public const string PersonFile = "PersonModel.csv";
        public const string TeamModelFile = "TeamModel.csv";
        public const string TournamentModelFile = "TournamentModel.csv";
        public const string MatchupModelFile = "MatchupModel.csv";
        public const string MatchupEntryModelFile = "MatchupEntryModel.csv";

        public static List<Idataconnection> Connections { get; private set; }

        public static void IntializeConnection(DataType db)
        {
            if( db == DataType.DataBase)
            {
                //ToDo - create something for Database connection
                SqlDataConnection sql = new SqlDataConnection();
                Connections.Add(sql);
            }
            else if(db == DataType.TextFile)
            {
                //Todo - Create a TxtFile
                TextDataConnection Text = new TextDataConnection();
                Connections.Add(Text);
                
            }
        }

        public static string CnnString(string Name)
        {
           return ConfigurationManager.ConnectionStrings[Name].ConnectionString;
        }

    }
}
