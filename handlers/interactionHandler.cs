using DSharpPlus;
using DSharpPlus.Entities;
using DSharpPlus.EventArgs;

namespace discord_kdx_bot.handlers
{
    internal class interactionHandler
    {
        public static async Task HandleInteraction(DiscordClient client, ComponentInteractionCreateEventArgs args)
        {
            if (args.Id.StartsWith("give_role_"))
            {
                var roleIdStr = args.Id.Replace("give_role_", "");
                if (ulong.TryParse(roleIdStr, out ulong roleId))
                {
                    var guild = args.Guild;
                    var member = await guild.GetMemberAsync(args.User.Id);
                    var role = guild.GetRole(roleId);
                    var member_has_role = member.Roles.Any(r => r.Id == roleId);

                    try
                    {
                        if (role != null)
                        {
                            if (!member_has_role)
                            {
                                await member.GrantRoleAsync(role);
                                await args.Interaction.CreateResponseAsync(InteractionResponseType.ChannelMessageWithSource,
                                    new DiscordInteractionResponseBuilder()
                                    .WithContent($"✅ {args.User.Username} successfully optained the role: @{role.Name}")
                                    .AsEphemeral(true));
                                await Task.Delay(5000);
                                await args.Interaction.DeleteOriginalResponseAsync();
                            }
                            else
                            {
                                await member.RevokeRoleAsync(role);
                                await args.Interaction.CreateResponseAsync(InteractionResponseType.ChannelMessageWithSource,
                                    new DiscordInteractionResponseBuilder()
                                    .WithContent($"❌ {args.User.Username} successfully removed the role: @{role.Name}")
                                    .AsEphemeral(true));
                                await Task.Delay(5000);
                                await args.Interaction.DeleteOriginalResponseAsync();
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        await args.Interaction.CreateResponseAsync(InteractionResponseType.ChannelMessageWithSource,
                            new DiscordInteractionResponseBuilder().WithContent($"{e.Message}"));
                    }
                }
            }
        }
    }
}
