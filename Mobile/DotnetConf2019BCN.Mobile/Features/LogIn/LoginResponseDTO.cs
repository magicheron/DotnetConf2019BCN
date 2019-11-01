﻿using Newtonsoft.Json;

namespace DotnetConf2019BCN.Mobile.Features.LogIn
{
    public class LoginResponseDTO
    {
        [JsonProperty(PropertyName = "access_token")]
        public AccessTokenDTO AccessToken { get; set; }

        public class AccessTokenDTO
        {
            public string Token { get; set; }

            [JsonProperty(PropertyName = "token_type")]
            public string TokenType { get; set; }

            [JsonProperty(PropertyName = "expires_in")]
            public int ExpiresIn { get; set; }
        }
    }
}
