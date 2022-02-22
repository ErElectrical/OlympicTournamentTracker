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
        /// <summary>
        /// All of our text file name for differnent model.
        /// </summary>
        public const string PrizesFile = "PrizeModel.csv";
        public const string PersonFile = "PersonModel.csv";
        public const string TeamModelFile = "TeamModel.csv";
        public const string TournamentModelFile = "TournamentModel.csv";
        public const string MatchupModelFile = "MatchupModel.csv";
        public const string MatchupEntryModelFile = "MatchupEntryModel.csv";

        /// <summary>
        /// varible that will hold the connection 
        /// basically it will take the object of both classes that will do stuff to do connection in both way sql and text.
        /// </summary>
        public static List<Idataconnection> Connections { get; private set; } = new List<Idataconnection>();

   
        public static void IntializeConnection(DataTypeenum db)
        {
           if( db == DataTypeenum.DataBase)
            {
                //ToDo - create something for Database connection
                SqlDataConnection sql = new SqlDataConnection();
                Connections.Add(sql);
            }
            else if(db == DataTypeenum.TextFile)
            {
                //Todo - Create a TxtFile
                TextDataConnection Text = new TextDataConnection();
                Connections.Add(Text);
                
            }
        }

        /// <summary>
        /// it returns a connection string based on the File name we proivided to it
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        public static string CnnString(string Name)
        {
           return ConfigurationManager.ConnectionStrings[Name].ConnectionString;
        }

        /// <summary>
        /// search for the given Key in app.config file
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string AppKeyLookup(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }
    }
}
