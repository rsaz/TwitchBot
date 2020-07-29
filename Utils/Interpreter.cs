using System;
using System.Collections.Generic;

namespace twitchBot.Utils
{
    public static class Interpreter
    {
        public static void Init(string message)
        {
            // Splitting the connection info
            var msg = message;
            var irc = message.Substring(1, message.IndexOf(" ")); // tmi.twitch.tv
            var messageCode = message.Substring(message.IndexOf(" ") + 1, 3); // 001

            var userStart = message.Substring(message.IndexOf(messageCode) + 4);
            var user = userStart.Substring(0, userStart.IndexOf(" ")); // user

            var welcome = userStart.Substring(userStart.IndexOf(":") + 1); // welcome

            // Writing back to the console the connection info
            Console.WriteLine($"Init Bot...");
            Console.WriteLine($"irc: {irc}");
            Console.WriteLine($"message code: {messageCode}");
            Console.WriteLine($"user: {user}");
            Console.WriteLine($"message: {welcome}");
        }
        public static Dictionary<string, string> Chat(string message)
        {
            var msgData = new Dictionary<string, string>();
            var msg = message;
            if (msg.Contains("PRIVMSG"))
            {
                // Splitting the username from the string
                var splitPoint = msg.IndexOf("!", 1);
                var chatName = msg.Substring(0, splitPoint);
                chatName = chatName.Substring(1);

                // Splitting the user message from the string
                splitPoint = msg.IndexOf(":", 1);
                msg = msg.Substring(splitPoint + 1);
                Console.WriteLine($"{chatName} : {msg}");

                msgData.Add(chatName, msg);
                return msgData;
            }

            return null;
        }
    }
}