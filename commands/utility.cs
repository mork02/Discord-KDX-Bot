using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.Entities;
using DSharpPlus.SlashCommands;
namespace discord_kdx_bot.commands
{
    public class utilityCommands : ApplicationCommandModule
    {
        [SlashCommand("activedevbadge", "Shows you how to get the Badge.")]
        public async Task ActiveDevBadgeCommand(InteractionContext ctx)
        {
            var embed = new DiscordEmbedBuilder
            {
                Title = "Active Developer Badge",
                Description = "[Click here, to get the Badge](https://discord.com/developers/active-developer)",
                Color = DiscordColor.Red
            };

            await ctx.CreateResponseAsync(InteractionResponseType.ChannelMessageWithSource,
                new DiscordInteractionResponseBuilder().AddEmbed(embed));
        }

        [SlashCommand("ping", "Pings to check if the Bot is running.")]
        public async Task PingCommand(InteractionContext ctx)
        {
            var embed = new DiscordEmbedBuilder
            {
                Title = "Ping",
                Description = "*Pong*",
                Color = DiscordColor.Red
            };
            await ctx.CreateResponseAsync(InteractionResponseType.ChannelMessageWithSource,
                new DiscordInteractionResponseBuilder().AddEmbed(embed));
        }

    }
}