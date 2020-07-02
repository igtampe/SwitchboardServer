namespace SwitchboardServer {
    partial class ServerSettingsForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ServerSettingsForm));
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
            "Igtampe",
            "4",
            "1:00 AM 12/25/2019"}, -1);
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem(new string[] {
            "LBL+",
            "Beta 1.0"}, -1);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.IPTextbox = new System.Windows.Forms.TextBox();
            this.ToolTipHandler = new System.Windows.Forms.ToolTip(this.components);
            this.PortTextbox = new System.Windows.Forms.TextBox();
            this.MultiLoginCheckbox = new System.Windows.Forms.CheckBox();
            this.AnonymousCheckbox = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.UsersListview = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.AddUserBTN = new System.Windows.Forms.Button();
            this.SetPLevelButton = new System.Windows.Forms.Button();
            this.SetPasswordBTN = new System.Windows.Forms.Button();
            this.DeleteUserBTN = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.OKBTN = new System.Windows.Forms.Button();
            this.CancelBTN = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.SwitchboardServerAbout = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Port";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.AnonymousCheckbox);
            this.groupBox1.Controls.Add(this.MultiLoginCheckbox);
            this.groupBox1.Controls.Add(this.PortTextbox);
            this.groupBox1.Controls.Add(this.IPTextbox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(150, 159);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Main Server Settings";
            // 
            // IPTextbox
            // 
            this.IPTextbox.Location = new System.Drawing.Point(38, 26);
            this.IPTextbox.Name = "IPTextbox";
            this.IPTextbox.Size = new System.Drawing.Size(100, 20);
            this.IPTextbox.TabIndex = 2;
            this.ToolTipHandler.SetToolTip(this.IPTextbox, resources.GetString("IPTextbox.ToolTip"));
            // 
            // PortTextbox
            // 
            this.PortTextbox.Location = new System.Drawing.Point(38, 52);
            this.PortTextbox.Name = "PortTextbox";
            this.PortTextbox.Size = new System.Drawing.Size(100, 20);
            this.PortTextbox.TabIndex = 2;
            this.ToolTipHandler.SetToolTip(this.PortTextbox, resources.GetString("PortTextbox.ToolTip"));
            // 
            // MultiLoginCheckbox
            // 
            this.MultiLoginCheckbox.AutoSize = true;
            this.MultiLoginCheckbox.Location = new System.Drawing.Point(38, 78);
            this.MultiLoginCheckbox.Name = "MultiLoginCheckbox";
            this.MultiLoginCheckbox.Size = new System.Drawing.Size(90, 30);
            this.MultiLoginCheckbox.TabIndex = 3;
            this.MultiLoginCheckbox.Text = "Allow Multiple\r\nLogins";
            this.ToolTipHandler.SetToolTip(this.MultiLoginCheckbox, resources.GetString("MultiLoginCheckbox.ToolTip"));
            this.MultiLoginCheckbox.UseVisualStyleBackColor = true;
            // 
            // AnonymousCheckbox
            // 
            this.AnonymousCheckbox.AutoSize = true;
            this.AnonymousCheckbox.Location = new System.Drawing.Point(38, 114);
            this.AnonymousCheckbox.Name = "AnonymousCheckbox";
            this.AnonymousCheckbox.Size = new System.Drawing.Size(108, 30);
            this.AnonymousCheckbox.TabIndex = 4;
            this.AnonymousCheckbox.Text = "Allow anonymous\r\nusers";
            this.ToolTipHandler.SetToolTip(this.AnonymousCheckbox, resources.GetString("AnonymousCheckbox.ToolTip"));
            this.AnonymousCheckbox.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.DeleteUserBTN);
            this.groupBox2.Controls.Add(this.SetPasswordBTN);
            this.groupBox2.Controls.Add(this.SetPLevelButton);
            this.groupBox2.Controls.Add(this.AddUserBTN);
            this.groupBox2.Controls.Add(this.UsersListview);
            this.groupBox2.Location = new System.Drawing.Point(168, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(409, 159);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "User Management";
            // 
            // UsersListview
            // 
            this.UsersListview.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.UsersListview.HideSelection = false;
            this.UsersListview.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.UsersListview.Location = new System.Drawing.Point(6, 18);
            this.UsersListview.Name = "UsersListview";
            this.UsersListview.Size = new System.Drawing.Size(316, 126);
            this.UsersListview.TabIndex = 3;
            this.UsersListview.UseCompatibleStateImageBehavior = false;
            this.UsersListview.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Username";
            this.columnHeader1.Width = 122;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "PLevel";
            this.columnHeader2.Width = 47;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Last Login";
            this.columnHeader3.Width = 139;
            // 
            // AddUserBTN
            // 
            this.AddUserBTN.Location = new System.Drawing.Point(328, 24);
            this.AddUserBTN.Name = "AddUserBTN";
            this.AddUserBTN.Size = new System.Drawing.Size(75, 23);
            this.AddUserBTN.TabIndex = 4;
            this.AddUserBTN.Text = "Add User";
            this.AddUserBTN.UseVisualStyleBackColor = true;
            // 
            // SetPLevelButton
            // 
            this.SetPLevelButton.Location = new System.Drawing.Point(328, 55);
            this.SetPLevelButton.Name = "SetPLevelButton";
            this.SetPLevelButton.Size = new System.Drawing.Size(75, 23);
            this.SetPLevelButton.TabIndex = 5;
            this.SetPLevelButton.Text = "Set PLevel";
            this.SetPLevelButton.UseVisualStyleBackColor = true;
            // 
            // SetPasswordBTN
            // 
            this.SetPasswordBTN.Location = new System.Drawing.Point(328, 85);
            this.SetPasswordBTN.Name = "SetPasswordBTN";
            this.SetPasswordBTN.Size = new System.Drawing.Size(75, 23);
            this.SetPasswordBTN.TabIndex = 6;
            this.SetPasswordBTN.Text = "Set Pass";
            this.SetPasswordBTN.UseVisualStyleBackColor = true;
            // 
            // DeleteUserBTN
            // 
            this.DeleteUserBTN.Location = new System.Drawing.Point(328, 114);
            this.DeleteUserBTN.Name = "DeleteUserBTN";
            this.DeleteUserBTN.Size = new System.Drawing.Size(75, 23);
            this.DeleteUserBTN.TabIndex = 7;
            this.DeleteUserBTN.Text = "Delete User";
            this.DeleteUserBTN.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Controls.Add(this.listView1);
            this.groupBox3.Location = new System.Drawing.Point(12, 177);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(258, 207);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Extensions";
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader5});
            this.listView1.HideSelection = false;
            this.listView1.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem2});
            this.listView1.Location = new System.Drawing.Point(9, 19);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(238, 147);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Extension";
            this.columnHeader4.Width = 164;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Version";
            this.columnHeader5.Width = 61;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(172, 172);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Settings";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.SwitchboardServerAbout);
            this.groupBox4.Controls.Add(this.pictureBox1);
            this.groupBox4.Location = new System.Drawing.Point(276, 177);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(301, 178);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "About";
            // 
            // OKBTN
            // 
            this.OKBTN.Location = new System.Drawing.Point(415, 361);
            this.OKBTN.Name = "OKBTN";
            this.OKBTN.Size = new System.Drawing.Size(75, 23);
            this.OKBTN.TabIndex = 0;
            this.OKBTN.Text = "OK";
            this.OKBTN.UseVisualStyleBackColor = true;
            // 
            // CancelBTN
            // 
            this.CancelBTN.Location = new System.Drawing.Point(496, 361);
            this.CancelBTN.Name = "CancelBTN";
            this.CancelBTN.Size = new System.Drawing.Size(75, 23);
            this.CancelBTN.TabIndex = 0;
            this.CancelBTN.Text = "Cancel";
            this.CancelBTN.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SwitchboardServer.Properties.Resources.Switchboard__Wide_;
            this.pictureBox1.Location = new System.Drawing.Point(6, 19);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(289, 76);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // SwitchboardServerAbout
            // 
            this.SwitchboardServerAbout.Location = new System.Drawing.Point(6, 110);
            this.SwitchboardServerAbout.Name = "SwitchboardServerAbout";
            this.SwitchboardServerAbout.Size = new System.Drawing.Size(289, 56);
            this.SwitchboardServerAbout.TabIndex = 2;
            this.SwitchboardServerAbout.Text = "Switchboard Server (Version 1.0)\r\nBased on Switchboard Server (Version 1.0)\r\n\r\n(C" +
    ")2020 Igtampe, No Rights Reserved\r\n";
            this.SwitchboardServerAbout.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ServerSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(587, 402);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.CancelBTN);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.OKBTN);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ServerSettingsForm";
            this.Text = "Settings";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox AnonymousCheckbox;
        private System.Windows.Forms.ToolTip ToolTipHandler;
        private System.Windows.Forms.CheckBox MultiLoginCheckbox;
        private System.Windows.Forms.TextBox PortTextbox;
        private System.Windows.Forms.TextBox IPTextbox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListView UsersListview;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Button DeleteUserBTN;
        private System.Windows.Forms.Button SetPasswordBTN;
        private System.Windows.Forms.Button SetPLevelButton;
        private System.Windows.Forms.Button AddUserBTN;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button CancelBTN;
        private System.Windows.Forms.Button OKBTN;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label SwitchboardServerAbout;
    }
}