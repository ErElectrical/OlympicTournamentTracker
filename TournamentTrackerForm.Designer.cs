namespace TournamentTrackerUI
{
    partial class TournamentTrackerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TournamentTrackerForm));
            this.HeaderLabel = new System.Windows.Forms.Label();
            this.TournamentName = new System.Windows.Forms.Label();
            this.RoundLabel = new System.Windows.Forms.Label();
            this.RoundDropDown = new System.Windows.Forms.ComboBox();
            this.UnplayedonlyCheckBox = new System.Windows.Forms.CheckBox();
            this.MatchUpBox = new System.Windows.Forms.ListBox();
            this.TeamOneLabel = new System.Windows.Forms.Label();
            this.TeamOneScore = new System.Windows.Forms.Label();
            this.TeamoneScorevalue = new System.Windows.Forms.TextBox();
            this.TeamTwoName = new System.Windows.Forms.Label();
            this.TeamTwoScoreValue = new System.Windows.Forms.Label();
            this.TeamTwoScore = new System.Windows.Forms.TextBox();
            this.Versus = new System.Windows.Forms.Label();
            this.ScoreButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // HeaderLabel
            // 
            this.HeaderLabel.AutoSize = true;
            this.HeaderLabel.Font = new System.Drawing.Font("Cascadia Mono", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HeaderLabel.ForeColor = System.Drawing.Color.RosyBrown;
            this.HeaderLabel.Location = new System.Drawing.Point(66, 36);
            this.HeaderLabel.Name = "HeaderLabel";
            this.HeaderLabel.Size = new System.Drawing.Size(286, 49);
            this.HeaderLabel.TabIndex = 0;
            this.HeaderLabel.Text = "Tournament :";
            this.HeaderLabel.Click += new System.EventHandler(this.HeaderLabel_Click);
            // 
            // TournamentName
            // 
            this.TournamentName.AutoSize = true;
            this.TournamentName.Font = new System.Drawing.Font("Cascadia Mono", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TournamentName.ForeColor = System.Drawing.Color.RosyBrown;
            this.TournamentName.Location = new System.Drawing.Point(358, 36);
            this.TournamentName.Name = "TournamentName";
            this.TournamentName.Size = new System.Drawing.Size(154, 49);
            this.TournamentName.TabIndex = 1;
            this.TournamentName.Text = "<None>";
            this.TournamentName.Click += new System.EventHandler(this.label1_Click);
            // 
            // RoundLabel
            // 
            this.RoundLabel.AutoSize = true;
            this.RoundLabel.Font = new System.Drawing.Font("Cascadia Mono", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RoundLabel.ForeColor = System.Drawing.Color.RosyBrown;
            this.RoundLabel.Location = new System.Drawing.Point(68, 115);
            this.RoundLabel.Name = "RoundLabel";
            this.RoundLabel.Size = new System.Drawing.Size(120, 45);
            this.RoundLabel.TabIndex = 2;
            this.RoundLabel.Text = "Round";
            this.RoundLabel.Click += new System.EventHandler(this.RoundLabel_Click);
            // 
            // RoundDropDown
            // 
            this.RoundDropDown.FormattingEnabled = true;
            this.RoundDropDown.Location = new System.Drawing.Point(228, 115);
            this.RoundDropDown.Name = "RoundDropDown";
            this.RoundDropDown.Size = new System.Drawing.Size(284, 43);
            this.RoundDropDown.TabIndex = 3;
            // 
            // UnplayedonlyCheckBox
            // 
            this.UnplayedonlyCheckBox.AutoSize = true;
            this.UnplayedonlyCheckBox.ForeColor = System.Drawing.Color.RosyBrown;
            this.UnplayedonlyCheckBox.Location = new System.Drawing.Point(228, 164);
            this.UnplayedonlyCheckBox.Name = "UnplayedonlyCheckBox";
            this.UnplayedonlyCheckBox.Size = new System.Drawing.Size(231, 41);
            this.UnplayedonlyCheckBox.TabIndex = 4;
            this.UnplayedonlyCheckBox.Text = "UnplayedOnly";
            this.UnplayedonlyCheckBox.UseVisualStyleBackColor = true;
            // 
            // MatchUpBox
            // 
            this.MatchUpBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MatchUpBox.ForeColor = System.Drawing.Color.RosyBrown;
            this.MatchUpBox.FormattingEnabled = true;
            this.MatchUpBox.ItemHeight = 35;
            this.MatchUpBox.Location = new System.Drawing.Point(76, 267);
            this.MatchUpBox.Name = "MatchUpBox";
            this.MatchUpBox.Size = new System.Drawing.Size(436, 212);
            this.MatchUpBox.TabIndex = 5;
            // 
            // TeamOneLabel
            // 
            this.TeamOneLabel.AutoSize = true;
            this.TeamOneLabel.ForeColor = System.Drawing.Color.RosyBrown;
            this.TeamOneLabel.Location = new System.Drawing.Point(605, 267);
            this.TeamOneLabel.Name = "TeamOneLabel";
            this.TeamOneLabel.Size = new System.Drawing.Size(177, 37);
            this.TeamOneLabel.TabIndex = 6;
            this.TeamOneLabel.Text = "<Team one>";
            this.TeamOneLabel.Click += new System.EventHandler(this.TeamOneLabel_Click);
            // 
            // TeamOneScore
            // 
            this.TeamOneScore.AutoSize = true;
            this.TeamOneScore.ForeColor = System.Drawing.Color.RosyBrown;
            this.TeamOneScore.Location = new System.Drawing.Point(605, 322);
            this.TeamOneScore.Name = "TeamOneScore";
            this.TeamOneScore.Size = new System.Drawing.Size(97, 37);
            this.TeamOneScore.TabIndex = 7;
            this.TeamOneScore.Text = "Score";
            this.TeamOneScore.Click += new System.EventHandler(this.TeamTwoTable_Click);
            // 
            // TeamoneScorevalue
            // 
            this.TeamoneScorevalue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TeamoneScorevalue.Location = new System.Drawing.Point(708, 322);
            this.TeamoneScorevalue.Name = "TeamoneScorevalue";
            this.TeamoneScorevalue.Size = new System.Drawing.Size(100, 39);
            this.TeamoneScorevalue.TabIndex = 8;
            // 
            // TeamTwoName
            // 
            this.TeamTwoName.AutoSize = true;
            this.TeamTwoName.ForeColor = System.Drawing.Color.RosyBrown;
            this.TeamTwoName.Location = new System.Drawing.Point(605, 389);
            this.TeamTwoName.Name = "TeamTwoName";
            this.TeamTwoName.Size = new System.Drawing.Size(177, 37);
            this.TeamTwoName.TabIndex = 9;
            this.TeamTwoName.Text = "<Team Two>";
            // 
            // TeamTwoScoreValue
            // 
            this.TeamTwoScoreValue.AutoSize = true;
            this.TeamTwoScoreValue.ForeColor = System.Drawing.Color.RosyBrown;
            this.TeamTwoScoreValue.Location = new System.Drawing.Point(605, 442);
            this.TeamTwoScoreValue.Name = "TeamTwoScoreValue";
            this.TeamTwoScoreValue.Size = new System.Drawing.Size(97, 37);
            this.TeamTwoScoreValue.TabIndex = 10;
            this.TeamTwoScoreValue.Text = "Score";
            this.TeamTwoScoreValue.Click += new System.EventHandler(this.label2_Click);
            // 
            // TeamTwoScore
            // 
            this.TeamTwoScore.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TeamTwoScore.Location = new System.Drawing.Point(708, 442);
            this.TeamTwoScore.Name = "TeamTwoScore";
            this.TeamTwoScore.Size = new System.Drawing.Size(100, 39);
            this.TeamTwoScore.TabIndex = 11;
            // 
            // Versus
            // 
            this.Versus.AutoSize = true;
            this.Versus.Font = new System.Drawing.Font("Cascadia Mono SemiBold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Versus.ForeColor = System.Drawing.Color.RosyBrown;
            this.Versus.Location = new System.Drawing.Point(682, 367);
            this.Versus.Name = "Versus";
            this.Versus.Size = new System.Drawing.Size(30, 22);
            this.Versus.TabIndex = 12;
            this.Versus.Text = "vs";
            // 
            // ScoreButton
            // 
            this.ScoreButton.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.ScoreButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gold;
            this.ScoreButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.ScoreButton.Font = new System.Drawing.Font("Cascadia Mono", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ScoreButton.ForeColor = System.Drawing.Color.RosyBrown;
            this.ScoreButton.Location = new System.Drawing.Point(907, 356);
            this.ScoreButton.Name = "ScoreButton";
            this.ScoreButton.Size = new System.Drawing.Size(130, 45);
            this.ScoreButton.TabIndex = 13;
            this.ScoreButton.Text = "Score";
            this.ScoreButton.UseVisualStyleBackColor = true;
            this.ScoreButton.Click += new System.EventHandler(this.ScoreButton_Click);
            // 
            // TournamentTrackerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 35F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1600, 984);
            this.Controls.Add(this.ScoreButton);
            this.Controls.Add(this.Versus);
            this.Controls.Add(this.TeamTwoScore);
            this.Controls.Add(this.TeamTwoScoreValue);
            this.Controls.Add(this.TeamTwoName);
            this.Controls.Add(this.TeamoneScorevalue);
            this.Controls.Add(this.TeamOneScore);
            this.Controls.Add(this.TeamOneLabel);
            this.Controls.Add(this.MatchUpBox);
            this.Controls.Add(this.UnplayedonlyCheckBox);
            this.Controls.Add(this.RoundDropDown);
            this.Controls.Add(this.RoundLabel);
            this.Controls.Add(this.TournamentName);
            this.Controls.Add(this.HeaderLabel);
            this.Font = new System.Drawing.Font("Cascadia Mono", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.RosyBrown;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "TournamentTrackerForm";
            this.Text = "Tournament  Viewer";
            this.Load += new System.EventHandler(this.TournamentTrackerForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label HeaderLabel;
        private System.Windows.Forms.Label TournamentName;
        private System.Windows.Forms.Label RoundLabel;
        private System.Windows.Forms.ComboBox RoundDropDown;
        private System.Windows.Forms.CheckBox UnplayedonlyCheckBox;
        private System.Windows.Forms.ListBox MatchUpBox;
        private System.Windows.Forms.Label TeamOneLabel;
        private System.Windows.Forms.Label TeamOneScore;
        private System.Windows.Forms.TextBox TeamoneScorevalue;
        private System.Windows.Forms.Label TeamTwoName;
        private System.Windows.Forms.Label TeamTwoScoreValue;
        private System.Windows.Forms.TextBox TeamTwoScore;
        private System.Windows.Forms.Label Versus;
        private System.Windows.Forms.Button ScoreButton;
    }
}

