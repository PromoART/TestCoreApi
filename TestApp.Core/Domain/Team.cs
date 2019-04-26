using System.Collections.Generic;
using Newtonsoft.Json;

namespace TestApp.Core.Domain
{
    public class Team:IEntity<string>
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("short_name")]
        public string ShortName { get; set; }
        [JsonProperty("home_town")]
        public string HomeTown { get; set; }
        [JsonProperty("players")]
        public List<Player> Players { get; set; }
    }
}
