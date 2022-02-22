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
    public partial class CreateTeam : Form
    {
        ITeamRequester CallingForm;
        private List<PersonModel> availableTeamMembers = new List<PersonModel>();
        private List<PersonModel> SelectedTeamMembers = new List<PersonModel>();
        public CreateTeam(ITeamRequester Caller)
        {
            InitializeComponent();
            CreateSampleData();
            CallingForm = Caller;
            WireUpLists();
        }

        private void LoadData()
        {
            SqlDataConnection sql = new SqlDataConnection();
            availableTeamMembers = sql.GetPerson_All();
        }

        private void CreateSampleData()
        {
            availableTeamMembers.Add(new PersonModel { FirstName = "Tim", LastName = "Southe" });
            SelectedTeamMembers.Add(new PersonModel { FirstName = "John", LastName = "Cena" });
        }
        private void WireUpLists()
        {
            TeamMemberDropDownMenu.DataSource = null;
           TeamMemberDropDownMenu.DataSource= availableTeamMembers;
           TeamMemberDropDownMenu.DisplayMember = "FullName";

            TeamPLayerListBox.DataSource = null;

            TeamPLayerListBox.DataSource = SelectedTeamMembers;
            TeamPLayerListBox.DisplayMember = "FullName";


        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void PhonenumberLabel_Click(object sender, EventArgs e)
        {

        }

        private void SelectTeamMemberLabel_Click(object sender, EventArgs e)
        {

        }

        private void TeamMemberDropDownMenu_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CreateTeamButton_Click(object sender, EventArgs e)
        {
            TeamModel tm = new TeamModel();
            tm.TeamName = TeamNameTextArea.Text;
            tm.Teammembers = SelectedTeamMembers;

            ConnectionConfig.Connections.Add((Idataconnection)tm);

            CallingForm.CompleteTeam(tm);

            this.Close();

            //Todo - if we are not creating the create trem form than do something to tackle
        }

        private bool ValidForm()
        {
            bool Output = true;
            if(FirstNameValue.Text.Length == 0)
            {
                Output = false;
            }
            if(LastNameValue.Text.Length ==0)
            {
                Output = false;
            }
            if(EmailValue.Text.Length == 0)
            {
                Output = false;
            }
            if(CellPhonenumberValue.Text.Length == 0)
            {
                Output = false;
            }
            return Output;
            
        }

        private void FirstNameTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void EmailLabelValue_TextChanged(object sender, EventArgs e)
        {

        }

        private void AddMemberButton_Click(object sender, EventArgs e)
        {
            PersonModel p = (PersonModel)TeamMemberDropDownMenu.SelectedItem;
            if (p != null)
            {


                availableTeamMembers.Remove(p);
                SelectedTeamMembers.Add(p);

                WireUpLists();
            }
            else
            {
                MessageBox.Show("Please choose One Player");

            }

          
        }

        private void DeleteSelectedMemberButton_Click(object sender, EventArgs e)
        {
            PersonModel p = (PersonModel)TeamPLayerListBox.SelectedItem;
            if (p != null)
            {

                SelectedTeamMembers.Remove(p);
                availableTeamMembers.Add(p);

                WireUpLists();
            }
            else
            {
                MessageBox.Show("Please choose One Player");

            }
        }

        private void CreateMemberButton_Click(object sender, EventArgs e)
        {
            if (ValidForm())
            {
                PersonModel Model = new PersonModel();
                Model.FirstName = FirstNameValue.Text;
                Model.LastName = LastNameValue.Text;
                Model.Email = EmailValue.Text;
                Model.CellPhoneNumber = CellPhonenumberValue.Text;

                SqlDataConnection sql = new SqlDataConnection();
                sql.CreatePlayer(Model);

                availableTeamMembers.Add(Model);
                WireUpLists();
                FirstNameValue.Text = "";
                LastNameValue.Text = "";
                EmailValue.Text = "";
                CellPhonenumberValue.Text = "";
            }
            else
            {
                MessageBox.Show("You need To fill again ");
            }
        }
    }
}
