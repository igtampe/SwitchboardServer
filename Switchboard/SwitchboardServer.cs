using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace Switchboard {

    public class SwitchboardServer {

        protected String ServerName="SWITCHBOARD DEFAULT SERVER";
        protected String ServerVersion="BETA 1.0";

        protected StreamWriter LogPen;

        protected List<SwitchboardConnection> Connections;
        protected List<SwitchboardExtension> Extensions;
        protected List<SwitchboardUser> Users;

        protected bool AllowAnonymous;
        protected SwitchboardUser AnonymousUser;

        protected String WelcomeMessage;

        private TcpListener Ears;

        public class SwitchboardConnection { 
            
            //god help me
            private SwitchboardServer Daddy;

            private DateTime ConnectedSince;
            private IPEndPoint IP;
            private SwitchboardUser User;

            private NetworkStream River;
            private Socket TheSocket;

            private List<string> PreviousCommands;
            public bool IsConnected => TheSocket.Connected;

            public SwitchboardConnection(SwitchboardServer Daddy,Socket MainSocket) {
            
                ConnectedSince = DateTime.Now;
                IP = (IPEndPoint)MainSocket.RemoteEndPoint;
                River = new NetworkStream(MainSocket);
                TheSocket = MainSocket;

                this.Daddy = Daddy;

                Daddy.ToLog("New user connected from " + IP.Address.ToString());

                User = Daddy.AnonymousUser;

                PreviousCommands = new List<String>();

            }

            /// <summary>Ticks this connection</summary>
            /// <returns>True if the connection should be maintained, false otherwise.</returns>
            public void Tick() {

                //If there's data available.
                if(River.DataAvailable) {
                    Daddy.ToLog("Attempting to read message from " + IP.Address.ToString());

                    //Save all the bytes to an array
                    List<byte> Bytes = new List<byte>();
                    while(River.DataAvailable) { Bytes.Add((byte)River.ReadByte()); }

                    //Parse that array of bytes as an ASCII encoded string
                    String Command = System.Text.Encoding.ASCII.GetString(Bytes.ToArray());

                    //Handle VBNullChar or \0 in this case.
                    Command = Command.Replace("\0","");

                    //Add this to the list of commands.
                    PreviousCommands.Add(Command);

                    //Now let's try to parse it.
                    String Reply="";

                    String[] CommandSplit = Command.Split(' ');
                    switch(CommandSplit[0].ToUpper()) {
                        case "WELCOME":
                            Reply = Daddy.GetWelcomeMessage();
                            break;
                        case "LOGIN":
                            if(CommandSplit.Length != 3) { Reply = "Could not log you in, invalid login details"; } else {
                                SwitchboardUser myUser = null;

                                //Find the user.
                                foreach(SwitchboardUser User in Daddy.Users) { if(User.GetUsername() == CommandSplit[1]) { myUser = User; break; } }

                                if(myUser != null && myUser.VerifyPassword(CommandSplit[2])) {
                                    User = myUser;
                                    Reply = "Successfully logged in as " + User.GetUsername();
                                } else {
                                    Reply = "Could not log you in, invalid login details";
                                }
                            }
                            break;
                        case "LOGOUT":
                            if(User == Daddy.AnonymousUser) { Reply = "You're already logged out!"; } else {
                                User.SetOnline(false);
                                User = Daddy.AnonymousUser;
                                Reply = "You've been successfully logged out.";
                            }
                            break;
                        case "CLOSE":
                            River.Close();
                            TheSocket.Close();
                            return;
                        default:
                            if(!Daddy.AllowAnonymous && User == Daddy.AnonymousUser) { Reply = "You're unauthorized to run any other commands."; } else { 
                                foreach(SwitchboardExtension extension in Daddy.Extensions) {
                                    if(!String.IsNullOrEmpty(Reply)) { break; }
                                    Reply = extension.Parse(ref User,Command);
                                }
                                if(string.IsNullOrEmpty(Reply)) { Reply = "Could not parse command [" + Command + "]"; }
                            }
                            break;
                    }

                    //Time to return whatever it is we got.

                    Byte[] ReturnBytes = System.Text.Encoding.ASCII.GetBytes(Reply);
                    River.Write(ReturnBytes,0,ReturnBytes.Length);
                    
                    //and we're done.

                }

                return;
            }

            public List<String> GetPrevCommands() { return PreviousCommands; }
            public SwitchboardUser getUser() { return User; }
            public DateTime getConnectedSince() { return ConnectedSince; }
            public IPEndPoint getIP() { return IP; }

            public void Close() {
                River.Close();
                TheSocket.Close();
            }

        
        }

        private class SwitchboardMainExtension:SwitchboardExtension {

            private SwitchboardServer HeadServer;

            public SwitchboardMainExtension(SwitchboardServer Main) : base("MAIN","1.0") {
                HeadServer = Main;
            }

            public override string Help() {
                return "Switchboard Main Extension [Version " + Version + "\n" +
                    "\n" +
                    "Available Commands: \n" +
                    "VER                            : Displays Server Version\n" +
                    "SHOWEXTENSIONS                 : Displays all available extensions\n" +
                    "HELP [Extension]               : Displays help on the extension\n" +
                    "SETPASS (CurrentPass) (NewPas) : Sets your new password. Password must not contain spaces, or the character ~\n" +
                    "CLOSE                          : Closes the connection and disconnects you from the server \n" +
                    "LOGIN (USERNAME) (PASSWORD)    : Logs you in if you're currently anonymous\n" +
                    "LOGOUT                         : Logs you out of this terminal, maintains you connected as an anonymous user.\n" +
                    "WELCOME                        : Shows this server's welcome message" +
                    "\n" +
                    "More user options are available on the server";
            }

            public override string Parse(ref SwitchboardUser User,string Command) {
                String[] CommandSplit = Command.Split(' ');

                switch(CommandSplit[0].ToUpper()) {
                    case "VER":
                        return HeadServer.ServerName + " [Version " + HeadServer.ServerVersion + "]";

                    case "SHOWEXTENSIONS":
                        String AllExtensions = HeadServer.Extensions.Count + " Extension(s)\n\n";
                        foreach(SwitchboardExtension Extension in HeadServer.Extensions) {AllExtensions += Extension.GetName() + " [Version " + Extension.GetVersion() + "]\n";}
                        return AllExtensions;

                    case "HELP":
                        if(CommandSplit.Length == 1) { return Help(); }
                        foreach(SwitchboardExtension Extension in HeadServer.Extensions) {if(Extension.GetName().ToUpper() == CommandSplit[1]) { return Extension.Help(); }}
                        return "Could not find extension " + CommandSplit[1];

                    case "SETPASS":
                        if(CommandSplit.Length != 3 || Command.Contains("~")) { return "Could not update password due to invalid characters"; }
                        if(User == HeadServer.AnonymousUser) { return "cannot set password if user is not logged in"}

                        if(User.setPassword(CommandSplit[1],CommandSplit[2])) {

                            HeadServer.SaveUsers();
                            return "Successfully updated password!"; 
                        }

                        return "Server was unable to update your password";

                    default:
                        return null;
                }

            }

            public override void Tick() {}
        }

        protected void SaveUsers() {

            if(File.Exists("SwitchboardUsers.txt")) { File.Delete("SwitchboardUsers.txt"); }
            StreamWriter Pen = File.CreateText("SwitchboardUsers.txt");

            foreach(SwitchboardUser User in Users) { Pen.WriteLine(User.ToString()); }
            Pen.Close();
        }

        /// <summary>Gets the welcome message, and appends a warning if anonymous use is not allowed.</summary>
        /// <returns></returns>
        protected string GetWelcomeMessage() {
            if(AllowAnonymous) { return WelcomeMessage; }
            return WelcomeMessage + "\n\nThis server requires that you log in. Use Login (Username) (Password) to log in.";
        }

        public SwitchboardServer(String IP, int Port, ref List<SwitchboardExtension> Extensions, String WelcomeMessage, bool AllowAnonymous) {
            LogPen = File.AppendText("SwitchboardLog.log");
            LogPen.WriteLine("\n\n"+ServerName + " [Version " + ServerVersion + "]\n\n" + "[" + DateTime.Now.ToShortDateString() + "] Starting Server...");

            this.WelcomeMessage = WelcomeMessage;

            ToLog("Registering extensions...");
            this.Extensions = Extensions;
            Extensions.Add(new DummyExtension());
            Extensions.Add(new SwitchboardMainExtension(this));

            ToLog("Loading Users...");
            Users = new List<SwitchboardUser>();
            if(File.Exists("SwitchboardUsers.txt")) {
                //Read all lines from the file
                String[] UserStrings = File.ReadAllLines("SwitchboardUsers.txt");
                
                //For each userstring, add a new user
                foreach(String UserString in UserStrings) {Users.Add(new SwitchboardUser(UserString));}
            }

            this.AllowAnonymous = AllowAnonymous;
            AnonymousUser = new SwitchboardUser("Anonymous","",0,"");

            if(Users.Count == 0 && !AllowAnonymous) { ToLog("WARNING! No registered users and now annonymous access! You won't be able to actually use this server!"); }

            ToLog("One last thing...");
            Connections = new List<SwitchboardConnection>();

            ToLog("Actually starting the server...");
            Ears = new TcpListener(IPAddress.Parse(IP),Port);
            Ears.Start();
            ToLog("Server started!");

        }

        public void Tick() {

            //Check if we need to let in another connection.
            if(Ears.Pending()) {
                //Let them in to the system.
                Connections.Add(new SwitchboardConnection(this,Ears.AcceptSocket()));
            }

            //ok now check every connection to see if they're pending.
            foreach(SwitchboardConnection Connection in Connections) { 
                Connection.Tick();
                if(!Connection.IsConnected) { Connections.Remove(Connection); } //if the connection was closed, remove it from the list
            }

            //now tick every extension
            foreach(SwitchboardExtension extension in Extensions) {extension.Tick();}

        }

        public void Close() {
            foreach(SwitchboardConnection Connection in Connections) {
                Connection.Tick();
                if(!Connection.IsConnected) { Connections.Remove(Connection); } //if the connection was closed, remove it from the list
            }

            Ears.Stop();
            ToLog("Server stopped");
            LogPen.Close();
        }

        protected void ToLog(String LogItem) {
            String Line = "[" + DateTime.Now.ToShortTimeString() + "] " + LogItem;
            LogPen.WriteLine(Line);
            Console.WriteLine(Line);
        }

        public List<SwitchboardConnection> GetConnections() {return Connections;}

    }
   

}
