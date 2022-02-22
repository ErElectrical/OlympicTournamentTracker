namespace TournamentTrackerUI
{
    partial class EnterTournamentForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.HeaderLabel = new System.Windows.Forms.Label();
            this.TournamentNameLabel = new System.Windows.Forms.Label();
            this.TournamentNameValue = new System.Windows.Forms.TextBox();
            this.EntryFeeLabel = new System.Windows.Forms.Label();
            this.EntryFeeValue = new System.Windows.Forms.TextBox();
            this.SelectTeamLabel = new System.Windows.Forms.Label();
            this.EnterNewTeamLinkLabel = new System.Windows.Forms.LinkLabel();
            this.SelectedTeamDropDownMenu = new System.Windows.Forms.ComboBox();
            this.AddTeamButton = new System.Windows.Forms.Button();
            this.CreatePrizeButton = new System.Windows.Forms.Button();
            this.TeamPlayerLabel = new System.Windows.Forms.Label();
            this.TournammentTeamListBox = new System.Windows.Forms.ListBox();
            this.TeamPlayerLabelForPrize = new System.Windows.Forms.Label();
            this.PrizeBoxList = new System.Windows.Forms.ListBox();
            this.DeleteSelectedPlayerButton = new System.Windows.Forms.Button();
            this.DeleteSelectedPrizeBox = new System.Windows.Forms.Button();
            this.CreateTournamentButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // HeaderLabel
            // 
            this.HeaderLabel.AutoSize = true;
            this.HeaderLabel.Font = new System.Drawing.Font("Cascadia Mono", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HeaderLabel.ForeColor = System.Drawing.Color.RosyBrown;
            this.HeaderLabel.Location = new System.Drawing.Point(12, 9);
            this.HeaderLabel.Name = "HeaderLabel";
            this.HeaderLabel.Size = new System.Drawing.Size(396, 49);
            this.HeaderLabel.TabIndex = 1;
            this.HeaderLabel.Text = "Create Tournament";
            this.HeaderLabel.Click += new System.EventHandler(this.HeaderLabel_Click);
            // 
            // TournamentNameLabel
            // 
            this.TournamentNameLabel.AutoSize = true;
            this.TournamentNameLabel.Font = new System.Drawing.Font("Cascadia Mono", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TournamentNameLabel.ForeColor = System.Drawing.Color.RosyBrown;
            this.TournamentNameLabel.Location = new System.Drawing.Point(14, 72);
            this.TournamentNameLabel.Name = "TournamentNameLabel";
            this.TournamentNameLabel.Size = new System.Drawing.Size(257, 37);
            this.TournamentNameLabel.TabIndex = 2;
            this.TournamentNameLabel.Text = "Tournament Name";
            this.TournamentNameLabel.Click += new System.EventHandler(this.label1_Click);
            // 
            // TournamentNameValue
            // 
            this.TournamentNameValue.Font = new System.Drawing.Font("Cascadia Mono SemiBold", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TournamentNameValue.ForeColor = System.Drawing.Color.RosyBrown;
            this.TournamentNameValue.Location = new System.Drawing.Point(21, 112);
            this.TournamentNameValue.Name = "TournamentNameValue";
            this.TournamentNameValue.Size = new System.Drawing.Size(250, 39);
            this.TournamentNameValue.TabIndex = 3;
            // 
            // EntryFeeLabel
            // 
            this.EntryFeeLabel.AutoSize = true;
            this.EntryFeeLabel.BackColor = System.Drawing.Color.White;
            this.EntryFeeLabel.Font = new System.Drawing.Font("Cascadia Mono SemiBold", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EntryFeeLabel.ForeColor = System.Drawing.Color.RosyBrown;
            this.EntryFeeLabel.Location = new System.Drawing.Point(21, 188);
            this.EntryFeeLabel.Name = "EntryFeeLabel";
            this.EntryFeeLabel.Size = new System.Drawing.Size(161, 37);
            this.EntryFeeLabel.TabIndex = 4;
            this.EntryFeeLabel.Text = "Entry Fee";
            // 
            // EntryFeeValue
            // 
            this.EntryFeeValue.Font = new System.Drawing.Font("Cascadia Mono SemiBold", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EntryFeeValue.ForeColor = System.Drawing.Color.RosyBrown;
            this.EntryFeeValue.Location = new System.Drawing.Point(188, 188);
            this.EntryFeeValue.Name = "EntryFeeValue";
            this.EntryFeeValue.Size = new System.Drawing.Size(95, 39);
            this.EntryFeeValue.TabIndex = 5;
            // 
            // SelectTeamLabel
            // 
            this.SelectTeamLabel.AutoSize = true;
            this.SelectTeamLabel.BackColor = System.Drawing.Color.White;
            this.SelectTeamLabel.Font = new System.Drawing.Font("Cascadia Mono SemiBold", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectTeamLabel.ForeColor = System.Drawing.Color.RosyBrown;
            this.SelectTeamLabel.Location = new System.Drawing.Point(21, 258);
            this.SelectTeamLabel.Name = "SelectTeamLabel";
            this.SelectTeamLabel.Size = new System.Drawing.Size(193, 37);
            this.SelectTeamLabel.TabIndex = 6;
            this.SelectTeamLabel.Text = "Select Team";
            // 
            // EnterNewTeamLinkLabel
            // 
            this.EnterNewTeamLinkLabel.AutoSize = true;
            this.EnterNewTeamLinkLabel.ForeColor = System.Drawing.Color.RosyBrown;
            this.EnterNewTeamLinkLabel.Location = new System.Drawing.Point(231, 274);
            this.EnterNewTeamLinkLabel.Name = "EnterNewTeamLinkLabel";
            this.EnterNewTeamLinkLabel.Size = new System.Drawing.Size(77, 16);
            this.EnterNewTeamLinkLabel.TabIndex = 7;
            this.EnterNewTeamLinkLabel.TabStop = true;
            this.EnterNewTeamLinkLabel.Text = "Create New";
            this.EnterNewTeamLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.EnterNewTeamLinkLabel_LinkClicked);
            // 
            // SelectedTeamDropDownMenu
            // 
            this.SelectedTeamDropDownMenu.Font = new System.Drawing.Font("Cascadia Mono SemiBold", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectedTeamDropDownMenu.ForeColor = System.Drawing.Color.RosyBrown;
            this.SelectedTeamDropDownMenu.FormattingEnabled = true;
            this.SelectedTeamDropDownMenu.Location = new System.Drawing.Point(21, 293);
            this.SelectedTeamDropDownMenu.Name = "SelectedTeamDropDownMenu";
            this.SelectedTeamDropDownMenu.Size = new System.Drawing.Size(284, 43);
            this.SelectedTeamDropDownMenu.TabIndex = 8;
            this.SelectedTeamDropDownMenu.SelectedIndexChanged += new System.EventHandler(this.RoundDropDown_SelectedIndexChanged);
            // 
            // AddTeamButton
            // 
            this.AddTeamButton.Font = new System.Drawing.Font("Cascadia Mono SemiBold", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddTeamButton.ForeColor = System.Drawing.Color.RosyBrown;
            this.AddTeamButton.Location = new System.Drawing.Point(111, 358);
            this.AddTeamButton.Name = "AddTeamButton";
            this.AddTeamButton.Size = new System.Drawing.Size(119, 23);
            this.AddTeamButton.TabIndex = 10;
            this.AddTeamButton.Text = "Add Team";
            this.AddTeamButton.UseVisualStyleBackColor = true;
            this.AddTeamButton.Click += new System.EventHandler(this.AddTeamButton_Click);
            // 
            // CreatePrizeButton
            // 
            this.CreatePrizeButton.Font = new System.Drawing.Font("Cascadia Mono SemiBold", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreatePrizeButton.ForeColor = System.Drawing.Color.RosyBrown;
            this.CreatePrizeButton.Location = new System.Drawing.Point(111, 399);
            this.CreatePrizeButton.Name = "CreatePrizeButton";
            this.CreatePrizeButton.Size = new System.Drawing.Size(119, 23);
            this.CreatePrizeButton.TabIndex = 11;
            this.CreatePrizeButton.Text = "Create Prize";
            this.CreatePrizeButton.UseVisualStyleBackColor = true;
            this.CreatePrizeButton.Click += new System.EventHandler(this.CreatePrizeButton_Click);
            // 
            // TeamPlayerLabel
            // 
            this.TeamPlayerLabel.AutoSize = true;
            this.TeamPlayerLabel.Font = new System.Drawing.Font("Cascadia Mono SemiBold", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TeamPlayerLabel.ForeColor = System.Drawing.Color.RosyBrown;
            this.TeamPlayerLabel.Location = new System.Drawing.Point(407, 72);
            this.TeamPlayerLabel.Name = "TeamPlayerLabel";
            this.TeamPlayerLabel.Size = new System.Drawing.Size(193, 37);
            this.TeamPlayerLabel.TabIndex = 12;
            this.TeamPlayerLabel.Text = "Team/Player";
            this.TeamPlayerLabel.Click += new System.EventHandler(this.TeamPlayerLabel_Click);
            // 
            // TournammentTeamListBox
            // 
            this.TournammentTeamListBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TournammentTeamListBox.ForeColor = System.Drawing.Color.RosyBrown;
            this.TournammentTeamListBox.FormattingEnabled = true;
            this.TournammentTeamListBox.ItemHeight = 16;
            this.TournammentTeamListBox.Location = new System.Drawing.Point(414, 112);
            this.TournammentTeamListBox.Name = "TournammentTeamListBox";
            this.TournammentTeamListBox.Size = new System.Drawing.Size(219, 130);
            this.TournammentTeamListBox.TabIndex = 13;
            this.TournammentTeamListBox.SelectedIndexChanged += new System.EventHandler(this.MatchUpBox_SelectedIndexChanged);
            // 
            // TeamPlayerLabelForPrize
            // 
            this.TeamPlayerLabelForPrize.AutoSize = true;
            this.TeamPlayerLabelForPrize.Font = new System.Drawing.Font("Cascadia Mono SemiBold", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TeamPlayerLabelForPrize.ForeColor = System.Drawing.Color.RosyBrown;
            this.TeamPlayerLabelForPrize.Location = new System.Drawing.Point(407, 258);
            this.TeamPlayerLabelForPrize.Name = "TeamPlayerLabelForPrize";
            this.TeamPlayerLabelForPrize.Size = new System.Drawing.Size(97, 37);
            this.TeamPlayerLabelForPrize.TabIndex = 14;
            this.TeamPlayerLabelForPrize.Text = "Prize";
            this.TeamPlayerLabelForPrize.Click += new System.EventHandler(this.TeamPlayerLabelForPrize_Click);
            // 
            // PrizeBoxList
            // 
            this.PrizeBoxList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PrizeBoxList.ForeColor = System.Drawing.Color.RosyBrown;
            this.PrizeBoxList.FormattingEnabled = true;
            this.PrizeBoxList.ItemHeight = 16;
            this.PrizeBoxList.Location = new System.Drawing.Point(414, 298);
            this.PrizeBoxList.Name = "PrizeBoxList";
            this.PrizeBoxList.Size = new System.Drawing.Size(219, 130);
            this.PrizeBoxList.TabIndex = 15;
            // 
            // DeleteSelectedPlayerButton
            // 
            this.DeleteSelectedPlayerButton.Font = new System.Drawing.Font("Cascadia Mono SemiBold", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteSelectedPlayerButton.ForeColor = System.Drawing.Color.RosyBrown;
            this.DeleteSelectedPlayerButton.Location = new System.Drawing.Point(654, 161);
            this.DeleteSelectedPlayerButton.Name = "DeleteSelectedPlayerButton";
            this.DeleteSelectedPlayerButton.Size = new System.Drawing.Size(81, 52);
            this.DeleteSelectedPlayerButton.TabIndex = 16;
            this.DeleteSelectedPlayerButton.Text = "Delete Selected";
            this.DeleteSelectedPlayerButton.UseVisualStyleBackColor = true;
            this.DeleteSelectedPlayerButton.Click += new System.EventHandler(this.DeleteSelectedPlayerButton_Click);
            // 
            // DeleteSelectedPrizeBox
            // 
            this.DeleteSelectedPrizeBox.Font = new System.Drawing.Font("Cascadia Mono SemiBold", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteSelectedPrizeBox.ForeColor = System.Drawing.Color.RosyBrown;
            this.DeleteSelectedPrizeBox.Location = new System.Drawing.Point(654, 329);
            this.DeleteSelectedPrizeBox.Name = "DeleteSelectedPrizeBox";
            this.DeleteSelectedPrizeBox.Size = new System.Drawing.Size(81, 52);
            this.DeleteSelectedPrizeBox.TabIndex = 17;
            this.DeleteSelectedPrizeBox.Text = "Delete Selected";
            this.DeleteSelectedPrizeBox.UseVisualStyleBackColor = true;
            this.DeleteSelectedPrizeBox.Click += new System.EventHandler(this.DeleteSelectedPrizeBox_Click);
            // 
            // CreateTournamentButton
            // 
            this.CreateTournamentButton.Font = new System.Drawing.Font("Cascadia Mono SemiBold", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreateTournamentButton.ForeColor = System.Drawing.Color.RosyBrown;
            this.CreateTournamentButton.Location = new System.Drawing.Point(272, 450);
            this.CreateTournamentButton.Name = "CreateTournamentButton";
            this.CreateTournamentButton.Size = new System.Drawing.Size(154, 43);
            this.CreateTournamentButton.TabIndex = 18;
            this.CreateTournamentButton.Text = "Create Tournament";
            this.CreateTournamentButton.UseVisualStyleBackColor = true;
            this.CreateTournamentButton.Click += new System.EventHandler(this.CreateTournamentButton_Click);
            // 
            // EnterTournamentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 505);
            this.Controls.Add(this.CreateTournamentButton);
            this.Controls.Add(this.DeleteSelectedPrizeBox);
            this.Controls.Add(this.DeleteSelectedPlayerButton);
            this.Controls.Add(this.PrizeBoxList);
            this.Controls.Add(this.TeamPlayerLabelForPrize);
            this.Controls.Add(this.TournammentTeamListBox);
            this.Controls.Add(this.TeamPlayerLabel);
            this.Controls.Add(this.CreatePrizeButton);
            this.Controls.Add(this.AddTeamButton);
            this.Controls.Add(this.SelectedTeamDropDownMenu);
            this.Controls.Add(this.EnterNewTeamLinkLabel);
            this.Controls.Add(this.SelectTeamLabel);
            this.Controls.Add(this.EntryFeeValue);
            this.Controls.Add(this.EntryFeeLabel);
            this.Controls.Add(this.TournamentNameValue);
            this.Controls.Add(this.TournamentNameLabel);
            this.Controls.Add(this.HeaderLabel);
            this.Name = "EnterTournamentForm";
            this.Text = "EnterTournamentForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label HeaderLabel;
        private System.Windows.Forms.Label TournamentNameLabel;
        private System.Windows.Forms.TextBox TournamentNameValue;
        private System.Windows.Forms.Label EntryFeeLabel;
        private System.Windows.Forms.TextBox EntryFeeValue;
        private System.Windows.Forms.Label SelectTeamLabel;
        private System.Windows.Forms.LinkLabel EnterNewTeamLinkLabel;
        private System.Windows.Forms.ComboBox SelectedTeamDropDownMenu;
        private System.Windows.Forms.Button AddTeamButton;
        private System.Windows.Forms.Button CreatePrizeButton;
        private System.Windows.Forms.Label TeamPlayerLabel;
        private System.Windows.Forms.ListBox TournammentTeamListBox;
        private System.Windows.Forms.Label TeamPlayerLabelForPrize;
        private System.Windows.Forms.ListBox PrizeBoxList;
        private System.Windows.Forms.Button DeleteSelectedPlayerButton;
        private System.Windows.Forms.Button DeleteSelectedPrizeBox;
        private System.Windows.Forms.Button CreateTournamentButton;
    }
}