using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;

namespace discord_kdx_bot.commands
{
    public class prefixCommands : BaseCommandModule
    {
        [Command("dice")]
        public async Task DiceCommand(CommandContext ctx, int length = 6)
        {
            Random rnd = new Random();
            int diceNum = rnd.Next(1, length + 1);
            await ctx.Channel.SendMessageAsync("You rolled: " + diceNum.ToString());
        }
    }
}
