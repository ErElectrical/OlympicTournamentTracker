using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TournamentTracker;

namespace TournamentTrackerUI
{
    public partial class TournamentDashBoard : Form
    {
        List<TournamentModel> tournaments;
        SqlDataConnection sql = new SqlDataConnection();
       
        
        public TournamentDashBoard()
        {

            InitializeComponent();
            tournaments = sql.GetTournament_All().ToList();
        }

        private void CretateTournamentButton_Click(object sender, EventArgs e)
        {
            EnterTournamentForm frm = new EnterTournamentForm();
            frm.Show();

        }
        private void WireupLists()
        {
            LoadExistingTournamentDropDownMenu.DataSource=tournaments;
            LoadExistingTournamentDropDownMenu.DisplayMember = "TournamentName";

        }

        private void LoadExistingTournamentButton_Click(object sender, EventArgs e)
        {
            TournamentModel tm = (TournamentModel)LoadExistingTournamentDropDownMenu.SelectedItem;
            TournamentTrackerForm frm = new TournamentTrackerForm(tm);
            frm.Show();
        }
    }
}
