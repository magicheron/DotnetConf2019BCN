using Newtonsoft.Json;

namespace DotnetConf2019BCN.Mobile.Features.LogIn
{
    public class LoginRequestDTO
    {
        public string Username { get; set; }

        public string Password { get; set; }

        [JsonProperty(PropertyName = "grant_type")]
        public string GrantType { get; set; } = "password";
    }
}
