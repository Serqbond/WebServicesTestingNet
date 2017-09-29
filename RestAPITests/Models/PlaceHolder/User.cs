using Newtonsoft.Json;

namespace RestAPITests.Models.PlaceHolder
{
    public class User
    {
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("body")]
        public string Body { get; set; }
        [JsonProperty("userId")]
        public int UserId { get; set; }        
    }
}
