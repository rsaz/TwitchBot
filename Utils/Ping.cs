using System;
using System.Threading;

namespace twitchBot.Utils
{
    public class Ping
    {
        private TwitchClient client;
        private Thread sender;
        public Ping(TwitchClient client)
        {
            this.client = client;
            sender = new Thread(new ThreadStart(Run));
        }
        public void Start()
        {
            sender.IsBackground = true;
            sender.Start();
        }
        private void Run()
        {
            while (true)
            {
                Console.WriteLine("Sending PING");
                client.SendIrcMessages("PING irc.twitch.tv");
                Thread.Sleep(TimeSpan.FromMinutes(5));
                Console.WriteLine("Sent PING");
            }
        }
    }
}