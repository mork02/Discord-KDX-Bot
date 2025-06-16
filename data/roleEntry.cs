// working on json role manager to optain role info from user
// role_config.json
// next step: create a roleManager for set and get data from json
namespace discord_kdx_bot.data
{
    internal class RoleEntry
    {
        public ulong id { get; set; }
        public string name { get; set; }
        public string emoji { get; set; }
        public string description { get; set; }
        public int position { get; set; }
        public bool is_default { get; set; }
    }
}
