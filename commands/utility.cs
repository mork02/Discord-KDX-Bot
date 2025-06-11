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

        [SlashCommand("addreactionmessage", "Adds a reaction message")]
        public async Task ReactionMessage(
            InteractionContext ctx,
            [Option("message_link", "Link to the target message")] string message_link, 
            [Option("role", "select the roles as a list")] string? Role = null)
        {
            if (Role == null)
            {
                var botMember = await ctx.Guild.GetMemberAsync(ctx.Client.CurrentUser.Id);
                var botRole = botMember.Roles.OrderByDescending(r => r.Position).FirstOrDefault();

                var roles = ctx.Guild.Roles.Values
                    .Where(role =>
                    !role.IsManaged &&
                    role.Name != "@everyone" &&
                    role.Position < botRole.Position)
                    .OrderByDescending(r => r.Position)
                    .ToList();

                var embed = new DiscordEmbedBuilder()
                {
                    Title = "Select Role",
                    Description = "Select the Role you want to give, when someone reacts to the message",
                    Color = DiscordColor.Red
                };

                var role_arr = roles
                    .Select(r => new DiscordSelectComponentOption(r.Name, r.Name))
                    .ToList();

                var dropDownMenu = new DiscordSelectComponent(
                    customId: "role_drop_down",
                    placeholder: "Select the role",
                    options: role_arr
                );

                await ctx.CreateResponseAsync(InteractionResponseType.ChannelMessageWithSource,
                new DiscordInteractionResponseBuilder()
                .AddEmbed(embed)
                .AddComponents(dropDownMenu));

            }
        }

    }
}