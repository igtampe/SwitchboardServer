using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Switchboard {
    
    /// <summary>Configuration of the Switchboard Server.</summary>
    public static class SwitchboardConfiguration {

        /// <summary>Name of this server</summary>
        public const String ServerName = "SWITCHBOARD DEFAULT SERVER";

        /// <summary>Version of this server</summary>
        public const String ServerVersion = "BETA 1.0";

        public static List<SwitchboardExtension> ServerExtensions() {

            List<SwitchboardExtension> List = new List<SwitchboardExtension>();

            //Here add/initialize your server extensions.
            //By default, the server will always have the DummyExtension, and the Switchboard Main Extension.

            return List;

        }

    }
}
