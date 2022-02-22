namespace TournamentTrackerUI
{
    partial class TournamentDashBoard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TournamentDashBoard));
            this.HeaderLabel = new System.Windows.Forms.Label();
            this.LoadExistingTournamentLabel = new System.Windows.Forms.Label();
            this.LoadExistingTournamentDropDownMenu = new System.Windows.Forms.ComboBox();
            this.LoadExistingTournamentButton = new System.Windows.Forms.Button();
            this.CretateTournamentButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // HeaderLabel
            // 
            this.HeaderLabel.AutoSize = true;
            this.HeaderLabel.Font = new System.Drawing.Font("Cascadia Mono", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HeaderLabel.ForeColor = System.Drawing.Color.RosyBrown;
            this.HeaderLabel.Location = new System.Drawing.Point(479, 45);
            this.HeaderLabel.Name = "HeaderLabel";
            this.HeaderLabel.Size = new System.Drawing.Size(462, 49);
            this.HeaderLabel.TabIndex = 4;
            this.HeaderLabel.Text = "Tournament DashBoard";
            // 
            // LoadExistingTournamentLabel
            // 
            this.LoadExistingTournamentLabel.AutoSize = true;
            this.LoadExistingTournamentLabel.BackColor = System.Drawing.Color.White;
            this.LoadExistingTournamentLabel.Font = new System.Drawing.Font("Cascadia Mono SemiBold", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoadExistingTournamentLabel.ForeColor = System.Drawing.Color.RosyBrown;
            this.LoadExistingTournamentLabel.Location = new System.Drawing.Point(510, 142);
            this.LoadExistingTournamentLabel.Name = "LoadExistingTournamentLabel";
            this.LoadExistingTournamentLabel.Size = new System.Drawing.Size(401, 37);
            this.LoadExistingTournamentLabel.TabIndex = 8;
            this.LoadExistingTournamentLabel.Text = "Load Existing Tournament";
            // 
            // LoadExistingTournamentDropDownMenu
            // 
            this.LoadExistingTournamentDropDownMenu.Font = new System.Drawing.Font("Cascadia Mono SemiBold", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoadExistingTournamentDropDownMenu.ForeColor = System.Drawing.Color.RosyBrown;
            this.LoadExistingTournamentDropDownMenu.FormattingEnabled = true;
            this.LoadExistingTournamentDropDownMenu.Location = new System.Drawing.Point(513, 182);
            this.LoadExistingTournamentDropDownMenu.Name = "LoadExistingTournamentDropDownMenu";
            this.LoadExistingTournamentDropDownMenu.Size = new System.Drawing.Size(394, 43);
            this.LoadExistingTournamentDropDownMenu.TabIndex = 10;
            // 
            // LoadExistingTournamentButton
            // 
            this.LoadExistingTournamentButton.Font = new System.Drawing.Font("Cascadia Mono SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoadExistingTournamentButton.ForeColor = System.Drawing.Color.RosyBrown;
            this.LoadExistingTournamentButton.Location = new System.Drawing.Point(637, 249);
            this.LoadExistingTournamentButton.Name = "LoadExistingTournamentButton";
            this.LoadExistingTournamentButton.Size = new System.Drawing.Size(146, 68);
            this.LoadExistingTournamentButton.TabIndex = 12;
            this.LoadExistingTournamentButton.Text = "Load Tournament";
            this.LoadExistingTournamentButton.UseVisualStyleBackColor = true;
            this.LoadExistingTournamentButton.Click += new System.EventHandler(this.LoadExistingTournamentButton_Click);
            // 
            // CretateTournamentButton
            // 
            this.CretateTournamentButton.Font = new System.Drawing.Font("Cascadia Mono SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CretateTournamentButton.ForeColor = System.Drawing.Color.RosyBrown;
            this.CretateTournamentButton.Location = new System.Drawing.Point(555, 383);
            this.CretateTournamentButton.Name = "CretateTournamentButton";
            this.CretateTournamentButton.Size = new System.Drawing.Size(311, 68);
            this.CretateTournamentButton.TabIndex = 13;
            this.CretateTournamentButton.Text = "Create Tournament";
            this.CretateTournamentButton.UseVisualStyleBackColor = true;
            this.CretateTournamentButton.Click += new System.EventHandler(this.CretateTournamentButton_Click);
            // 
            // TournamentDashBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(22F, 49F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1924, 1055);
            this.Controls.Add(this.CretateTournamentButton);
            this.Controls.Add(this.LoadExistingTournamentButton);
            this.Controls.Add(this.LoadExistingTournamentDropDownMenu);
            this.Controls.Add(this.LoadExistingTournamentLabel);
            this.Controls.Add(this.HeaderLabel);
            this.Font = new System.Drawing.Font("Cascadia Mono SemiBold", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            this.Name = "TournamentDashBoard";
            this.Text = "TournamentDashBoard";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label HeaderLabel;
        private System.Windows.Forms.Label LoadExistingTournamentLabel;
        private System.Windows.Forms.ComboBox LoadExistingTournamentDropDownMenu;
        private System.Windows.Forms.Button LoadExistingTournamentButton;
        private System.Windows.Forms.Button CretateTournamentButton;
    }
}