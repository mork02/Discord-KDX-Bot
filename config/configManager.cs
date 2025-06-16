using Newtonsoft.Json;

namespace discord_kdx_bot.config
{
    internal class ConfigManager
    {
        public string token { get; set; }
        public string prefix { get; set; }

        public async Task Load()
        {
            using (StreamReader sr = new StreamReader("config.json"))
            {
                string json = await sr.ReadToEndAsync();
                BotConfig data = JsonConvert.DeserializeObject<BotConfig>(json);
                token = data.token;
                prefix = data.prefix;
            }
        }

    }
    internal sealed class BotConfig
    {
        public string token { get; set; }
        public string prefix { get; set; }
    }
}
