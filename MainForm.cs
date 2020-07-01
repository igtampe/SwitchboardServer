using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Switchboard;

namespace SwitchboardServerForm {
    public partial class MainForm:Form {

        private Switchboard.SwitchboardServer MainServer;

        /// <summary>Initialization of the main form</summary>
        public MainForm() {
            InitializeComponent();
            DisconnectButton.Enabled = false;
            ConnectionDetailsButton.Enabled = false;

            ConnectionsListView.Items.Clear();
            ConnectionsListView.Enabled = false;
        }

        /// <summary>Shwne selecting a user from the listview</summary>
        private void ConnectionsListView_SelectedIndexChanged(object sender,EventArgs e) {
            DisconnectButton.Enabled = true;
            ConnectionDetailsButton.Enabled = true;
        }

        private void ServerBWorker_DoWork(object sender,DoWorkEventArgs e) {
            //First lets start a server.
            List<SwitchboardExtension> Extensions = new List<SwitchboardExtension>();
            MainServer = new Switchboard.SwitchboardServer("127.0.0.1",909,ref Extensions,"H o l a",true);

            //now 
            while(!ServerBWorker.CancellationPending) {
                MainServer.Tick();
                Thread.Sleep(100);  //sleep to make sure this doesn't drive my computer insane
            }

            //if there is a cancelation pending:
            MainServer.Close();

        }

        private void ServerBWorker_ReportProgress(object sender,ProgressChangedEventArgs e) {
            //Report the progress on the internal server
            ConnectionsListView.Items.Clear();
            foreach(Switchboard.SwitchboardServer.SwitchboardConnection Con in MainServer.GetConnections()) {
                ListViewItem NLI = new ListViewItem(Con.getUser().GetUsername());
                NLI.SubItems.Add(Con.getIP().Address.ToString());
                NLI.SubItems.Add(Con.getConnectedSince().ToShortTimeString() + " " + Con.getConnectedSince().ToShortDateString());
            }
        }

        private void ServerBWorker_Done(object Sender,RunWorkerCompletedEventArgs e) {
            StatusLabel.Text = "Status: Offline";
            StartStopServerButton.Text = "Start Server";
            DisconnectButton.Enabled = false;
            ConnectionDetailsButton.Enabled = false;

            ConnectionsListView.Items.Clear();
            ConnectionsListView.Enabled = false;
            MainServer = null;
        }

        private void StartStopServerButton_Click(object sender,EventArgs e) {
            if(MainServer == null) {

                //Server is not started
                StatusLabel.Text = "Status: Online";
                StartStopServerButton.Text = "Stop";
                ConnectionsListView.Enabled = Enabled;

                ServerBWorker.RunWorkerAsync();

            } else {ServerBWorker.CancelAsync();} //server is started, cancel it.

        }
    }
}
