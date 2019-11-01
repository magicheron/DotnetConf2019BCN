using System.Threading.Tasks;

namespace DotnetConf2019BCN.Mobile.Features.LogIn
{
    public class FakeLoginAPI : ILoginAPI
    {
        public Task<LoginResponseDTO> LoginAsync(LoginRequestDTO request)
        {
            return Task.FromResult(
                new LoginResponseDTO
                {
                    AccessToken = new LoginResponseDTO.AccessTokenDTO
                    {
                        Token = "faketoken",
                        TokenType = "faketokentype",
                        ExpiresIn = 1000,
                    },
                });
        }
    }
}