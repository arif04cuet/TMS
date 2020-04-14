using Module.Core.Shared;
using Newtonsoft.Json;

namespace Module.Core.Data
{
    public class TokenViewModel : IViewModel
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }
        [JsonProperty("refresh_token")]
        public string RefreshToken { get; set; }
        [JsonProperty("expires_in")]
        public int ExpiresIn { get; set; }
        [JsonProperty("user_id")]
        public long UserId { get; set; }
        public UserInfoViewModel UserInfo { get; set; }
    }
}
