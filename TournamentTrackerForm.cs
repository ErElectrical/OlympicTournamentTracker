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
    public partial class TournamentTrackerForm : Form
    {

        private TournamentModel tournaements = new TournamentModel();
        BindingList<int> rounds = new BindingList<int>();
        BindingList<MatchupModel> SelectedMatchups = new BindingList<MatchupModel>();

        BindingSource roundbinding = new BindingSource();
        BindingSource MatchupBinding = new BindingSource();
        public TournamentTrackerForm(TournamentModel tournamentModel)
        {
            InitializeComponent();
            tournaements = tournamentModel;
            tournaements.onTournamentComplete += Tournament_OnTournamentComplete;

            wirecupRoundlists();
            wireupMatchuplists();

            LoadFormData();
            LoadRound();
        }

        private void Tournament_OnTournamentComplete(object sender, DateTime e)
        {
            this.Close();
        }

        private void LoadFormData()
        {
            if(tournaements.TournamentName.Length > 0)
            {
                TournamentName.Text = tournaements.TournamentName;

            }
            else
            {
                MessageBox.Show("Please enter TournamentName first");
            }
        }

        private void LoadRound()
        {
            // rounds = new BindingList<int>();
            rounds.Clear();
            rounds.Add(1);
            int currround = 1;
            foreach (List<MatchupModel> matchups in tournaements.Rounds)
            {
                if (matchups.First().MatchupRound > currround)
                {
                    currround = matchups.First().MatchupRound;
                    rounds.Add(currround);

                }
            }
            LoadMatchups(1);
            // wirecupRoundlists();
        }

        private void wirecupRoundlists()
        {
            roundbinding.DataSource = rounds;
            RoundDropDown.DataSource = roundbinding;


        }
        private void wireupMatchuplists()
        {
            MatchupBinding.DataSource = SelectedMatchups;
            MatchUpBox.DataSource = MatchupBinding;
            MatchUpBox.DisplayMember = "DisPlayName";
        }
        private void TournamentTrackerForm_Load(object sender, EventArgs e)
        {

        }

        private void HeaderLabel_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void RoundLabel_Click(object sender, EventArgs e)
        {

        }

        private void TeamTwoTable_Click(object sender, EventArgs e)
        {

        }

        private void TeamOneLabel_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private string IsvalidData()
        {
            string output = " ";
            double teamonescorevalue = 0;
            double teamtwoscorevalue = 0;

            bool scoreonevalid = double.TryParse(TeamoneScorevalue.Text, out teamonescorevalue);
            bool scoretwovalid = double.TryParse(TeamTwoScoreValue.Text, out teamtwoscorevalue);
            if(! scoreonevalid)
            {
                output = "The score one value is not a valid number";
            }
            else if(! scoretwovalid)
            {
                output = "The score two value is not a valid number ";
            }
            else if(teamonescorevalue == 0 && teamtwoscorevalue == 0)
            {
                output = "you didnot enter a score for either team";
            }
            else if(teamonescorevalue == teamtwoscorevalue)
            {
                output = " We do not allow ties in this application ";
            }
            return output;

                

        }

        /// <summary>
        /// Method is responsible for the event whenever someone ask for score value
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ScoreButton_Click(object sender, EventArgs e)
        {
            string errorMessage = IsvalidData();
            if(errorMessage.Length > 0)
            {
                MessageBox.Show(errorMessage);
                return;
            }
            // put all the teams that is available in Matchupbox 
            MatchupModel m = (MatchupModel)MatchUpBox.SelectedItem;
            double teamonescorevalue = 0;
            double teamtwoscorevalue = 0;
            //traversing in to team entries
            for (int i = 0; i < m.Entries.Count; i++)
            {
                //for teamone 
                if (i == 0)
                {
                    //check weather we are not getting null value
                    if (m.Entries[0].TeamCompeting != null)
                    {
                       //do validation for score value
                        bool scorevalid = double.TryParse(TeamoneScorevalue.Text, out teamonescorevalue);
                        if (scorevalid)
                        {
                            //if validation succed update the score value in enties.
                            m.Entries[0].Score = teamonescorevalue;
                        }
                        else
                        {
                            MessageBox.Show("Please enter a valid score for Team 1");
                            return;
                        }
                    }

                }
                //for teamtwo
                if (i == 1)
                {
                    //check weather we are not getting null as entry
                    if (m.Entries[1].TeamCompeting != null)
                    {

                      //do validation for score value
                        bool scorevalid = double.TryParse(TeamTwoScoreValue.Text, out teamtwoscorevalue);
                        if (scorevalid)
                        {
                            m.Entries[1].Score = teamtwoscorevalue;
                        }
                        else
                        {
                            MessageBox.Show("Please enter a valid score for Team 2");
                            return;
                        }

                    }
                }
            }
            try
            {
                TournamentLogic.UpdateTournamentsResult(tournaements);
            }
            catch(Exception ex)
            {
                MessageBox.Show($"The application has following error : {ex.Message}");
            }
            //initialise the winner id based on the score
            LoadMatchups((int)RoundDropDown.SelectedItem);
           

        }

        private void RoundDropDown_SelectedIndexChanged(object sender, EventArgs e)
            {
                LoadMatchups((int)RoundDropDown.SelectedItem);
            }
            private void LoadMatchups(int round)
            {


                foreach (List<MatchupModel> matchups in tournaements.Rounds)
                {
                    if (matchups.First().MatchupRound == round)
                    {
                        SelectedMatchups.Clear();
                        foreach (MatchupModel m in matchups)
                        {
                            if (m.winner != null || !UnplayedonlyCheckBox.Checked)
                            {
                                SelectedMatchups.Add(m);
                            }
                        }
                    }
                }
                if(SelectedMatchups.Count > 0)
                {
                LoadMatchup(SelectedMatchups.First());

                }
                DisplayMatchupInfo();
          

            }
        private void DisplayMatchupInfo()
        {
            bool isvisible = (SelectedMatchups.Count > 0);

            TeamOneLabel.Visible = isvisible;
            TeamoneScorevalue.Visible = isvisible;
            TeamOneScore.Visible = isvisible;
            TeamTwoName.Visible = isvisible;
            TeamoneScorevalue.Visible = isvisible;
            TeamOneScore.Visible = isvisible;
            ScoreButton.Visible = isvisible;
            Versus.Visible = isvisible;

                

            
        }



        private void LoadMatchup(MatchupModel m)
            {
                for (int i = 0; i < m.Entries.Count; i++)
                {
                    if (i == 0)
                    {
                        if (m.Entries[0].TeamCompeting != null)
                        {
                            TeamOneLabel.Text = m.Entries[0].TeamCompeting.TeamName;
                            TeamoneScorevalue.Text = m.Entries[0].Score.ToString();

                            TeamTwoName.Text = "<bye>";
                            TeamTwoScoreValue.Text = "0";

                        }
                        else
                        {
                            TeamOneLabel.Text = "not yet set";
                            TeamoneScorevalue.Text = " ";
                        }
                    }

                    if (i == 1)
                    {
                        if (m.Entries[1].TeamCompeting != null)
                        {
                            TeamTwoName.Text = m.Entries[1].TeamCompeting.TeamName;
                            TeamTwoScoreValue.Text = m.Entries[1].Score.ToString();

                        }
                        else
                        {
                            TeamOneLabel.Text = "not yet set";
                            TeamoneScorevalue.Text = " ";
                        }
                    }


                }
            }

            private void MatchUpBox_SelectedIndexChanged(object sender, EventArgs e)
            {
                LoadMatchup(SelectedMatchups.First());
            }

            private void UnplayedonlyCheckBox_CheckedChanged(object sender, EventArgs e)
            {
                LoadMatchups((int)RoundDropDown.SelectedItem);
            }
        }
    }

