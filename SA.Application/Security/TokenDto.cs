using Newtonsoft.Json;

namespace SA.Application.Security
{
    public class TokenDto
    {
        [JsonProperty("access_token")]
        public virtual string AccessToken { get; set; }
        [JsonProperty("token_type")]
        public virtual string TokenType { get; set; }
        [JsonProperty("scope")]
        public virtual string Scope { get; set; }
        /// <summary>
        /// Expiration in seconds
        /// </summary>
        [JsonProperty("expires_in")]
        public virtual int ExpiresIn { get; set; }
    }
}
