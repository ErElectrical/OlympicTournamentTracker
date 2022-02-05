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
            this.TournamentNameTextArea = new System.Windows.Forms.TextBox();
            this.EntryFeeLabel = new System.Windows.Forms.Label();
            this.EntryFeeValue = new System.Windows.Forms.TextBox();
            this.SelectTeamLabel = new System.Windows.Forms.Label();
            this.EnterNewTeamLinkLabel = new System.Windows.Forms.LinkLabel();
            this.TeamDropDownMenu = new System.Windows.Forms.ComboBox();
            this.AddTeamButton = new System.Windows.Forms.Button();
            this.CreatePrizeButton = new System.Windows.Forms.Button();
            this.TeamPlayerLabel = new System.Windows.Forms.Label();
            this.TournammentPLayerListBox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
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
            // TournamentNameTextArea
            // 
            this.TournamentNameTextArea.Font = new System.Drawing.Font("Cascadia Mono SemiBold", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TournamentNameTextArea.ForeColor = System.Drawing.Color.RosyBrown;
            this.TournamentNameTextArea.Location = new System.Drawing.Point(21, 112);
            this.TournamentNameTextArea.Name = "TournamentNameTextArea";
            this.TournamentNameTextArea.Size = new System.Drawing.Size(250, 39);
            this.TournamentNameTextArea.TabIndex = 3;
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
            // 
            // TeamDropDownMenu
            // 
            this.TeamDropDownMenu.Font = new System.Drawing.Font("Cascadia Mono SemiBold", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TeamDropDownMenu.ForeColor = System.Drawing.Color.RosyBrown;
            this.TeamDropDownMenu.FormattingEnabled = true;
            this.TeamDropDownMenu.Location = new System.Drawing.Point(21, 293);
            this.TeamDropDownMenu.Name = "TeamDropDownMenu";
            this.TeamDropDownMenu.Size = new System.Drawing.Size(284, 43);
            this.TeamDropDownMenu.TabIndex = 8;
            this.TeamDropDownMenu.SelectedIndexChanged += new System.EventHandler(this.RoundDropDown_SelectedIndexChanged);
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
            // 
            // TournammentPLayerListBox
            // 
            this.TournammentPLayerListBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TournammentPLayerListBox.ForeColor = System.Drawing.Color.RosyBrown;
            this.TournammentPLayerListBox.FormattingEnabled = true;
            this.TournammentPLayerListBox.ItemHeight = 16;
            this.TournammentPLayerListBox.Location = new System.Drawing.Point(414, 112);
            this.TournammentPLayerListBox.Name = "TournammentPLayerListBox";
            this.TournammentPLayerListBox.Size = new System.Drawing.Size(219, 130);
            this.TournammentPLayerListBox.TabIndex = 13;
            this.TournammentPLayerListBox.SelectedIndexChanged += new System.EventHandler(this.MatchUpBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cascadia Mono SemiBold", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.RosyBrown;
            this.label1.Location = new System.Drawing.Point(407, 258);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(193, 37);
            this.label1.TabIndex = 14;
            this.label1.Text = "Team/Player";
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
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TournammentPLayerListBox);
            this.Controls.Add(this.TeamPlayerLabel);
            this.Controls.Add(this.CreatePrizeButton);
            this.Controls.Add(this.AddTeamButton);
            this.Controls.Add(this.TeamDropDownMenu);
            this.Controls.Add(this.EnterNewTeamLinkLabel);
            this.Controls.Add(this.SelectTeamLabel);
            this.Controls.Add(this.EntryFeeValue);
            this.Controls.Add(this.EntryFeeLabel);
            this.Controls.Add(this.TournamentNameTextArea);
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
        private System.Windows.Forms.TextBox TournamentNameTextArea;
        private System.Windows.Forms.Label EntryFeeLabel;
        private System.Windows.Forms.TextBox EntryFeeValue;
        private System.Windows.Forms.Label SelectTeamLabel;
        private System.Windows.Forms.LinkLabel EnterNewTeamLinkLabel;
        private System.Windows.Forms.ComboBox TeamDropDownMenu;
        private System.Windows.Forms.Button AddTeamButton;
        private System.Windows.Forms.Button CreatePrizeButton;
        private System.Windows.Forms.Label TeamPlayerLabel;
        private System.Windows.Forms.ListBox TournammentPLayerListBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox PrizeBoxList;
        private System.Windows.Forms.Button DeleteSelectedPlayerButton;
        private System.Windows.Forms.Button DeleteSelectedPrizeBox;
        private System.Windows.Forms.Button CreateTournamentButton;
    }
}