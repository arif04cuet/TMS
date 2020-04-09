using Newtonsoft.Json;

namespace Module.Identity.Domain.Login
{
    public class LoginDto
    {
        public bool Authenticated { get; set; }
        public string ReditectUrl { get; set; }

        [JsonIgnore]
        public long UserId { get; set; }
    }
}
