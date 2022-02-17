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
        List<TournamentModel> tournaments = ConnectionConfig.Connections.GetTournaments_All();
        public TournamentDashBoard()
        {
            InitializeComponent();
        }

        private void CretateTournamentButton_Click(object sender, EventArgs e)
        {

        }
    }
}
