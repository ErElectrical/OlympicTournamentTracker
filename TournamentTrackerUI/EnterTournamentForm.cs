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
    public partial class EnterTournamentForm : Form,IPrizeRequest,ITeamRequester
    {
        List<TeamModel> AvailableTeams = new List<TeamModel>();
        List<TeamModel> SelectedTeams = new List<TeamModel>();
        List<PrizeModel> SelectedPrizes = new List<PrizeModel>();
        public EnterTournamentForm()
        {
            InitializeComponent();
            WireupLists();
        }

        private void FeedAvailableTeams()
        {
            SqlDataConnection sql = new SqlDataConnection();
            AvailableTeams = sql.GetTeam_All();
        }

        private void WireupLists()
        {
            SelectedTeamDropDownMenu.DataSource = null;
            SelectedTeamDropDownMenu.DataSource = AvailableTeams;
            SelectedTeamDropDownMenu.DisplayMember = "TeamName";


            TournammentTeamListBox.DataSource = null;
            TournammentTeamListBox.DataSource = SelectedTeams;
            TournammentTeamListBox.DisplayMember = "TeamName";

            PrizeBoxList.DataSource = null;
            PrizeBoxList.DataSource = SelectedPrizes;
            PrizeBoxList.DisplayMember = "PlaceName";



        }

        private void HeaderLabel_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void RoundDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void MatchUpBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void TeamPlayerLabelForPrize_Click(object sender, EventArgs e)
        {

        }

        private void TeamPlayerLabel_Click(object sender, EventArgs e)
        {

        }

        private void AddTeamButton_Click(object sender, EventArgs e)
        {
            TeamModel tm = (TeamModel)SelectedTeamDropDownMenu.SelectedItem;
            if(tm != null)
            {
                AvailableTeams.Remove(tm);
                SelectedTeams.Add(tm);

                WireupLists();
            }
            else
            {
                MessageBox.Show("Please choose something");
            }
        }

        /// <summary>
        ///What we have to do
        /// call cretePrizeForm
        /// get back a PrizeModel From the form
        /// take back the PrizeModel and put it to selected Prizes list box.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreatePrizeButton_Click(object sender, EventArgs e)
        {
            //call createPrize form
            CreatePrize frm = new CreatePrize(this);
            frm.Show();
        }

        public void PrizeComplete(PrizeModel Model)
        {
            //get back the Model from Form
            //already we have Our Model as Parameter of Method

            //Take Back the Model and Put it to selectedPrize 

            SelectedPrizes.Add(Model);
            WireupLists();
        }

        /// <summary>
        /// Call the CreateTeam Form
        /// Get Back Model From the Form
        /// Put that Model To SelectedTeams list box.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EnterNewTeamLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CreateTeam Ct = new CreateTeam(this);
            Ct.Show();
        }

        public void CompleteTeam(TeamModel Model)
        {
            SelectedTeams.Add(Model);
            WireupLists();
        }

        /// <summary>
        /// What To do
        /// Create A TeamModel
        /// Remove the Team from Selected  Teams
        /// Put it into Available Teams
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteSelectedPlayerButton_Click(object sender, EventArgs e)
        {
            TeamModel tm = (TeamModel)TournammentTeamListBox.SelectedItem;

            if (tm != null)
            {
                SelectedTeams.Remove(tm);
                AvailableTeams.Add(tm);
                WireupLists();

            }
            else
            {
                MessageBox.Show("Plase Choose Team ");
            }
        }

        /// <summary>
        /// What to do
        /// create a PrizeModel and put the selectedPrize into it
        /// Remove that Prize from the selectedPrizes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteSelectedPrizeBox_Click(object sender, EventArgs e)
        {
            PrizeModel p = (PrizeModel)PrizeBoxList.SelectedItem;

            if(p != null)
            {
                SelectedPrizes.Remove(p);
                WireupLists();
            }
            else
            {
                MessageBox.Show("Please Select Prize ");
            }
        }

        private void CreateTournamentButton_Click(object sender, EventArgs e)
        {
            //Validate data

            decimal fee = 0;
            bool feeAcceptable = decimal.TryParse(EntryFeeValue.Text, out fee);
            if(!feeAcceptable)
            {
                MessageBox.Show("Plase enter a valid entry fee",
                                "Invalid Format",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }

            //create Tournament Entry

            TournamentModel tm = new TournamentModel();
            tm.TournamentName = TournamentNameValue.Text;
            tm.EntryFees = fee;



            //Create Prize Entry

            tm.prizes = SelectedPrizes;

            //Create all of Team Entry
            tm.EnteredTeams = SelectedTeams;
            //craete all Matchups
            TournamentLogic.CreateRounds(tm);

            ConnectionConfig.Connections.Add((Idataconnection)tm);
            tm.AlertUsersToNewRound();

            TournamentLogic.UpdateTournamentsResult(tm);

            TournamentTrackerForm frm = new TournamentTrackerForm(tm);
            frm.Show();
            this.Close();

        }
    }
}
