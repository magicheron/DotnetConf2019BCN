using System.Collections.Generic;
using System.Threading.Tasks;
using Refit;

namespace DotnetConf2019BCN.Mobile.Features.LogIn
{
    public class FakeProfilesAPI : IProfilesAPI
    {
        public Task<IEnumerable<ProfileDTO>> GetAsync([Header("Authorization")] string authorizationHeader) =>
            Task.FromResult<IEnumerable<ProfileDTO>>(new List<ProfileDTO>
            {
                new ProfileDTO { Email = "fake@fake.com" },
            });
    }
}
