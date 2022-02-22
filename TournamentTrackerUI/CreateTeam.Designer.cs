namespace TournamentTrackerUI
{
    partial class CreateTeam
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateTeam));
            this.HeaderLabel = new System.Windows.Forms.Label();
            this.TeamNameLabel = new System.Windows.Forms.Label();
            this.TeamNameTextArea = new System.Windows.Forms.TextBox();
            this.SelectTeamMemberLabel = new System.Windows.Forms.Label();
            this.TeamMemberDropDownMenu = new System.Windows.Forms.ComboBox();
            this.AddMemberButton = new System.Windows.Forms.Button();
            this.TeamMemberGroupBox = new System.Windows.Forms.GroupBox();
            this.CreateMemberButton = new System.Windows.Forms.Button();
            this.CellPhonenumberValue = new System.Windows.Forms.TextBox();
            this.PhonenumberLabel = new System.Windows.Forms.Label();
            this.EmailValue = new System.Windows.Forms.TextBox();
            this.EmailLabel = new System.Windows.Forms.Label();
            this.LastNameValue = new System.Windows.Forms.TextBox();
            this.LastNameLabel = new System.Windows.Forms.Label();
            this.FirstNameValue = new System.Windows.Forms.TextBox();
            this.FirstNameLabel = new System.Windows.Forms.Label();
            this.TeamPLayerListBox = new System.Windows.Forms.ListBox();
            this.DeleteSelectedMemberButton = new System.Windows.Forms.Button();
            this.CreateTeamButton = new System.Windows.Forms.Button();
            this.TeamMemberGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // HeaderLabel
            // 
            this.HeaderLabel.AutoSize = true;
            this.HeaderLabel.Font = new System.Drawing.Font("Cascadia Mono", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HeaderLabel.ForeColor = System.Drawing.Color.RosyBrown;
            this.HeaderLabel.Location = new System.Drawing.Point(1, 9);
            this.HeaderLabel.Name = "HeaderLabel";
            this.HeaderLabel.Size = new System.Drawing.Size(264, 49);
            this.HeaderLabel.TabIndex = 2;
            this.HeaderLabel.Text = "Create Team";
            // 
            // TeamNameLabel
            // 
            this.TeamNameLabel.AutoSize = true;
            this.TeamNameLabel.Font = new System.Drawing.Font("Cascadia Mono", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TeamNameLabel.ForeColor = System.Drawing.Color.RosyBrown;
            this.TeamNameLabel.Location = new System.Drawing.Point(8, 81);
            this.TeamNameLabel.Name = "TeamNameLabel";
            this.TeamNameLabel.Size = new System.Drawing.Size(161, 37);
            this.TeamNameLabel.TabIndex = 3;
            this.TeamNameLabel.Text = "Team Name";
            // 
            // TeamNameTextArea
            // 
            this.TeamNameTextArea.Font = new System.Drawing.Font("Cascadia Mono SemiBold", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TeamNameTextArea.ForeColor = System.Drawing.Color.RosyBrown;
            this.TeamNameTextArea.Location = new System.Drawing.Point(10, 121);
            this.TeamNameTextArea.Name = "TeamNameTextArea";
            this.TeamNameTextArea.Size = new System.Drawing.Size(250, 39);
            this.TeamNameTextArea.TabIndex = 4;
            // 
            // SelectTeamMemberLabel
            // 
            this.SelectTeamMemberLabel.AutoSize = true;
            this.SelectTeamMemberLabel.BackColor = System.Drawing.Color.White;
            this.SelectTeamMemberLabel.Font = new System.Drawing.Font("Cascadia Mono SemiBold", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectTeamMemberLabel.ForeColor = System.Drawing.Color.RosyBrown;
            this.SelectTeamMemberLabel.Location = new System.Drawing.Point(3, 200);
            this.SelectTeamMemberLabel.Name = "SelectTeamMemberLabel";
            this.SelectTeamMemberLabel.Size = new System.Drawing.Size(305, 37);
            this.SelectTeamMemberLabel.TabIndex = 7;
            this.SelectTeamMemberLabel.Text = "Select Team Member";
            this.SelectTeamMemberLabel.Click += new System.EventHandler(this.SelectTeamMemberLabel_Click);
            // 
            // TeamMemberDropDownMenu
            // 
            this.TeamMemberDropDownMenu.Font = new System.Drawing.Font("Cascadia Mono SemiBold", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TeamMemberDropDownMenu.ForeColor = System.Drawing.Color.RosyBrown;
            this.TeamMemberDropDownMenu.FormattingEnabled = true;
            this.TeamMemberDropDownMenu.Location = new System.Drawing.Point(10, 240);
            this.TeamMemberDropDownMenu.Name = "TeamMemberDropDownMenu";
            this.TeamMemberDropDownMenu.Size = new System.Drawing.Size(284, 43);
            this.TeamMemberDropDownMenu.TabIndex = 9;
            this.TeamMemberDropDownMenu.SelectedIndexChanged += new System.EventHandler(this.TeamMemberDropDownMenu_SelectedIndexChanged);
            // 
            // AddMemberButton
            // 
            this.AddMemberButton.Font = new System.Drawing.Font("Cascadia Mono SemiBold", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddMemberButton.ForeColor = System.Drawing.Color.RosyBrown;
            this.AddMemberButton.Location = new System.Drawing.Point(77, 309);
            this.AddMemberButton.Name = "AddMemberButton";
            this.AddMemberButton.Size = new System.Drawing.Size(119, 23);
            this.AddMemberButton.TabIndex = 11;
            this.AddMemberButton.Text = "Add Member";
            this.AddMemberButton.UseVisualStyleBackColor = true;
            this.AddMemberButton.Click += new System.EventHandler(this.AddMemberButton_Click);
            // 
            // TeamMemberGroupBox
            // 
            this.TeamMemberGroupBox.Controls.Add(this.CreateMemberButton);
            this.TeamMemberGroupBox.Controls.Add(this.CellPhonenumberValue);
            this.TeamMemberGroupBox.Controls.Add(this.PhonenumberLabel);
            this.TeamMemberGroupBox.Controls.Add(this.EmailValue);
            this.TeamMemberGroupBox.Controls.Add(this.EmailLabel);
            this.TeamMemberGroupBox.Controls.Add(this.LastNameValue);
            this.TeamMemberGroupBox.Controls.Add(this.LastNameLabel);
            this.TeamMemberGroupBox.Controls.Add(this.FirstNameValue);
            this.TeamMemberGroupBox.Controls.Add(this.FirstNameLabel);
            this.TeamMemberGroupBox.Font = new System.Drawing.Font("Cascadia Mono SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TeamMemberGroupBox.ForeColor = System.Drawing.Color.Salmon;
            this.TeamMemberGroupBox.Location = new System.Drawing.Point(10, 353);
            this.TeamMemberGroupBox.Name = "TeamMemberGroupBox";
            this.TeamMemberGroupBox.Size = new System.Drawing.Size(343, 317);
            this.TeamMemberGroupBox.TabIndex = 12;
            this.TeamMemberGroupBox.TabStop = false;
            this.TeamMemberGroupBox.Text = "Add New Member";
            // 
            // CreateMemberButton
            // 
            this.CreateMemberButton.Font = new System.Drawing.Font("Cascadia Mono SemiBold", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreateMemberButton.ForeColor = System.Drawing.Color.RosyBrown;
            this.CreateMemberButton.Location = new System.Drawing.Point(102, 244);
            this.CreateMemberButton.Name = "CreateMemberButton";
            this.CreateMemberButton.Size = new System.Drawing.Size(119, 51);
            this.CreateMemberButton.TabIndex = 13;
            this.CreateMemberButton.Text = "Create Member";
            this.CreateMemberButton.UseVisualStyleBackColor = true;
            this.CreateMemberButton.Click += new System.EventHandler(this.CreateMemberButton_Click);
            // 
            // CellPhonenumberValue
            // 
            this.CellPhonenumberValue.Font = new System.Drawing.Font("Cascadia Mono SemiBold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CellPhonenumberValue.ForeColor = System.Drawing.Color.RosyBrown;
            this.CellPhonenumberValue.Location = new System.Drawing.Point(172, 194);
            this.CellPhonenumberValue.Name = "CellPhonenumberValue";
            this.CellPhonenumberValue.Size = new System.Drawing.Size(165, 27);
            this.CellPhonenumberValue.TabIndex = 19;
            // 
            // PhonenumberLabel
            // 
            this.PhonenumberLabel.AutoSize = true;
            this.PhonenumberLabel.ForeColor = System.Drawing.Color.RosyBrown;
            this.PhonenumberLabel.Location = new System.Drawing.Point(6, 194);
            this.PhonenumberLabel.Name = "PhonenumberLabel";
            this.PhonenumberLabel.Size = new System.Drawing.Size(156, 27);
            this.PhonenumberLabel.TabIndex = 18;
            this.PhonenumberLabel.Text = "Phone Number";
            this.PhonenumberLabel.Click += new System.EventHandler(this.PhonenumberLabel_Click);
            // 
            // EmailValue
            // 
            this.EmailValue.Font = new System.Drawing.Font("Cascadia Mono SemiBold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EmailValue.ForeColor = System.Drawing.Color.RosyBrown;
            this.EmailValue.Location = new System.Drawing.Point(155, 138);
            this.EmailValue.Name = "EmailValue";
            this.EmailValue.Size = new System.Drawing.Size(165, 27);
            this.EmailValue.TabIndex = 17;
            this.EmailValue.TextChanged += new System.EventHandler(this.EmailLabelValue_TextChanged);
            // 
            // EmailLabel
            // 
            this.EmailLabel.AutoSize = true;
            this.EmailLabel.ForeColor = System.Drawing.Color.RosyBrown;
            this.EmailLabel.Location = new System.Drawing.Point(17, 138);
            this.EmailLabel.Name = "EmailLabel";
            this.EmailLabel.Size = new System.Drawing.Size(72, 27);
            this.EmailLabel.TabIndex = 16;
            this.EmailLabel.Text = "Email";
            // 
            // LastNameValue
            // 
            this.LastNameValue.Font = new System.Drawing.Font("Cascadia Mono SemiBold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LastNameValue.ForeColor = System.Drawing.Color.RosyBrown;
            this.LastNameValue.Location = new System.Drawing.Point(155, 87);
            this.LastNameValue.Name = "LastNameValue";
            this.LastNameValue.Size = new System.Drawing.Size(165, 27);
            this.LastNameValue.TabIndex = 15;
            // 
            // LastNameLabel
            // 
            this.LastNameLabel.AutoSize = true;
            this.LastNameLabel.ForeColor = System.Drawing.Color.RosyBrown;
            this.LastNameLabel.Location = new System.Drawing.Point(17, 86);
            this.LastNameLabel.Name = "LastNameLabel";
            this.LastNameLabel.Size = new System.Drawing.Size(120, 27);
            this.LastNameLabel.TabIndex = 14;
            this.LastNameLabel.Text = "Last Name";
            this.LastNameLabel.Click += new System.EventHandler(this.label1_Click);
            // 
            // FirstNameValue
            // 
            this.FirstNameValue.Font = new System.Drawing.Font("Cascadia Mono SemiBold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FirstNameValue.ForeColor = System.Drawing.Color.RosyBrown;
            this.FirstNameValue.Location = new System.Drawing.Point(155, 43);
            this.FirstNameValue.Name = "FirstNameValue";
            this.FirstNameValue.Size = new System.Drawing.Size(165, 27);
            this.FirstNameValue.TabIndex = 13;
            this.FirstNameValue.TextChanged += new System.EventHandler(this.FirstNameTextBox_TextChanged);
            // 
            // FirstNameLabel
            // 
            this.FirstNameLabel.AutoSize = true;
            this.FirstNameLabel.ForeColor = System.Drawing.Color.RosyBrown;
            this.FirstNameLabel.Location = new System.Drawing.Point(17, 43);
            this.FirstNameLabel.Name = "FirstNameLabel";
            this.FirstNameLabel.Size = new System.Drawing.Size(132, 27);
            this.FirstNameLabel.TabIndex = 0;
            this.FirstNameLabel.Text = "First Name";
            // 
            // TeamPLayerListBox
            // 
            this.TeamPLayerListBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TeamPLayerListBox.Font = new System.Drawing.Font("Cascadia Mono SemiBold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TeamPLayerListBox.ForeColor = System.Drawing.Color.RosyBrown;
            this.TeamPLayerListBox.FormattingEnabled = true;
            this.TeamPLayerListBox.ItemHeight = 30;
            this.TeamPLayerListBox.Location = new System.Drawing.Point(436, 121);
            this.TeamPLayerListBox.Name = "TeamPLayerListBox";
            this.TeamPLayerListBox.Size = new System.Drawing.Size(572, 482);
            this.TeamPLayerListBox.TabIndex = 14;
            // 
            // DeleteSelectedMemberButton
            // 
            this.DeleteSelectedMemberButton.Font = new System.Drawing.Font("Cascadia Mono SemiBold", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteSelectedMemberButton.ForeColor = System.Drawing.Color.RosyBrown;
            this.DeleteSelectedMemberButton.Location = new System.Drawing.Point(1049, 309);
            this.DeleteSelectedMemberButton.Name = "DeleteSelectedMemberButton";
            this.DeleteSelectedMemberButton.Size = new System.Drawing.Size(81, 52);
            this.DeleteSelectedMemberButton.TabIndex = 17;
            this.DeleteSelectedMemberButton.Text = "Delete Selected";
            this.DeleteSelectedMemberButton.UseVisualStyleBackColor = true;
            this.DeleteSelectedMemberButton.Click += new System.EventHandler(this.DeleteSelectedMemberButton_Click);
            // 
            // CreateTeamButton
            // 
            this.CreateTeamButton.Font = new System.Drawing.Font("Cascadia Mono SemiBold", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreateTeamButton.ForeColor = System.Drawing.Color.RosyBrown;
            this.CreateTeamButton.Location = new System.Drawing.Point(640, 636);
            this.CreateTeamButton.Name = "CreateTeamButton";
            this.CreateTeamButton.Size = new System.Drawing.Size(154, 43);
            this.CreateTeamButton.TabIndex = 19;
            this.CreateTeamButton.Text = "Create Team";
            this.CreateTeamButton.UseVisualStyleBackColor = true;
            this.CreateTeamButton.Click += new System.EventHandler(this.CreateTeamButton_Click);
            // 
            // CreateTeam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(22F, 49F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1924, 1055);
            this.Controls.Add(this.CreateTeamButton);
            this.Controls.Add(this.DeleteSelectedMemberButton);
            this.Controls.Add(this.TeamPLayerListBox);
            this.Controls.Add(this.TeamMemberGroupBox);
            this.Controls.Add(this.AddMemberButton);
            this.Controls.Add(this.TeamMemberDropDownMenu);
            this.Controls.Add(this.SelectTeamMemberLabel);
            this.Controls.Add(this.TeamNameTextArea);
            this.Controls.Add(this.TeamNameLabel);
            this.Controls.Add(this.HeaderLabel);
            this.Font = new System.Drawing.Font("Cascadia Mono SemiBold", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.RosyBrown;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            this.Name = "CreateTeam";
            this.Text = "CreateTeam";
            this.TeamMemberGroupBox.ResumeLayout(false);
            this.TeamMemberGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label HeaderLabel;
        private System.Windows.Forms.Label TeamNameLabel;
        private System.Windows.Forms.TextBox TeamNameTextArea;
        private System.Windows.Forms.Label SelectTeamMemberLabel;
        private System.Windows.Forms.ComboBox TeamMemberDropDownMenu;
        private System.Windows.Forms.Button AddMemberButton;
        private System.Windows.Forms.GroupBox TeamMemberGroupBox;
        private System.Windows.Forms.Label LastNameLabel;
        private System.Windows.Forms.TextBox FirstNameValue;
        private System.Windows.Forms.Label FirstNameLabel;
        private System.Windows.Forms.TextBox LastNameValue;
        private System.Windows.Forms.TextBox CellPhonenumberValue;
        private System.Windows.Forms.Label PhonenumberLabel;
        private System.Windows.Forms.TextBox EmailValue;
        private System.Windows.Forms.Label EmailLabel;
        private System.Windows.Forms.Button CreateMemberButton;
        private System.Windows.Forms.ListBox TeamPLayerListBox;
        private System.Windows.Forms.Button DeleteSelectedMemberButton;
        private System.Windows.Forms.Button CreateTeamButton;
    }
}