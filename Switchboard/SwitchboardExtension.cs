using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Switchboard {
    public abstract class SwitchboardExtension {

        protected string Name;
        protected string Version;

        public SwitchboardExtension(String Name, String Version) { this.Name = Name; this.Version = Version; }

        /// <summary>Executes every tick</summary>
        public abstract void Tick();

        /// <summary></summary>
        /// <param name="User">USER attempting to execute a command within this extension</param>
        /// <param name="Command">The command the user is trying to execute</param>
        /// <returns>A string if the extension was able to parse it, otherwise null</returns>
        public abstract string Parse(ref SwitchboardUser User,String Command);

        /// <summary>
        /// returns a bit of info on the extension and help with its commands.
        /// maybe also include a list of the available commands, though nose.
        /// </summary>
        public abstract string Help();

        public string GetName() { return Name; }
        public string GetVersion() { return Version; }

    }

    /// <summary>The default dummy extension which also serves as an example for what you should do</summary>
    public class DummyExtension:SwitchboardExtension {

        /// <summary>Handle any initialization of your extension here</summary>
        public DummyExtension() : base("DummyExtension","Version 1.0") { }

        //NAMES OF EXTENSIONS SHOULD NOT HAVE SPACES. OTHERWISE HELP WILL BE INACCESSIBLE.

        public override string Help() {return "This is just a dummy extension. Don't have any funny ideas this isn't hiding anything.";}

        public override string Parse(ref SwitchboardUser User,string Command) {

            if(Command == "CONNECTED") { return "Congrats! You've connected to the server!"; }
            return null;
        }

        public override void Tick() {}
    }

    public class SwitchboardUser {
        private String Username;
        private String Password;
        private int PermissionLevel;

        private bool Online;
        private String LastOnline;

        public SwitchboardUser(String Username,String Password,int PermissionLevel,String LastOnline) {
            this.Username = Username;
            this.Password = Password;
            this.PermissionLevel = PermissionLevel;
            this.LastOnline = LastOnline;
        }

        public SwitchboardUser(String UserString) {
            String[] Split = UserString.Split('~');
            if(Split.Length != 4) { throw new ArgumentException("UserString was not of length 4: " + UserString); }

            Username = Split[0];
            Password = Split[1];
            PermissionLevel = int.Parse(Split[2]);
            LastOnline = Split[3];
        }

        /// <summary>Retrieves the username of this user</summary>
        public String GetUsername() { return Username; }

        /// <summary>Verifies the given password with the actual password of this user</summary>
        /// <param name="Password">Password to verify</param>
        /// <returns>True if the password matches the one on record, false otherwise</returns>
        public Boolean VerifyPassword(String Password) { return this.Password==Password; }

        /// <summary>Verifies if a user can run a certain command with the required permission level</summary>
        /// <param name="RequiredPermissionLevel">Permission level of the command you want to verify if this user can run</param>
        /// <returns>True if the user matches or exceeds the specified permission level, false otherwise</returns>
        public Boolean canExecute(int RequiredPermissionLevel) { return PermissionLevel >= RequiredPermissionLevel; }


        /// <summary>Sets the password of the current user</summary>
        /// <param name="CurrentPassword">Current password for verification purposes</param>
        /// <param name="NewPassword">New User's Password</param>
        /// <returns>True if the password was able to be replaced, false otherwise</returns>
        public Boolean setPassword(String CurrentPassword, String NewPassword) {
            if(Password != CurrentPassword) { return false; }
            Password = NewPassword;
            return true;
        }

        /// <summary>Function to check if the user is online</summary>
        public Boolean IsOnline() { return Online; }

        /// <summary>Function to set a user as online or offline. If the user is set to offline, it updates the user's info</summary>
        public void SetOnline(Boolean Onl) {
            Online = Onl;
            if(!Onl) { LastOnline = DateTime.Now.ToString(); }
        }

        /// <summary>Generates a string that can be used to *save* this user.</summary>
        /// <returns>A string that represents this user</returns>
        public override string ToString() {return String.Join("~",Username,Password,PermissionLevel,LastOnline);}

    }

}
