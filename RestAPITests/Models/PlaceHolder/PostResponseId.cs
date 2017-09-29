using Newtonsoft.Json;

namespace RestAPITests.Models.PlaceHolder
{
    public class PostResponseId
    {
        [JsonProperty("id")]
        public int Id { get; set; }
    }
}