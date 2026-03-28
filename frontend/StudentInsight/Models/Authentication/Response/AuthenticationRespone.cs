using System.Text.Json.Serialization;

namespace StudentInsight.Models.Authentication.Response
{
    public class AuthenticationRespone
    {
        [JsonPropertyName("id")]
        public Guid UserId { get; init; }
    }
}
