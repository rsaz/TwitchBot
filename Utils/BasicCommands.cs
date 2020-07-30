using System.Collections.Generic;
using System.Linq;

namespace twitchBot.Utils
{
    public class BasicCommands
    {
        private string cmdInitials = "!";
        private Dictionary<string, string> data;
        public string CommandListener(Dictionary<string, string> data)
        {
            // dictionary decomposition 
            if (data != null && (data[data.Keys.ElementAt(0)]).Substring(0, cmdInitials.Length) == cmdInitials)
            {
                this.data = data;
                string user = data.Keys.ElementAt(0);
                string msg = data[data.Keys.ElementAt(0)];

                return CommandTree(user, msg);
            }

            return null;
        }

        // This function is the manager to address who should be responding to the command. [Temp solution]
        // we need to keep track of who placed the command
        // Function act as controller to address responses base on type of commands
        private string CommandTree(string user, string msg)
        {
            switch (msg.ToLower())
            {
                case "!project":
                    return "Twitch Bot Project";
                case "!akira":
                    return $"Hey {user}, Akira is a nice person. He is my boss";
                default:
                    return "I don't have answer for that yet";
            }
        }
    }
}