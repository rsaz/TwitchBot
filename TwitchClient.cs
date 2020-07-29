using System.IO;
using System.Net.Sockets;

namespace twitchBot
{
    public class TwitchClient
    {
        private string username;
        private string password;
        private string channelName;

        private TcpClient tcpClient;
        private StreamReader reader;
        private StreamWriter writer;

        public TwitchClient(string host, int port, string user, string pwd, string channel)
        {
            username = user;
            password = pwd;
            channelName = channel;

            tcpClient = new TcpClient(host, port);
            reader = new StreamReader(tcpClient.GetStream());
            writer = new StreamWriter(tcpClient.GetStream());

            writer.WriteLine($"PASS {password}");
            writer.WriteLine($"NICK {username}");
            writer.WriteLine($"USER {username} 8 * :{username}");
            writer.WriteLine($"JOIN #{channelName}");
            SendChatMessages("YourBot");

            writer.Flush();
        }

        public string ReadChatMessage() => reader.ReadLine();

        public void SendIrcMessages(string message)
        {
            writer.WriteLine(message);
            writer.Flush();
        }

        public void SendChatMessages(string message)
        {
            // server to client 
            writer.WriteLine($":{username}!{username}@{username}.tmi.twitch.tv PRIVMSG #{channelName} :{message}");

            // < client to server 
            writer.WriteLine($"PRIVMSG #{channelName} : {message}");
        }

    }
}