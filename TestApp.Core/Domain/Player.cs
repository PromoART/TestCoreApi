using System.Collections.Generic;
using Newtonsoft.Json;

namespace TestApp.Core.Domain
{
    public class Player: IEntity<string>
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("first_name")]
        public string FirstName { get; set; }
        [JsonProperty("middle_name")]
        public string MiddleName { get; set; }
        [JsonProperty("last_name")]
        public string LastName { get; set; }
        [JsonProperty("position")]
        public Position Position { get; set; }
        [JsonProperty("skills")]
        public Dictionary<string,string> Skills { get; set; }
        [JsonProperty("age")]
        public string Age { get; set; }
        [JsonProperty("teamId")]
        public string TeamId { get; set; }
    }
}
