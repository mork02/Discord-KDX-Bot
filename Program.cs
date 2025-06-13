using discord_kdx_bot.commands;
using discord_kdx_bot.config;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.Entities;
using DSharpPlus.SlashCommands;

namespace discord_kdx_bot
{
    internal class Program
    {

        private static DiscordClient Client { get; set; }
        private static CommandsNextExtension Commands { get; set; }

        static async Task Main(string[] args)
        {
            var jsonReader = new JSONReader();
            await jsonReader.ReadJSON();

            var discordConfig = new DiscordConfiguration()
            {
                Intents = DiscordIntents.All,
                Token = jsonReader.token,
                TokenType = TokenType.Bot,
                AutoReconnect = true
            };

            Client = new DiscordClient(discordConfig);

            Client.Ready += Client_Ready;

            var commandsConfig = new CommandsNextConfiguration()
            {
                StringPrefixes = new string[] { jsonReader.prefix },
                EnableMentionPrefix = true,
                EnableDms = true,
                EnableDefaultHelp = false
            };

            Commands = Client.UseCommandsNext(commandsConfig);
            Commands.RegisterCommands<prefixCommands>();

            var slash = Client.UseSlashCommands();
            slash.RegisterCommands<discord_kdx_bot.commands.utilityCommands>();

            Client.ComponentInteractionCreated += on_Interaction;

            await Client.ConnectAsync();
            await Task.Delay(-1);

        }

        private async static Task on_Interaction(DiscordClient sender, DSharpPlus.EventArgs.ComponentInteractionCreateEventArgs args)
        {
            if (args.Id == "role_drop_down")
            {
                var selected_role = args.Values[0];
                
                await args.Interaction.CreateResponseAsync(InteractionResponseType.ChannelMessageWithSource,
                    new DiscordInteractionResponseBuilder()
                    .WithContent($"Hello {args.User.Mention}, you selected: {selected_role}"));
            }
        }

        private static Task Client_Ready(DiscordClient sender, DSharpPlus.EventArgs.ReadyEventArgs args)
        {
            return Task.CompletedTask;
        }
    }
}

