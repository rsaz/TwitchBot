using System;
using Microsoft.Extensions.Configuration;
using twitchBot.Utils;
using System.Linq;

namespace twitchBot
{
    class Program
    {
        static void Main(string[] args)
        {
            // Getting the secret to be used in the password section
            var builder = new ConfigurationBuilder()
            .AddUserSecrets<Program>()
            .Build();

            var serviceProvider = builder.Providers.First();
            if (!serviceProvider.TryGet("TwitchAccess:username", out var username)) return;
            if (!serviceProvider.TryGet("TwitchAccess:OAuth", out var password)) return;
            if (!serviceProvider.TryGet("TwitchAccess:channel", out var channel)) return;

            var client = new TwitchClient("irc.twitch.tv", 6667, username, password, channel);

            // Ping the server to prevent twitch disconnect your bot
            var botAlive = new Ping(client);
            botAlive.Start();

            // Initial connection
            Interpreter.Init(client.ReadChatMessage());

            // Message listener
            while (true)
            {
                var message = client.ReadChatMessage();
                Interpreter.Chat(message);
            }

            Console.ReadKey();
        }

    }
}
