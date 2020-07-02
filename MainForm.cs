using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Windows.Forms;
using Switchboard;

namespace SwitchboardServerForm {
    public partial class MainForm:Form {

        //------------------------------[Variables]------------------------------

        /// <summary>Main server this form holds</summary>
        private Switchboard.SwitchboardServer MainServer;

        //------------------------------[Constructor]------------------------------

        public MainForm() {
            InitializeComponent();
            ConnectionDetailsButton.Enabled = false;

            ConnectionsListView.Items.Clear();
            ConnectionsListView.Enabled = false;
            ConnectionsListView.FullRowSelect = true;
            ConnectionsListView.MultiSelect = false;
        }

        //------------------------------[Buttons]------------------------------

        /// <summary>Shwne selecting a user from the listview</summary>
        private void ConnectionsListView_SelectedIndexChanged(object sender,EventArgs e) {
            ConnectionDetailsButton.Enabled = true;
        }

        private void ConnectionDetailsButton_Click(object sender,EventArgs e) {

            //Make sure there is at least one connection selected.
            //Well, there will only ever be one because we disabled multi-select but shh its ok.
            if(ConnectionsListView.SelectedIndices.Count == 0) {
                MessageBox.Show("Please select a connection to see its details","n o",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

            //Get the connection index
            int ConnectionIndex = ConnectionsListView.SelectedIndices[0];

            //Get the connection.
            Switchboard.SwitchboardServer.SwitchboardConnection Connection = MainServer.GetConnections()[ConnectionIndex];

            //Pass the connection to a connection details form
            
            //TODO: Connection details form

        }

        private void ServerSettingsButton_Click(object sender,EventArgs e) {

            //Make sure there is no main server since these settings cannot be modified while the server is running.
            if(MainServer != null) {
                MessageBox.Show("Settings can only be modified while server isn't running!","n o",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

            //Now launch the de-esta cosa. The settings form will handle loading settings.
            
            //TODO: Settings Details Form.

        }

        private void StartStopServerButton_Click(object sender,EventArgs e) {
            if(MainServer == null) {

                //Server is not started
                StatusLabel.Text = "Status: Online";
                StartStopServerButton.Text = "Stop";
                ConnectionsListView.Enabled = Enabled;
                

                ServerBWorker.RunWorkerAsync();

            } else { ServerBWorker.CancelAsync(); } //server is started, cancel it.

        }

        //------------------------------[Server Background Worker]------------------------------

        private void ServerTime(object sender,DoWorkEventArgs e) {
            
            //TODO: Load Settings before execution
            
            //First lets start a server.
            MainServer = new Switchboard.SwitchboardServer(this, "127.0.0.1",909,"H o l a",true);

            //now 
            while(!ServerBWorker.CancellationPending) {
                MainServer.Tick();
                Thread.Sleep(100);  //sleep to make sure this doesn't drive my computer insane
            }

            //if there is a cancelation pending:
            MainServer.Close();

        }

        private void RefreshListview(object sender,ProgressChangedEventArgs e) {
            //Report the progress on the internal server
            ConnectionsListView.Items.Clear();
            foreach(Switchboard.SwitchboardServer.SwitchboardConnection Con in MainServer.GetConnections()) {
                ListViewItem NLI = new ListViewItem(Con.GetUser().GetUsername());
                NLI.SubItems.Add(Con.GetIP().Address.ToString());
                NLI.SubItems.Add(Con.GetConnectedSince().ToShortTimeString() + " " + Con.GetConnectedSince().ToShortDateString());
                ConnectionsListView.Items.Add(NLI);
            }
        }

        private void ServerDone(object Sender,RunWorkerCompletedEventArgs e) {
            StatusLabel.Text = "Status: Offline";
            StartStopServerButton.Text = "Start Server";
            ConnectionDetailsButton.Enabled = false;

            ConnectionsListView.Items.Clear();
            ConnectionsListView.Enabled = false;
            MainServer = null;
        }

    }
}
