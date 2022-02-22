using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TournamentTracker;



namespace TournamentTrackerUI
{
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            //Initialize the dataBase connection
            TournamentTracker.ConnectionConfig.IntializeConnection(DataTypeenum.DataBase);
            TournamentTracker.ConnectionConfig.IntializeConnection(DataTypeenum.TextFile);




            Application.Run(new TournamentDashBoard());
                
        }
    }
}
