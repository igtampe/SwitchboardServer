using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Windows.Forms;
using Switchboard;

namespace SwitchboardServer {
    public partial class ServerSettingsForm:Form {

        //------------------------------[Variables]------------------------------

        /// <summary>List that holds extensions</summary>
        private readonly List<SwitchboardExtension> Extensions;

        /// <summary>List that holds all of the users</summary>
        private readonly List<ManageableUser> Users;

        //------------------------------[Internal Classes]------------------------------

        private class ManageableUser:SwitchboardUser{
            public ManageableUser(String Userstring):base(Userstring) { }

            public void SetPassword(String Password) { this.Password = Password; }
            public void SetPLevel(int PLevel) { PermissionLevel = PLevel; }
            public int GetPLevel() { return PermissionLevel; }
        }

        //------------------------------[Constructor]------------------------------

        public ServerSettingsForm() {
            InitializeComponent();

            UsersListview.Items.Clear();
            ExtensionsListview.Items.Clear();

            UsersListview.FullRowSelect = true;
            UsersListview.MultiSelect = false;
            ExtensionsListview.FullRowSelect = true;
            ExtensionsListview.MultiSelect = false;

            //Load Main Settings from SwitchboardServer.cfg
            if(!File.Exists("SwitchboardServer.cfg")) {

                //Show a brief little welcome message!
                MessageBox.Show("Welcome to Switchboard! We'll just put the default configuration values here, and then you can be on your way. \n\n Thanks for using Switchboard","Welcome!",MessageBoxButtons.OK,MessageBoxIcon.Information);

                //Get the default values
                LoadDefault();
            } else {

                try {

                    String[] Settings = File.ReadAllLines("SwitchboardServer.cfg")[0].Split(':');
                    IPTextbox.Text = Settings[0];
                    PortTextbox.Text = Settings[1];
                    AnonymousCheckbox.Checked = bool.Parse(Settings[2]);
                    MultiLoginCheckbox.Checked = bool.Parse(Settings[3]);

                } catch(Exception e) {
                    MessageBox.Show("There was a problem interpretting your config file. Default values were loaded instead. \n\n" + e.Message + "\n" + e.StackTrace,"oopsie",MessageBoxButtons.OK,MessageBoxIcon.Error); ;
                    LoadDefault();
                }

            }

            //Load Users the same way the server does.
            Users = new List<ManageableUser>();
            if(File.Exists("SwitchboardUsers.txt")) {
                //Read all lines from the file
                String[] UserStrings = File.ReadAllLines("SwitchboardUsers.txt");

                //For each userstring, add a new user
                foreach(String UserString in UserStrings) {
                    ManageableUser User = new ManageableUser(UserString);

                    Users.Add(User);

                    ListViewItem NLI = new ListViewItem(User.GetUsername());
                    NLI.SubItems.Add(User.GetPLevel().ToString());
                    NLI.SubItems.Add(User.GetLastOnline());
                    UsersListview.Items.Add(NLI);

                                     
                }
            }

            //Load extensions and display them.
            Extensions = SwitchboardConfiguration.ServerExtensions();
            foreach(SwitchboardExtension extension in Extensions) {
                ListViewItem NLI = new ListViewItem(extension.GetName());
                NLI.SubItems.Add(extension.GetVersion());
                ExtensionsListview.Items.Add(NLI);
            }

            //Load Welcome.txt
            if(File.Exists("Welcome.txt")) { WelcomeBox.Text = File.ReadAllText("Welcome.txt"); } 
            else { WelcomeBox.Text = SwitchboardConfiguration.DefaultWelcome; }

        }

        //------------------------------[Buttons]------------------------------

        private void CancelBTN_Click(object sender,EventArgs e) {Close();}

        private void OKBTN_Click(object sender,EventArgs e) {

            //make sure the IP is parsable to an IP and the port is parsable to an int.
            if(!IPAddress.TryParse(IPTextbox.Text,out IPAddress temp) || !int.TryParse(PortTextbox.Text,out int Port)) {
                MessageBox.Show("Could not parse your settings! Check the IP or port","oopsie",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

            //ok now save everything

            if(File.Exists("SwitchboardServer.cfg")) { File.Delete("SwitchboardServer.cfg"); }
            File.WriteAllText("SwitchboardServer.cfg",String.Join(":",IPTextbox.Text,PortTextbox.Text,AnonymousCheckbox.Checked,MultiLoginCheckbox.Checked));

            if(File.Exists("Welcome.txt")) { File.Delete("Welcome.txt"); }
            File.WriteAllText("Welcome.txt",WelcomeBox.Text);

            if(File.Exists("SwitchboardUsers.txt")) { File.Delete("SwitchboardUsers.txt"); }
            
            StreamWriter UserPen = File.CreateText("SwitchboardUsers.txt");

            foreach(SwitchboardUser User in Users) { UserPen.WriteLine(User.ToString()); }
            UserPen.Close();

            Close();
        }

        private void ExtensionSettingsBTN_Click(object sender,EventArgs e) {
            //Make sure there is at least one extension selected.
            if(ExtensionsListview.SelectedIndices.Count == 0) {
                MessageBox.Show("Please select a connection to see its details","n o",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

            //Get the connection index
            int ConnectionIndex = ExtensionsListview.SelectedIndices[0];

            //Run the extension's settings function (which should bring up a form as a show-dialog)
            Extensions[ConnectionIndex].Settings();

        }

        //------------------------------[Other Stuff]------------------------------

        /// <summary>Loads default values</summary>
        public void LoadDefault() {
            IPTextbox.Text = SwitchboardConfiguration.DefaultIP;
            PortTextbox.Text = SwitchboardConfiguration.DefaultPort.ToString();
            AnonymousCheckbox.Checked = SwitchboardConfiguration.AllowAnonymousDefault;
            MultiLoginCheckbox.Checked = SwitchboardConfiguration.MultiLoginDefault;
        }

    }
}
