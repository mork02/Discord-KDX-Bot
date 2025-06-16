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

        [SlashCommand("addroleMessage", "Adds a message to get a role")]
        public async Task ReactionMessage(
            InteractionContext ctx,
            [Option("title", "adds a title to the embed")] string title,
            [Option("discription", "adds a description to the embed")] string description,
            [Option("role_id", "adds a role to the embed")] string role_id
            )
        {
            try
            {
                var embed = new DiscordEmbedBuilder
                {
                    Title = title.ToString(),
                    Description = description.ToString(),
                    Color = DiscordColor.Red
                };

                var button = new DiscordButtonComponent(
                    DSharpPlus.ButtonStyle.Primary,
                    $"give_role_{role_id}",
                    "Collect Role"
                    );

                await ctx.CreateResponseAsync(InteractionResponseType.ChannelMessageWithSource,
                    new DiscordInteractionResponseBuilder()
                    .AddEmbed(embed)
                    .AddComponents(button)
                    );
                    

            }
            catch (Exception ex)
            {
                Console.WriteLine(" Error in /addreactionmessage: " + ex.Message);
                await ctx.CreateResponseAsync(InteractionResponseType.ChannelMessageWithSource,
                    new DiscordInteractionResponseBuilder().WithContent("Error."));
            }
            
        }
    }
}