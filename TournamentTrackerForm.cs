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

        private TournamentModel tournaements;
        BindingList<int> rounds = new BindingList<int>();
        BindingList<MatchupModel> SelectedMatchups = new BindingList<MatchupModel>();

        BindingSource roundbinding = new BindingSource();
        BindingSource MatchupBinding = new BindingSource();
        public TournamentTrackerForm(TournamentModel tournamentModel)
        {
            InitializeComponent();
            tournaements = tournamentModel;

            wirecupRoundlists();
            wireupMatchuplists();

            LoadFormData();
            LoadRound();
        }

        private void LoadFormData()
        {
            TournamentName.Text = tournaements.TournamentName;
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

        private void ScoreButton_Click(object sender, EventArgs e)
        {
            MatchupModel m = (MatchupModel)MatchUpBox.SelectedItem;
            double teamonescorevalue = 0;
            double teamtwoscorevalue = 0;
            for (int i = 0; i < m.Entries.Count; i++)
            {
                if (i == 0)
                {
                    if (m.Entries[0].TeamCompeting != null)
                    {
                       
                        bool scorevalid = double.TryParse(TeamoneScorevalue.Text, out teamonescorevalue);
                        if (scorevalid)
                        {
                            m.Entries[0].Score = teamonescorevalue;
                        }
                        else
                        {
                            MessageBox.Show("Please enter a valid score for Team 1");
                            return;
                        }
                    }

                }

                if (i == 1)
                {
                    if (m.Entries[1].TeamCompeting != null)
                    {

                      
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
            if(teamonescorevalue>teamtwoscorevalue)
            {
                //todo team one win
                m.winner = m.Entries[0].TeamCompeting;
            }
            else if(teamtwoscorevalue>teamonescorevalue)
            {
                m.winner = m.Entries[1].TeamCompeting;
            }
            else
            {
                MessageBox.Show("I do not handle tie games");
            }

            foreach(List<MatchupModel> round in tournaements.Rounds)
            {
                foreach(MatchupModel rm in round)
                {
                    foreach(MatchupEntryModel me in rm.Entries)
                    {
                        if(me.ParentMatchup != null)
                        {
                            if (me.ParentMatchup.id == m.id)
                            {
                                me.TeamCompeting = m.winner;
                                SqlDataConnection sqlData = new SqlDataConnection();
                                sqlData.UpdateMatchup(rm);
                            }
                        }
                        
                    }
                }
            }
            LoadMatchups((int)RoundDropDown.SelectedItem);
            SqlDataConnection sql = new SqlDataConnection();
            sql.UpdateMatchup(m);

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

