# Twitch Bot made with .NET Core

![BOT](https://github.com/rsaz/TwitchBot/blob/master/bot.png)

## Concept

**_Twitch bots_** were created to make streaming easier and more convenient for Twitch streamers. While having **_moderators_** in chat is nice, they can make mistakes and also have a reaction time that massively exceeds the time a computer takes to react to messages written in chat. Twitch bots are in no way a replacement for a human mod-. Basically, Twitch bots are perfect for simple tasks, but you need mods to make the tough decisions.

## Goal

To provide you a boilerplate, fully functional chat bot setup for twitch using .NET Core that you can either customize, you can use as is, or use as reference to implement your own bot in the programming language you prefer or are familiar with.

## Project Functionalities

- **Connection** With IRC Twitch Chat;
- **Ping**: A separate thread to ping twitch server every 5 minutes (_Time is customizable_). This functionality prevents your twitch bot to be disconnected;
- **Interpretator**: A static class responsible to humanize the messages that can be read and written in the chat;
- **Secrets**: Is a resource from .NET only that allows you to hide or encapsulate critical information such as username, password, oauth, channel, etc of your application. You can replace this resource for a static class or dotenv to keep your critical data safe;
- **Commands**: This functionality is to give the application the ability to respond commands given by the viewers in the chat. You can customize the name of commands and how they can respond; Command Initials can be customized. Ex.: "!", "!R", etc.

## How To Use

1. Download or Clone the repo [Git](https://github.com/rsaz/TwitchBot.git)
2. Download the extension User Secrets or set via Cli command: **dotnet user-secrets set YourSecretName "YourSecretContent"**
3. If you are using the extention, right click in the twitchBot.csproj and select Manage user secret
4. Your secret should have this configuration
   - ![Secret](https://github.com/rsaz/TwitchBot/blob/master/Secrets.PNG)
5. Create a Twitch account just for your bot. Suggestion: you can create an account with the same email you are currently using your main account
6. To find your Twitch oauth click in this link: [Twitch Oauth](https://twitchapps.com/tmi/)
7. In the secrets file just set your:
   - username: yourBotTwitchAccount
   - Oauth: [Twitch Oauth](https://twitchapps.com/tmi/)
   - Channel: channel you want to connect your bot
8. In the class BasicCommands you can define your commands and how your bot repond to it.

## Tools

- VSCODE IDE
- VSCODE Extensions:
  - C# for Visual Studio Code (powered by OmniSharp)
  - .NET Core User Secrets: Extension mimicking Visual Studio's "Manage User Secrets" functionality.
- Nuget Package:
  - Microsoft.Extensions.Configuration
  - Microsoft.Extensions.Configuration.UserSecrets

## Follow me on [Twitch](https://www.twitch.tv/id_akira)
